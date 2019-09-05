using System.Collections.Generic;
using WebApiDemo_5Sept19.Model;
namespace WebApiDemo_5Sept19
{
    public class BookService : IBook
    {
        List<string> serverMessageList = new List<string>();

        public Response GetResponse()
        {
            return new Response(null, serverMessageList);
        }
        public Response delete(int id)
        {
            if (id.IntNegativeCheck())
                return new BookData().delete(id);

            serverMessageList.Add("Invalid Id, Id should be a positive number");
            return GetResponse();
        }

        public Response get(int id)
        {
            if (id.IntNegativeCheck())
                return new BookData().get(id);

            serverMessageList.Add("Invalid Id, Id should be a positive number");
            return GetResponse();
        }

        public Response get()
        {
            return new BookData().get();
        }

        public Response post(Book book)
        {
            if (book.BookObjectValidation())
                return new BookData().post(book);
            serverMessageList.Add("Invalid Data is passed");
            return GetResponse();
        }

        public Response put(Book book)
        {
            if (book.BookObjectValidation())
                return new BookData().put(book);
            serverMessageList.Add("Invalid Data is passed");
            return GetResponse();
        }
    }
}
