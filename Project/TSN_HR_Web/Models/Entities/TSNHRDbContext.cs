using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TSN_HR_Web.Models.Entities;

public partial class TSNHRDbContext : DbContext
{
    public TSNHRDbContext(DbContextOptions<TSNHRDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<bac_luong> bac_luongs { get; set; }

    public virtual DbSet<bao_hiem> bao_hiems { get; set; }

    public virtual DbSet<bo_phan> bo_phans { get; set; }

    public virtual DbSet<chuc_vu> chuc_vus { get; set; }

    public virtual DbSet<co_so> co_sos { get; set; }

    public virtual DbSet<hop_dong> hop_dongs { get; set; }

    public virtual DbSet<loai_hop_dong> loai_hop_dongs { get; set; }

    public virtual DbSet<loai_vien_chuc> loai_vien_chucs { get; set; }

    public virtual DbSet<luong> luongs { get; set; }

    public virtual DbSet<muc_luong_co_so> muc_luong_co_sos { get; set; }

    public virtual DbSet<ngach_cong_vien_chuc> ngach_cong_vien_chucs { get; set; }

    public virtual DbSet<nghiep_vu> nghiep_vus { get; set; }

    public virtual DbSet<nhan_vien> nhan_viens { get; set; }

    public virtual DbSet<nhan_vien_bo_phan> nhan_vien_bo_phans { get; set; }

    public virtual DbSet<nhan_vien_chuc_vu> nhan_vien_chuc_vus { get; set; }

    public virtual DbSet<nhan_vien_phu_cap> nhan_vien_phu_caps { get; set; }

    public virtual DbSet<nhom_ngach> nhom_ngaches { get; set; }

    public virtual DbSet<phu_cap> phu_caps { get; set; }

    public virtual DbSet<so_yeu_ly_lich> so_yeu_ly_liches { get; set; }

    public virtual DbSet<thanh_phan_gia_dinh> thanh_phan_gia_dinhs { get; set; }

    public virtual DbSet<xep_luong_nhan_vien> xep_luong_nhan_viens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<bac_luong>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_muc_luong");

            entity.ToTable("bac_luong");

            entity.HasIndex(e => e.ma_muc_luong, "UQ_ma_muc_luong").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.he_so_luong).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_muc_luong)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.ngach).WithMany(p => p.bac_luongs)
                .HasForeignKey(d => d.ngach_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_muc_luong_ngach_vien_chuc");
        });

        modelBuilder.Entity<bao_hiem>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_thong_tin_bao_hiem");

            entity.ToTable("bao_hiem");

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())", "DF_thong_tin_bao_hiem_created");
            entity.Property(e => e.is_active).HasDefaultValue(true, "DF_thong_tin_bao_hiem_is_active");
            entity.Property(e => e.ma_kcb_cu).HasMaxLength(50);
            entity.Property(e => e.ma_kcb_moi).HasMaxLength(50);
            entity.Property(e => e.so_bhxh).HasMaxLength(20);
            entity.Property(e => e.so_bhyt).HasMaxLength(20);
            entity.Property(e => e.so_ksk).HasMaxLength(20);
            entity.Property(e => e.so_the_cong_doan).HasMaxLength(20);
            entity.Property(e => e.ten_kcb_cu).HasMaxLength(200);
            entity.Property(e => e.ten_kcb_moi).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())", "DF_thong_tin_bao_hiem_updated");
        });

        modelBuilder.Entity<bo_phan>(entity =>
        {
            entity.ToTable("bo_phan");

            entity.HasIndex(e => e.ma_bo_phan, "UQ_ma_bo_phan").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_bo_phan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ten_bo_phan).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.co_so).WithMany(p => p.bo_phans)
                .HasForeignKey(d => d.co_so_id)
                .HasConstraintName("FK_bo_phan_co_so");
        });

        modelBuilder.Entity<chuc_vu>(entity =>
        {
            entity.ToTable("chuc_vu");

            entity.HasIndex(e => e.ma_chuc_vu, "UQ_ma_chuc_vu").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_chuc_vu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ten_chuc_vu).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.bo_phan).WithMany(p => p.chuc_vus)
                .HasForeignKey(d => d.bo_phan_id)
                .HasConstraintName("FK_chuc_vu_bo_phan");
        });

        modelBuilder.Entity<co_so>(entity =>
        {
            entity.ToTable("co_so");

            entity.HasIndex(e => e.ma_co_so, "UQ_ma_co_so").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.dia_chi).HasMaxLength(300);
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_co_so)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ten_co_so).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<hop_dong>(entity =>
        {
            entity.ToTable("hop_dong");

            entity.HasIndex(e => e.so_hdld, "UQ_hop_dong_so").IsUnique();

            entity.Property(e => e.SO_HDLD_L).HasMaxLength(50);
            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.loai_ky_ket).HasMaxLength(20);
            entity.Property(e => e.ly_do_nghi).HasMaxLength(200);
            entity.Property(e => e.so_hdld).HasMaxLength(50);
            entity.Property(e => e.so_quyet_dinh_thoi_viec).HasMaxLength(100);
            entity.Property(e => e.tien_tro_cap).HasMaxLength(20);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.loai_hop_dong).WithMany(p => p.hop_dongs)
                .HasForeignKey(d => d.loai_hop_dong_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hop_dong_loai_hop_dong");

            entity.HasOne(d => d.nhan_vien).WithMany(p => p.hop_dongs)
                .HasForeignKey(d => d.nhan_vien_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hop_dong_nhan_vien");
        });

        modelBuilder.Entity<loai_hop_dong>(entity =>
        {
            entity.ToTable("loai_hop_dong");

            entity.HasIndex(e => e.ma_loai, "UQ_ma_loai_hop_dong").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_loai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ten_loai).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<loai_vien_chuc>(entity =>
        {
            entity.ToTable("loai_vien_chuc");

            entity.HasIndex(e => e.ma_loai_vien_chuc, "UQ_loai_vien_chuc_ma").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_loai_vien_chuc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ten_loai_vien_chuc).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<luong>(entity =>
        {
            entity.ToTable("luong");

            entity.HasIndex(e => e.ma_luong, "UQ_ma_luong").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.gia_canh).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.luong_thuc_nhan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ma_luong)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ma_thue).HasMaxLength(20);
            entity.Property(e => e.nam_tham_nien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.tong_khau_tru).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.tong_thu_nhap).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.tru_khac).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.nhan_vien).WithMany(p => p.luongs)
                .HasForeignKey(d => d.nhan_vien_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_luong_nhan_vien");
        });

        modelBuilder.Entity<muc_luong_co_so>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__muc_luon__3213E83FA5DDFB63");

            entity.ToTable("muc_luong_co_so");

            entity.Property(e => e.so_tien).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<ngach_cong_vien_chuc>(entity =>
        {
            entity.ToTable("ngach_cong_vien_chuc");

            entity.HasIndex(e => e.ma_ngach, "UQ_ma_ngach").IsUnique();

            entity.Property(e => e.chuyen_nganh).HasMaxLength(200);
            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_ngach)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ten_ngach).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.nhom_ngach).WithMany(p => p.ngach_cong_vien_chucs)
                .HasForeignKey(d => d.nhom_ngach_id)
                .HasConstraintName("FK_ngach_nhom");
        });

        modelBuilder.Entity<nghiep_vu>(entity =>
        {
            entity.ToTable("nghiep_vu");

            entity.HasIndex(e => e.ma_nghiep_vu, "UQ_ma_nghiep_vu").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.loai_nghiep_vu).HasMaxLength(200);
            entity.Property(e => e.ma_nghiep_vu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ten_nghiep_vu).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<nhan_vien>(entity =>
        {
            entity.ToTable("nhan_vien");

            entity.HasIndex(e => e.ma_nv, "UQ_ma_nhan_vien").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_nv)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.ma_so_yeu_ly_lichNavigation).WithMany(p => p.nhan_viens)
                .HasForeignKey(d => d.ma_so_yeu_ly_lich)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nhan_vien_ma_so_yeu_ly_lich");

            entity.HasOne(d => d.ma_thong_tin_bao_hiemNavigation).WithMany(p => p.nhan_viens)
                .HasForeignKey(d => d.ma_thong_tin_bao_hiem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nhan_vien_ma_thong_tin_bao_hiem");
        });

        modelBuilder.Entity<nhan_vien_bo_phan>(entity =>
        {
            entity.ToTable("nhan_vien_bo_phan");

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.bo_phan).WithMany(p => p.nhan_vien_bo_phans)
                .HasForeignKey(d => d.bo_phan_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nhan_vien_bo_phan_bo_phan");

            entity.HasOne(d => d.chuc_vu).WithMany(p => p.nhan_vien_bo_phans)
                .HasForeignKey(d => d.chuc_vu_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nhan_vien_bo_phan_chuc_vu");

            entity.HasOne(d => d.nhan_vien).WithMany(p => p.nhan_vien_bo_phans)
                .HasForeignKey(d => d.nhan_vien_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nhan_vien_bo_phan_nhan_vien");
        });

        modelBuilder.Entity<nhan_vien_chuc_vu>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__nhan_vie__3213E83F982F90A9");

            entity.ToTable("nhan_vien_chuc_vu");

            entity.Property(e => e.created_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.is_primary).HasDefaultValue(true);
            entity.Property(e => e.updated_date).HasColumnType("datetime");

            entity.HasOne(d => d.chuc_vu).WithMany(p => p.nhan_vien_chuc_vus)
                .HasForeignKey(d => d.chuc_vu_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nvcv_cv");

            entity.HasOne(d => d.nhan_vien).WithMany(p => p.nhan_vien_chuc_vus)
                .HasForeignKey(d => d.nhan_vien_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nvcv_nv");
        });

        modelBuilder.Entity<nhan_vien_phu_cap>(entity =>
        {
            entity.ToTable("nhan_vien_phu_cap");

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.nhan_vien).WithMany(p => p.nhan_vien_phu_caps)
                .HasForeignKey(d => d.nhan_vien_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nhan_vien_phu_cap_nhan_vien");

            entity.HasOne(d => d.phu_cap).WithMany(p => p.nhan_vien_phu_caps)
                .HasForeignKey(d => d.phu_cap_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nhan_vien_phu_cap_phu_cap");
        });

        modelBuilder.Entity<nhom_ngach>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__nhom_nga__3213E83FB6A8C988");

            entity.ToTable("nhom_ngach");

            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_nhom).HasMaxLength(10);
            entity.Property(e => e.ten_nhom).HasMaxLength(100);
        });

        modelBuilder.Entity<phu_cap>(entity =>
        {
            entity.ToTable("phu_cap");

            entity.HasIndex(e => e.ma_phu_cap, "UQ_ma_phu_cap").IsUnique();

            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_phu_cap)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mo_ta).HasMaxLength(500);
            entity.Property(e => e.ten_phu_cap).HasMaxLength(200);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<so_yeu_ly_lich>(entity =>
        {
            entity.ToTable("so_yeu_ly_lich");

            entity.HasIndex(e => e.ma_so_yeu_ly_lich, "UQ_ma_so_yeu_ly_lich").IsUnique();

            entity.Property(e => e.chuyen_nganh).HasMaxLength(100);
            entity.Property(e => e.created_date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.dan_toc).HasMaxLength(50);
            entity.Property(e => e.dia_chi).HasMaxLength(300);
            entity.Property(e => e.dien_thoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.dien_thoai_home)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ho_nv).HasMaxLength(50);
            entity.Property(e => e.hoc_van).HasMaxLength(50);
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.ma_giay).HasMaxLength(20);
            entity.Property(e => e.ma_so_thue)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ma_so_yeu_ly_lich)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ma_tai_khoan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ma_trang_phuc).HasMaxLength(10);
            entity.Property(e => e.ngan_hang).HasMaxLength(100);
            entity.Property(e => e.nguyen_quan).HasMaxLength(200);
            entity.Property(e => e.noi_cap).HasMaxLength(200);
            entity.Property(e => e.noi_sinh).HasMaxLength(200);
            entity.Property(e => e.passport).HasMaxLength(20);
            entity.Property(e => e.so_cccd)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ten_nv).HasMaxLength(50);
            entity.Property(e => e.thuong_tru).HasMaxLength(300);
            entity.Property(e => e.ton_giao).HasMaxLength(50);
            entity.Property(e => e.trinh_do).HasMaxLength(50);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<thanh_phan_gia_dinh>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__thanh_ph__3213E83F8DDDBAE9");

            entity.ToTable("thanh_phan_gia_dinh");

            entity.HasIndex(e => e.so_yeu_ly_lich_id, "IX_TPGD_SYLL");

            entity.Property(e => e.cong_tac).HasMaxLength(200);
            entity.Property(e => e.created_date).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.dia_chi).HasMaxLength(300);
            entity.Property(e => e.gioi_tinh).HasMaxLength(10);
            entity.Property(e => e.ho_va_ten_dem).HasMaxLength(50);
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.nghe_nghiep).HasMaxLength(100);
            entity.Property(e => e.quan_he).HasMaxLength(50);
            entity.Property(e => e.ten).HasMaxLength(50);
            entity.Property(e => e.updated_date).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.so_yeu_ly_lich).WithMany(p => p.thanh_phan_gia_dinhs)
                .HasForeignKey(d => d.so_yeu_ly_lich_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TPGD_SYLL");
        });

        modelBuilder.Entity<xep_luong_nhan_vien>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__xep_luon__3213E83FC1F03DC6");

            entity.ToTable("xep_luong_nhan_vien");

            entity.Property(e => e.is_hien_hanh).HasDefaultValue(true);
            entity.Property(e => e.quyet_dinh_so).HasMaxLength(50);

            entity.HasOne(d => d.bac_luong).WithMany(p => p.xep_luong_nhan_viens)
                .HasForeignKey(d => d.bac_luong_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_xlnv_bac_luong");

            entity.HasOne(d => d.ngach).WithMany(p => p.xep_luong_nhan_viens)
                .HasForeignKey(d => d.ngach_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_xlnv_ngach");

            entity.HasOne(d => d.nhan_vien).WithMany(p => p.xep_luong_nhan_viens)
                .HasForeignKey(d => d.nhan_vien_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_xlnv_nhan_vien");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
