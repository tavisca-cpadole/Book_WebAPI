using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19
{
    public class BookData : IBook
    {
        List<Book> bookList = new List<Book>();

        List<string> serverMessageList = new List<string>();
        public BookData()
        {
            LoadJson();
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\cpadole\source\repos\WebApiDemo_5Sept19\WebApiDemo_5Sept19\Data\BookData.json"))
            {
                string json = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }

        public Response GetResponse(List<Book> books = null)
        {
            if (books != null)
                return new Response(books, serverMessageList);
            return new Response(bookList, serverMessageList);
        }
        public Response delete(int id)
        {
            for (int i = 0; i < bookList.Count; i++)
                if (bookList[i].id == id)
                {
                    bookList.Remove(bookList[i]);
                    SaveJson();
                    serverMessageList.Add("Item Deleted");
                }
            if (serverMessageList.Count == 0)
                serverMessageList.Add("Item Not Found");

            return GetResponse();
        }

        public Response get(int id)
        {
            List<Book> output = new List<Book>();
            foreach (var item in bookList)
                if (item.id == id)
                {
                    output.Add(item);
                    serverMessageList.Add(item.name);
                }
            if (serverMessageList.Count == 0)
                serverMessageList.Add("Item Not Found");

            return GetResponse(output);
        }

        public Response post(Book book)
        {
            bool compare = false;
            foreach (var item in bookList)
            {
                if (item.IsEquals(book))
                {
                    compare = true;
                    break;
                }
            }
            if (!compare)
            {
                bookList.Add(book);
                SaveJson();

                serverMessageList.Add("Book Added");
            }
            else

            {
                serverMessageList.Add("Data redundant");
            }
            return GetResponse();
        }

        public Response put(Book book)
        {
            // bookList = bookList.Where(b => b.id == id)?.Select(b => { b = book; return b; }).ToList() ?? bookList;
            List<Book> output = new List<Book>();
            for (int i = 0; i < bookList.Count; i++)
                if (bookList[i].id == book.id)
                {
                    bookList[book.id].author = book.author;
                    bookList[book.id].category = book.category;
                    bookList[book.id].price = book.price;
                    bookList[book.id].name = book.name;
                    SaveJson();
                    output.Add(book);
                    serverMessageList.Add("Updated");
                }
            if (serverMessageList.Count == 0)
                serverMessageList.Add("Invalid Id");

            return GetResponse(output);

        }

        public Response get()
        {
            return GetResponse();
        }

        public void SaveJson()
        {
            string json = JsonConvert.SerializeObject(bookList.ToArray());

            File.WriteAllText(@"C:\Users\cpadole\source\repos\WebApiDemo_5Sept19\WebApiDemo_5Sept19\Data\BookData.json", json);
        }
    }
}
