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
    public class DSRIPThermostatController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPThermostatController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPTstatChanDevMap/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Thermostat>>> GetThermostat(string siteId, string thermostatId)
        {
            if (siteId == null & thermostatId == null)
            {
                return NotFound();
            }

            if (thermostatId == null) {
                return await _context.Thermostats
                                .Where(s => s.SiteId == siteId)
                                .ToListAsync();
            }

            var tstatChannelDeviceMap = await _context.Thermostats
                                                .Where(s => s.ThermostatId == thermostatId)
                                                .ToListAsync();

            if (tstatChannelDeviceMap == null)
            {
                return NotFound();
            }

            return tstatChannelDeviceMap;
        }

        // PUT: api/DSRIPTstatChanDevMap/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Thermostat>> PutThermostats(Thermostat tstatChannelDeviceMap)
        {
            if (ThermostatExists(tstatChannelDeviceMap.ThermostatId))
            {
                _context.Entry(tstatChannelDeviceMap).State = EntityState.Modified;    
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return tstatChannelDeviceMap;
        }

        // POST: api/DSRIPTstatChanDevMap
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Thermostat>> PostThermostats(IList<Thermostat> tstats)
        {
            Thermostat ts = new Thermostat();

            foreach(Thermostat tstatChannelDeviceMap in tstats)
            {
                tstatChannelDeviceMap.ThermostatId = Guid.NewGuid().ToString();
                _context.Thermostats.Add(tstatChannelDeviceMap);
                ts = tstatChannelDeviceMap;    
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThermostat", new { id = ts.ThermostatId }, ts);
        }

        // DELETE: api/DSRIPTstatChanDevMap/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<Thermostat>> DeleteThermostat(string id)
        {
            var tstatChannelDeviceMap = await _context.Thermostats
                                                .Where(s => s.ThermostatId == id)
                                                .FirstOrDefaultAsync();

            if (tstatChannelDeviceMap == null)
            {
                return NotFound();
            }

            _context.Thermostats.Remove(tstatChannelDeviceMap);
            await _context.SaveChangesAsync();

            return tstatChannelDeviceMap;
        }

        private bool ThermostatExists(string id)
        {
            return _context.Thermostats.Any(e => e.ThermostatId == id);
        }
    }
}
