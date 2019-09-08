using FluentAssertions;
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
            Response expectedBook = new Response(bookList, serverMessageList,200);
            Response actualBook = new BookService().Get();
            expectedBook.Should().BeEquivalentTo(actualBook);
        }

        [Fact]
        public void Check_If_Only_Book_Data_Returned_With_Id()
        {
            List<string> serverMessageList = new List<string>()
            {
                "Book #1"
            };
            List<Book> books = new List<Book>() {
               new Book("Book #1","Neelesh",1,40,"Fiction") };
            LoadJson();

            Response expectedBook = new Response(books, serverMessageList,200);
            Response actualBook = new BookService().Get(1);
            expectedBook.Should().BeEquivalentTo(actualBook);
        }

        [Fact]
        public void Check_If_Negative_Id_Is_Entered()
        {
            List<string> msg = new List<string>()
            {
                "Invalid Id, Id should be a positive number"
            };
            Response expectedBook = new Response(null, msg,400);
            Response actualBook = new BookService().Get(-12);
            expectedBook.Should().BeEquivalentTo(actualBook);
        }

        [Fact]
        public void Check_If_No_Data_For_Id_Exists()
        {


            List<string> msg = new List<string>()
            {
                "Item Not Found"
            };
            // LoadJson();
            Response expectedBook = new Response(bookList, msg,404);
            Response actualBook = new BookService().Get(8);
            expectedBook.Should().BeEquivalentTo(actualBook);
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
            List<string> serverMessageList = new List<string>();
            serverMessageList.Add("Negative Id Is Entered, Please Enter Positive Id");
            LoadJson();
            Response expectedBook = new Response(null, serverMessageList,400);
            Response actualBook = new BookService().Post(new Book("Book #1", "Neelesh", -121, 40, "Fiction"));
            expectedBook.Should().BeEquivalentTo(actualBook);
        }

        [Fact]
        public void Check_If_Book_Is_Added_For_Valid_Object()
        {
            List<string> serverMessageList = new List<string>() { "Book Added" };

            Response actualBook = new BookService().Post(book_to_add);
            LoadJson();
            Response expectedBook = new Response(bookList, serverMessageList,200);
            expectedBook.Should().BeEquivalentTo(actualBook);
        }

        [Fact]
        public void Check_If_Id_Already_Exists()
        {
            List<string> serverMessageList = new List<string>() { "Data redundant" };

            Response actualBook = new BookService().Post(new Book("Book #1", "Neelesh", 1, 40, "Fiction"));
            //LoadJson();

            Response expectedBook = new Response(null, serverMessageList,400);

            expectedBook.Should().BeEquivalentTo(actualBook);
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


            List<string> serverMessageList = new List<string>();

            //serverMessageList.Add("Name Entered Is Empty, Please Enter a name");          
            serverMessageList.Add("Negative Id Is Entered, Please Enter Positive Id");                        
            //serverMessageList.Add("Negative Price Is Entered, Please Enter Positive Price");                      
            //serverMessageList.Add("Author Name Entered Is Empty, Please Enter a Valid Author name");            
            //serverMessageList.Add("Category Name Entered Is Empty, Please Enter a Valid Category name");            
            //serverMessageList.Add("Author Name Entered has digits in it, Author Name cannot have digits");



            LoadJson();
            Response expectedBook = new Response(null, serverMessageList,400);
            Response actualBook = new BookService().Put(new Book("Book #1", "Neelesh", -121, 40, "Fiction"));
            expectedBook.Should().BeEquivalentTo(actualBook);
        }

        [Fact]
        public void Check_If_Book_Data_Updated_For_Correct_Id()
        {
            List<string> serverMessageList = new List<string>() { "Updated" };

            Response expectedBook = new Response(new List<Book>() { new Book("Book #3", "Rameez", 3, 40, "Non-Fiction") }, serverMessageList,200);
            Response actualBook = new BookService().Put(new Book("Book #3", "Rameez", 3, 40, "Non-Fiction"));
            expectedBook.Should().BeEquivalentTo(actualBook);
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
        public void Check_For_Id_Entered_Is_Not_Present()
        {
            List<string> serverMessageList = new List<string>() { "Item Not Found" };
            LoadJson();
            Response expectedBook = new Response(bookList, serverMessageList,404);
            Response actualBook = new BookService().Delete(121);
            expectedBook.Should().BeEquivalentTo(actualBook);
        }

        [Fact]
        public void Check_For_Id_Invalid_Id_Entered()
        {
            List<string> serverMessageList = new List<string>() { "Invalid Id, Id should be a positive number" };
            LoadJson();
            Response expectedBook = new Response(null, serverMessageList,400);
            Response actualBook = new BookService().Delete(-124);
            expectedBook.Should().BeEquivalentTo(actualBook);
        }



        [Fact]
        public void Check_If_Book_Is_Deleted()
        {


            List<string> serverMessageList = new List<string>() { "Item Deleted" };

            //LoadJson();


            Response actualBook = new BookService().Delete(5);
            LoadJson();
            Response expectedBook = new Response(bookList, serverMessageList,200);
            expectedBook.Should().BeEquivalentTo(actualBook);
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
