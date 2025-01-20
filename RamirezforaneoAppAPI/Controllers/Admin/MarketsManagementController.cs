using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RamirezforaneoApp.Data;
using RamirezforaneoApp.Models;

namespace RamirezforaneoAppAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsManagementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarketsManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MarketsManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Market>>> GetMarket()
        {
            return await _context.Market.ToListAsync();
        }

        // GET: api/MarketsManagement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Market>> GetMarket(int id)
        {
            var market = await _context.Market.FindAsync(id);

            if (market == null)
            {
                return NotFound();
            }

            return market;
        }

        // PUT: api/MarketsManagement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarket(int id, Market market)
        {
            if (id != market.MarketItemId)
            {
                return BadRequest();
            }

            _context.Entry(market).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketExists(id))
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

        // POST: api/MarketsManagement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Market>> PostMarket(Market market)
        {
            _context.Market.Add(market);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarket", new { id = market.MarketItemId }, market);
        }

        // DELETE: api/MarketsManagement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarket(int id)
        {
            var market = await _context.Market.FindAsync(id);
            if (market == null)
            {
                return NotFound();
            }

            _context.Market.Remove(market);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarketExists(int id)
        {
            return _context.Market.Any(e => e.MarketItemId == id);
        }
    }
}
