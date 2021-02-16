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
    public class DSRIPSolarPvReadingController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPSolarPvReadingController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPBatDataTemplate/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SolarPvReading>>> GetSolarPvReading(string solarpvid, string startTime, string endTime)
        {
            if (solarpvid == null | startTime == null | endTime == null)
            {
                return NotFound();
            }

            var batteryDataTemplate = await _context.SolarPvReadings
                                                .FromSqlRaw("select * from solarpvreadings where (solarpvid='" + solarpvid + "' and timestamp >= '" + startTime + "' and timestamp <= '" + endTime + "')")
                                                .ToListAsync();

            if (batteryDataTemplate == null)
            {
                return NotFound();
            }

            return batteryDataTemplate;
        }

        // PUT: api/DSRIPBatDataTemplate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<SolarPvReading>> PutSolarPvReadings(SolarPvReading batteryDataTemplate)
        {
            if (SolarPvReadingExists(batteryDataTemplate.SolarPvReadingId)) 
            {
                _context.Entry(batteryDataTemplate).State = EntityState.Modified;
    
            }
            else 
            {
                return NotFound();
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return batteryDataTemplate;
        }

        // POST: api/DSRIPBatDataTemplate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SolarPvReading>> PostSolarPvReadings(IList<SolarPvReading> solarpvdata)
        {
            SolarPvReading spr = new SolarPvReading();

            foreach(SolarPvReading batteryDataTemplate in solarpvdata)
            {
                batteryDataTemplate.SolarPvReadingId = Guid.NewGuid().ToString();
                _context.SolarPvReadings.Add(batteryDataTemplate);
                spr = batteryDataTemplate;
                
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolarPvReading", new { id = spr.SolarPvReadingId }, spr);
        }

        // DELETE: api/DSRIPBatDataTemplate/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<SolarPvReading>> DeleteSolarPvReading(string id)
        {
            var batteryDataTemplate = await _context.SolarPvReadings
                                                .Where(s => s.SolarPvReadingId == id)
                                                .FirstOrDefaultAsync();

            if (batteryDataTemplate == null)
            {
                return NotFound();
            }

            _context.SolarPvReadings.Remove(batteryDataTemplate);
            await _context.SaveChangesAsync();

            return batteryDataTemplate;
        }

        private bool SolarPvReadingExists(string id)
        {
            return _context.SolarPvReadings.Any(e => e.SolarPvReadingId == id);
        }
    }
}
