using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Data;
using TSN_HR_Web.Models;

namespace TSN_HR_Web.Controllers
{
    public class BoPhansController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BoPhansController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: List Phong ban
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoPhans.ToListAsync());
        }
        // GET: Phong ban/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boPhan = await _context.BoPhans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boPhan == null)
            {
                return NotFound();
            }

            return View(boPhan);
        }
        // GET: Phong ban/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Phong Ban/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBoPhan,TenBoPhan,CoSoId")] BoPhan boPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boPhan);
        }

        // GET: Phong ban/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boPhan = await _context.BoPhans.FindAsync(id);
            if (boPhan == null)
            {
                return NotFound();
            }
            return View(boPhan);
        }

        // POST: phong ban/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaBoPhan,TenBoPhan,CoSoId")] BoPhan boPhan)
        {
            if (id != boPhan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoPhanExists(boPhan.Id))
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
            return View(boPhan);
        }
        // GET: Phong ban/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boPhan = await _context.BoPhans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boPhan == null)
            {
                return NotFound();
            }

            return View(boPhan);
        }

        // POST: Phong ban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boPhan = await _context.BoPhans.FindAsync(id);
            if (boPhan != null)
            {
                _context.BoPhans.Remove(boPhan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BoPhanExists(int id)
        {
            return _context.BoPhans.Any(e => e.Id == id);
        }
    }
}