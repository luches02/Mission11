using Microsoft.EntityFrameworkCore.Query;

namespace Mission11.Models
{
    public interface IBookStoreRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
