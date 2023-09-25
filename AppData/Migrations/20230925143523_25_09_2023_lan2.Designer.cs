﻿// <auto-generated />
using System;
using App_Data.DbContextt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App_Data.Migrations
{
    [DbContext(typeof(BazaizaiContext))]
    [Migration("20230925143523_25_09_2023_lan2")]
    partial class _25_09_2023_lan2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App_Data.Models.Anh", b =>
                {
                    b.Property<string>("IdAnh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdSanPhamChiTiet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAnh");

                    b.HasIndex("IdSanPhamChiTiet");

                    b.ToTable("Anh");
                });

            modelBuilder.Entity("App_Data.Models.ChatLieu", b =>
                {
                    b.Property<string>("IdChatLieu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaChatLieu")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenChatLieu")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdChatLieu");

                    b.ToTable("ChatLieus");
                });

            modelBuilder.Entity("App_Data.Models.ChucVu", b =>
                {
                    b.Property<string>("IdChucVu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaChucVu")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenChucVu")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdChucVu");

                    b.ToTable("chucVus");
                });

            modelBuilder.Entity("App_Data.Models.GioHang", b =>
                {
                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("NguoiDungIdNguoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdNguoiDung");

                    b.HasIndex("NguoiDungIdNguoiDung");

                    b.ToTable("gioHangs");
                });

            modelBuilder.Entity("App_Data.Models.GioHangChiTiet", b =>
                {
                    b.Property<string>("IdGioHangChiTiet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("GiaGoc")
                        .HasColumnType("float");

                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdSanPhamCT")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Soluong")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdGioHangChiTiet");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdSanPhamCT");

                    b.ToTable("gioHangChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.HoaDon", b =>
                {
                    b.Property<string>("IdHoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdKhachHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdThongTinGH")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdVoucher")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaHoaDon")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime?>("NgayNhan")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("NgayShip")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("DateTime");

                    b.Property<double?>("TienGiam")
                        .HasColumnType("float");

                    b.Property<double?>("TienShip")
                        .HasColumnType("float");

                    b.Property<double?>("TongTien")
                        .HasColumnType("float");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThaiThanhToan")
                        .HasColumnType("int");

                    b.HasKey("IdHoaDon");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdThongTinGH");

                    b.HasIndex("IdVoucher");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("App_Data.Models.HoaDonChiTiet", b =>
                {
                    b.Property<string>("IdHoaDonChiTiet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("GiaBan")
                        .HasColumnType("float");

                    b.Property<double?>("GiaGoc")
                        .HasColumnType("float");

                    b.Property<string>("IdHoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdSanPhamChiTiet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdHoaDonChiTiet");

                    b.HasIndex("IdHoaDon");

                    b.HasIndex("IdSanPhamChiTiet");

                    b.ToTable("hoaDonChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.KhachHang", b =>
                {
                    b.Property<string>("IdKhachHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKhachHang")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TenKhachHang")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdKhachHang");

                    b.HasIndex("IdNguoiDung");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("App_Data.Models.KhuyenMai", b =>
                {
                    b.Property<string>("IdKhuyenMai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("LoaiHinhKM")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MaKhuyenMai")
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("MucGiam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime");

                    b.Property<string>("PhamVi")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenKhuyenMai")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdKhuyenMai");

                    b.ToTable("KhuyenMai", (string)null);
                });

            modelBuilder.Entity("App_Data.Models.KhuyenMaiChiTiet", b =>
                {
                    b.Property<string>("IdKhuyenMaiChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("IdKhuyenMai")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IdKhuyenMai");

                    b.Property<string>("IdSanPhamChiTiet")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IdSanPhamChiTiet");

                    b.Property<string>("MoTa")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdKhuyenMaiChiTiet");

                    b.HasIndex("IdKhuyenMai");

                    b.HasIndex("IdSanPhamChiTiet");

                    b.ToTable("KhuyenMaiChiTiet", (string)null);
                });

            modelBuilder.Entity("App_Data.Models.KichCo", b =>
                {
                    b.Property<string>("IdKichCo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("MaKichCo")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("SoKichCo")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdKichCo");

                    b.ToTable("kichCos");
                });

            modelBuilder.Entity("App_Data.Models.KieuDeGiay", b =>
                {
                    b.Property<string>("IdKieuDeGiay")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKieuDeGiay")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenKieuDeGiay")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Trangthai")
                        .HasColumnType("int");

                    b.HasKey("IdKieuDeGiay");

                    b.ToTable("kieuDeGiays");
                });

            modelBuilder.Entity("App_Data.Models.LoaiGiay", b =>
                {
                    b.Property<string>("IdLoaiGiay")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaLoaiGiay")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenLoaiGiay")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdLoaiGiay");

                    b.ToTable("LoaiGiays");
                });

            modelBuilder.Entity("App_Data.Models.MauSac", b =>
                {
                    b.Property<string>("IdMauSac")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaMauSac")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenMauSac")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdMauSac");

                    b.ToTable("mauSacs");
                });

            modelBuilder.Entity("App_Data.Models.NguoiDung", b =>
                {
                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("IdChucVu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNguoiDung")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TenDangNhap")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("TenNguoiDung")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdNguoiDung");

                    b.HasIndex("IdChucVu");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("App_Data.Models.PhuongThucThanhToan", b =>
                {
                    b.Property<string>("IdPhuongThucThanhToan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaPhuongThucThanhToan")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenPhuongThucThanhToan")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdPhuongThucThanhToan");

                    b.ToTable("PhuongThucThanhToans");
                });

            modelBuilder.Entity("App_Data.Models.PhuongThucThanhToanChiTiet", b =>
                {
                    b.Property<string>("IdPhuongThucThanhToanChiTiet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdHoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdThanhToan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("SoTien")
                        .HasColumnType("float");

                    b.HasKey("IdPhuongThucThanhToanChiTiet");

                    b.HasIndex("IdHoaDon");

                    b.HasIndex("IdThanhToan");

                    b.ToTable("phuongThucThanhToanChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.SanPham", b =>
                {
                    b.Property<string>("IdSanPham")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaSanPham")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Trangthai")
                        .HasColumnType("int");

                    b.HasKey("IdSanPham");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("App_Data.Models.SanPhamChiTiet", b =>
                {
                    b.Property<string>("IdChiTietSp")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(250)");

                    b.Property<double?>("GiaBan")
                        .HasColumnType("float");

                    b.Property<double?>("GiaNhap")
                        .HasColumnType("float");

                    b.Property<string>("IdChatLieu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdKichCo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdKieuDeGiay")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdLoaiGiay")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdMauSac")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdSanPham")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdThuongHieu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdXuatXu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ma")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MoTa")
                        .HasColumnType("Nvarchar(max)");

                    b.Property<int?>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThaiSale")
                        .HasColumnType("int");

                    b.HasKey("IdChiTietSp");

                    b.HasIndex("IdChatLieu");

                    b.HasIndex("IdKichCo");

                    b.HasIndex("IdKieuDeGiay");

                    b.HasIndex("IdLoaiGiay");

                    b.HasIndex("IdMauSac");

                    b.HasIndex("IdSanPham");

                    b.HasIndex("IdThuongHieu");

                    b.HasIndex("IdXuatXu");

                    b.ToTable("sanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.SanPhamYeuThich", b =>
                {
                    b.Property<string>("IdSanPhamYeuThich")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdSanPhamChiTiet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdSanPhamYeuThich");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdSanPhamChiTiet");

                    b.ToTable("sanPhamYeuThiches");
                });

            modelBuilder.Entity("App_Data.Models.ThongTinGiaoHang", b =>
                {
                    b.Property<string>("IdThongTinGH")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("TenNguoiNhan")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdThongTinGH");

                    b.HasIndex("IdNguoiDung");

                    b.ToTable("thongTinGiaoHangs");
                });

            modelBuilder.Entity("App_Data.Models.ThuongHieu", b =>
                {
                    b.Property<string>("IdThuongHieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("MaThuongHieu")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenThuongHieu")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdThuongHieu");

                    b.ToTable("thuongHieus");
                });

            modelBuilder.Entity("App_Data.Models.Voucher", b =>
                {
                    b.Property<string>("IdVoucher")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DieuKien")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("LoaiHinhUuDai")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("MaVoucher")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("MucUuDai")
                        .HasColumnType("float");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenVoucher")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdVoucher");

                    b.ToTable("vouchers");
                });

            modelBuilder.Entity("App_Data.Models.VoucherNguoiDung", b =>
                {
                    b.Property<string>("IdVouCherNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdVouCher")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdVouCherNguoiDung");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdVouCher");

                    b.ToTable("voucherNguoiDungs");
                });

            modelBuilder.Entity("App_Data.Models.XuatXu", b =>
                {
                    b.Property<string>("IdXuatXu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ma")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdXuatXu");

                    b.ToTable("xuatXus");
                });

            modelBuilder.Entity("App_Data.Models.Anh", b =>
                {
                    b.HasOne("App_Data.Models.SanPhamChiTiet", "SanPhamChiTiets")
                        .WithMany("Anh")
                        .HasForeignKey("IdSanPhamChiTiet");

                    b.Navigation("SanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.GioHang", b =>
                {
                    b.HasOne("App_Data.Models.NguoiDung", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("NguoiDungIdNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("App_Data.Models.GioHangChiTiet", b =>
                {
                    b.HasOne("App_Data.Models.GioHang", "GioHang")
                        .WithMany("GioHangChiTiet")
                        .HasForeignKey("IdNguoiDung");

                    b.HasOne("App_Data.Models.SanPhamChiTiet", "SanPhamChiTiet")
                        .WithMany("GioHangChiTiet")
                        .HasForeignKey("IdSanPhamCT");

                    b.Navigation("GioHang");

                    b.Navigation("SanPhamChiTiet");
                });

            modelBuilder.Entity("App_Data.Models.HoaDon", b =>
                {
                    b.HasOne("App_Data.Models.KhachHang", "KhachHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdNguoiDung");

                    b.HasOne("App_Data.Models.ThongTinGiaoHang", "ThongTinGiaoHang")
                        .WithMany("HoaDon")
                        .HasForeignKey("IdThongTinGH");

                    b.HasOne("App_Data.Models.Voucher", "Voucher")
                        .WithMany("HoaDon")
                        .HasForeignKey("IdVoucher");

                    b.Navigation("KhachHang");

                    b.Navigation("ThongTinGiaoHang");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("App_Data.Models.HoaDonChiTiet", b =>
                {
                    b.HasOne("App_Data.Models.HoaDon", "HoaDon")
                        .WithMany("HoaDonChiTiet")
                        .HasForeignKey("IdHoaDon");

                    b.HasOne("App_Data.Models.SanPhamChiTiet", "SanPhamChiTiet")
                        .WithMany("HoaDonChiTiet")
                        .HasForeignKey("IdSanPhamChiTiet");

                    b.Navigation("HoaDon");

                    b.Navigation("SanPhamChiTiet");
                });

            modelBuilder.Entity("App_Data.Models.KhachHang", b =>
                {
                    b.HasOne("App_Data.Models.NguoiDung", "NguoiDung")
                        .WithMany("KhachHangs")
                        .HasForeignKey("IdNguoiDung");

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("App_Data.Models.KhuyenMaiChiTiet", b =>
                {
                    b.HasOne("App_Data.Models.KhuyenMai", "KhuyenMai")
                        .WithMany("KhuyenMaiChiTiet")
                        .HasForeignKey("IdKhuyenMai");

                    b.HasOne("App_Data.Models.SanPhamChiTiet", "SanPhamChiTiet")
                        .WithMany("KhuyenMaiChiTiet")
                        .HasForeignKey("IdSanPhamChiTiet");

                    b.Navigation("KhuyenMai");

                    b.Navigation("SanPhamChiTiet");
                });

            modelBuilder.Entity("App_Data.Models.NguoiDung", b =>
                {
                    b.HasOne("App_Data.Models.ChucVu", "ChucVu")
                        .WithMany("NguoiDungs")
                        .HasForeignKey("IdChucVu");

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("App_Data.Models.PhuongThucThanhToanChiTiet", b =>
                {
                    b.HasOne("App_Data.Models.HoaDon", "HoaDons")
                        .WithMany("PhuongThucThanhToanChiTiet")
                        .HasForeignKey("IdHoaDon");

                    b.HasOne("App_Data.Models.PhuongThucThanhToan", "PhuongThucThanhToan")
                        .WithMany("PhuongThucThanhToanChiTiets")
                        .HasForeignKey("IdThanhToan");

                    b.Navigation("HoaDons");

                    b.Navigation("PhuongThucThanhToan");
                });

            modelBuilder.Entity("App_Data.Models.SanPhamChiTiet", b =>
                {
                    b.HasOne("App_Data.Models.ChatLieu", "ChatLieu")
                        .WithMany("SanPhamChiTiets")
                        .HasForeignKey("IdChatLieu");

                    b.HasOne("App_Data.Models.KichCo", "KichCo")
                        .WithMany("SanPhamChiTiets")
                        .HasForeignKey("IdKichCo");

                    b.HasOne("App_Data.Models.KieuDeGiay", "KieuDeGiay")
                        .WithMany("SanPhamChiTiets")
                        .HasForeignKey("IdKieuDeGiay");

                    b.HasOne("App_Data.Models.LoaiGiay", "LoaiGiay")
                        .WithMany("SanPhamChiTiets")
                        .HasForeignKey("IdLoaiGiay");

                    b.HasOne("App_Data.Models.MauSac", "MauSac")
                        .WithMany("SanPhamChiTiets")
                        .HasForeignKey("IdMauSac");

                    b.HasOne("App_Data.Models.SanPham", "SanPham")
                        .WithMany("SanPhamChiTiets")
                        .HasForeignKey("IdSanPham");

                    b.HasOne("App_Data.Models.ThuongHieu", "ThuongHieu")
                        .WithMany("SanPhamChiTiets")
                        .HasForeignKey("IdThuongHieu");

                    b.HasOne("App_Data.Models.XuatXu", "XuatXu")
                        .WithMany("SanPhamChiTiets")
                        .HasForeignKey("IdXuatXu");

                    b.Navigation("ChatLieu");

                    b.Navigation("KichCo");

                    b.Navigation("KieuDeGiay");

                    b.Navigation("LoaiGiay");

                    b.Navigation("MauSac");

                    b.Navigation("SanPham");

                    b.Navigation("ThuongHieu");

                    b.Navigation("XuatXu");
                });

            modelBuilder.Entity("App_Data.Models.SanPhamYeuThich", b =>
                {
                    b.HasOne("App_Data.Models.NguoiDung", "NguoiDung")
                        .WithMany("SanPhamYeuThich")
                        .HasForeignKey("IdNguoiDung");

                    b.HasOne("App_Data.Models.SanPhamChiTiet", "SanPhamChiTiet")
                        .WithMany("SanPhamYeuThichs")
                        .HasForeignKey("IdSanPhamChiTiet");

                    b.Navigation("NguoiDung");

                    b.Navigation("SanPhamChiTiet");
                });

            modelBuilder.Entity("App_Data.Models.ThongTinGiaoHang", b =>
                {
                    b.HasOne("App_Data.Models.NguoiDung", "NguoiDungs")
                        .WithMany("ThongTinGiaoHangs")
                        .HasForeignKey("IdNguoiDung");

                    b.Navigation("NguoiDungs");
                });

            modelBuilder.Entity("App_Data.Models.VoucherNguoiDung", b =>
                {
                    b.HasOne("App_Data.Models.NguoiDung", "NguoiDungs")
                        .WithMany("VoucherNguoiDungs")
                        .HasForeignKey("IdNguoiDung");

                    b.HasOne("App_Data.Models.Voucher", "Vouchers")
                        .WithMany("VoucherNguoiDungs")
                        .HasForeignKey("IdVouCher");

                    b.Navigation("NguoiDungs");

                    b.Navigation("Vouchers");
                });

            modelBuilder.Entity("App_Data.Models.ChatLieu", b =>
                {
                    b.Navigation("SanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.ChucVu", b =>
                {
                    b.Navigation("NguoiDungs");
                });

            modelBuilder.Entity("App_Data.Models.GioHang", b =>
                {
                    b.Navigation("GioHangChiTiet");
                });

            modelBuilder.Entity("App_Data.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiet");

                    b.Navigation("PhuongThucThanhToanChiTiet");
                });

            modelBuilder.Entity("App_Data.Models.KhachHang", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("App_Data.Models.KhuyenMai", b =>
                {
                    b.Navigation("KhuyenMaiChiTiet");
                });

            modelBuilder.Entity("App_Data.Models.KichCo", b =>
                {
                    b.Navigation("SanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.KieuDeGiay", b =>
                {
                    b.Navigation("SanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.LoaiGiay", b =>
                {
                    b.Navigation("SanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.MauSac", b =>
                {
                    b.Navigation("SanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.NguoiDung", b =>
                {
                    b.Navigation("KhachHangs");

                    b.Navigation("SanPhamYeuThich");

                    b.Navigation("ThongTinGiaoHangs");

                    b.Navigation("VoucherNguoiDungs");
                });

            modelBuilder.Entity("App_Data.Models.PhuongThucThanhToan", b =>
                {
                    b.Navigation("PhuongThucThanhToanChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.SanPham", b =>
                {
                    b.Navigation("SanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.SanPhamChiTiet", b =>
                {
                    b.Navigation("Anh");

                    b.Navigation("GioHangChiTiet");

                    b.Navigation("HoaDonChiTiet");

                    b.Navigation("KhuyenMaiChiTiet");

                    b.Navigation("SanPhamYeuThichs");
                });

            modelBuilder.Entity("App_Data.Models.ThongTinGiaoHang", b =>
                {
                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("App_Data.Models.ThuongHieu", b =>
                {
                    b.Navigation("SanPhamChiTiets");
                });

            modelBuilder.Entity("App_Data.Models.Voucher", b =>
                {
                    b.Navigation("HoaDon");

                    b.Navigation("VoucherNguoiDungs");
                });

            modelBuilder.Entity("App_Data.Models.XuatXu", b =>
                {
                    b.Navigation("SanPhamChiTiets");
                });
#pragma warning restore 612, 618
        }
    }
}
