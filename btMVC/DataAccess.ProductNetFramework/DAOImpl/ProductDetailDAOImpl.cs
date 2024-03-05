using DataAccess.ProductNetFramework.DAO;
using DataAccess.ProductNetFramework.DBHelper;
using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DAOImpl
{
    public class ProductDetailDAOImpl : IProductDetailDAO
    {
        public List<ProductDetail> GetProductDetailById(int ProductId)
        {
            var list = new List<ProductDetail>();
            try
            {
                var conn = DBConnection.GetSqlConnection();
                var cmd = new SqlCommand("ProductDetail_GetById",conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                var sqlDataReader = cmd.ExecuteReader();
                list = DataReaderMapToList<ProductDetail>(sqlDataReader).ToList();
                conn.Close();
            }
            catch (Exception  ex)
            {

                throw;
            }
            return list;
        }
        public List<T> DataReaderMapToList<T>(SqlDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
