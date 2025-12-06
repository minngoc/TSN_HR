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
    public class SoYeuLyLichsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoYeuLyLichsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: So yeu ly lich cua nhan vien
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoYeuLyLichs.ToListAsync());
        }

        // GET: So yeu ly lich/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soYeuLyLich = await _context.SoYeuLyLichs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soYeuLyLich == null)
            {
                return NotFound();
            }

            return View(soYeuLyLich);
        }

        // GET: So yeu ly lich/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: So yeu ly lich/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SoYeuLyLichId,HoVaTenDem,Ten,GioiTinh,NgaySinh,NoiSinh,NguyenQuan,DanToc,TonGiao,CMND,NoiCap,DiaChiThuongTru,DiaChiTamTru,SoDienThoaiNha,SoDienThoaiCaNhan,MaTaiKhoan,TenNganHang,MaTrangPhuc,MaGiay,Avatar")] SoYeuLyLich soYeuLyLich)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soYeuLyLich);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soYeuLyLich);
        }

        // GET: So yeu ly lich/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soYeuLyLich = await _context.SoYeuLyLichs.FindAsync(id);
            if (soYeuLyLich == null)
            {
                return NotFound();
            }
            return View(soYeuLyLich);
        }

        // POST: So yeu ly lich/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SoYeuLyLichId,HoVaTenDem,Ten,GioiTinh,NgaySinh,NoiSinh,NguyenQuan,DanToc,TonGiao,CMND,NoiCap,DiaChiThuongTru,DiaChiTamTru,SoDienThoaiNha,SoDienThoaiCaNhan,MaTaiKhoan,TenNganHang,MaTrangPhuc,MaGiay,Avatar")] SoYeuLyLich soYeuLyLich)
        {
            if (id != soYeuLyLich.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soYeuLyLich);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoYeuLyLichExists(soYeuLyLich.Id))
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
            return View(soYeuLyLich);
        }

        // GET: So yeu li lich/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soYeuLyLich = await _context.SoYeuLyLichs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soYeuLyLich == null)
            {
                return NotFound();
            }

            return View(soYeuLyLich);
        }

        // POST: So yeu ly lich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soYeuLyLich = await _context.SoYeuLyLichs.FindAsync(id);
            if (soYeuLyLich != null)
            {
                _context.SoYeuLyLichs.Remove(soYeuLyLich);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoYeuLyLichExists(int id)
        {
            return _context.SoYeuLyLichs.Any(e => e.Id == id);
        }
    }
}
