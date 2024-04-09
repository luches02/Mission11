using Microsoft.AspNetCore.Mvc;
using Mission11.Models;

namespace Mission11.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookStoreRepository _repo;

        //constructor method run one time on startup
        public CategoryViewComponent(IBookStoreRepository temp)
        {
            _repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            var Categories = _repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(Categories);
        }
    }
}
