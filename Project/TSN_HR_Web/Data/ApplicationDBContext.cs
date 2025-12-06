using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models;

namespace TSN_HR_Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // TODO: Add DbSet for each object

        //DBSet for Nhan Vien
        public DbSet<NhanVien> NhanViens { get; set; }

        // DbSet for Co So
        public DbSet<CoSo> CoSos { get; set; }
        //DbSet for Bo Phan
        public DbSet<BoPhan> BoPhans { get; set; }
        // DbSet for ChucVu
        public DbSet<ChucVu> ChucVus { get; set; }
        // DbSet for Ngach cong vien chuc
        public DbSet<NgachCongVienChuc> NgachCongVienChucs { get; set; }
        // DbSet for Muc Luong
        public DbSet<MucLuong> MucLuongs { get; set; }
        // DbSet for Luong
        //public DbSet<Luong> Luongs { get; set; }

        // DbSet for So yeu ly lich
        public DbSet<SoYeuLyLich> SoYeuLyLichs { get; set; }

        //DbSet for Hop Dong
        public DbSet<HopDong> HopDongs { get; set; }

    }
}


