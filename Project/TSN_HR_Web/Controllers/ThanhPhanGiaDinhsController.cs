using Microsoft.AspNetCore.Mvc;
using TSN_HR_Web.Controllers;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

public class ThanhPhanGiaDinhsController : BaseController
{
    private readonly TSNHRDbContext _context;

    public ThanhPhanGiaDinhsController(TSNHRDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Add(ThanhPhanGiaDinhCreateDto dto)
    {
        var entity = new thanh_phan_gia_dinh
        {
            so_yeu_ly_lich_id = dto.SoYeuLyLichId,
            ho_va_ten_dem = dto.HoVaTenDem,
            ten = dto.Ten,
            gioi_tinh = dto.GioiTinh,
            ngay_sinh = dto.NgaySinh,
            quan_he = dto.QuanHe,
            nghe_nghiep = dto.NgheNghiep,
            dia_chi = dto.DiaChiCongTac,
            is_active = true,
            created_date = DateTime.Now,
        };

        _context.thanh_phan_gia_dinhs.Add(entity);
        _context.SaveChanges();

        // trả list mới để reload table
        var items = _context
            .thanh_phan_gia_dinhs.Where(x =>
                x.so_yeu_ly_lich_id == dto.SoYeuLyLichId && x.is_active
            )
            .Select(x => new ThanhPhanGiaDinhItemViewModel
            { /* map */
            })
            .ToList();

        return Json(items);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var entity = _context.thanh_phan_gia_dinhs.Find(id);
        if (entity == null)
            return NotFound();

        entity.is_active = false;
        _context.SaveChanges();

        return Ok();
    }
}
