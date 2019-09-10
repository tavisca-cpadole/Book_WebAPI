using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19
{
    public interface IBook
    {
        Response Get(int id);
        Response Put(Book book);
        Response Delete(int id);
        Response Post(Book book);


        Response Get();
    }
}
