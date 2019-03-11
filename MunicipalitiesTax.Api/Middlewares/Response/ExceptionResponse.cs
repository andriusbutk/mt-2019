using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalitiesTax.Api.Middlewares.Response
{
    public class ExceptionResponse
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }

        public bool IsDevelopment { get; set; }

        public DateTime Date { get; set; }

        public string InternalServerErrorMessage => !IsDevelopment ? "Server error :( ." : string.Empty;

        public ExceptionResponse(bool isDevelopment)
        {
            IsDevelopment = isDevelopment;
            Date = DateTime.UtcNow;
        }
    }
}
