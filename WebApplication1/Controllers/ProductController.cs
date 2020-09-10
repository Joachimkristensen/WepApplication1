using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // Call method 'save' in repo
                _repository.Save(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
