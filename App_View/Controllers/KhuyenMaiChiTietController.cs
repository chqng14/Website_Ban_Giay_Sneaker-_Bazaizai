﻿using App_Data.Models;
using App_View.IServices;
using App_View.Services;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static App_Data.Repositories.TrangThai;

namespace App_View.Controllers
{
    public class KhuyenMaiChiTietController : Controller
    {
        public HttpClient httpClient { get; set; }
        private readonly IKhuyenMaiChiTietServices khuyenMaiChiTietServices;
        private readonly IKhuyenMaiServices khuyenMaiServices;
        private readonly ISanPhamChiTietService sanPhamChiTietService;
        public KhuyenMaiChiTietController(IKhuyenMaiChiTietServices khuyenMaiChiTietServices, IKhuyenMaiServices khuyenMaiServices, ISanPhamChiTietService sanPhamChiTietService)
        {
            httpClient = new HttpClient();
            this.khuyenMaiChiTietServices = khuyenMaiChiTietServices;
            this.khuyenMaiServices = khuyenMaiServices;
            this.sanPhamChiTietService = sanPhamChiTietService;
        }

        public async Task<IActionResult> GetAllKhuyenMaiChiTiet()
        {
            var KhuyenMaiChiTiet = JsonConvert.DeserializeObject<List<KhuyenMaiChiTiet>>(await (await httpClient.GetAsync("https://bazaizaiapi-v2.azurewebsites.net/api/KhuyenMaiChiTiet")).Content.ReadAsStringAsync());
            return View(KhuyenMaiChiTiet);
        }
        public async Task<IActionResult> DetailKhuyenMaiChiTiet(string id)
        {

            var kichCo = (JsonConvert.DeserializeObject<List<KhuyenMaiChiTiet>>(await (await httpClient.GetAsync("https://bazaizaiapi-v2.azurewebsites.net/api/KhuyenMaiChiTiet")).Content.ReadAsStringAsync())).FirstOrDefault(x => x.IdKhuyenMaiChiTiet == id);
            return View(kichCo);

        }

        public ActionResult CreateKhuyenMaiChiTiet()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateKhuyenMaiChiTiet(KhuyenMaiChiTiet q)
        {
            await httpClient.PostAsync($"https://bazaizaiapi-v2.azurewebsites.net/api/KhuyenMaiChiTiet?mota={q.MoTa}&trangThai={q.TrangThai}&IDKm={q.IdKhuyenMai}&IDSpCt={q.IdSanPhamChiTiet}", null);
            return RedirectToAction("GetAllKhuyenMaiChiTiet");
        }


        public async Task<IActionResult> DeleteKhuyenMaiChiTiet(string id)
        {
            await httpClient.DeleteAsync($"https://bazaizaiapi-v2.azurewebsites.net/api/KhuyenMaiChiTiet/{id}");
            return RedirectToAction("GetAllKhuyenMaiChiTiet");
        }

        public async Task<IActionResult> EditKhuyenMaiChiTiet(string IdKhuyenMaiChiTiet)
        {
            var kichCo = (JsonConvert.DeserializeObject<List<KhuyenMaiChiTiet>>(await (await httpClient.GetAsync("https://bazaizaiapi-v2.azurewebsites.net/api/KhuyenMaiChiTiet")).Content.ReadAsStringAsync())).FirstOrDefault(x => x.IdKhuyenMaiChiTiet == IdKhuyenMaiChiTiet);

            if (kichCo == null)
            {
                return NotFound();
            }

            return View(kichCo);
        }
        [HttpPost]

        public async Task<IActionResult> EditKhuyenMaiChiTiet(KhuyenMaiChiTiet a)
        {
            var apiUrl = $"https://bazaizaiapi-v2.azurewebsites.net/api/KhuyenMaiChiTiet/{a.IdKhuyenMaiChiTiet}?mota={a.MoTa}&trangThai={a.TrangThai}&IDKm={a.IdKhuyenMai}&IDSpCt={a.IdSanPhamChiTiet}";

            var response = await httpClient.PutAsync(apiUrl, null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllKhuyenMaiChiTiet");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult ViewKhuyenMai()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> KhuyenMaiDongGiaAsync(string idKhuyenMai)
        {
            var kmct = (await khuyenMaiChiTietServices.GetAllKhuyenMaiChiTiet()).Where(x => x.TrangThai == (int)TrangThaiSaleDetail.DangKhuyenMai&&x.IdKhuyenMai== idKhuyenMai).GroupBy(x=>x.SanPham).Select(x=>x.First()).ToList();
            var model = new App_Data.ViewModels.SanPhamChiTietViewModel.DanhSachGiayViewModel();
            model = sanPhamChiTietService.GetDanhSachGiayViewModelAynsc().Result;
            var lstSpDuocApDungKhuyenMai = model.LstAllSanPham.Where(x => x.GiaThucTe < x.GiaGoc).ToList();
            ViewBag.lstSpct = lstSpDuocApDungKhuyenMai.ToList();
            var khuyenMai = (await khuyenMaiServices.GetAllKhuyenMai()).Where(x => x.TrangThai == (int)TrangThaiSale.DangBatDau);
            ViewBag.KhuyemMai = khuyenMai;
            return PartialView(kmct);
        }
    }
}
