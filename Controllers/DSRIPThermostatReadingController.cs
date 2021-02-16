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
    public class DSRIPThermostatReadingController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPThermostatReadingController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPTstatDataTemp/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ThermostatReading>>> GetThermostatReading(string thermostatId, string startTime, string endTime)
        {
            if (thermostatId == null | startTime == null | endTime == null)
            {
                return NotFound();
            }

            var tstatDataTemplate = await _context.ThermostatReadings
                                            .FromSqlRaw("select * from thermostatreadings where (thermostatid='" + thermostatId + "' and timestamp >= '" + startTime + "' and timestamp <= '" + endTime + "')")
                                            .ToListAsync();

            if (tstatDataTemplate == null)
            {
                return NotFound();
            }

            return tstatDataTemplate;
        }

        // PUT: api/DSRIPTstatDataTemp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ThermostatReading>> PutThermostatReadings(ThermostatReading tstatDataTemplate)
        {
            if (ThermostatReadingExists(tstatDataTemplate.ThermostatReadingId))
            {
                _context.Entry(tstatDataTemplate).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               throw;
            }

            return tstatDataTemplate;
        }

        // POST: api/DSRIPTstatDataTemp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ThermostatReading>> PostThermostatReadings(IList<ThermostatReading> tstatData)
        {
            ThermostatReading tsr = new ThermostatReading();

            foreach(ThermostatReading tstatDataTemplate in tstatData)
            {
                tstatDataTemplate.ThermostatReadingId = Guid.NewGuid().ToString();
                _context.ThermostatReadings.Add(tstatDataTemplate);
                tsr = tstatDataTemplate;
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThermostatReading", new { id = tsr.ThermostatReadingId }, tsr);
        }

        // DELETE: api/DSRIPTstatDataTemp/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ThermostatReading>> DeleteThermostatReading(string id)
        {
            var tstatDataTemplate = await _context.ThermostatReadings
                                            .Where(s => s.ThermostatReadingId == id)
                                            .FirstOrDefaultAsync();

            if (tstatDataTemplate == null)
            {
                return NotFound();
            }

            _context.ThermostatReadings.Remove(tstatDataTemplate);
            await _context.SaveChangesAsync();

            return tstatDataTemplate;
        }

        private bool ThermostatReadingExists(string id)
        {
            return _context.ThermostatReadings.Any(e => e.ThermostatReadingId== id);
        }
    }
}
