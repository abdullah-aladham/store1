using Microsoft.AspNetCore.Mvc;
using store1.Data;
using store1.Models.MViews;
using store1.Models;

namespace store1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            List<ProductViewModel> productList = new List<ProductViewModel>();

            if (products != null)
            {
                foreach (var product in products)
                {
                    var ProductViewModel = new ProductViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,

                    };
                    productList.Add(ProductViewModel);
                }
                return View(productList);
            }
            return View(productList);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel ProductData)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var product = new Products()
                    {
                        Id = ProductData.Id,
                        Name = ProductData.Name,
                        Description = ProductData.Description,
                        price=ProductData.price,
                        wholesalePrice= ProductData.wholesalePrice,
                    };
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Product created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                TempData["errorMessage"] = e.Message;
                return View("Index");
            }

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult UpdateProduct(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var product = new Products()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Description = model.Description,
                        price = model.price,
                        wholesalePrice= model.wholesalePrice,
                    };
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    TempData["sucessMessage"] = "Product details Updated Successully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Product data is invalid";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return RedirectToAction("Index");
            }
            //return View();

        }
        public IActionResult Update(int Id)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == Id);
                if (product != null)
                {
                    var ProductView = new ProductViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description= product.Description,
                        wholesalePrice= product.wholesalePrice,
                        price= product.price,
                    };
                    return View(ProductView);
                }
                else
                {
                    TempData["errorMessage"] = $"Product details are not avaliable with Id : {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error Message"] = e.Message;
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int Id)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == Id);
                if (product != null)
                {
                    var productView = new ProductViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        wholesalePrice = product.wholesalePrice,
                        price= product.price,

                    };
                    return View(productView);
                }
                 
                {
                    TempData["errorMessage"] = "Product details are not avaliable with Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult DeleteProduct(ProductViewModel model)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == model.Id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Customer deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Product details not avaliable with the Id:{model.Id}";
                    return RedirectToAction("index");
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return View();

            }


        }
    }
}
