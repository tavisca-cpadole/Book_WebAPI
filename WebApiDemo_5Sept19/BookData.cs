using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WebApiDemo_5Sept19.Controllers;
using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19
{
    public class BookData : IBook
    {
        List<Book> bookList = new List<Book>();
        int code = 200;
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

        public Response GetResponse(List<Book> books = null, int statusCode = 200)
        {
            //if (books != null)
            //    return new Response(books, serverMessageList);
            return new Response(books, serverMessageList, statusCode);
        }
        public Response Delete(int id)
        {
            if (bookList.Count == 0)
                return GetResponse(null, (int)HttpStatusCode.INTERNAL_SERVER_ERROR);
            for (int i = 0; i < bookList.Count; i++)
                if (bookList[i].id == id)
                {
                    bookList.Remove(bookList[i]);
                    SaveJson();
                    serverMessageList.Add("Item Deleted");
                }
            if (serverMessageList.Count == 0)
            {
                serverMessageList.Add("Item Not Found");
                code = (int)HttpStatusCode.NOT_FOUND;
            }

            return GetResponse(bookList, code);
        }

        public Response Get(int id)
        {
            if (bookList.Count == 0)
                return GetResponse(null, (int)HttpStatusCode.INTERNAL_SERVER_ERROR);

            List<Book> output = new List<Book>();
            foreach (var item in bookList)
                if (item.id == id)
                {
                    output.Add(item);
                    serverMessageList.Add(item.name);
                    break;
                }
            if (serverMessageList.Count == 0)
            {
                code = (int)HttpStatusCode.NOT_FOUND;
                serverMessageList.Add("Item Not Found");
            }

            return GetResponse(output, code);
        }

        public Response Post(Book book)
        {
            if (bookList.Count == 0)
                return GetResponse(null, (int)HttpStatusCode.INTERNAL_SERVER_ERROR);

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
                return GetResponse(bookList, (int)HttpStatusCode.CREATED);
            }
            else
            {
                code = (int)HttpStatusCode.BAD_REQUEST;
                serverMessageList.Add("Data redundant");
            }
            return GetResponse(null, code);
        }

        public Response Put(Book book)
        {
            if (bookList.Count == 0)
                return GetResponse(null, (int)HttpStatusCode.INTERNAL_SERVER_ERROR);
            // bookList = bookList.Where(b => b.id == id)?.Select(b => { b = book; return b; }).ToList() ?? bookList;
            List<Book> output = new List<Book>();
            for (int i = 0; i < bookList.Count; i++)
                if (bookList[i].id == book.id)
                {
                    bookList[i].author = book.author;
                    bookList[i].category = book.category;
                    bookList[i].price = book.price;
                    bookList[i].name = book.name;
                    SaveJson();
                    output.Add(book);
                    serverMessageList.Add("Updated");
                    break;
                }
            if (serverMessageList.Count == 0)
            {
                code = (int)HttpStatusCode.BAD_REQUEST;
                serverMessageList.Add("Invalid Id");
            }

            return GetResponse(output, code);

        }

        public Response Get()
        {
            if (bookList.Count == 0)
                return GetResponse(null, (int)HttpStatusCode.INTERNAL_SERVER_ERROR);
            return GetResponse(bookList);
        }

        public void SaveJson()
        {
            string json = JsonConvert.SerializeObject(bookList.ToArray());

            File.WriteAllText(@"C:\Users\cpadole\source\repos\WebApiDemo_5Sept19\WebApiDemo_5Sept19\Data\BookData.json", json);
        }

        public Response GetWithCategory(string name)
        {
            if (bookList.Count == 0)
                return GetResponse(null, (int)HttpStatusCode.INTERNAL_SERVER_ERROR);

            List<Book> output = new List<Book>();
            for (int i = 0; i < bookList.Count; i++)
                if (bookList[i].category.ToLowerInvariant() == name.ToLowerInvariant())
                {
                    output.Add(bookList[i]);
                    serverMessageList.Add($"List Of Books belonging to Category {name}");
                    break;
                }
            if (serverMessageList.Count == 0)
            {
                code = (int)HttpStatusCode.BAD_REQUEST;
                serverMessageList.Add("No Books With Such Category Exists");
            }

            return GetResponse(output, code);
        }
    }


}
