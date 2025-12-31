using System.Text.Json;
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
            var query = _context
                .nhan_viens.AsNoTracking()
                .Where(nv => nv.is_active) // chỉ NV hiện tại
                .Select(nv => new
                {
                    id = nv.id,
                    ma_nhan_vien = nv.ma_nv,

                    ho_va_ten = nv.ma_so_yeu_ly_lichNavigation.ho_nv
                        + " "
                        + nv.ma_so_yeu_ly_lichNavigation.ten_nv,

                    ten_chuc_vu = nv
                        .nhan_vien_bo_phans.Where(bp => bp.is_primary)
                        .Select(bp => bp.bo_phan.ten_bo_phan)
                        .FirstOrDefault(),

                    trang_thai = "Đang làm việc",
                });

            return DataTablesResult(query, Request);
        }

        // =========================================================
        // DETAILS
        // =========================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var nv = await _context
                .nhan_viens.Include(x => x.ma_so_yeu_ly_lichNavigation)
                    .ThenInclude(s => s.thanh_phan_gia_dinhs)
                .Include(x => x.ma_thong_tin_bao_hiemNavigation)
                .Include(x => x.hop_dongs)
                .Include(x => x.nhan_vien_bo_phans)
                .Include(x => x.nhan_vien_chuc_vus)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (nv == null)
                return NotFound();

            var syll = nv.ma_so_yeu_ly_lichNavigation;
            var baoHiem = nv.ma_thong_tin_bao_hiemNavigation;
            var hopDong = nv.hop_dongs.FirstOrDefault(hd => hd.is_active);
            var giaDinh = nv.ma_so_yeu_ly_lichNavigation.thanh_phan_gia_dinhs.ToList();

            var model = new NhanVienCreateViewModel
            {
                // ===== SƠ YẾU LÝ LỊCH =====
                ho_nv = syll.ho_nv,
                ten_nv = syll.ten_nv,
                gioi_tinh =
                    syll.gioi_tinh == 1 ? "Nam"
                    : syll.gioi_tinh == 0 ? "Nữ"
                    : null,

                ngay_sinh = syll.ngay_sinh,
                noi_sinh = syll.noi_sinh,
                nguyen_quan = syll.nguyen_quan,
                dan_toc = syll.dan_toc,
                ton_giao = syll.ton_giao,
                so_cccd = syll.so_cccd,
                ngay_cap = syll.ngay_cap,
                noi_cap = syll.noi_cap,
                thuong_tru = syll.thuong_tru,
                dia_chi = syll.dia_chi,
                dien_thoai = syll.dien_thoai,
                dien_thoai_home = syll.dien_thoai_home,
                ma_tai_khoan = syll.ma_tai_khoan,
                ngan_hang = syll.ngan_hang,
                ma_so_thue = syll.ma_so_thue,
                ma_trang_phuc = syll.ma_trang_phuc,
                ma_giay = syll.ma_giay,

                // ===== THÔNG TIN BẢO HIỂM =====
                ma_kcb_cu = baoHiem.ma_kcb_cu,
                ten_kcb_cu = baoHiem.ten_kcb_cu,
                ma_kcb_moi = baoHiem.ma_kcb_moi,
                ten_kcb_moi = baoHiem.ten_kcb_moi,
                so_bhxh = baoHiem.so_bhxh,
                so_ksk = baoHiem.so_ksk,
                so_bhyt = baoHiem.so_bhyt,
                ngay_bhtn = baoHiem.ngay_bhtn,
                ngay_bhxh = baoHiem.ngay_bhxh,
                ng_thu_viec = baoHiem.ng_thu_viec,
                ng_vao_chinh_thuc = baoHiem.ng_vao_chinh_thuc,

                // ===== HỢP ĐỒNG =====
                ky_hd_tu = hopDong.KY_HD_TU,
                ky_hd_den = hopDong.KY_HD_DEN,
                loai_hop_dong_id = hopDong.loai_hop_dong_id,
                loai_ky_ket = hopDong.loai_ky_ket,
                // ===== PHÒNG BAN / CHỨC VỤ =====
                BoPhanId = nv.nhan_vien_bo_phans.FirstOrDefault()?.bo_phan_id,
                ChucVuId = nv.nhan_vien_chuc_vus.FirstOrDefault()?.chuc_vu_id,
                // ===== DROPDOWN =====
                BoPhanList = GetBoPhanList(),
                ChucVuList = GetChucVuList(nv.nhan_vien_bo_phans.FirstOrDefault()?.bo_phan_id),
                so_hdld = hopDong.so_hdld,
                // so_lan_tai_ky = hopDong.SO_LAN,
                // quyet_dinh_ban_ngach = hopDong,
                // ngay_ban_ngach = hopDong,
                // ma_ngach = hopDong,
                // bac_luong = hopDong,
                // ngay_xep_luong = hopDong,
                // quyet_dinh_xep_luong = hopDong,
                // phu_cap_bhxh = hopDong,
                // tien = hopDong,
                ngay_thoi_viec = hopDong.ng_thoi_viec,
                so_quyet_dinh_thoi_viec = hopDong.so_quyet_dinh_thoi_viec,
                ly_do_nghi = hopDong.ly_do_nghi,
                tien_tro_cap = hopDong.tien_tro_cap,
            };
            model.ThanhPhanGiaDinh = giaDinh
                .Select(x => new ThanhPhanGiaDinhViewModel
                {
                    HoVaTenDem = x.ho_va_ten_dem,
                    Ten = x.ten,
                    QuanHe = x.quan_he,
                    NgaySinh = x.ngay_sinh,
                    NgheNghiep = x.nghe_nghiep,
                    DiaChiCongTac = x.dia_chi,
                })
                .ToList();

            return PartialView("_NhanVienForm", model);
        }

        // =========================================================
        // CREATE – GET
        // =========================================================
        public IActionResult Create()
        {
            var model = new NhanVienCreateViewModel
            {
                ThanhPhanGiaDinh = new List<ThanhPhanGiaDinhViewModel>(),
                BoPhanList = _context
                    .bo_phans.AsNoTracking()
                    .Where(bp => bp.is_active)
                    .Select(bp => new SelectListItem
                    {
                        Value = bp.id.ToString(),
                        Text = bp.ten_bo_phan,
                    })
                    .ToList(),
                ChucVuList = new List<SelectListItem>(),
            };

            BuildHocVanTrinhDo(model);
            return View(model);
        }

        // =========================================================
        // API: LOAD CHỨC VỤ THEO PHÒNG BAN
        // =========================================================
        [HttpGet]
        public IActionResult GetChucVuByBoPhan(int boPhanId)
        {
            var data = _context
                .chuc_vus.AsNoTracking()
                .Where(x => x.bo_phan_id == boPhanId && x.is_active)
                .Select(x => new { id = x.id, ten_chuc_vu = x.ten_chuc_vu })
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
                BuildHocVanTrinhDo(model);

                model.BoPhanList = _context
                    .bo_phans.Where(x => x.is_active)
                    .Select(x => new SelectListItem
                    {
                        Value = x.id.ToString(),
                        Text = x.ten_bo_phan,
                    })
                    .ToList();

                return PartialView("_NhanVienForm", model);
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. SƠ YẾU LÝ LỊCH
                var soYeuLyLich = new so_yeu_ly_lich
                {
                    ma_so_yeu_ly_lich = "TMP" + (DateTime.UtcNow.Ticks % 10_000_000).ToString("D7"),

                    ho_nv = model.ho_nv ?? "",
                    ten_nv = model.ten_nv ?? "",
                    gioi_tinh =
                        model.gioi_tinh == "Nam" ? (byte)1
                        : model.gioi_tinh == "Nữ" ? (byte)0
                        : null,

                    ngay_sinh = model.ngay_sinh,
                    noi_sinh = model.noi_sinh,
                    nguyen_quan = model.nguyen_quan,
                    dan_toc = model.dan_toc,
                    ton_giao = model.ton_giao,
                    so_cccd = model.so_cccd,
                    ngay_cap = model.ngay_cap,
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
                    is_active = true,
                };

                _context.so_yeu_ly_liches.Add(soYeuLyLich);
                await _context.SaveChangesAsync();
                // sinh mã SYLL tăng dần theo format SYLL000001, SYLL000002, ...
                soYeuLyLich.ma_so_yeu_ly_lich = $"SYLL{soYeuLyLich.id.ToString().PadLeft(6, '0')}";
                await _context.SaveChangesAsync();

                // 2. BẢO HIỂM
                var baoHiem = new bao_hiem
                {
                    ma_kcb_cu = model.ma_kcb_cu,
                    ten_kcb_cu = model.ten_kcb_cu,
                    ma_kcb_moi = model.ma_kcb_moi,
                    ten_kcb_moi = model.ten_kcb_moi,
                    so_bhxh = model.so_bhxh,
                    so_ksk = model.so_ksk,
                    so_bhyt = model.so_bhyt,
                    ngay_bhtn = model.ngay_bhtn,
                    ngay_bhxh = model.ngay_bhxh,
                    thay_bhxh = model.thay_bhxh,
                    so_the_cong_doan = model.so_the_cong_doan,
                    ng_thu_viec = model.ng_thu_viec,
                    ng_vao_chinh_thuc = model.ng_vao_chinh_thuc,
                    effective_from = DateOnly.FromDateTime(DateTime.Today),
                    is_active = true,
                };

                _context.bao_hiems.Add(baoHiem);
                await _context.SaveChangesAsync();

                // 3. NHÂN VIÊN
                var nhanVien = new nhan_vien
                {
                    ma_nv = "TMP" + (DateTime.UtcNow.Ticks % 10_000_000).ToString("D7"),
                    ma_so_yeu_ly_lich = soYeuLyLich.id,
                    ma_thong_tin_bao_hiem = baoHiem.id,
                    is_active = true,
                };

                _context.nhan_viens.Add(nhanVien);
                await _context.SaveChangesAsync();

                // sinh mã NV
                nhanVien.ma_nv = $"TSN{nhanVien.id.ToString().PadLeft(6, '0')}";
                await _context.SaveChangesAsync();

                // 4. HỢP ĐỒNG
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
                if (!model.ky_hd_tu.HasValue)
                {
                    ModelState.AddModelError(
                        nameof(model.ky_hd_tu),
                        "Vui lòng chọn ngày bắt đầu hợp đồng"
                    );
                    return View(model);
                }
                var hopDong = new hop_dong
                {
                    so_hdld = "TMP" + (DateTime.UtcNow.Ticks % 10_000_000).ToString("D7"),
                    nhan_vien_id = nhanVien.id,
                    loai_hop_dong_id = model.loai_hop_dong_id ?? 0,
                    KY_HD_TU = model.ky_hd_tu.Value,
                    KY_HD_DEN = model.ky_hd_den.HasValue ? model.ky_hd_den.Value : null,
                    loai_ky_ket = so_thang_ky_hd,
                    is_active = true,
                };
                _context.hop_dongs.Add(hopDong);
                await _context.SaveChangesAsync();
                // sinh mã HĐ
                hopDong.so_hdld = $"HD{hopDong.id.ToString().PadLeft(6, '0')}";
                await _context.SaveChangesAsync();
                // 5. GÁN CHỨC VỤ
                var chucVu = await _context.chuc_vus.FirstAsync(x => x.id == model.ChucVuId);

                _context.nhan_vien_bo_phans.Add(
                    new nhan_vien_bo_phan
                    {
                        nhan_vien_id = nhanVien.id,
                        chuc_vu_id = chucVu.id,
                        bo_phan_id = chucVu.bo_phan_id!.Value,
                        is_primary = true,
                        is_active = true,
                    }
                );

                await _context.SaveChangesAsync();

                if (!string.IsNullOrEmpty(model.ThanhPhanGiaDinhJson))
                {
                    var giaDinhItems = JsonSerializer.Deserialize<
                        List<ThanhPhanGiaDinhItemViewModel>
                    >(model.ThanhPhanGiaDinhJson);

                    foreach (var item in giaDinhItems!)
                    {
                        _context.thanh_phan_gia_dinhs.Add(
                            new thanh_phan_gia_dinh
                            {
                                so_yeu_ly_lich_id = soYeuLyLich.id,

                                ho_va_ten_dem = item.HoVaTenDem,
                                ten = item.Ten,
                                ngay_sinh = !string.IsNullOrEmpty(item.NgaySinh)
                                    ? DateOnly.FromDateTime(DateTime.Parse(item.NgaySinh))
                                    : null,

                                gioi_tinh = item.GioiTinh,
                                quan_he = item.QuanHe,
                                nghe_nghiep = item.NgheNghiep,

                                // map đúng theo entity
                                dia_chi = item.DiaChiCongTac,

                                created_date = DateTime.Now,
                                updated_date = DateTime.Now,
                                is_active = true,
                            }
                        );
                    }

                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return Json(
                    new { success = false, message = ex.InnerException?.Message ?? ex.Message }
                );
            }
        }

        // =========================================================
        // DELETE
        // =========================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var nv = await _context.nhan_viens.FindAsync(id);
            if (nv == null)
                return NotFound();

            nv.is_active = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =========================================================
        private bool NhanVienExists(int id)
        {
            return _context.nhan_viens.Any(e => e.id == id);
        }

        private void BuildHocVanTrinhDo(NhanVienCreateViewModel model)
        {
            model.HocVanList = new List<SelectListItem>
            {
                new("Trung cấp", "Trung cấp"),
                new("Cao đẳng", "Cao đẳng"),
                new("Đại học", "Đại học"),
                new("Sau đại học", "Sau đại học"),
            };

            model.TrinhDoList = new List<SelectListItem>
            {
                new("Cử nhân", "Cử nhân"),
                new("Thạc sĩ", "Thạc sĩ"),
                new("Tiến sĩ", "Tiến sĩ"),
            };
        }

        private string GenerateSoYeuLyLichCode()
        {
            return "SYLL" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        private List<SelectListItem> GetBoPhanList()
        {
            return _context
                .bo_phans.AsNoTracking()
                .Where(x => x.is_active)
                .Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.ten_bo_phan })
                .ToList();
        }

        private List<SelectListItem> GetChucVuList(int? boPhanId)
        {
            if (boPhanId == null)
                return new List<SelectListItem>();

            return _context
                .chuc_vus.AsNoTracking()
                .Where(x => x.bo_phan_id == boPhanId && x.is_active)
                .Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.ten_chuc_vu })
                .ToList();
        }
    }
}
