﻿using App_Data.Models;
using App_Data.ViewModels.VoucherNguoiDung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.IRepositories
{
    public interface IVoucherNguoiDungRepos
    {
        Task<bool> TangVoucherNguoiDung(AddVoucherRequestDTO addVoucherRequestDTO);
    }
}