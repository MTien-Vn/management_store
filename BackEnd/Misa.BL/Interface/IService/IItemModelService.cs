using MISA.BL.ServiceRes;
using NMT.Model.Entity;
using NMT.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Interface.IService
{
    public interface IItemModelService : IBaseService<Item>
    {
        /// <summary>
        /// lưu/ update sản phẩm  mới (có thể) kèm theo nhà cung cấp
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        public ServiceResponse SaveItemModel(ItemModel itemModel);
    }
}
