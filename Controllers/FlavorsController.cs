using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly FlavorsContext _context;

        public FlavorsController(FlavorsContext context)
        {
            _context = context;
        }

        // GET: Flavors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flavors.ToListAsync());
        }

        // GET: Flavors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavors = await _context.Flavors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flavors == null)
            {
                return NotFound();
            }

            return View(flavors);
        }

        // GET: Flavors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flavors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image_URL,Description,Price")] Flavors flavors)
        {
            if (ModelState.IsValid)
            {
                ImaggaDAL img = new ImaggaDAL();
                bool result = img.CheckImage(flavors.Image_URL);//check if the img contain ice cream
                if (result)
                {
                    _context.Add(flavors);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                //צריך להודיע על שגיאה שהתמונה לא נכונה
            }
            return View(flavors);

        }

        // GET: Flavors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavors = await _context.Flavors.FindAsync(id);
            if (flavors == null)
            {
                return NotFound();
            }
            return View(flavors);
        }

        // POST: Flavors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image_URL,Description,Price")] Flavors flavors)
        {
            if (id != flavors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flavors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlavorsExists(flavors.Id))
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
            return View(flavors);
        }

        // GET: Flavors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavors = await _context.Flavors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flavors == null)
            {
                return NotFound();
            }

            return View(flavors);
        }

        // POST: Flavors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flavors = await _context.Flavors.FindAsync(id);
            _context.Flavors.Remove(flavors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlavorsExists(int id)
        {
            return _context.Flavors.Any(e => e.Id == id);
        }
    }
}
