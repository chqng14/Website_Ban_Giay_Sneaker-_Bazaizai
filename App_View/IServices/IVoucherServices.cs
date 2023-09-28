﻿using App_Data.Models;
using App_Data.ViewModels.Voucher;

namespace App_View.IServices
{
    public interface IVoucherServices
    {
        Task<List<Voucher>> GetAllVoucher();
        Task<bool> CreateVoucher(VoucherDTO voucherDTO);
        Task<bool> UpdateVoucher(VoucherDTO voucherDTO);
        Task<bool> DeleteVoucher(string id);
        Task<Voucher> GetVoucherById(string id);
    }
}