using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DAO
{
    public interface IProductDAO
    {
        List<Product> GetProduct(string name);
        Product GetProductbyId (int id);
        List<Product> ProductDelete(int id);
        int ProductUpdate(Product product); // HÀm NÀy NÓ CHỈ TRẢ VỀ SỐ DÒng THAY ĐỔi CHỨ KHONG TRẢ VỀ ojBECT PRODUCT
        int ProductAdd(Product product);

    }
}
