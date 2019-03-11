using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MunicipalitiesTax.Api.Middlewares.Response;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MunicipalitiesTax.Api.Middlewares
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;

        public ApiExceptionMiddleware(RequestDelegate next, IHostingEnvironment env)
        {
            _next = next;
            _env = env;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = new ExceptionResponse(_env.IsDevelopment());
                response.Message = ex.Message;

                if (response.IsDevelopment)
                {
                    response.StackTrace = ex.StackTrace;
                }

                var json = JsonConvert.SerializeObject(response);

                using (var streamWriter = new StreamWriter(context.Response.Body))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
            }
        }
    }
}
