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
    public class DSRIPElectricVehicleReadingController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPElectricVehicleReadingController(dsripppdContext context)
        {
            _context = context;
        }


        // GET: api/DSRIPBatDataTemplate/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ElectricVehicleReading>>> GetElectricVehicleReading(string evId, string startTime, string endTime)
        {
            if (evId == null | startTime == null | endTime == null)
            {
                return NotFound();
            }

            var batteryDataTemplate = await _context.ElectricVehicleReadings.FromSqlRaw("Select * from electricvehiclereadings where (electricvehicleid='" + evId + "' and timestamp >= '" + startTime + "' and timestamp <= '" + endTime + "')").ToListAsync();

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
        public async Task<IActionResult> PutElectricVehicleReading(string id, ElectricVehicleReading batteryDataTemplate)
        {
            if (id != batteryDataTemplate.ElectricVehicleReadingId)
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
                if (!EVReadingExists(id))
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
        public async Task<ActionResult<ElectricVehicleReading>> PostElectricVehicleReading(IList<ElectricVehicleReading> evReadings)
        {
            ElectricVehicleReading batteryDataTemp = new ElectricVehicleReading();

            foreach(ElectricVehicleReading batteryDataTemplate in evReadings)
            {
                batteryDataTemplate.ElectricVehicleReadingId = Guid.NewGuid().ToString();
                _context.ElectricVehicleReadings.Add(batteryDataTemplate);
                batteryDataTemp = batteryDataTemplate;
                
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectricVehicleReading", new { id = batteryDataTemp.ElectricVehicleReadingId }, batteryDataTemp);
        }

        // DELETE: api/DSRIPBatDataTemplate/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ElectricVehicleReading>> DeleteElectricVehicleReading(string id)
        {
            var batteryDataTemplate = await _context.ElectricVehicleReadings.FindAsync(id);
            if (batteryDataTemplate == null)
            {
                return NotFound();
            }

            _context.ElectricVehicleReadings.Remove(batteryDataTemplate);
            await _context.SaveChangesAsync();

            return batteryDataTemplate;
        }

        private bool EVReadingExists(string id)
        {
            return _context.ElectricVehicleReadings.Any(e => e.ElectricVehicleReadingId == id);
        }
    }
}
