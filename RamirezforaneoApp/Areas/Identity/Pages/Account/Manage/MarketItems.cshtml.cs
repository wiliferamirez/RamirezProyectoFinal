using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RamirezforaneoApp.Data;
using RamirezforaneoApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RamirezforaneoApp.Areas.Identity.Pages.Account.Manage
{
    public class MarketItemsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MarketItemsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Market> MarketItems { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var applicationDbContext = _context.Market.Include(m => m.Category);
            var currentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MarketItems = await _context.Market
                .Include(m => m.Category)
                .Where(m => m.ItemSellerId == currentId) 
                .ToListAsync();

            return Page();
        }
    }
}
