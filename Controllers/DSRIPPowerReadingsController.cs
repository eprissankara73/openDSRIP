using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MYSQL.Models;

namespace MYSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DSRIPPowerReadingsController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPPowerReadingsController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPLoadDataTemp/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PowerReadings>>> GetPowerReadings(string loadId, string startTime, string endTime)
        {
            if (loadId == null | startTime == null | endTime == null)
            {
                return NotFound();
            }

            var loadDataTemplate = await _context.PowerReadings
                                            .FromSqlRaw("select * from powerreadings where (loadid='" + loadId + "' and timestamp >= '" + startTime + "' and timestamp <= '" + endTime + "')")
                                            .ToListAsync();

            if (loadDataTemplate == null)
            {
                return NotFound();
            }

            return loadDataTemplate;
        }

        // PUT: api/DSRIPLoadDataTemp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutPowerReadings(string id, PowerReadings loadDataTemplate)
        {
            if (id != loadDataTemplate.PowerReadingId)
            {
                return BadRequest();
            }

            _context.Entry(loadDataTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PowerReadingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DSRIPLoadDataTemp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PowerReadings>> PostPowerReadings(IList<PowerReadings> loadData)
        {
            PowerReadings pr = new PowerReadings();

            foreach(PowerReadings loadDataTemplate in loadData)
            {
                loadDataTemplate.PowerReadingId = Guid.NewGuid().ToString();
                _context.PowerReadings.Add(loadDataTemplate);
                pr = loadDataTemplate;      
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPowerReadings", new { id = pr.PowerReadingId }, pr);
        }

        // DELETE: api/DSRIPLoadDataTemp/5
        [HttpDelete]
        public async Task<ActionResult<PowerReadings>> DeletePowerReadings(string id)
        {
            var loadDataTemplate = await _context.PowerReadings
                                            .Where(s => s.PowerReadingId == id)
                                            .FirstOrDefaultAsync();

            if (loadDataTemplate == null)
            {
                return NotFound();
            }

            _context.PowerReadings.Remove(loadDataTemplate);
            await _context.SaveChangesAsync();

            return loadDataTemplate;
        }

        private bool PowerReadingExists(string id)
        {
            return _context.PowerReadings.Any(e => e.PowerReadingId == id);
        }
    }
}
