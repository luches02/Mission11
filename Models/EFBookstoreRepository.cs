
using Microsoft.AspNetCore.Mvc;

namespace Mission11.Models
{
    public class EFBookstoreRepository : IBookStoreRepository
    {
        private BookstoreContext _context;
        public EFBookstoreRepository(BookstoreContext temp) {
            _context = temp;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
