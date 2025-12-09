namespace TSN_HR_Web.ViewModels
{
    public class NhanVienCreateViewModel
    {
        // ============================
        // 1) Sơ yếu lý lịch
        // ============================
        // public string MaNhanVien { get; set; }
        public string HoVaTenDem { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string NguyenQuan { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public string CMND { get; set; }
        public DateTime? NgayCap { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string DiaChiTamTru { get; set; }
        public string SoDienThoaiNha { get; set; }
        public string SoDienThoai { get; set; }
        public string SoTaiKhoan { get; set; }
        public string NganHang { get; set; }
        public string MaSoThue { get; set; }
        public string Avata { get; set; }


        // ============================
        // 2) Thông tin bảo hiểm
        // ============================
        public string HocVan { get; set; }
        public string TrinhDo { get; set; }
        public string ChuyenNganh { get; set; }
        public string LoaiKyKet { get; set; }
        public string MaKhamChuaBenhCu { get; set; }
        public string MaKhamChuaBenhMoi { get; set; }
        public string TenKhamChuaBenhCu { get; set; }
        public string TenKhamChuaBenhMoi { get; set; }
        public string SoBaoHiemXaHoi { get; set; }
        public string SoKhamSucKhoe { get; set; }
        public string SoBaoHiemYTe { get; set; }
        public DateTime NgayTinhBaoHiemXaHoi { get; set; }
        public DateTime NgayTinhBaoHiemTaiNan { get; set; }

        public DateTime? NgayCapBaoHiem { get; set; }
        public DateTime NgayThuViec { get; set; }
        public DateTime NgayVaoChinhThuc { get; set; }

        // ============================
        // 3) Bộ phận - drop down select box
        // ============================
        public string TenBoPhan { get; set; }
        public string ChucVu { get; set; }

        // ============================
        // 4) Hợp đồng
        // ============================
        public string LoaiHopDong { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int SoLanTaiKy { get; set; }
        public string QuyetDinhBanNgach { get; set; }
        public DateTime NgayBanNgach { get; set; }
        public string MaNgach { get; set; }
        public string BacLuong { get; set; }
        public string Luong { get; set; }
        public string PhuCap { get; set; }
        public string QUyetDinhXepLuong { get; set; }
        public DateTime NgayXepLuong { get; set; }
        public DateTime NgayThoiViec { get; set; }     
        public string SoQuyetDinhNghi { get; set; }
        public string LyDoNghi { get; set; }
        public string TienTroCap { get; set; }
    }
}
