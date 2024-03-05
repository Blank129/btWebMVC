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
    public class ProductDAOImpl : IProductDAO
    {
        public List<Product> GetProduct(string productName)
        {
            var list = new List<Product>();
            try
            {
                var conn = DBConnection.GetSqlConnection();
                var cmd = new SqlCommand("Product_GetList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_ProductName", productName);
                var sqlDataReader = cmd.ExecuteReader();
                list = DataReaderMapToList<Product>(sqlDataReader).ToList();
                conn.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }

        public Product GetProductbyId(int id)
        {
            var list = new List<Product>();
            var conn = DBConnection.GetSqlConnection();
            var cmd = new SqlCommand("Product_GetById", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ProductId", id);
            var sqlDataReader = cmd.ExecuteReader();
            list = DataReaderMapToList<Product>(sqlDataReader).ToList();
            var product = list.Where(s => s.ProductId == id).FirstOrDefault();
            conn.Close();
            return product;
        
        }      

        public List<Product> ProductDelete(int id)
        {
            // id ở đây đang =0 do bên ngoài truyền sai nên chỗ này ko nhận được dữ liệu
            var list = new List<Product>();
            var conn = DBConnection.GetSqlConnection();
            var cmd = new SqlCommand("SP_Product_Delete", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", id);
            var sqlDataReader = cmd.ExecuteNonQuery();
            conn.Close();
            return list;

        }

        public int ProductUpdate(Product product)
        {
            try
            {
                var conn = DBConnection.GetSqlConnection();
                var cmd = new SqlCommand("SP_Product_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductType", product.ProductType);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                var rowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return rowAffect;


            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public int ProductAdd(Product product)
        {
            try
            {
                var conn = DBConnection.GetSqlConnection();
                var cmd = new SqlCommand("SP_Product_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductType", product.ProductType);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                var rowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return rowAffect;
            }
            catch (Exception ex)
            {

                throw;
            }
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
