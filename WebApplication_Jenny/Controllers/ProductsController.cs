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
        public ApiResponse GetProduct(int? Id = null)
        {
            var response = new ApiResponse();
            try
            {
                if(Id == null)
                {
                    response.Data = _productService.GetAllProduct();
                }
                else
                {
                    response.Data = _productService.GetProductById(Id.Value);
                }
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
        public ApiResponse CreateProduct([FromBody]PostOrPutProductViewModel productVM)
        {
            var response = new ApiResponse();
            try
            {
                _productService.CreateProduct(productVM);
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

        [HttpPut]
        public ApiResponse UpdateProduct([FromBody]ProductViewModel productVM)
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
                response.Message = $"成功，共影響{_productService.DeleteProductById(Id)}筆資料列";
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
