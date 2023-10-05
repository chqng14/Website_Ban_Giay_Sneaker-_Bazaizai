﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_Data.DbContextt;
using App_Data.Models;

using App_Data.ViewModels.GioHangChiTiet;
using App_View.Services;
using App_View.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using DocumentFormat.OpenXml.VariantTypes;
using App_Data.ViewModels.SanPhamChiTietDTO;
using Microsoft.CodeAnalysis;
using System.Globalization;

namespace App_View.Controllers
{
    public class GioHangChiTietsController : Controller
    {
        private readonly HttpClient httpClient;
        IGioHangChiTietServices GioHangChiTietServices;
        private readonly SignInManager<NguoiDung> _signInManager;
        private readonly UserManager<NguoiDung> _userManager;
        ISanPhamChiTietService _sanPhamChiTietService;
        public GioHangChiTietsController(SignInManager<NguoiDung> signInManager, UserManager<NguoiDung> userManager, ISanPhamChiTietService sanPhamChiTietService)
        {
            httpClient = new HttpClient();
            GioHangChiTietServices = new GioHangChiTietServices();
            _sanPhamChiTietService = sanPhamChiTietService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: GioHangChiTiets
        public async Task<IActionResult> ShowCartUser()
        {
            var idNguoiDung = _userManager.GetUserId(User);
            var giohang = (await GioHangChiTietServices.GetAllGioHang()).Where(c => c.IdNguoiDung == idNguoiDung).ToList();
            return View(giohang);
        }

        public async Task<IActionResult> CheckOut()
        {
            var idNguoiDung = _userManager.GetUserId(User);
            var giohang = (await GioHangChiTietServices.GetAllGioHang()).Where(c => c.IdNguoiDung == idNguoiDung).ToList();
            return View(giohang);
        }

        // GET: GioHangChiTiets/Details/5
        public async Task<IActionResult> Details(string id)
        {


            return View();
        }

        // GET: GioHangChiTiets/Create
        public async Task<IActionResult> AddToCart(GioHangChiTietDTOCUD gioHangChiTietDTOCUD)
        {
            var idNguoiDung = _userManager.GetUserId(User);
            var product = await _sanPhamChiTietService.GetByKeyAsync(gioHangChiTietDTOCUD.IdSanPhamCT);
            var giohang = new GioHangChiTietDTOCUD();
            giohang.IdGioHangChiTiet = Guid.NewGuid().ToString();
            giohang.IdSanPhamCT = gioHangChiTietDTOCUD.IdSanPhamCT;
            giohang.IdNguoiDung = idNguoiDung;
            giohang.SoLuong = gioHangChiTietDTOCUD.SoLuong;
            giohang.GiaGoc = product.GiaBan;
            GioHangChiTietServices.CreateCartDetailDTO(giohang);
            return RedirectToAction("ShowCartUser");
        }


        // GET: GioHangChiTiets/Edit/5
        public async Task<IActionResult> CapNhatSoLuongGioHang(string IdGioHangChiTiet, int SoLuong, string IdSanPhamChiTiet)
        {
            var jsonupdate = await GioHangChiTietServices.UpdateGioHang(IdGioHangChiTiet, SoLuong);
            //var SumPrice = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0}đ", Convert.ToDouble((await _sanPhamChiTietService.GetByKeyAsync(IdSanPhamChiTiet)).GiaBan * SoLuong));
            var idNguoiDung = _userManager.GetUserId(User);
            var giohang = (await GioHangChiTietServices.GetAllGioHang()).Where(c => c.IdNguoiDung == idNguoiDung).ToList();
            double TongTien = 0;
            foreach (var item in giohang)
            {
                TongTien += (double)item.GiaGoc * (int)item.SoLuong;
            }
            return Json(new { /*SumPrice = SumPrice,*/ TongTien = TongTien });
        }

        // POST: GioHangChiTiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdGioHangChiTiet,IdNguoiDung,IdSanPhamCT,Soluong,GiaGoc,TrangThai")] GioHangChiTiet gioHangChiTiet)
        {

            return View();
        }

        // GET: GioHangChiTiets/Delete/5
        public async Task<IActionResult> DeleteCart(string id)
        {
            var jsondelete = await GioHangChiTietServices.DeleteGioHang(id);
            return RedirectToAction("ShowCartUser");
        }

        public async Task<IActionResult> DeleteAllCart()
        {
            var idNguoiDung = _userManager.GetUserId(User);
            List<GioHangChiTietDTO> giohang = (await GioHangChiTietServices.GetAllGioHang()).Where(c => c.IdNguoiDung == idNguoiDung).ToList();
            foreach (var item in giohang)
            {
                var jsondelete = await GioHangChiTietServices.DeleteGioHang(item.IdGioHangChiTiet);
            }
            return RedirectToAction("ShowCartUser");
        }
    }
}
