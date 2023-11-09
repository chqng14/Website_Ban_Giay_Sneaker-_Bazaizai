﻿using App_Data.Models;
using App_Data.Repositories;
using App_Data.ViewModels.DanhGia;
using App_Data.ViewModels.HoaDon;
using App_Data.ViewModels.Voucher;
using App_View.IServices;
using Newtonsoft.Json;
using OpenXmlPowerTools;
using System.Net.Http;

namespace App_View.Services
{
    public class DanhGiaService : IDanhGiaService
    {
        private readonly HttpClient _httpClient;
        public DanhGiaService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> CreateDanhGia(DanhGia danhGia)
        {
            try
            {
                string apiUrl = $"https://localhost:7038/api/DanhGia/AddDanhGia?BinhLuan={Uri.EscapeDataString(danhGia.BinhLuan)}&ParentId={danhGia.ParentId}&SaoSp={danhGia.SaoSp}&SaoVanChuyen={danhGia.SaoVanChuyen}&IdNguoiDung={danhGia.IdNguoiDung}&IdSanPhamChiTiet={danhGia.IdSanPhamChiTiet}";
                var response = await _httpClient.PostAsync(apiUrl, null);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {                  
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }


        public async Task<bool> DeleteDanhGia(string id)
        {
            string apiUrl = $"https://localhost:7038/api/DanhGia/XoaDanhGia/{id}";
            try
            {
                var response = await _httpClient.DeleteAsync(apiUrl);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
       
       
        public async Task<List<DanhGia>> GetAllDanhGia()
        {
            string apiUrl = "https://localhost:7038/api/DanhGia/GetAllDanhGia";

            try
            {
                var apiData = await _httpClient.GetStringAsync(apiUrl);
                return JsonConvert.DeserializeObject<List<DanhGia>>(apiData);
            }
            catch (HttpRequestException)
            {
                return new List<DanhGia>();
            }
        }

        public async Task<List<DanhGiaViewModel>> GetListAsyncViewModel(string Idchitietsp)
        {
            string apiUrl = $"https://localhost:7038/api/DanhGia/GetDanhGiaViewModel?idspchitiet={Idchitietsp}";

            try
            {
                var apiData = await _httpClient.GetStringAsync(apiUrl);
                return JsonConvert.DeserializeObject<List<DanhGiaViewModel>>(apiData);
            }
            catch (HttpRequestException)
            {
                return new List<DanhGiaViewModel>();
            }
        }


        public async Task<DanhGia> GetDanhGiaById(string id)
        {     
            string apiUrl = $"https://localhost:7038/api/DanhGia/GetDanhGiaById/{id}";
            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string apiData = await response.Content.ReadAsStringAsync();
                    var danhGia = JsonConvert.DeserializeObject<DanhGia>(apiData);
                    return danhGia;
                }
                else
                {              
                    return null;
                }
            }
            catch (HttpRequestException)
            {       
                return null;
            }
        }


        public async Task<bool> UpdateDanhGia(DanhGia danhGia)
        {
            try
            {
                string apiUrl = $"https://localhost:7038/api/DanhGia/ChinhSuaDanhGia?IdDanhGia={danhGia.IdDanhGia}&BinhLuan={danhGia.BinhLuan}&SaoSp={danhGia.SaoSp}&SaoVanChuyen={danhGia.SaoVanChuyen}&IdNguoiDung={danhGia.IdNguoiDung}&IdSanPhamChiTiet={danhGia.IdSanPhamChiTiet}";

                var content = new StringContent(string.Empty);

                var response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }



    }
}