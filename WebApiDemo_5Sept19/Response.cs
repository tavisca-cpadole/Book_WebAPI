using System.Collections.Generic;
using WebApiDemo_5Sept19.Model;
namespace WebApiDemo_5Sept19
{
    public class Response
    {
        public List<Book> Books { get; set; }
        public List<string> ServerMessage { get; set; }

        public Response(List<Book> books, List<string> serverMessage)
        {
            Books = books;
            ServerMessage = serverMessage;
        }
    }
}
