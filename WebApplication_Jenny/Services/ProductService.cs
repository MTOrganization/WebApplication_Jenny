using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication_Jenny.Models;
using WebApplication_Jenny.Repositories;

namespace WebApplication_Jenny.Services
{
    public class ProductService
    {
        private readonly NorthwindDapper _dapper;
        public ProductService()
        {
            _dapper = new NorthwindDapper();
        }
        public IEnumerable<Product> GetAllProduct()
        {
            return _dapper.GetAll<Product>();
        }
    }
}