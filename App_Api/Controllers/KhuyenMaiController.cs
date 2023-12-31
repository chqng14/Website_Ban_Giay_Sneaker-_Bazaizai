﻿using App_Data.DbContextt;
using App_Data.IRepositories;
using App_Data.Models;
using App_Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Linq;
using System.Runtime.CompilerServices;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        private readonly IAllRepo<KhuyenMai> repos;
        BazaizaiContext context = new BazaizaiContext();
        DbSet<KhuyenMai> khuyenMais;
        public KhuyenMaiController()
        {
            khuyenMais = context.khuyenMais;
            AllRepo<KhuyenMai> all = new AllRepo<KhuyenMai>(context, khuyenMais);
            repos = all;
        }
        [HttpGet]
        public IEnumerable<KhuyenMai> GetAllKhuyenMai()
        {
            return repos.GetAll();
        }

        [HttpPost("Create-KhuyenMai")]

        public async Task<IActionResult> CreateKhuyenMaiAsync(string id,string Ten, DateTime ngayBD, DateTime ngayKT, int trangThai, decimal mucGiam, int loaiHinh, IFormFile formFile)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string rootPath = Directory.GetParent(currentDirectory).FullName;
                string uploadDirectory = Path.Combine(rootPath, "App_View", "wwwroot", "AnhSale");
                string MaTS;
                if (repos.GetAll().Count() == 0)
                {
                    MaTS = "KM1";
                }
                else
                {
                    MaTS = "KM" + (repos.GetAll().Count() + 1);
                }
                if (formFile.Length > 0)
                {
                    using var stream = new MemoryStream();
                    formFile.CopyTo(stream);
                    stream.Position = 0;

                    using var image = SixLabors.ImageSharp.Image.Load(stream);

                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new SixLabors.ImageSharp.Size(1600, 1600),
                        Mode = ResizeMode.Max
                    }));

                    var encoder = new JpegEncoder
                    {
                        Quality = 80
                    };

                    string fileName = Guid.NewGuid().ToString() +formFile.FileName;
                    string outputPath = Path.Combine(uploadDirectory, fileName);
                    using var outputStream = new FileStream(outputPath, FileMode.Create);
                    await image.SaveAsync(outputStream, encoder);
                    KhuyenMai KhuyenMai = new KhuyenMai();
                    KhuyenMai.TenKhuyenMai = Ten;
                    KhuyenMai.MaKhuyenMai = MaTS;
                    KhuyenMai.IdKhuyenMai = id;
                    KhuyenMai.TrangThai = trangThai;
                    KhuyenMai.NgayBatDau = ngayBD;
                    KhuyenMai.NgayKetThuc = ngayKT;
                    KhuyenMai.MucGiam = mucGiam;
                    KhuyenMai.LoaiHinhKM = loaiHinh;
                    KhuyenMai.Url = fileName;

                    repos.AddItem(KhuyenMai);
                }
                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditKhuyenMaiAsync(string id, string Ten, DateTime ngayBD, DateTime ngayKT, int trangThai, decimal mucGiam, int loaiHinh, IFormFile formFile)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string rootPath = Directory.GetParent(currentDirectory).FullName;
            string uploadDirectory = Path.Combine(rootPath, "App_View", "wwwroot", "AnhSale");
            if (formFile.Length > 0 && formFile != null)
            {
                using var stream = new MemoryStream();
                formFile.CopyTo(stream);
                stream.Position = 0;

                using var image = SixLabors.ImageSharp.Image.Load(stream);

                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new SixLabors.ImageSharp.Size(1600, 1600),
                    Mode = ResizeMode.Max
                }));

                var encoder = new JpegEncoder
                {
                    Quality = 80
                };

                string fileName = Guid.NewGuid().ToString() + formFile.FileName;
                string outputPath = Path.Combine(uploadDirectory, fileName);

                using var outputStream = new FileStream(outputPath, FileMode.Create);
                await image.SaveAsync(outputStream, encoder);
                var KhuyenMai = repos.GetAll().First(p => p.IdKhuyenMai == id);
                KhuyenMai.TenKhuyenMai = Ten;
                KhuyenMai.TrangThai = trangThai;
                KhuyenMai.NgayBatDau = ngayBD;
                KhuyenMai.NgayKetThuc = ngayKT;
                KhuyenMai.MucGiam = mucGiam;
                KhuyenMai.LoaiHinhKM = loaiHinh;
                KhuyenMai.Url = fileName;
                repos.EditItem(KhuyenMai);
            }
            else 
            {
                var KhuyenMai = await context.khuyenMais.FindAsync(id);
                KhuyenMai.TenKhuyenMai = Ten;
                KhuyenMai.TrangThai = trangThai;
                KhuyenMai.NgayBatDau = ngayBD;
                KhuyenMai.NgayKetThuc = ngayKT;
                KhuyenMai.MucGiam = mucGiam;
                KhuyenMai.LoaiHinhKM = loaiHinh;
                repos.EditItem(KhuyenMai);
            }
            return Ok();
        }
        [HttpPut("EditNoiImage")]
        public async Task<IActionResult> EditKhuyenMai(string id, string Ten, DateTime ngayBD, DateTime ngayKT, int trangThai, decimal mucGiam, int loaiHinh)
        {
                var KhuyenMai = await context.khuyenMais.FindAsync(id);
                KhuyenMai.TenKhuyenMai = Ten;
                KhuyenMai.TrangThai = trangThai;
                KhuyenMai.NgayBatDau = ngayBD;
                KhuyenMai.NgayKetThuc = ngayKT;
                KhuyenMai.MucGiam = mucGiam;
                KhuyenMai.LoaiHinhKM = loaiHinh;
                repos.EditItem(KhuyenMai);
            return Ok();
        }

        [HttpDelete("{id}")]
        public bool DeleteKhuyenMai(string id)
        {
            var KhuyenMai = repos.GetAll().First(p => p.IdKhuyenMai == id);
            return repos.RemoveItem(KhuyenMai);
        }
    }
}
