﻿
using Misa.BL.Interface.IRepository;
using MISA.BL.ServiceRes;
using NMT.Enum.Enum;
using NMT.Utils;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.ValidateData
{
    /// <summary>
    /// xác minh thôn tin trước khi lưu hoặc cập nhật
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// createdBy: Mạnh Tiến(27/12/2020)
    public class ValidateObj<T>
    {
        IBaseRepository<T> _baseRepository;
        public ValidateObj(IBaseRepository<T> repo)
        {
            _baseRepository = repo;
        }

        /// <summary>
        /// xác minh thôn tin trước khi lưu hoặc cập nhật
        /// </summary>
        /// <param name="model"></param>
        /// <returns>trả về kiểu serviceResult</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        public ServiceResponse ValidateObject(T model, string id)
        {
            int flag = 0;
            var serviceResultInvalid = new ServiceResponse();
            var serviceResultOk = new ServiceResponse();
            var properties = typeof(T).GetProperties();

            List<PropertyInfo> propCheckDupPair = new List<PropertyInfo>();
            List<object> valueCheckDupPair = new List<object>();

            StringBuilder sqlCheckDupPair = new StringBuilder(10);
            sqlCheckDupPair.Append($"SELECT ");

            foreach (var property in properties)
            {
                var propertyName = property.Name.ToLower();
                var propertyValue = property.GetValue(model);
                if(property.IsDefined(typeof(Required), true) && (propertyValue == null || propertyValue.ToString() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if(requiredAttribute != null)
                    {
                        var proName = (requiredAttribute as Required).PropertyName;
                        var errorMess = (requiredAttribute as Required).ErrorMesseger;
                        serviceResultInvalid.Messenger.Add(errorMess == null ? $"{proName} không được trống" : errorMess);
                    }
                    serviceResultInvalid.MisaCode = MyEnum.Invalid;
                    flag++;
                }

                if(property.IsDefined(typeof(CheckDup), true))
                {
                    string sql = $"SELECT {propertyName} FROM {typeof(T).Name.ToLower()} WHERE {propertyName}='{propertyValue}'";
                    string sql2 = $"SELECT {propertyName} FROM {typeof(T).Name.ToLower()} WHERE {propertyName}='{propertyValue}' AND {typeof(T).Name.ToLower()}_id='{id}'";
                    //id == null-thêm mới   id != null-cập nhật
                    if(id == null)
                    {
                        var entity = _baseRepository.GEtDataBySQL(sql).FirstOrDefault();
                        if (entity != null)
                        {
                            var checkDupAttribute = property.GetCustomAttributes(typeof(CheckDup), true).FirstOrDefault();
                            var proName = (checkDupAttribute as CheckDup).PropertyName;
                            var errorMess = (checkDupAttribute as CheckDup).ErrorMesseger;
                            serviceResultInvalid.Messenger.Add(errorMess == null ? $"{proName} đã tồn tại" : errorMess);
                            serviceResultInvalid.MisaCode = MyEnum.Invalid;
                            flag++;
                        }
                    }
                    else
                    {
                        var entity = _baseRepository.GEtDataBySQL(sql).FirstOrDefault();
                        var entity2 = _baseRepository.GEtDataBySQL(sql2).FirstOrDefault();
                        if (entity2 == null  && entity != null)
                        {
                            var checkDupAttribute = property.GetCustomAttributes(typeof(CheckDup), true).FirstOrDefault();
                            var proName = (checkDupAttribute as CheckDup).PropertyName;
                            var errorMess = (checkDupAttribute as CheckDup).ErrorMesseger;
                            serviceResultInvalid.Messenger.Add(errorMess == null ? $"{proName} đã tồn tại" : errorMess);
                            serviceResultInvalid.MisaCode = MyEnum.Invalid;
                            flag++;
                        }
                    }
                }
                if(property.IsDefined(typeof(CheckDupPair), true))
                {
                    valueCheckDupPair.Add(propertyValue);
                    propCheckDupPair.Add(property);
                }
            }
            if(propCheckDupPair.Any())
            {
                //build câu sql 
                foreach (var propertyName in propCheckDupPair)
                {
                    sqlCheckDupPair.Append(propertyName);
                    sqlCheckDupPair.Append(' ');
                }
                sqlCheckDupPair.Append($"FROM {typeof(T).Name.ToLower()} WHERE ");
                for (int i = 0; i < sqlCheckDupPair.Length; i++)
                {
                    if (i != 0)
                    {
                        sqlCheckDupPair.Append(" AND ");
                    }
                    sqlCheckDupPair.Append(propCheckDupPair.ElementAt(i));
                    sqlCheckDupPair.Append("='");
                    sqlCheckDupPair.Append(valueCheckDupPair.ElementAt(i));
                    sqlCheckDupPair.Append("'");

                }
                var entity = _baseRepository.GEtDataBySQL(sqlCheckDupPair.ToString()).FirstOrDefault();
                if(entity != null)
                {
                    flag++;
                    var checkDupAttribute = propCheckDupPair[0].GetCustomAttributes(typeof(CheckDupPair), true).FirstOrDefault();
                    var errorMess = (checkDupAttribute as CheckDupPair).ErrorMesseger;
                    serviceResultInvalid.MisaCode = MyEnum.Invalid;
                    serviceResultInvalid.Messenger.Add(errorMess);
                }
            }
            if(flag == 0)
            {
                serviceResultOk.Messenger.Add(Misa.BL.Properties.Resources.Success);
                serviceResultOk.MisaCode = MyEnum.Scuccess;
                return serviceResultOk;
            }
            return serviceResultInvalid;
        }
    }
}
