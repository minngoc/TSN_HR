using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSN_HR_Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HopDongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHopDongLaoDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiHopDongId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoHopDongLaoDongCu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KyHopDongTu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KyHopDongDen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLanTaiKy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoYeuLyLichs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoYeuLyLichId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoVaTenDem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguyenQuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanToc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TonGiao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiTamTru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoaiNha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoaiCaNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNganHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTrangPhuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaGiay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoYeuLyLichs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDongs");

            migrationBuilder.DropTable(
                name: "SoYeuLyLichs");
        }
    }
}
