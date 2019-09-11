using System;

namespace WebApiDemo_5Sept19
{
    public class Log
    {
        public Log(object request, object response)
        {
            Time = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            Request = request;
            Response = response;
        }

        public string Time { get; set; }
        //public string Status { get; set; }
        //public string Type { get; set; }

        public object Request { get; set; }

        public object Response { get; set; }
    }


}
