using Misa.BL.Interface.IDBConnector;
using Misa.BL.Interface.IRepository;
using NMT.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.DL.RepositoryImp
{
    public class ItemModelRepositoryImp : BaseRepositoryImp<Item>, IItemModelRepository
    {
        public ItemModelRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
