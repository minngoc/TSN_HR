using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSN_HR_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddNgachCongVienChuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MucLuongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMucLuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgachCongVienChucId = table.Column<int>(type: "int", nullable: false),
                    BacLuong = table.Column<int>(type: "int", nullable: false),
                    HeSoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucLuongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NgachCongVienChucs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNgach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNgach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgachCongVienChucs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MucLuongs");

            migrationBuilder.DropTable(
                name: "NgachCongVienChucs");
        }
    }
}
