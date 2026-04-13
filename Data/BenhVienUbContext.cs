using System;
using System.Collections.Generic;
using BHYTDashboard.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BHYTDashboard.Data;

public partial class BenhVienUbContext : DbContext
{
    public BenhVienUbContext()
    {
    }

    public BenhVienUbContext(DbContextOptions<BenhVienUbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDvkt> ChiTietDvkts { get; set; }

    public virtual DbSet<ChiTietThuoc> ChiTietThuocs { get; set; }

    public virtual DbSet<DanhMucDoiTuong> DanhMucDoiTuongs { get; set; }

    public virtual DbSet<DanhMucIcd10> DanhMucIcd10s { get; set; }

    public virtual DbSet<DanhMucNhomChiPhi> DanhMucNhomChiPhis { get; set; }

    public virtual DbSet<HoSoBenhNhan> HoSoBenhNhans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KU34JC9\\SQLEXPRESS;Database=BHYTDashboardDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDvkt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiTietD__3214EC07508B6BB4");

            entity.ToTable("ChiTietDVKT");

            entity.Property(e => e.MaBacSi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaDichVu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaLk)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MaLK");
            entity.Property(e => e.MaNhomChiPhi)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaVatTu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayYlenh).HasColumnName("NgayYLenh");
            entity.Property(e => e.TenDichVu)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TenVatTu)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.MaLkNavigation).WithMany(p => p.ChiTietDvkts)
                .HasForeignKey(d => d.MaLk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDVK__MaLK__3C69FB99");

            entity.HasOne(d => d.MaNhomChiPhiNavigation).WithMany(p => p.ChiTietDvkts)
                .HasForeignKey(d => d.MaNhomChiPhi)
                .HasConstraintName("FK__ChiTietDV__MaNho__45F365D3");
        });

        modelBuilder.Entity<ChiTietThuoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiTietT__3214EC076F5A254A");

            entity.ToTable("ChiTietThuoc");

            entity.Property(e => e.DonViTinh)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaLk)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MaLK");
            entity.Property(e => e.MaNhomChiPhi)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaThuoc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenThuoc)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.MaLkNavigation).WithMany(p => p.ChiTietThuocs)
                .HasForeignKey(d => d.MaLk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietThu__MaLK__398D8EEE");

            entity.HasOne(d => d.MaNhomChiPhiNavigation).WithMany(p => p.ChiTietThuocs)
                .HasForeignKey(d => d.MaNhomChiPhi)
                .HasConstraintName("FK__ChiTietTh__MaNho__44FF419A");
        });

        modelBuilder.Entity<DanhMucDoiTuong>(entity =>
        {
            entity.HasKey(e => e.MaDoiTuong).HasName("PK__DanhMucD__291408A164B5DC2E");

            entity.ToTable("DanhMucDoiTuong");

            entity.Property(e => e.MaDoiTuong)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenDoiTuong)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DanhMucIcd10>(entity =>
        {
            entity.HasKey(e => e.MaIcd).HasName("PK__DanhMucI__3B5EE75567E3A4FA");

            entity.ToTable("DanhMucICD10");

            entity.Property(e => e.MaIcd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaICD");
            entity.Property(e => e.TenBenh)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DanhMucNhomChiPhi>(entity =>
        {
            entity.HasKey(e => e.MaNhomChiPhi).HasName("PK__DanhMucN__40482F3C9128A357");

            entity.ToTable("DanhMucNhomChiPhi");

            entity.Property(e => e.MaNhomChiPhi)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenNhomChiPhi)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoSoBenhNhan>(entity =>
        {
            entity.HasKey(e => e.MaLk).HasName("PK__HoSoBenh__2725C77A7CB7A511");

            entity.ToTable("HoSoBenhNhan");

            entity.Property(e => e.MaLk)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MaLK");
            entity.Property(e => e.ChanDoanRa)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChanDoanVao)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DiaChi)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaBenhChinh)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaBn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MaBN");
            entity.Property(e => e.MaCskcb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaCSKCB");
            entity.Property(e => e.MaDoiTuong)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaTheBhyt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaTheBHYT");
            entity.Property(e => e.TongBhchiTra).HasColumnName("TongBHChiTra");

            entity.HasOne(d => d.MaBenhChinhNavigation).WithMany(p => p.HoSoBenhNhans)
                .HasForeignKey(d => d.MaBenhChinh)
                .HasConstraintName("FK__HoSoBenhN__MaBen__440B1D61");

            entity.HasOne(d => d.MaDoiTuongNavigation).WithMany(p => p.HoSoBenhNhans)
                .HasForeignKey(d => d.MaDoiTuong)
                .HasConstraintName("FK__HoSoBenhN__MaDoi__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
