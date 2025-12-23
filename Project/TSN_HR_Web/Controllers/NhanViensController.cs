using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class NhanViensController : BaseController
    {
        private readonly TSNHRDbContext _context;

        public NhanViensController(TSNHRDbContext context)
        {
            _context = context;
        }

        // ================== HELPER ==================
        private static DateOnly? ToDateOnly(DateTime? dt)
        {
            return dt is DateTime d ? DateOnly.FromDateTime(d) : null;
        }

        public IActionResult Index()
        {
            return View();
        }

        // =========================================================
        // DATATABLES API – LOAD DANH SÁCH NHÂN VIÊN
        // =========================================================
        [HttpGet]
        public IActionResult GetData(bool status = true)
        {
            var query = _context.nhan_viens
                .AsNoTracking()
                .Where(nv => nv.is_active) // chỉ NV hiện tại
                .Select(nv => new
                {
                    id = nv.id,
                    ma_nhan_vien = nv.ma_nv,

                    ho_va_ten =
                        nv.ma_so_yeu_ly_lichNavigation.ho_nv + " " +
                        nv.ma_so_yeu_ly_lichNavigation.ten_nv,

                    ten_chuc_vu = nv.nhan_vien_bo_phans
                        .Where(bp => bp.is_primary)
                        .Select(bp => bp.bo_phan.ten_bo_phan)
                        .FirstOrDefault(),

                    trang_thai = "Đang làm"
                });

            return DataTablesResult(query, Request);
        }

        // =========================================================
        // DETAILS
        // =========================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var nhanVien = await _context.nhan_viens
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (nhanVien == null) return NotFound();

            return View(nhanVien);
        }

        // =========================================================
        // CREATE – GET
        // =========================================================
        public IActionResult Create()
        {
            ViewBag.HocVanList = new SelectList(
                new[] { "Trung cấp", "Cao đẳng", "Đại học", "Sau đại học" }
            );

            ViewBag.TrinhDoList = new SelectList(
                new[] { "Sơ cấp", "Trung cấp", "Cao đẳng", "Đại học", "Thạc sĩ", "Tiến sĩ" }
            );

            var model = new NhanVienCreateViewModel
            {
                BoPhanList = _context.bo_phans
    .AsNoTracking()
    .Where(bp => bp.is_active)
    .Select(bp => new SelectListItem
    {
        Value = bp.id.ToString(),
        Text = bp.ten_bo_phan
    })
    .ToList(),

                ChucVuList = new List<SelectListItem>()
            };

            return View(model);
        }

        // =========================================================
        // API: LOAD CHỨC VỤ THEO PHÒNG BAN
        // =========================================================
        [HttpGet]
        public IActionResult GetChucVuByBoPhan(int boPhanId)
        {
            var data = _context.chuc_vus
                .AsNoTracking()
                .Where(x => x.bo_phan_id == boPhanId && x.is_active)
                .Select(x => new
                {
                    id = x.id,
                    ten = x.ten_chuc_vu
                })
                .ToList();

            return Json(data);
        }

        // =========================================================
        // CREATE – POST
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NhanVienCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ" });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. SƠ YẾU LÝ LỊCH
                var soYeuLyLich = new so_yeu_ly_lich
                {
                    ma_so_yeu_ly_lich = "TMP",
                    ho_nv = model.ho_nv ?? "",
                    ten_nv = model.ten_nv ?? "",
                    gioi_tinh = model.gioi_tinh ?? "",
                    ngay_sinh = ToDateOnly(model.ngay_sinh),
                };

                _context.so_yeu_ly_liches.Add(soYeuLyLich);
                await _context.SaveChangesAsync();

                soYeuLyLich.ma_so_yeu_ly_lich = $"SYLL{soYeuLyLich.id:000000}";
                await _context.SaveChangesAsync();

                // 2. BẢO HIỂM
                var baoHiem = new bao_hiem
                {
                    so_bhxh = model.so_bhxh,
                    so_bhyt = model.so_bhyt,
                    effective_from = DateOnly.FromDateTime(DateTime.Today)
                };

                _context.bao_hiems.Add(baoHiem);
                await _context.SaveChangesAsync();

                // 3. NHÂN VIÊN
                var nhanVien = new nhan_vien
                {
                    ma_nv = "TMP",
                    ma_so_yeu_ly_lich = soYeuLyLich.id,
                    ma_thong_tin_bao_hiem = baoHiem.id,
                    is_active = true
                };

                _context.nhan_viens.Add(nhanVien);
                await _context.SaveChangesAsync();

                nhanVien.ma_nv = $"TSN{nhanVien.id:000000}";
                await _context.SaveChangesAsync();

                // 4. GÁN CHỨC VỤ
                var chucVu = await _context.chuc_vus.FirstAsync(x => x.id == model.chuc_vu_id);

                _context.nhan_vien_bo_phans.Add(new nhan_vien_bo_phan
                {
                    nhan_vien_id = nhanVien.id,
                    chuc_vu_id = chucVu.id,
                    bo_phan_id = chucVu.bo_phan_id!.Value,
                    is_primary = true,
                    is_active = true
                });

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Json(new { success = false, message = ex.Message });
            }
        }

        // =========================================================
        // DELETE
        // =========================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var nv = await _context.nhan_viens.FindAsync(id);
            if (nv == null) return NotFound();

            nv.is_active = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =========================================================
        private bool NhanVienExists(int id)
        {
            return _context.nhan_viens.Any(e => e.id == id);
        }
    }
}
