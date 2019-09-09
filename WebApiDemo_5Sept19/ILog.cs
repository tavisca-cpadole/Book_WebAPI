using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo_5Sept19
{
    public class Log
    {
        public Log(object request, object response)
        {
            Time = DateTime.Now.ToString();
            Request = request;
            Response = response;
        }

        public string Time { get; set; }
        //public string Status { get; set; }
        //public string Type { get; set; }

        public object Request { get; set; }

        public object Response { get; set; }
    }
    public static class JsonFileLogger
    {
        public static void WriteLog(Log log)
        {
            string path = "./Log/Log.json";
            string json = File.ReadAllText(path);
            List<Log> logs = JsonConvert.DeserializeObject<List<Log>>(json);
            logs.Add(log);
            string newJson = JsonConvert.SerializeObject(logs);
            File.WriteAllText(path, newJson);
        }
    }

    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var request = await FormatRequest(context.Request);


            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {

                context.Response.Body = responseBody;


                await _next(context);


                var response = await FormatResponse(context.Response);


                JsonFileLogger.WriteLog(new Log(request, response));


                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;


            request.EnableRewind();


            var buffer = new byte[Convert.ToInt32(request.ContentLength)];


            await request.Body.ReadAsync(buffer, 0, buffer.Length);


            var bodyAsText = Encoding.UTF8.GetString(buffer);


            request.Body = body;

            return $"REQUEST METHOD: {request.Method}, REQUEST BODY: {request.Query}, REQUEST URL: {request.Path}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {

            response.Body.Seek(0, SeekOrigin.Begin);


            string text = await new StreamReader(response.Body).ReadToEndAsync();


            response.Body.Seek(0, SeekOrigin.Begin);


            return $"{response.StatusCode}: {text}";
        }
    }

    //public class ValidatorActionFilter : IActionFilter
    //{
    //    public void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        if (!filterContext.ModelState.IsValid)
    //        {
    //            filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
    //        }
    //    }

    //    public void OnActionExecuted(ActionExecutedContext filterContext)
    //    {

    //    }
    //}

}
