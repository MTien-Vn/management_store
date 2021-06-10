using Dapper;
using Misa.BL.Interface.IDBConnector;
using Misa.BL.Interface.IRepository.IVendorRepository;
using NMT.Model.Entity;
using System.Data;

namespace Misa.DL.RepositoryImp.VendorRepositoryImp
{
    public class VendorRepositoryImp : BaseRepositoryImp<Vendor>, IVendorRepository
    {
        public VendorRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
