﻿using Microsoft.AspNetCore.Mvc;
using Misa.BL.Interface.IService;
using MISA.BL.ServiceRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        IBaseService<T> baseService;
        public BaseEntityController(IBaseService<T> _baseService)
        {
            this.baseService = _baseService;
        }
        /// <summary>
        /// api lấy dữ liệu phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách</returns>
        /// created: Manh Tien(22/2/2021)
        // GET: api/<BaseController>
        [HttpGet("{page}/{limmit}")]
        public ServiceResponse Get(long page = 1, long limmit = 10)
        {
            return baseService.GetEntity(page, limmit);
        }

        /// <summary>
        /// api lấy toàn bộ danh sách
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách</returns>
        /// created: Manh Tien(22/2/2021)
        [HttpGet]
        public ServiceResponse GetAll(long page = 1, long limmit = 10)
        {
            return baseService.GetEntity(page, limmit);
        }

        /// <summary>
        /// api lấy đối tượng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpGet("{id}")]
        public ServiceResponse GetEntityById(string id)
        {
            return baseService.GetEntityById(id);
        }

        /// <summary>
        /// api lấy số lượng của đói tượng trong db
        /// </summary>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpGet("numberEntity")]
        public ServiceResponse NumberEntity()
        {
            return baseService.CountEntity();
        }

        // POST api/<BaseController>
        /// <summary>
        /// api lưu đối tương
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>service result </returns>
        /// created: Manh Tien(22/2/2021)
        [HttpPost]
        public ServiceResponse Post([FromBody] T entity)
        {
            return baseService.InsertT(entity);
        }

        // PUT api/<BaseController>/5
        /// <summary>
        /// api cập nhật đối tượng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpPut("{id}")]
        public ServiceResponse Put(string id, [FromBody] T entity)
        {
            return baseService.UpdateT(entity, id);
        }

    }
}
