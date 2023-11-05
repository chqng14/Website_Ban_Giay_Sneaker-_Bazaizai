﻿using App_Data.DbContextt;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.HoaDon;
using App_Data.ViewModels.HoaDonChiTietDTO;
using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private PTThanhToanChiTietController _PTThanhToanChiTietController;
        private HoaDonChiTietController _hoaDonChiTietController;
        private readonly IHoaDonRepos _hoaDon;
        private readonly IMapper _mapper;
        private PTThanhToanController _PTThanhToanController;
        private SanPhamChiTietController _sanPhamChiTietController;
        public HoaDonController(IMapper mapper, SanPhamChiTietController sanPhamChiTietController)
        {
            _hoaDon = new HoaDonRepos(mapper);
            _mapper = mapper;
            _hoaDonChiTietController = new HoaDonChiTietController(mapper);
            _PTThanhToanChiTietController = new PTThanhToanChiTietController();
            _PTThanhToanController = new PTThanhToanController();
            _sanPhamChiTietController = sanPhamChiTietController;
        }
        [HttpPost]
        public async Task<HoaDon> TaoHoaDonTaiQuay(HoaDon hoaDon)
        {
            return _hoaDon.TaoHoaDonTaiQuay(hoaDon);
        }
        // POST api/<HoaDonController>
        [HttpPost]
        public async Task<string> TaoHoaDonOnlineDTO(HoaDonDTO HoaDonDTO)
        {
            var hoadon = _mapper.Map<HoaDon>(HoaDonDTO);
            _hoaDon.AddBill(hoadon);
            return hoadon.MaHoaDon;
        }
        [HttpGet]
        public async Task<List<HoaDonChoDTO>> GetAllHoaDonCho()
        {
            return _hoaDon.GetAllHoaDonCho();
        }
        [HttpGet]
        public async Task<List<HoaDonViewModel>> GetHoaDonOnline()
        {
            return _hoaDon.GetHoaDon();
        }

        //[HttpGet]
        //public async Task<string> GetHoaDonOnlineTest()
        //{
        //    var danhSachHoaDon = new List<HoaDonTest>();

        //    var danhSachHoaDonGoc = await GetHoaDonOnline();
        //    var sanPhamArray = new JArray();
        //    foreach (var hoadon in danhSachHoaDonGoc)
        //    {
        //        var hoadonct = (await _hoaDonChiTietController.GetAllHoaDon()).Where(c => c.IdHoaDon == hoadon.IdHoaDon).ToList();
        //        var loaithanhtoan = await GetPTThanhToan(hoadon.IdHoaDon);
        //        foreach (var item in hoadonct)
        //        {
        //            var sp = await _sanPhamChiTietController.GetSanPhamViewModel(item.IdSanPhamChiTiet);
        //            var sanPhamObject = new JObject()
        //            {
        //                {"IdSanPhamChiTiet", item.IdSanPhamChiTiet },
        //                        {"SoLuong", item.SoLuong },
        //                        {"GiaBan", item.GiaBan },
        //                        {"GiaGoc", item.GiaGoc },
        //                        {"GiaNhap", item.GiaGoc },
        //                        {"TenSanPham", sp.SanPham},
        //                        {"LinkAnh", JArray.FromObject(sp.ListTenAnh)},
        //                        {"TenMauSac", sp.MauSac },
        //                        {"TenKichCo",sp.KichCo },
        //                        {"TenThuongHieu", sp.ThuongHieu }
        //            };
        //            sanPhamArray.Add(sanPhamObject);
        //            var hoadontest = new HoaDonTest()
        //            {
        //                IdHoaDon = hoadon.IdHoaDon,
        //                MaHoaDon = hoadon.MaHoaDon,
        //                //TenSanPham = sp.SanPham,
        //                //SoLuong = item.SoLuong,
        //                TienGiam = hoadon.TienGiam,
        //                TienShip = hoadon.TienShip,
        //                TongTien = hoadon.TongTien,
        //                SanPham = sanPhamArray,
        //                //GiaBan = item.GiaBan,
        //                NgayTao = hoadon.NgayTao,
        //                NgayGiaoDuKien = hoadon.NgayGiaoDuKien,
        //                TrangThaiGiaoHang = hoadon.TrangThaiGiaoHang,
        //                TrangThaiThanhToan = hoadon.TrangThaiThanhToan,
        //                TenNguoiNhan = hoadon.TenNguoiNhan,
        //                DiaChi = hoadon.DiaChi,
        //                SDT = hoadon.SDT,
        //                LoaiThanhToan = loaithanhtoan,
        //            };
        //            danhSachHoaDon.Add(hoadontest);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(danhSachHoaDon);
        //}

        [HttpGet]
        public async Task<List<HoaDonTest>> GetHoaDonOnlineTest()
        {
            var danhSachHoaDon = new List<HoaDonTest>();

            var danhSachHoaDonGoc = await GetHoaDonOnline();
            foreach (var hoadon in danhSachHoaDonGoc)
            {
                var hoadonct = (await _hoaDonChiTietController.GetAllHoaDon()).Where(c => c.IdHoaDon == hoadon.IdHoaDon).ToList();
                var loaithanhtoan = await GetPTThanhToan(hoadon.IdHoaDon);

                var sanPhamList = new List<SanPhamTest>(); // Tạo JArray mới cho mỗi hóa đơn

                foreach (var item in hoadonct)
                {
                    var sp = await _sanPhamChiTietController.GetSanPhamViewModel(item.IdSanPhamChiTiet);
                    var sanPhamObject = new SanPhamTest
                    {
                        //IdSanPhamChiTiet = item.IdSanPhamChiTiet,
                        SoLuong = item.SoLuong,
                        GiaBan = item.GiaBan,
                        //GiaGoc = item.GiaGoc,
                        //GiaNhap = item.GiaGoc,
                        TenSanPham = sp.SanPham,
                        LinkAnh = sp.ListTenAnh,
                        TenMauSac = sp.MauSac,
                        TenKichCo = sp.KichCo,
                        TenThuongHieu = sp.ThuongHieu,
                        TrangThaiGiaoHang = hoadon.TrangThaiGiaoHang,
                        TongTien = item.GiaBan * item.SoLuong,
                    };
                    sanPhamList.Add(sanPhamObject);
                }

                var hoadontest = new HoaDonTest()
                {
                    IdHoaDon = hoadon.IdHoaDon,
                    MaHoaDon = hoadon.MaHoaDon,
                    TienGiam = hoadon.TienGiam,
                    TienShip = hoadon.TienShip,
                    TongTien = hoadon.TongTien,
                    TongGia = hoadon.TongTien + hoadon.TienShip - (hoadon.TienGiam ?? 0),
                    SanPham = sanPhamList,
                    NgayTao = hoadon.NgayTao,
                    NgayGiaoDuKien = hoadon.NgayGiaoDuKien,
                    TrangThaiGiaoHang = hoadon.TrangThaiGiaoHang,
                    TrangThaiThanhToan = hoadon.TrangThaiThanhToan,
                    TenNguoiNhan = hoadon.TenNguoiNhan,
                    DiaChi = hoadon.DiaChi,
                    SDT = hoadon.SDT,
                    LoaiThanhToan = loaithanhtoan,
                };

                danhSachHoaDon.Add(hoadontest);
            }

            return danhSachHoaDon;
        }


        [HttpPut]
        public async Task<bool> UpdateTrangThaiHoaDonOnline(string idHoaDon, int TrangThaiThanhToan)
        {
            var hoadon = _hoaDon.GetHoaDonUpdate().FirstOrDefault(c => c.IdHoaDon == idHoaDon);
            hoadon.TrangThaiThanhToan = TrangThaiThanhToan;
            await _hoaDonChiTietController.SuaTrangThaiHoaDon(idHoaDon, TrangThaiThanhToan);
            return _hoaDon.EditBill(hoadon);
        }

        [HttpPut]
        public async Task<bool> UpdateNgayHoaDonOnline(string idHoaDon, DateTime? NgayThanhToan, DateTime? NgayNhan, DateTime? NgayShip)
        {
            var hoadon = _hoaDon.GetHoaDonUpdate().FirstOrDefault(c => c.IdHoaDon == idHoaDon);
            hoadon.NgayNhan = NgayNhan ?? hoadon.NgayNhan;
            hoadon.NgayShip = NgayShip ?? hoadon.NgayShip;
            hoadon.NgayThanhToan = NgayThanhToan ?? hoadon.NgayThanhToan;
            return _hoaDon.EditBill(hoadon);
        }

        [HttpGet]
        public async Task<string> GetPTThanhToan(string idhoadon)
        {
            var pt = _PTThanhToanChiTietController.PhuongThucThanhToanChiTietByIdPTTT(idhoadon);
            var idpt = _PTThanhToanController.ShowAll().FirstOrDefault(c => c.IdPhuongThucThanhToan == pt.IdThanhToan);
            return idpt.TenPhuongThucThanhToan;
        }
    }
}
