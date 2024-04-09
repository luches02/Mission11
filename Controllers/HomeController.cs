using Microsoft.AspNetCore.Mvc;
using Mission11.Models;
using Mission11.Models.ViewModels;
using System.Diagnostics;

namespace Mission11.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository _repo;
        public HomeController(IBookStoreRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum, string category)
        {
            int pageSize = 10;

            var blah = new BookListViewModel
            {
                Books = _repo.Books
                    .Where(x => x.Category == category || category == null)
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? _repo.Books.Count() : _repo.Books.Where(x => x.Category == category).Count()
                },

                CurrentCategory = category 
            };

            return View(blah);
        }  
            
    }
}
