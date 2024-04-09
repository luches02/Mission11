using Microsoft.EntityFrameworkCore.Query;

namespace Mission11.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        
        public virtual void AddItem(Book book, int quantity)
        {
            CartLine? line = Lines
                .Where(x => x.Book.BookId == book.BookId)
                .FirstOrDefault();

            //has this item already been added to cart if not add it, if yes increase quantityt 
            if (line == null) 
            {
                Lines.Add(new CartLine()
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;   
            }
        }

        public virtual void RemoveLine(Book book) => Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public virtual void Clear() => Lines.Clear();

        public double CalculateTotal() => Lines.Sum(x => x.Book.Price * x.Quantity);
    

        public class CartLine
        {
            public int CartLineId { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
