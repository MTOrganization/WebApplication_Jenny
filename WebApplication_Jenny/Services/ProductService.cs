using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication_Jenny.Models;
using WebApplication_Jenny.Repositories;
using WebApplication_Jenny.ViewModels;

namespace WebApplication_Jenny.Services
{
    public class ProductService
    {
        private readonly NorthwindDapper _dapper;
        public ProductService()
        {
            _dapper = new NorthwindDapper();
        }
        public IEnumerable<ProductViewModel> GetAllProduct()
        {
            var productList =  _dapper.GetAll<Products>();
            var productViewModelList = productList.Select(x => new ProductViewModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                SupplierID = x.SupplierID,
                CategoryID = x.CategoryID,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued
            });
            return productViewModelList;
        }

        public ProductViewModel GetProductById(int Id)
        {
            var product = _dapper.GetProductById(Id);
            var productViewModel = product == null ? null : new ProductViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            };
            return productViewModel;
        }

        public int DeleteProductById(int Id)
        {
            return _dapper.DeleteProductById(Id);
        }
    }
}