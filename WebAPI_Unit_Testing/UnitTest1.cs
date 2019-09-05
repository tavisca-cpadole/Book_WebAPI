using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WebApiDemo_5Sept19;
using WebApiDemo_5Sept19.Model;
using Xunit;

namespace WebAPI_Unit_Testing
{




    public class GetMethodTest
    {
        List<Book> bookList = new List<Book>();

        [Fact]
        public void Check_If_Complete_Data_Returned_Without_Id()
        {


            List<string> serverMessageList = new List<string>();
            LoadJson();
            var expectedBook = new Response(bookList, serverMessageList);
            var actualBook = new BookService().get();
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        [Fact]
        public void Check_If_Only_Book_Data_Returned_With_Id()
        {
            List<string> serverMessageList = new List<string>();
            List<Book> books = new List<Book>() {
               new Book("Book #1","Neelesh",1,40,"Fiction") };
            LoadJson();

            var expectedBook = new Response(books, serverMessageList);
            var actualBook = new BookService().get(1);
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        [Fact]
        public void Check_If_Negative_Id_Is_Entered()
        {


            List<string> msg = new List<string>()
            {
                "Invalid Id, Id should be a positive number"
            };
            var expectedBook = new Response(bookList, msg);
            var actualBook = new BookService().get();
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        [Fact]
        public void Check_If_No_Data_For_Id_Exists()
        {


            List<string> msg = new List<string>()
            {
                "Item Not Found"
            };
            // LoadJson();
            var expectedBook = new Response(bookList, msg);
            var actualBook = new BookService().get();
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\cpadole\source\repos\WebApiDemo_5Sept19\WebApiDemo_5Sept19\Data\BookData.json"))
            {

                string json = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }
    }

    public class PostMethodTest
    {
        List<Book> bookList = new List<Book>();
        public Book book_to_add = new Book("Harry Potter", "Chinmay", 99, 90, "Horror");
        [Fact]
        public void Check_If_Invalid_Object_Is_Passed()
        {
            List<string> serverMessageList = new List<string>() { "Invalid Data is passed" };
            LoadJson();
            var expectedBook = new Response(bookList, serverMessageList);
            var actualBook = new BookService().post(new Book("Book #1", "Neelesh", -121, 40, "Fiction"));
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        [Fact]
        public void Check_If_Book_Is_Added_For_Valid_Object()
        {
            List<string> serverMessageList = new List<string>() { "Book Added" };

            var actualBook = new BookService().post(book_to_add);
            LoadJson();
            var expectedBook = new Response(bookList, serverMessageList);
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        [Fact]
        public void Check_If_Id_Already_Exists()
        {
            List<string> serverMessageList = new List<string>() { "Data redundant" };
            LoadJson();

            var expectedBook = new Response(bookList, serverMessageList);
            var actualBook = new BookService().post(new Book("Book #1", "Neelesh", 1, 40, "Fiction"));
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }



        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\cpadole\source\repos\WebApiDemo_5Sept19\WebApiDemo_5Sept19\Data\BookData.json"))
            {

                string json = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }
    }

    public class PutMethodTest
    {
        List<Book> bookList = new List<Book>();

        [Fact]
        public void Check_If_Invalid_Object_Is_Passed()
        {


            List<string> serverMessageList = new List<string>() { "Invalid Data is passed" };
            LoadJson();
            var expectedBook = new Response(bookList, serverMessageList);
            var actualBook = new BookService().put(new Book("Book #1", "Neelesh", -121, 40, "Fiction"));
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        [Fact]
        public void Check_If_Book_Data_Updated_For_Correct_Id()
        {


            List<string> serverMessageList = new List<string>() { "Updated" };

            var expectedBook = new Response(new List<Book>() { new Book("Book #1", "Neelesh", 1, 40, "Non-Fiction") }, serverMessageList);
            var actualBook = new BookService().put(new Book("Book #1", "Neelesh", 1, 40, "Non-Fiction"));
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\cpadole\source\repos\WebApiDemo_5Sept19\WebApiDemo_5Sept19\Data\BookData.json"))
            {

                string json = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }
    }

    public class DeleteMethodTest
    {
        List<Book> bookList = new List<Book>();

        [Fact]
        public void Check_For_Invalid_Id_Entered()
        {
            List<string> serverMessageList = new List<string>() { "Item Not Found" };
            LoadJson();
            var expectedBook = new Response(bookList, serverMessageList);
            var actualBook = new BookService().delete(121);
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }

        [Fact]
        public void Check_If_Book_Is_Deleted()
        {


            List<string> serverMessageList = new List<string>() { "Item Deleted" };

            //LoadJson();


            var actualBook = new BookService().delete(5);
            LoadJson();
            var expectedBook = new Response(bookList, serverMessageList);
            Assert.Equal(expectedBook.ToString(), actualBook.ToString());
        }



        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\cpadole\source\repos\WebApiDemo_5Sept19\WebApiDemo_5Sept19\Data\BookData.json"))
            {

                string json = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }


    }
}
