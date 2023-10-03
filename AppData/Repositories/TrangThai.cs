﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Repositories
{
    public class TrangThai
    {
        //Trạng thái bảng phụ
        public enum TrangThaiCoBan
        {
            [Description("Hoạt động")]
            HoatDong = 0,
            [Description("Không hoạt động")]
            KhongHoatDong = 1,
        }
        public enum TrangThaiVoucher
        {
            [Description("Hoạt động")]
            HoatDong = 0,
            [Description("Không hoạt động")]
            KhongHoatDong = 1,
        }
        public enum TrangThaiHoaDon
        {
            [Description("Chưa thanh toán")]
            ChuaThanhToan = 0,
            [Description("Đã thanh toán")]
            DaThanhToan = 1,
            [Description("Hủy")]
            Huy = 2,
        }
        public enum TrangThaiGiaHang
        {
            [Description("Tại quầy")]
            TaiQuay = 0,
            
        }

    }
}
