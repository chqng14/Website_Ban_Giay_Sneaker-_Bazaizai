﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_Data.DbContextt;
using App_Data.Models;
using Newtonsoft.Json;
using System.Net.Http;
using DocumentFormat.OpenXml.Drawing;
using Org.BouncyCastle.Ocsp;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace App_View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhuyenMaisController : Controller
    {
        private readonly BazaizaiContext _context;
        private readonly HttpClient _httpClient;
        public KhuyenMaisController(BazaizaiContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        // GET: Admin/KhuyenMais
        public async Task<IActionResult> Index()
        {
            var KhuyenMais = JsonConvert.DeserializeObject<List<KhuyenMai>>(await (await _httpClient.GetAsync("https://localhost:7038/api/KhuyenMai")).Content.ReadAsStringAsync());
            return View(KhuyenMais);
        }

        // GET: Admin/KhuyenMais/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.khuyenMais == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.khuyenMais
                .FirstOrDefaultAsync(m => m.IdKhuyenMai == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return View(khuyenMai);
        }

        // GET: Admin/KhuyenMais/Create
        public IActionResult Create()
        {
            ViewBag.ListLoaiHinh = new List<SelectListItem>
            {
                new SelectListItem { Text = "Thương hiệu", Value = "0" },
                new SelectListItem { Text = "Màu săc", Value = "1" },
                new SelectListItem { Text = "Định kỳ", Value = "2" },
                new SelectListItem { Text = "Mức giá", Value = "3" }
            };
            ViewBag.ListGiamGia = new List<SelectListItem>
            {
                new SelectListItem { Text = "5%", Value = "5" },
                new SelectListItem { Text = "10%", Value = "10" },
                new SelectListItem { Text = "15%", Value = "15" },
                new SelectListItem { Text = "20%", Value = "20" },
                new SelectListItem { Text = "25%", Value = "25" },
                new SelectListItem { Text = "30%", Value = "30" },
                new SelectListItem { Text = "35%", Value = "35" },
                new SelectListItem { Text = "40%", Value = "40" },
                new SelectListItem { Text = "45%", Value = "45" },
                new SelectListItem { Text = "50%", Value = "50" },
                new SelectListItem { Text = "55%", Value = "55" },
                new SelectListItem { Text = "60%", Value = "60" },
                new SelectListItem { Text = "65%", Value = "65" },
                new SelectListItem { Text = "70%", Value = "70" },
                new SelectListItem { Text = "75%", Value = "75" },
                new SelectListItem { Text = "80%", Value = "80" },
                new SelectListItem { Text = "85%", Value = "85" },
                new SelectListItem { Text = "90%", Value = "90" },
                new SelectListItem { Text = "95%", Value = "95" },
                new SelectListItem { Text = "100%", Value = "100" }
            };
            return View();
        }

        // POST: Admin/KhuyenMais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KhuyenMai khuyenMai)
        {
            khuyenMai.IdKhuyenMai = Guid.NewGuid().ToString();
            khuyenMai.TrangThai = 0;
            ViewData["IdKhuyenMai"] = new SelectList(_context.khuyenMais, "IdKhuyenMai", "IdKhuyenMai");
            ViewBag.ListLoaiHinh = new List<SelectListItem>
            {
                new SelectListItem { Text = "Thương hiệu", Value = "0" },
                new SelectListItem { Text = "Màu săc", Value = "1" },
                new SelectListItem { Text = "Định kỳ", Value = "2" },
                new SelectListItem { Text = "Mức giá", Value = "3" }
            };
            ViewBag.ListGiamGia = new List<SelectListItem>
            {
                new SelectListItem { Text = "5%", Value = "5" },
                new SelectListItem { Text = "10%", Value = "10" },
                new SelectListItem { Text = "15%", Value = "15" },
                new SelectListItem { Text = "20%", Value = "20" },
                new SelectListItem { Text = "25%", Value = "25" },
                new SelectListItem { Text = "30%", Value = "30" },
                new SelectListItem { Text = "35%", Value = "35" },
                new SelectListItem { Text = "40%", Value = "40" },
                new SelectListItem { Text = "45%", Value = "45" },
                new SelectListItem { Text = "50%", Value = "50" },
                new SelectListItem { Text = "55%", Value = "55" },
                new SelectListItem { Text = "60%", Value = "60" },
                new SelectListItem { Text = "65%", Value = "65" },
                new SelectListItem { Text = "70%", Value = "70" },
                new SelectListItem { Text = "75%", Value = "75" },
                new SelectListItem { Text = "80%", Value = "80" },
                new SelectListItem { Text = "85%", Value = "85" },
                new SelectListItem { Text = "90%", Value = "90" },
                new SelectListItem { Text = "95%", Value = "95" },
                new SelectListItem { Text = "100%", Value = "100" }
            };
            if (khuyenMai!=null)
            {
                await _httpClient.PostAsync($"https://localhost:7038/api/KhuyenMai?Ten={khuyenMai.TenKhuyenMai}&ngayBD={khuyenMai.NgayBatDau}&ngayKT={khuyenMai.NgayKetThuc}&trangThai={khuyenMai.TrangThai}&mucGiam={khuyenMai.MucGiam}&PhamVi={khuyenMai.PhamVi}&loaiHinh={khuyenMai.LoaiHinhKM}", null);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Admin/KhuyenMais/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.khuyenMais == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.khuyenMais.FindAsync(id);
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return View(khuyenMai);
        }

        // POST: Admin/KhuyenMais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdKhuyenMai,MaKhuyenMai,TenKhuyenMai,NgayBatDau,NgayKetThuc,LoaiHinhKM,MucGiam,PhamVi,TrangThai")] KhuyenMai khuyenMai)
        {
            if (id != khuyenMai.IdKhuyenMai)
            {
                return NotFound();
            }

            if (khuyenMai != null)
            {
                try
                {
                    _context.Update(khuyenMai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenMaiExists(khuyenMai.IdKhuyenMai))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khuyenMai);
        }

        // GET: Admin/KhuyenMais/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.khuyenMais == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.khuyenMais
                .FirstOrDefaultAsync(m => m.IdKhuyenMai == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return View(khuyenMai);
        }

        // POST: Admin/KhuyenMais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.khuyenMais == null)
            {
                return Problem("Entity set 'BazaizaiContext.khuyenMais'  is null.");
            }
            var khuyenMai = await _context.khuyenMais.FindAsync(id);
            if (khuyenMai != null)
            {
                _context.khuyenMais.Remove(khuyenMai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuyenMaiExists(string id)
        {
            return (_context.khuyenMais?.Any(e => e.IdKhuyenMai == id)).GetValueOrDefault();
        }
    }
}