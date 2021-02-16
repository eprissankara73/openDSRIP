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
    public class DSRIPPricingSignalsController : ControllerBase
    {
        private readonly dsripppdContext _context;

        public DSRIPPricingSignalsController(dsripppdContext context)
        {
            _context = context;
        }

        // GET: api/DSRIPBattery
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PricingSignals>>> GetPricingSignals(string startDate, string endDate, string marketContext)
        {
            if (startDate == null | endDate == null) 
            {
                return NotFound();
            } 

            if (marketContext == null)
            {
                return await _context.PricingSignals
                                        .FromSqlRaw("Select * from pricingsignals where (timestamp >= '" + startDate + "T00:00:00' and timestamp <= '" + endDate + "T23:59:59')")
                                        .ToListAsync();
            }

            var pricingsignals = await _context.PricingSignals
                                        .FromSqlRaw("Select * from pricingsignals where (timestamp >= '" + startDate + "T00:00:00' and timestamp <= '" + endDate + "T23:59:59' and marketcontext like '%" + marketContext + "%')")
                                        .ToListAsync();
            
            if (pricingsignals == null)
            {
                return NotFound();
            }

            return pricingsignals;
        }

        // PUT: api/DSRIPBatteries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<PricingSignals>> PutPricingSignals(PricingSignals pricingsignal)
        {

            if (PricingSignalsExists(pricingsignal.PricingSignalId))
            {
                _context.Entry(pricingsignal).State = EntityState.Modified;    
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               throw;
            }

            return pricingsignal;
        }

        // POST: api/DSRIPBattery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PricingSignals>> PostPricingSignals(IList<PricingSignals> psdata)
        {
            PricingSignals ps = new PricingSignals();

            foreach(PricingSignals pricingsignal in psdata)
            {
                Guid g = Guid.NewGuid();
                pricingsignal.PricingSignalId = g.ToString();
                _context.PricingSignals.Add(pricingsignal);
                ps = pricingsignal;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPricingSignals", new { id = ps.PricingSignalId }, ps);
        }

        // DELETE: api/DSRIPBatteries/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<PricingSignals>> DeleteBatteries(string id)
        {
            var pricingsignal = await _context.PricingSignals
                                        .Where(s => s.PricingSignalId == id)
                                        .FirstOrDefaultAsync();

            if (pricingsignal == null)
            {
                return NotFound();
            }

            _context.PricingSignals.Remove(pricingsignal);
            await _context.SaveChangesAsync();

            return pricingsignal;
        }

        private bool PricingSignalsExists(string id)
        {
            return _context.PricingSignals.Any(e => e.PricingSignalId == id);
        }
    }
}
