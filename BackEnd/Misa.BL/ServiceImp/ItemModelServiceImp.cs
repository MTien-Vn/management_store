﻿using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Properties;
using MISA.BL.ServiceRes;
using NMT.Enum.Enum;
using NMT.Model.Entity;
using NMT.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misa.BL.ServiceImp
{
    public class ItemModelServiceImp : BaseServiceImp<Item>, IItemModelService
    {
        IItemModelRepository itemRepository;
        public ItemModelServiceImp(IItemModelRepository _itemRepository) : base(_itemRepository)
        {
            itemRepository = _itemRepository;
        }

        public ServiceResponse SaveItemModel(ItemModel itemModel)
        {
            //List<Vendor> vendors = itemModel.vendors;
            //Item item = itemModel.item;

            //ServiceResponse sr = new ServiceResponse();

            //if (item.item_id == "" || item.item_id == null)
            //{
            //    var serResultItem = this.InsertT(item);
            //    if (serResultItem.MisaCode == MyEnum.Scuccess)
            //    {
            //        sr.MisaCode = MyEnum.Scuccess;

            //        var itemResult = serResultItem.Data as Item;

            //        //lưu vào bảng vendor_item
            //        var vendorItem = new Vendor_invoice();
            //        vendorItem.item_id = itemResult.item_id;

            //        var vendorIdErrors = new List<string>();

            //        foreach (var vendor in vendors)
            //        {
            //            vendorItem.vendor_id = vendor.vendor_id;
            //            var rs = vendorItemService.InsertT(vendorItem);
            //            if (rs.MisaCode == MyEnum.False)
            //            {
            //                vendorIdErrors.Add(item.item_id);
            //            }
            //        }
            //        if (vendorIdErrors.Any())
            //        {
            //            sr.Messenger.Add(Resources.Error_Insert_Vendor_Item);
            //            sr.Data = vendorIdErrors;
            //        }
            //    }
            //    else
            //    {
            //        sr.MisaCode = MyEnum.False;
            //        sr.Messenger.Add(Resources.False);
            //    }
            //    return sr;
            //}
            //else
            //{
            //    var serResultItem = this.UpdateT(item, item.item_id.ToString());
            //    return serResultItem;
            //}
            return null;
        }
    }
}
