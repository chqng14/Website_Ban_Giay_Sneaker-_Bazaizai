﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class NguoiDung
    {
        public string IdNguoiDung { get; set; }
        public string IdChucVu { get; set; }
        public string MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string SDT { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string AnhDaiDien { get; set; }
        public int TrangThai { get; set; }
        public virtual List<VoucherNguoiDung> VoucherNguoiDungs { get; set; }
        public virtual List<ChucVu> ChucVu
        { get; set; }
        public virtual IEnumerable<ThongTinGiaoHang> ThongTinGiaoHangs { get; set; }
        public virtual List<SanPhamYeuThich> SanPhamYeuThich { get; set; }
    }
}
