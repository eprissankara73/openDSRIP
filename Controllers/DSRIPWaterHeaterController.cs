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
    public class DSRIPWaterHeaterController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPWaterHeaterController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPWaterheater/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<WaterHeater>>> GetWaterheater(string siteId, string waterheaterId)
        {
            if (siteId == null & waterheaterId == null)
            {
                return NotFound();
            }

            if (waterheaterId == null)
            {
                return await _context.WaterHeaters
                                .Where(s => s.SiteId == siteId)
                                .ToListAsync();
            }

            var waterheaters = await _context.WaterHeaters
                                        .Where(s => s.WaterHeaterId == waterheaterId)
                                        .ToListAsync();

            if (waterheaters == null)
            {
                return NotFound();
            }

            return waterheaters;
        }

        // PUT: api/DSRIPWaterheater/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<WaterHeater>> PutWaterheaters(WaterHeater waterheater)
        {
            if (WaterheaterExists(waterheater.WaterHeaterId))
            {
                _context.Entry(waterheater).State = EntityState.Modified;

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

            return waterheater;
        }

        // POST: api/DSRIPWaterheater
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<WaterHeater>> PostWaterheaters(IList<WaterHeater> whData)
        {
            WaterHeater wh = new WaterHeater();

            foreach(WaterHeater waterheaters in whData) 
            {
                waterheaters.WaterHeaterId = Guid.NewGuid().ToString();
                _context.WaterHeaters.Add(waterheaters);
                wh = waterheaters;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterheater", new { id = wh.WaterHeaterId }, wh);
        }

        // DELETE: api/DSRIPWaterheater/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<WaterHeater>> DeleteWaterheater(string id)
        {
            var waterheaters = await _context.WaterHeaters
                                        .Where(s => s.WaterHeaterId == id)
                                        .FirstOrDefaultAsync();

            if (waterheaters == null)
            {
                return NotFound();
            }

            _context.WaterHeaters.Remove(waterheaters);
            await _context.SaveChangesAsync();

            return waterheaters;
        }

        private bool WaterheaterExists(string id)
        {
            return _context.WaterHeaters.Any(e => e.WaterHeaterId == id);
        }
    }
}
