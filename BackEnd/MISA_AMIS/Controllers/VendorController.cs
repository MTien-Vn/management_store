using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.BL.Interface.IService;
using Misa.BL.Interface.IService.IVendorService;
using MISA.BL.ServiceRes;
using NMT.Model.Entity;
using NMT.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseEntityController<Vendor>
    {
        IVendorService vendorService;
        public VendorController(IVendorService _vendorService) : base(_vendorService)
        {
            this.vendorService = _vendorService;
        }
        
    }
}
