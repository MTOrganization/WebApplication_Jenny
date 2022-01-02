using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication_Jenny.Interfaces;

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
    }
}