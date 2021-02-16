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
    public class DSRIPWaterHeaterReadingController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPWaterHeaterReadingController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPWhDataTemp/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<WaterHeaterReading>>> GetWaterHeaterReading(string waterheaterId, string startTime, string endTime)
        {
            if (waterheaterId == null | startTime == null | endTime == null)
            {
                return NotFound();
            }

            var waterheaterDataTemplate = await _context.WaterHeaterReadings
                                                    .FromSqlRaw("select * from waterheaterreadings where (waterheaterid='" + waterheaterId + "' and timestamp >= '" + startTime + "' and timestamp <= '" + endTime + "')")
                                                    .ToListAsync();


            if (waterheaterDataTemplate == null)
            {
                return NotFound();
            }

            return waterheaterDataTemplate;
        }

        // PUT: api/DSRIPWhDataTemp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<WaterHeaterReading>> PutWaterHeaterReading(WaterHeaterReading waterheaterDataTemplate)
        {
            if (WaterHeaterReadingExists(waterheaterDataTemplate.WaterHeaterReadingId))
            {
                _context.Entry(waterheaterDataTemplate).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return waterheaterDataTemplate;
        }

        // POST: api/DSRIPWhDataTemp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<WaterHeaterReading>> PostWaterHeaterReadings(IList<WaterHeaterReading> waterheaterData)
        {
            WaterHeaterReading whr = new WaterHeaterReading();

            foreach(WaterHeaterReading waterheaterDataTemplate in waterheaterData)
            {
                waterheaterDataTemplate.WaterHeaterReadingId = Guid.NewGuid().ToString();
                _context.WaterHeaterReadings.Add(waterheaterDataTemplate);
                whr = waterheaterDataTemplate;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterHeaterReading", new { id = whr.WaterHeaterReadingId }, whr);
        }

        // DELETE: api/DSRIPWhDataTemp/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<WaterHeaterReading>> DeleteWaterheaterDataTemplate(string id)
        {
            var waterheaterDataTemplate = await _context.WaterHeaterReadings
                                                    .Where(s => s.WaterHeaterReadingId == id)
                                                    .FirstOrDefaultAsync();
                                                    
            if (waterheaterDataTemplate == null)
            {
                return NotFound();
            }

            _context.WaterHeaterReadings.Remove(waterheaterDataTemplate);
            await _context.SaveChangesAsync();

            return waterheaterDataTemplate;
        }

        private bool WaterHeaterReadingExists(string id)
        {
            return _context.WaterHeaterReadings.Any(e => e.WaterHeaterReadingId == id);
        }
    }
}
