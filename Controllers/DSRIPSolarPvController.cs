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
    public class DSRIPSolarPvController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPSolarPvController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPBatteries/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SolarPv>>> GetSolarPv(string siteId, string solarpvId)
        {
            if (siteId == null & solarpvId == null)
            {
                return NotFound();
            }

            if (solarpvId == null)
            {
                return await _context.SolarPvs
                                .Where(s => s.SiteId == siteId)
                                .ToListAsync();    
            }

            var batteries = await _context.SolarPvs
                                    .Where(s => s.SolarPvId == solarpvId)
                                    .ToListAsync();

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
        public async Task<ActionResult<SolarPv>> PutSolarPv(SolarPv batteries)
        {
            if (SolarPvExists(batteries.SolarPvId))
            {
                _context.Entry(batteries).State = EntityState.Modified;
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

            return batteries;
        }

        // POST: api/DSRIPBattery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SolarPv>> PostSolarPvs(IList<SolarPv> solars)
        {
            SolarPv sp = new SolarPv();

            foreach(SolarPv batteries in solars)
            {
                batteries.SolarPvId = Guid.NewGuid().ToString();
                _context.SolarPvs.Add(batteries);
                sp = batteries;    
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolarPv", new { id = sp.SolarPvId }, sp);
        }

        // DELETE: api/DSRIPBatteries/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<SolarPv>> DeleteSolarPv(string id)
        {
            var batteries = await _context.SolarPvs
                                    .Where(s => s.SolarPvId == id)
                                    .FirstOrDefaultAsync();

            if (batteries == null)
            {
                return NotFound();
            }

            _context.SolarPvs.Remove(batteries);
            await _context.SaveChangesAsync();

            return batteries;
        }

        private bool SolarPvExists(string id)
        {
            return _context.SolarPvs.Any(e => e.SolarPvId == id);
        }
    }
}
