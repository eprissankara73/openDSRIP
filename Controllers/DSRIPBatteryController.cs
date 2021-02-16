using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MYSQL.Models;

namespace MYSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DSRIPBatteryController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPBatteryController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPBattery
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Battery>>> GetBatteries(string siteId, string batteryId)
        {
            if (siteId == null & batteryId == null) 
            {
                return NotFound();
            } 
            
            if (batteryId == null) 
            {
                return await _context.Batteries.FromSqlRaw("Select * from batteries where siteid='" + siteId + "'").ToListAsync();
            }

            var batteries = await _context.Batteries.FromSqlRaw("Select * from batteries where batteryid='" + batteryId + "'").ToListAsync();
            
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
        [Authorize]
        public async Task<IActionResult> PutBatteries(string id, Battery batteries)
        {

            if (id != batteries.BatteryId)
            {
                return BadRequest();
            }

            _context.Entry(batteries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryExists(id))
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
        public async Task<ActionResult<Battery>> PostBatteries(Battery batteries)
        {
            Guid g = Guid.NewGuid();
            batteries.BatteryId = g.ToString();
            _context.Batteries.Add(batteries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteries", new { id = batteries.BatteryId }, batteries);
        }

        // DELETE: api/DSRIPBatteries/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<Battery>> DeleteBatteries(string batteryId)
        {
            var batteries = await _context.Batteries.FindAsync(batteryId);
            if (batteries == null)
            {
                return NotFound();
            }

            _context.Batteries.Remove(batteries);
            await _context.SaveChangesAsync();

            return batteries;
        }

        private bool BatteryExists(string batteryId)
        {
            return _context.Batteries.Any(e => e.BatteryId == batteryId);
        }
    }
}
