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

namespace RamirezforaneoApp.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class SlidersManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlidersManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET: SliderManagement
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Slider.ToListAsync();
            
            return View(sliders);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(Slider slider)
        {
            if (string.IsNullOrEmpty(slider.SliderUrlImage) || !Uri.IsWellFormedUriString(slider.SliderUrlImage, UriKind.Absolute))
            {
                ModelState.AddModelError("SliderUrlImage", "Please enter a valid URL.");
                return View(slider);
            }

            try
            {
                slider.ImageStatus = true;
                _context.Slider.Add(slider);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving slider: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while saving the image.");
                return View(slider);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var slide = await _context.Slider.FirstOrDefaultAsync(m => m.SliderImageId == id);
            if(slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }
        // POST: SliderManagment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _context.Slider.FindAsync(id);
            if(slider != null)
            {
                _context.Slider.Remove(slider);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }



    }
}
