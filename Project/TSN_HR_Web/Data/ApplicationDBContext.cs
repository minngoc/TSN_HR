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
        //SbSet for ChucVu
        public DbSet<ChucVu> ChucVus { get; set; }

    }
}


