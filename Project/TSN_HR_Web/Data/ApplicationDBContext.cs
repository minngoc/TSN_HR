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

        // TODO: Thêm DbSet cho mỗi bảng
        public DbSet<NhanVien> NhanViens { get; set; }
    }
}


