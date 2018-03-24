namespace ClassLibraryDemo
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            this.Author = author;
            this.Title = title;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Title, Author);
        }
    }
}
