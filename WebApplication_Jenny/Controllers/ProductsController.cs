using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication_Jenny.Services;
using WebApplication_Jenny.ViewModels;

namespace WebApplication_Jenny.Controllers
{
    [RoutePrefix("[controller]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private readonly ProductService _productService;
        public ProductsController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        public ApiResponse GetAllProducts()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _productService.GetAllProduct();
                response.Message = "成功";
                response.ApiStatus = (int)ApiStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = $"錯誤：{ex.Message}";
                response.ApiStatus = (int)ApiStatus.Fail;
            }

            return response;
        }

        [HttpGet]
        public ApiResponse GetProductById(int Id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = null;
                response.Message = "成功";
                response.ApiStatus = (int)ApiStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = $"錯誤：{ex.Message}";
                response.ApiStatus = (int)ApiStatus.Fail;
            }

            return response;
        }

        [HttpPost]
        public ApiResponse CreateProduct()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = null;
                response.Message = "成功";
                response.ApiStatus = (int)ApiStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = $"錯誤：{ex.Message}";
                response.ApiStatus = (int)ApiStatus.Fail;
            }

            return response;
        }

        [HttpPatch]
        public ApiResponse ModifyProductById(int Id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = null;
                response.Message = "成功";
                response.ApiStatus = (int)ApiStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = $"錯誤：{ex.Message}";
                response.ApiStatus = (int)ApiStatus.Fail;
            }

            return response;
        }

        [HttpDelete]
        public ApiResponse DeleteProductById(int Id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = null;
                response.Message = "成功";
                response.ApiStatus = (int)ApiStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = $"錯誤：{ex.Message}";
                response.ApiStatus = (int)ApiStatus.Fail;
            }

            return response;
        }
    }
}
