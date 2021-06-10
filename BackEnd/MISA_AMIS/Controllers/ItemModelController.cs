using Microsoft.AspNetCore.Mvc;
using Misa.BL.Interface.IService;
using MISA.BL.ServiceRes;
using NMT.Model.Entity;
using NMT.Model.Model;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemModelController : BaseEntityController<Item>
    {
        readonly IItemModelService itemService;
        public ItemModelController(IItemModelService _itemService) : base(_itemService)
        {
            this.itemService = _itemService;
        }

        [HttpPost("postItemModel")]
        public ServiceResponse PostItemModel(ItemModel itemModel)
        {
            return itemService.SaveItemModel(itemModel);
        }
    }
}
