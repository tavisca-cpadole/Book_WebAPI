using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19
{
    public interface IBook
    {
        Response get(int id);
        Response put(Book book);
        Response delete(int id);
        Response post(Book book);

        Response get();
    }
}
