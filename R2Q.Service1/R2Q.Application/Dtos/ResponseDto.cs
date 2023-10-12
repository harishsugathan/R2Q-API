using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Application.Dtos
{
    public class ResponseDto<TValue>
    {
        public HttpStatusCode ResponseCode { get; set; }
        public bool IsError { get; set; } = false;
        public string[] ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public TValue Content { get; set; }
    }
}
