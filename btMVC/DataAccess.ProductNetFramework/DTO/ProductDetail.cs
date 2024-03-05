using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DTO
{
    public class ProductDetail
    {
       public int ProductDetailId {get; set;} 
       public int ProductId {get; set;}
       public string Description {get; set;} 
       public DateTime CreateDate {get; set;}
    }
}
