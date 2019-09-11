using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo_5Sept19
{
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

                var Logger = LoggerFactory.GetLoggingSystem("json");
                if (Logger != null)
                    Logger.WriteLog(new Log(request, response));

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);

            var bodyText = Encoding.UTF8.GetString(buffer); ;
            request.Body.Position = 0;

            return $"REQUEST METHOD: {request.Method}, REQUEST BODY: {bodyText}, REQUEST URL: {request.Path}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {

            response.Body.Seek(0, SeekOrigin.Begin);


            string text = await new StreamReader(response.Body).ReadToEndAsync();


            response.Body.Seek(0, SeekOrigin.Begin);


            return $"RESPONSE STATUSCODE: {response.StatusCode}, RESPONSE BODY: {text}";
        }
    }


}
