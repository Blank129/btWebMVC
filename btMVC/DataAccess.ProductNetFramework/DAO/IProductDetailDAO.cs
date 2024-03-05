using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DAO
{
    public interface IProductDetailDAO
    {
        List<ProductDetail> GetProductDetailById(int ProductId);
    }
}
