using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYSQL.Models;

namespace MYSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DSRIPUtilitiesController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPUtilitiesController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPUtilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilities>>> GetUtilities()
        {
            return await _context.Utilities.ToListAsync();
        }

        // GET: api/DSRIPUtilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilities>> GetUtilities(string id)
        {
            var utilities = await _context.Utilities.FindAsync(id);

            if (utilities == null)
            {
                return NotFound();
            }

            return utilities;
        }

        // PUT: api/DSRIPUtilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilities(string id, Utilities utilities)
        {
            if (id != utilities.UtilityId)
            {
                return BadRequest();
            }

            _context.Entry(utilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilitiesExists(id))
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

        // POST: api/DSRIPUtilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Utilities>> PostUtilities(Utilities utilities)
        {
            _context.Utilities.Add(utilities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilities", new { id = utilities.UtilityId }, utilities);
        }

        // DELETE: api/DSRIPUtilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilities>> DeleteUtilities(string id)
        {
            var utilities = await _context.Utilities.FindAsync(id);
            if (utilities == null)
            {
                return NotFound();
            }

            _context.Utilities.Remove(utilities);
            await _context.SaveChangesAsync();

            return utilities;
        }

        private bool UtilitiesExists(string id)
        {
            return _context.Utilities.Any(e => e.UtilityId == id);
        }
    }
}
