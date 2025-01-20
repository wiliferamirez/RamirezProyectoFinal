using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RamirezforaneoApp.Data;
using RamirezforaneoApp.Models;
using System.Net.Http.Headers;

namespace RamirezforaneoAppAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesManagementController : ControllerBase
    {
        private static string _storedToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjMmYzYTUxMS1hZWU3LTRjNWQtYjkwZi05ZTkyMGViNzQyMjUiLCJlbWFpbCI6IndpbGxpYW0ucmFtaXJlei5wYXVjYXJAdWRsYS5lZHUuZWMiLCJqdGkiOiIyNmQwZGYxNC04MzY0LTQ3NzYtYTQ3My0wNWI2NmM3ZGYzYjgiLCJleHAiOjE3Mzc0M";
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoriesManagementController> _logger;

        public CategoriesManagementController(ApplicationDbContext context, ILogger<CategoriesManagementController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Categories
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {

            try
            {
                var categories = await _context.Category.ToListAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving categories.", Error = ex.Message });
            }
        }

        // POST: api/Categories
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategories), new { id = category.CategoryId}, category);
        }

        // PUT: api/Categories/{id}
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest("Category ID mismatch.");
            }

            var existingCategory = await _context.Category.FindAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.CategoryName = category.CategoryName;

            _context.Entry(existingCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Categories/{id}
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
