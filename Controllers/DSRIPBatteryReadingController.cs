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
    public class DSRIPBatteryReadingController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPBatteryReadingController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPBatDataTemplate

        // GET: api/DSRIPBatDataTemplate/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BatteryReading>>> GetBatteryReadings(string batteryId, string startTime, string endTime)
        {
            Console.WriteLine("startTime: " + startTime);
            Console.WriteLine("endTime: "+endTime);

            if (batteryId == null | startTime == null | endTime == null) {
                return NotFound();
            }

            var batteryDataTemplate = await _context.BatteryReadings.FromSqlRaw("Select * from batteryreadings where (batteryid='" + batteryId + "' and timestamp >= '" + startTime + "' and timestamp <= '" + endTime + "')").ToListAsync();

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
        public async Task<IActionResult> PutBatteryReading(string id, BatteryReading batteryDataTemplate)
        {
            if (id != batteryDataTemplate.BatteryReadingId)
            {
                return BadRequest();
            }

            _context.Entry(batteryDataTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryReadingExists(id))
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

        // POST: api/DSRIPBatDataTemplate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BatteryReading>> PostBatteryReadings(IList<BatteryReading> batteryData)
        {
            BatteryReading batteryDataTemp = new BatteryReading();
            foreach (BatteryReading batteryDataTemplate in batteryData) 
            {
                batteryDataTemplate.BatteryReadingId = Guid.NewGuid().ToString();
                _context.BatteryReadings.Add(batteryDataTemplate);
                batteryDataTemp = batteryDataTemplate;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteryReadings", new { id = batteryDataTemp.BatteryReadingId }, batteryDataTemp);
        }

        // DELETE: api/DSRIPBatDataTemplate/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<BatteryReading>> DeleteBatteryDataTemplate(string id)
        {
            var batteryDataTemplate = await _context.BatteryReadings.FindAsync(id);
            if (batteryDataTemplate == null)
            {
                return NotFound();
            }

            _context.BatteryReadings.Remove(batteryDataTemplate);
            await _context.SaveChangesAsync();

            return batteryDataTemplate;
        }

        private bool BatteryReadingExists(string id)
        {
            return _context.BatteryReadings.Any(e => e.BatteryReadingId == id);
        }
    }
}
