using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication_Jenny.Interfaces;
using WebApplication_Jenny.Models;

namespace WebApplication_Jenny.Repositories
{
    public class NorthwindDapper
    {
        private readonly static string _connectionString = ConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString;
        public IEnumerable<T> GetAll<T>() where T : ITable
        {
            var type = typeof(T);
            string sql = $"SELECT * FROM [{type.Name}]";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var targetList = conn.Query<T>(sql);
                return targetList;
            }
        }

        public Products GetProductById(int Id)
        {
            string sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var targetList = conn.QueryFirstOrDefault<Products>(sql, new { ProductID = Id });
                return targetList;
            }
        }

        //public int ModifyProductUnitPrice()
        //{

        //}

        public int DeleteProductById(int Id)
        {
            string sql = "DELETE FROM Products WHERE ProductID = @ProductID";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var dataRow = conn.Execute(sql, new { ProductID = Id });
                return dataRow;
            }
        }
    }
}