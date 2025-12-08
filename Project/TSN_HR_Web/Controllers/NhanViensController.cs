using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Data;
using TSN_HR_Web.Models;
using TSN_HR_Web.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class NhanViensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhanViensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================== GET: NhanViens ==================
        // Hiển thị bảng Nhân viên với TEMP DATA
        public IActionResult Index()
        {
            // TEMP DATA – chỉ để test UI, sau này xoá và thay bằng data từ DB
            var tempData = new List<NhanVienListItemViewModel>
            {
                new NhanVienListItemViewModel
                {
                    Id = 1,
                    MaNhanVien = "NV001",
                    HoVaTen = "Nguyễn Văn A",
                    SoYeuLyLichId = 1001,
                    ThongTinBaoHiemId = 2001,
                    HopDongId = 3001,
                    MaLuongId = 4001,
                },
                new NhanVienListItemViewModel
                {
                    Id = 2,
                    MaNhanVien = "NV002",
                    HoVaTen = "Trần Thị B",
                    SoYeuLyLichId = 1002,
                    ThongTinBaoHiemId = 2002,
                    HopDongId = 3002,
                    MaLuongId = 4002,
                },
                new NhanVienListItemViewModel
                {
                    Id = 3,
                    MaNhanVien = "NV003",
                    HoVaTen = "Lê Văn C",
                    SoYeuLyLichId = 1003,
                    ThongTinBaoHiemId = 2003,
                    HopDongId = 3003,
                    MaLuongId = 4003,
                },
            };

            return View(tempData);
        }

        // ================== GET: NhanViens/Details/5 ==================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FirstOrDefaultAsync(m => m.Id == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // ================== GET: NhanViens/Create ==================
        public IActionResult Create()
        {
            // View Create vẫn dùng model NhanVien bình thường
            return View();
        }

        // ================== POST: NhanViens/Create ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,MaNhanVien,SoYeuLyLichId,MaThongTinBaoHiem")] NhanVien nhanVien
        )
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // ================== GET: NhanViens/Edit/5 ==================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return View(nhanVien);
        }

        // ================== POST: NhanViens/Edit/5 ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,MaNhanVien,SoYeuLyLichId,MaThongTinBaoHiem")] NhanVien nhanVien
        )
        {
            if (id != nhanVien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.Id))
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
            return View(nhanVien);
        }

        // ================== GET: NhanViens/Delete/5 ==================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FirstOrDefaultAsync(m => m.Id == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // ================== POST: NhanViens/Delete/5 ==================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanViens.Any(e => e.Id == id);
        }
    }
}
