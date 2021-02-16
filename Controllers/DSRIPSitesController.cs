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
    public class DSRIPSitesController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPSitesController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPSites/<siteID>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Sites>>> GetSite(string siteId)
        {
            if (siteId == null) 
            {
                Console.WriteLine("SiteId not found...");
                return await _context.Sites.FromSqlRaw("Select utilityid, siteid, name, city, state, zipcode, timezone, hassolar, sqfootage, type, floors, year, occupants, marketContext from sites").ToListAsync();
            }

            var sites = await _context.Sites.FromSqlRaw("Select * from sites where siteId='"  + siteId + "'").ToListAsync();

            if (sites == null)
            {
		        Console.WriteLine("No Sites Found!");
                return NotFound();
            }

	        Console.WriteLine("Sites Found!");
            return sites;
        }

        // PUT: api/DSRIPSites/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutSites(string id, Sites sites)
        {
            if (id != sites.SiteId)
            {
                return BadRequest();
            }

            _context.Entry(sites).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SitesExists(id))
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

        // POST: api/DSRIPSites
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Sites>> PostSites(Sites sites)
        {
            //Console.WriteLine("Site Name: " + sites.Name);
            //Sites sites = new Sites();
            Guid g = Guid.NewGuid();
            sites.SiteId = g.ToString();
            
            _context.Sites.Add(sites);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSite", new { id = sites.SiteId }, sites);
        }

        // DELETE: api/DSRIPSites/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<Sites>> DeleteSites(string id)
        {
            var sites = await _context.Sites.FromSqlRaw("Select * from sites where siteId='"  + id + "'").FirstOrDefaultAsync();

            if (sites == null)
            {
                return NotFound();
            }

            _context.Sites.Remove(sites);
            await _context.SaveChangesAsync();

            return sites;
        }

        private bool SitesExists(string id)
        {
            return _context.Sites.Any(e => e.SiteId == id);
        }
    }
}
