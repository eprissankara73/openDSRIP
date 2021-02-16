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
    public class DSRIPElectricVehicleController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPElectricVehicleController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPBatteries/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ElectricVehicle>>> GetElectricVehicle(string siteId, string evId)
        {
            if (siteId == null & evId == null) 
            {
                return NotFound();
            }

            if (evId == null)
            {
                return await _context.ElectricVehicles.FromSqlRaw("Select * from electricvehicles where siteid='" + siteId + "'").ToListAsync();
            }

            var batteries = await _context.ElectricVehicles.FromSqlRaw("Select * from electricvehicles where electricvehicleid='" + evId + "'").ToListAsync();

            if (batteries == null)
            {
                return NotFound();
            }

            return batteries;
        }

        // PUT: api/DSRIPBatteries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutElectricVehicle(ElectricVehicle batteries)
        {

            _context.Entry(batteries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EVExists(batteries.ElectricVehicleId))
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

        // POST: api/DSRIPBattery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Battery>> PostBatteries(ElectricVehicle evs)
        {
            Guid g = Guid.NewGuid();
            evs.ElectricVehicleId = g.ToString();

            _context.ElectricVehicles.Add(evs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectricVehicle", new { id = evs.ElectricVehicleId }, evs);
        }

        // DELETE: api/DSRIPBatteries/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ElectricVehicle>> DeleteElectricVehicle(string evId)
        {
            var batteries = await _context.ElectricVehicles.FromSqlRaw("Select * from electricvehicles where electricvehicleid='" + evId + "'").FirstOrDefaultAsync();
            
            if (batteries == null)
            {
                return NotFound();
            }

            _context.ElectricVehicles.Remove(batteries);
            await _context.SaveChangesAsync();

            return batteries;
        }

        private bool EVExists(string batteryId)
        {
            return _context.ElectricVehicles.Any(e => e.ElectricVehicleId == batteryId);
        }
    }
}
