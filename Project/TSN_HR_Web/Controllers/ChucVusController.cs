using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class ChucVusController : Controller
    {
        private readonly TSNHRDbContext _context;

        public ChucVusController(TSNHRDbContext context)
        {
            _context = context;
        }

        // GET: List Chuc vu
        public async Task<IActionResult> Index()
        {
            var data = await _context
                .chuc_vus.Select(cv => new ChucVuListItemViewModel
                {
                    id = cv.id,
                    ma_chuc_vu = cv.ma_chuc_vu,
                    ten_chuc_vu = cv.ten_chuc_vu,
                    ma_bo_phan = cv.bo_phan != null ? cv.bo_phan.ma_bo_phan : "",
                })
                .ToListAsync();

            return View(data);
        }

        // GET: Chuc vu/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucVu = await _context.chuc_vus.FirstOrDefaultAsync(m => m.id == id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return View(chucVu);
        }

        // GET: Chuc vu/Create
        public IActionResult Create()
        {
            var vm = new ChucVuCreateViewModel
            {
                BoPhanList = _context
                    .bo_phans.Where(bp => bp.is_active)
                    .Select(bp => new SelectListItem
                    {
                        Value = bp.id.ToString(),
                        Text = bp.ma_bo_phan + " - " + bp.ten_bo_phan,
                    })
                    .ToList(),
            };

            return View(vm);
        }

        // POST: Chuc vu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChucVuCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BoPhanList = _context
                    .bo_phans.Select(bp => new SelectListItem
                    {
                        Value = bp.id.ToString(),
                        Text = bp.ma_bo_phan + " - " + bp.ten_bo_phan,
                    })
                    .ToList();

                return View(model);
            }

            var chucVu = new chuc_vu
            {
                ma_chuc_vu = model.ma_chuc_vu,
                ten_chuc_vu = model.ten_chuc_vu,
                bo_phan_id = model.bo_phan_id,
                created_date = DateTime.Now,
                updated_date = DateTime.Now,
                is_active = true,
            };

            _context.chuc_vus.Add(chucVu);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Chuc vu/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucVu = await _context.chuc_vus.FindAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }
            return View(chucVu);
        }

        // POST: Chuc vu/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("ma_chuc_vu,ten_chuc_vu")] chuc_vu chucVu
        )
        {
            if (id != chucVu.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chucVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChucVuExists(chucVu.id))
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
            return View(chucVu);
        }

        // GET: Chuc vu/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucVu = await _context.chuc_vus.FirstOrDefaultAsync(m => m.id == id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return View(chucVu);
        }

        // POST: Chuc vu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chucVu = await _context.chuc_vus.FindAsync(id);
            if (chucVu != null)
            {
                _context.chuc_vus.Remove(chucVu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChucVuExists(int id)
        {
            return _context.chuc_vus.Any(e => e.id == id);
        }
    }
}
