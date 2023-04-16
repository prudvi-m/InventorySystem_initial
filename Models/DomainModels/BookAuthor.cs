namespace InventorySystem.Models
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
