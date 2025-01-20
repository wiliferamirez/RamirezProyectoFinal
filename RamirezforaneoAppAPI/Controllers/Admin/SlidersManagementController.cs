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
    public class SlidersManagementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SlidersManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SlidersManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slider>>> GetSlider()
        {
            return await _context.Slider.ToListAsync();
        }

        // GET: api/SlidersManagement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slider>> GetSlider(int id)
        {
            var slider = await _context.Slider.FindAsync(id);

            if (slider == null)
            {
                return NotFound();
            }

            return slider;
        }

        // PUT: api/SlidersManagement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlider(int id, Slider slider)
        {
            if (id != slider.SliderImageId)
            {
                return BadRequest();
            }

            _context.Entry(slider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SliderExists(id))
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

        // POST: api/SlidersManagement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Slider>> PostSlider(Slider slider)
        {
            _context.Slider.Add(slider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlider", new { id = slider.SliderImageId }, slider);
        }

        // DELETE: api/SlidersManagement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var slider = await _context.Slider.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }

            _context.Slider.Remove(slider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SliderExists(int id)
        {
            return _context.Slider.Any(e => e.SliderImageId == id);
        }
    }
}
