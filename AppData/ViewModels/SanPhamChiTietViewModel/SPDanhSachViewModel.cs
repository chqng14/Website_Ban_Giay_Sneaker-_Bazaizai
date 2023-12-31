﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModels.SanPhamChiTietViewModel
{
    public class SPDanhSachViewModel
    {
        public string? SumGuild { get; set; }
        public string? SanPham { get; set; }
        public string? ThuongHieu { get; set; }
        public string? LoaiGiay { get; set; }
        public string? KieuDeGiay { get; set; }
        public string? XuatXu { get; set; }
        public string? ChatLieu { get; set; }
        public int SoMau { get; set; }
        public int SoSize { get; set; }
        public int TongSoLuongTon { get; set; }
        public double TongSoLuongDaBan { get; set; }
    }
}
