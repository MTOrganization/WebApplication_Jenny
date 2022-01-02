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
        private readonly NorthwindRepository _repository;
        public ProductService()
        {
            _dapper = new NorthwindDapper();
            _repository = new NorthwindRepository();
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
            var productVM = product == null ? null : new ProductViewModel
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
            return productVM;
        }

        public void CreateProduct(PostOrPutProductViewModel productVM)
        {
            var product = new Products
            {
                ProductName = productVM.ProductName,
                SupplierID = productVM.SupplierID,
                CategoryID = productVM.CategoryID,
                QuantityPerUnit = productVM.QuantityPerUnit,
                UnitPrice = productVM.UnitPrice,
                UnitsInStock = productVM.UnitsInStock,
                UnitsOnOrder = productVM.UnitsOnOrder,
                ReorderLevel = productVM.ReorderLevel,
                Discontinued = productVM.Discontinued
            };
            _repository.Create(product);
            _repository.SaveChanges();
            _repository.Dispose();
        }

        public void UpdateProduct(ProductViewModel productVM)
        {
            var product = _dapper.GetProductById(productVM.ProductID);
            product.ProductName = productVM.ProductName;
            product.SupplierID = productVM.SupplierID;
            product.CategoryID = productVM.CategoryID;
            product.QuantityPerUnit = productVM.QuantityPerUnit;
            product.UnitPrice = productVM.UnitPrice;
            product.UnitsInStock = productVM.UnitsInStock;
            product.UnitsOnOrder = productVM.UnitsOnOrder;
            product.ReorderLevel = productVM.ReorderLevel;
            product.Discontinued = productVM.Discontinued;
            _repository.Update(product);
            _repository.SaveChanges();
            _repository.Dispose();
        }

        public int DeleteProductById(int Id)
        {
            return _dapper.DeleteProductById(Id);
        }
    }
}