using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RamirezforaneoApp.Data;
using RamirezforaneoApp.Models;

namespace RamirezforaneoApp.Controllers.UserSide
{
    [Authorize(Roles ="User, Admin")]
    public class MarketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Markets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Market.Include(m => m.Category).Include(m => m.ItemSeller);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Markets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var market = await _context.Market
                .Include(m => m.Category)
                .Include(m => m.ItemSeller)
                .FirstOrDefaultAsync(m => m.MarketItemId == id);
            if (market == null)
            {
                return NotFound();
            }

            return View(market);
        }

        // GET: Markets/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["ItemSellerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Markets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarketItemId,ItemName,ItemDescription,ItemImageUrl,ItemPrice,CategoryId,ItemCreationDate")] Market market)
        {
            if (ModelState.IsValid)
            {
                // Automatically assign the logged-in user's ID as the seller
                market.ItemSellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Set the creation date if not already set
                market.ItemCreationDate = DateTime.Now;

                // Add and save the item
                _context.Add(market);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Populate the dropdown for categories again if the model state is invalid
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", market.CategoryId);
            ViewData["ItemSellerId"] = new SelectList(_context.Users, "Id", "UserName", market.ItemSellerId);
            return View(market);
        }

        // GET: Markets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var market = await _context.Market.FindAsync(id);
            if (market == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", market.CategoryId);
            ViewData["ItemSellerId"] = new SelectList(_context.Users, "Id", "Id", market.ItemSellerId);
            return View(market);
        }

        // POST: Markets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarketItemId,ItemSellerId,ItemName,ItemDescription,ItemImageUrl,ItemPrice,CategoryId,ItemCreationDate")] Market market)
        {
            if (id != market.MarketItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(market);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarketExists(market.MarketItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", market.CategoryId);
            ViewData["ItemSellerId"] = new SelectList(_context.Users, "Id", "UserName", market.ItemSellerId);
            return View(market);
        }

        // GET: Markets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var market = await _context.Market
                .Include(m => m.Category)
                .Include(m => m.ItemSeller)
                .FirstOrDefaultAsync(m => m.MarketItemId == id);
            if (market == null)
            {
                return NotFound();
            }

            return View(market);
        }

        // POST: Markets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var market = await _context.Market.FindAsync(id);
            if (market != null)
            {
                _context.Market.Remove(market);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarketExists(int id)
        {
            return _context.Market.Any(e => e.MarketItemId == id);
        }
    }
}
