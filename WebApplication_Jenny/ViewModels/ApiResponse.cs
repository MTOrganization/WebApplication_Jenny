using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Jenny.ViewModels
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public int ApiStatus { get; set; }
    }
    public enum ApiStatus
    {
        Fail = 0,
        Success = 1
    }
}