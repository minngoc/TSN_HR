using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class NhanViensController : Controller
    {
        private readonly TSNHRDbContext _context;

        public NhanViensController(TSNHRDbContext context)
        {
            _context = context;
        }

        // ===== HELPER =====
        private static DateOnly? ToDateOnly(DateTime? dt)
        {
            return dt is DateTime d ? DateOnly.FromDateTime(d) : null;
        }

        // ================== GET: NhanViens ==================
        // Hiển thị bảng Nhân viên
        public IActionResult Index()
        {
            var data = _context
                .nhan_viens.Include(x => x.ma_so_yeu_ly_lichNavigation)
                .Include(x => x.nhan_vien_bo_phans)
                    .ThenInclude(bp => bp.bo_phan)
                .Select(x => new NhanVienListItemViewModel
                {
                    Id = x.id,
                    ma_nhan_vien = x.ma_nv,
                    ho_va_ten =
                        x.ma_so_yeu_ly_lichNavigation.ho_nv
                        + " "
                        + x.ma_so_yeu_ly_lichNavigation.ten_nv,

                    ten_chuc_vu = x
                        .nhan_vien_bo_phans.Where(bp => bp.is_primary)
                        .Select(bp => bp.bo_phan.ten_bo_phan)
                        .FirstOrDefault(),
                })
                .ToList();

            return View(data);
        }

        // ================== GET: NhanViens/Details/5 ==================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.nhan_viens.FirstOrDefaultAsync(m => m.id == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // ================== GET: NhanViens/Create ==================
        public IActionResult Create()
        {
            // Dropdown học vấn
            ViewBag.HocVanList = new SelectList(
                new[] { "Trung cấp", "Cao đẳng", "Đại học", "Sau đại học" }
            );

            // Dropdown trình độ
            ViewBag.TrinhDoList = new SelectList(
                new[] { "Sơ cấp", "Trung cấp", "Cao đẳng", "Đại học", "Thạc sĩ", "Tiến sĩ" }
            );

            // Model + Chức vụ
            var model = new NhanVienCreateViewModel
            {
                ChucVuList = _context
                    .chuc_vus.Select(cv => new SelectListItem
                    {
                        Value = cv.id.ToString(),
                        Text = cv.ten_chuc_vu,
                    })
                    .ToList(),
            };

            return View(model);
        }

        // ================== POST: NhanViens/Create ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NhanVienCreateViewModel model)
        {
            // ===== VALIDATION =====
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new
                    {
                        field = x.Key,
                        messages = x.Value.Errors.Select(e => e.ErrorMessage),
                    });

                return Json(new { success = false, errors });
            }
            // ===== VALIDATE NGHIỆP VỤ =====
            if (model.loai_hop_dong_id == null)
            {
                return Json(new { success = false, message = "Chưa chọn loại hợp đồng" });
            }

            if (model.ky_hd_tu == null)
            {
                return Json(new { success = false, message = "Chưa nhập ngày ký hợp đồng" });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // ======================================================
                // 1. SƠ YẾU LÝ LỊCH
                // ======================================================
                var soYeuLyLich = new so_yeu_ly_lich
                {
                    ma_so_yeu_ly_lich = "TMP", // bắt buộc (DB NOT NULL)

                    ho_nv = model.ho_nv ?? "",
                    ten_nv = model.ten_nv ?? "",
                    gioi_tinh = model.gioi_tinh ?? "",
                    ngay_sinh = ToDateOnly(model.ngay_sinh),
                    noi_sinh = model.noi_sinh,
                    nguyen_quan = model.nguyen_quan,
                    dan_toc = model.dan_toc,
                    ton_giao = model.ton_giao,
                    so_cccd = model.so_cccd,
                    ngay_cap = ToDateOnly(model.ngay_cap),
                    noi_cap = model.noi_cap,
                    thuong_tru = model.thuong_tru,
                    dia_chi = model.dia_chi,
                    dien_thoai_home = model.dien_thoai_home,
                    dien_thoai = model.dien_thoai,
                    ma_tai_khoan = model.ma_tai_khoan,
                    ngan_hang = model.ngan_hang,
                    ma_so_thue = model.ma_so_thue,
                    chuyen_nganh = model.chuyen_nganh,
                    ma_trang_phuc = model.ma_trang_phuc,
                    ma_giay = model.ma_giay,
                };

                _context.so_yeu_ly_liches.Add(soYeuLyLich);
                await _context.SaveChangesAsync();

                // sinh mã SYLL
                soYeuLyLich.ma_so_yeu_ly_lich = $"SYLL{soYeuLyLich.id.ToString().PadLeft(6, '0')}";
                await _context.SaveChangesAsync();

                // ======================================================
                // 2. BẢO HIỂM
                // ======================================================
                var baoHiem = new bao_hiem
                {
                    ma_kcb_cu = model.ma_kcb_cu,
                    ten_kcb_cu = model.ten_kcb_cu,
                    ma_kcb_moi = model.ma_kcb_moi,
                    ten_kcb_moi = model.ten_kcb_moi,
                    so_bhxh = model.so_bhxh,
                    so_ksk = model.so_ksk,
                    so_bhyt = model.so_bhyt,
                    ngay_bhtn = ToDateOnly(model.ngay_bhtn),
                    ngay_bhxh = ToDateOnly(model.ngay_bhxh),
                    thay_bhxh = model.thay_bhxh,
                    so_the_cong_doan = model.so_the_cong_doan,
                    ng_thu_viec = ToDateOnly(model.ng_thu_viec),
                    ng_vao_chinh_thuc = ToDateOnly(model.ng_vao_chinh_thuc),
                    effective_from = DateOnly.FromDateTime(DateTime.Today),
                };

                _context.bao_hiems.Add(baoHiem);
                await _context.SaveChangesAsync();

                // ======================================================
                // 3. NHÂN VIÊN
                // ======================================================
                var nhanVien = new nhan_vien
                {
                    ma_nv = "TMP", // bắt buộc (DB NOT NULL)
                    ma_so_yeu_ly_lich = soYeuLyLich.id,
                    ma_thong_tin_bao_hiem = baoHiem.id,
                };

                _context.nhan_viens.Add(nhanVien);
                await _context.SaveChangesAsync();

                // sinh mã NV
                nhanVien.ma_nv = $"TSN{nhanVien.id.ToString().PadLeft(6, '0')}";
                await _context.SaveChangesAsync();

                // ======================================================
                // 4. HỢP ĐỒNG
                // ======================================================
                string? so_thang_ky_hd = null;
                if (model.loai_ky_ket == "1")
                {
                    so_thang_ky_hd = "12 tháng";
                }
                else if (model.loai_ky_ket == "2")
                {
                    so_thang_ky_hd = "24 tháng";
                }
                else
                {
                    so_thang_ky_hd = "36 tháng";
                }
                var hopDong = new hop_dong
                {
                    so_hdld = "TMP",
                    nhan_vien_id = nhanVien.id,
                    loai_hop_dong_id = model.loai_hop_dong_id.Value,
                    KY_HD_TU = DateOnly.FromDateTime(model.ky_hd_tu.Value),
                    KY_HD_DEN = model.ky_hd_den.HasValue
                        ? DateOnly.FromDateTime(model.ky_hd_den.Value)
                        : null,
                    loai_ky_ket = so_thang_ky_hd,
                };

                _context.hop_dongs.Add(hopDong);
                await _context.SaveChangesAsync();

                hopDong.so_hdld = $"HD{hopDong.id.ToString().PadLeft(6, '0')}";
                await _context.SaveChangesAsync();

                // ======================================================
                // 5. CHỨC VỤ
                // ======================================================
                var nhanVienBoPhan = new nhan_vien_bo_phan
                {
                    nhan_vien_id = nhanVien.id,
                    bo_phan_id = model.bo_phan_id,
                    is_primary = true,
                };
                _context.nhan_vien_bo_phans.Add(nhanVienBoPhan);
                await _context.SaveChangesAsync();

                // ======================================================
                await transaction.CommitAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return Json(
                    new
                    {
                        success = false,
                        message = "Lỗi khi tạo nhân viên",
                        detail = ex.Message,
                    }
                );
            }
        }

        // ================== GET: NhanViens/Edit/5 ==================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.nhan_viens.FindAsync(id);
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
            [Bind("Id,MaNhanVien,SoYeuLyLichId,MaThongTinBaoHiem")] nhan_vien nhanVien
        )
        {
            if (id != nhanVien.id)
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
                    if (!NhanVienExists(nhanVien.id))
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

            var nhanVien = await _context.nhan_viens.FirstOrDefaultAsync(m => m.id == id);
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
            var nhanVien = await _context.nhan_viens.FindAsync(id);
            if (nhanVien != null)
            {
                _context.nhan_viens.Remove(nhanVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.nhan_viens.Any(e => e.id == id);
        }
    }
}
