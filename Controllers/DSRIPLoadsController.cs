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
    public class DSRIPLoadsController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPLoadsController(dsripppdContext context)
        {
            _context = context;
        }


        // GET: api/DSRIPLoadChanDevMap/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Loads>>> GetLoad(string siteId, string loadId)
        {
            if (siteId == null & loadId == null) 
            {
                return NotFound();
            }

            if (loadId == null)
            {
                return await _context.Loads
                                .Where(s => s.SiteId == siteId)
                                .ToListAsync();
            }

            var loadChannelDeviceMap = await _context.Loads
                                                .Where(s => s.LoadId == loadId)
                                                .ToListAsync();

            if (loadChannelDeviceMap == null)
            {
                return NotFound();
            }

            return loadChannelDeviceMap;
        }

        // PUT: api/DSRIPLoadChanDevMap/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Loads>> PutLoads(Loads loadChannelDeviceMap)
        {
            if (LoadExists(loadChannelDeviceMap.LoadId))
            {
                _context.Entry(loadChannelDeviceMap).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return loadChannelDeviceMap;
        }

        // POST: api/DSRIPLoadChanDevMap
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Loads>> PostLoads(IList<Loads> loadchannels)
        {
            Loads loadTemp = new Loads();

            foreach(Loads loadChannelDeviceMap in loadchannels)
            {
                loadChannelDeviceMap.LoadId = Guid.NewGuid().ToString();
                _context.Loads.Add(loadChannelDeviceMap);
                loadTemp = loadChannelDeviceMap;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoad", new { id = loadTemp.LoadId }, loadTemp);
        }

        // DELETE: api/DSRIPLoadChanDevMap/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<Loads>> DeleteLoads(string loadId)
        {
            var loadChannelDeviceMap = await _context.Loads
                                            .Where(s => s.LoadId == loadId)
                                            .FirstOrDefaultAsync();

            if (loadChannelDeviceMap == null)
            {
                return NotFound();
            }

            _context.Loads.Remove(loadChannelDeviceMap);
            await _context.SaveChangesAsync();

            return loadChannelDeviceMap;
        }

        private bool LoadExists(string id)
        {
            return _context.Loads.Any(e => e.LoadId == id);
        }
    }
}
