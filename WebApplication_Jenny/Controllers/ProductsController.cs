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

        /// <summary>
        /// 取得商品資訊
        /// </summary>
        /// <param name="id">以Id搜尋商品。若不提供Id，則可取回所有商品資訊</param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetProduct(int? id = null)
        {
            var response = new ApiResponse();
            try
            {
                if(id == null)
                {
                    response.Data = _productService.GetAllProduct();
                }
                else
                {
                    response.Data = _productService.GetProductById(id.Value);
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

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="value">依照格式填寫</param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse CreateProduct([FromBody]PostOrPutProductViewModel value)
        {
            var response = new ApiResponse();
            try
            {
                _productService.CreateProduct(value);
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

        /// <summary>
        /// 修改商品資訊
        /// </summary>
        /// <param name="value">依照格式填寫</param>
        /// <returns></returns>
        [HttpPut]
        public ApiResponse UpdateProduct([FromBody]ProductViewModel value)
        {
            var response = new ApiResponse();
            try
            {
                _productService.UpdateProduct(value);
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

        /// <summary>
        /// 刪除商品
        /// </summary>
        /// <param name="id">以Id刪除商品</param>
        /// <returns></returns>
        [HttpDelete]
        public ApiResponse DeleteProductById(int id)
        {
            var response = new ApiResponse();
            try
            {
                response.Message = $"成功，共影響{_productService.DeleteProductById(id)}筆資料列";
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
