using System.Collections.Generic;
using WebApiDemo_5Sept19.Model;
namespace WebApiDemo_5Sept19
{
    public class BookService : IBook
    {
        List<string> serverMessageList = new List<string>();
        int code = 400;
        public Response GetResponse() => new Response(null, serverMessageList, code);
        public Response Delete(int id)
        {
            if (id.IntNegativeCheck())
                return new BookData().Delete(id);

            serverMessageList.Add("Invalid Id, Id should be a positive number");
            return GetResponse();
        }

        public Response Get(int id)
        {
            if (id.IntNegativeCheck())
                return new BookData().Get(id);

            serverMessageList.Add("Invalid Id, Id should be a positive number");
            return GetResponse();
        }

        public Response Get()
        {
            return new BookData().Get();
        }

        public Response Post(Book book)
        {


            return new BookData().Post(book);
        }

        public Response Put(Book book)
        {


            return new BookData().Put(book);
        }


    }
}
