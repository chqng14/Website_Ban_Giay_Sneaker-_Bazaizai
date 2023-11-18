﻿using App_Data.Models;
using App_View.IServices;
using App_View.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App_View.Controllers
{
    public class DanhGiaController : Controller
    {

        private readonly UserManager<NguoiDung> _userManager;
        private readonly SignInManager<NguoiDung> _signInManager;
        private IDanhGiaService _danhGiaService;

        public DanhGiaController(IDanhGiaService danhGiaService, UserManager<NguoiDung> userManager,
            SignInManager<NguoiDung> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _danhGiaService = danhGiaService;
        }
        public ActionResult _ModalAddDanhGiaPartialView(string idSanPhamChiTiet)
        {

            //var model = await _sanPhamChiTietService.GetItemDetailViewModelAynsc(idSanPhamChiTiet);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _ModalAddDanhGiaPartialView(DanhGia danhgia)
        {
            var user = await _userManager.GetUserAsync(User);
            danhgia.IdNguoiDung = await _userManager.GetUserIdAsync(user);
            danhgia.ParentId = null;
            await _danhGiaService.CreateDanhGia(danhgia);

            return View();
        }
    }
}
