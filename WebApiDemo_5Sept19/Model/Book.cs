namespace WebApiDemo_5Sept19.Model
{
    public class Book
    {
        public Book(string name, string author, int id, int price, string category)
        {
            this.name = name;
            this.author = author;
            this.id = id;
            this.price = price;
            this.category = category;
        }

        public string name { get; set; }
        public string author { get; set; }
        public int id { get; private set; }

        public int price { get; set; }

        public string category { get; set; }

    }
}
