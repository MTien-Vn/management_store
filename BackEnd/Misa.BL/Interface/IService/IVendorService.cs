﻿using MISA.BL.ServiceRes;
using NMT.Model.Entity;
using NMT.Model.Model;
using System.Collections.Generic;

namespace Misa.BL.Interface.IService.IVendorService
{
    public interface IVendorService : IBaseService<Vendor>
    {
        #region save vendor
        /// <summary>
        /// lưu thông tin nhà cung cấp ( dùng cho cả save và update)
        /// </summary>
        /// <param name="vendor"></param>
        /// createdBy: ManhTien(22/2/2021)
        /// <returns>đối tượng ServiceResponse</returns>
        //ServiceResponse SaveVendor(VendorModel VendorModel);
        #endregion
        #region get vendor

        /// <summary>
        /// lấy thông tin nhà cung cấp bằng mã nhà cung cấp
        /// </summary>
        /// <param name="code"></param>
        /// <returns>thông tin nhân viên</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        ServiceResponse GetVendorByVendorCode(string code);

        /// <summary>
        /// kiểm tra sự tồn tại của số điện thoại
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        ServiceResponse GetVendorByPhoneNumber(string phoneNumber);

        /// <summary>
        /// kiểm tra sự tồn tại của email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        ServiceResponse GetVendorByEmail(string email);

        /// <summary>
        /// lấy thông tinh nhà cung cấp bằng tên
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách nhân viên</returns>
        /// <returns>thông tin của nhân viên</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        ServiceResponse GetVendorByName(string name, long page, long limmit);
        #endregion

        #region filter vendor
        /// <summary>
        /// lấy danh sách nhà cung cấp bằng từ khóa
        /// </summary>
        ///  <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách các nhân viên</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        ServiceResponse filterVendor(string key, long page, long limmit);
        #endregion

    }
}
