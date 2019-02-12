using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace LeadCoreAreas.Areas.Models
{
    public class CommonResponse
    {
        protected internal HttpContext Current => new HttpContextAccessor().HttpContext;
      
        public CommonResponse(int status,string message, object data=null)
        {
            
            this.Status = status;
            this.Message = message;
            this.Data = data;
            

        }
        public int Total { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }

    public class PagingFilter
    {
        public string Query { get; set; }
        public int? ID { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string OrderByDirection { get; set; } 
        public string OrderBy { get; set; }
    }

}
