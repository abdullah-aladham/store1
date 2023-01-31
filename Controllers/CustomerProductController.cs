using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store1.Data;
using store1.Models;
using store1.Models.MViews;

namespace store1.Controllers
{
    public class CustomerProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerProductController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _context.Customer_Products.ToList();
            List<CustomerProductViewModel> cpList = new List<CustomerProductViewModel>();

            if (customers != null)
            {

                foreach (var customerProd in customers)
                {
                    var CPViewModel = new CustomerProductViewModel()//CPViewmodel=CustomerProductViewModel
                    {
                        Id = customerProd.Id,
                        CustomerId = customerProd.CustomerId,
                        ProductId = customerProd.ProductId,
                    };
                    cpList.Add(CPViewModel);
                }
                return View(cpList);
            }
            return View(cpList);

        }
        [HttpGet]
        public IActionResult Create() {
        return View();
        }
        [HttpPost]
         public IActionResult CreateCustomerProduct(CustomerProductViewModel customerP)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customerProduct = new CustomerProducts()
                    {
                        Id = customerP.Id,
                        ProductId = customerP.ProductId,
                        CustomerId = customerP.CustomerId,
                    };
                    _context.Customer_Products.Add(customerProduct);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Customer created successfully";
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
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public IActionResult Edit(int Id) {
            try
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
                if (customer != null)
                {
                    var CustomerView = new CustomerViewModel()
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        type = customer.type,

                    };
                    return View(CustomerView);
                }
                else
                {
                    TempData["errorMessage"] = $"Customer details are not avaliable with Id : {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error Message"] = e.Message;
                return RedirectToAction("Index");
            }

        }
        [HttpPost] 
        public IActionResult EditCustomerProduct(CustomerProductViewModel model) 
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var customer = new CustomerProducts()
                    {
                        Id = model.Id,
                        CustomerId = model.CustomerId,
                        ProductId = model.ProductId,
                    };
                    _context.Customer_Products.Update(customer);
                    _context.SaveChanges();
                    TempData["sucessMessage"] = "customer Prdouct details Updated Successully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is invalid";
                    return RedirectToAction("Index"); ;
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return RedirectToAction("Index"); ;
            }
        }
        [HttpGet]
        public IActionResult Show()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowPriceByCustomerType(string type)
        {
            if(type!=null)
            var customers = _context.Customer_Products.FromSqlRaw($"SELECT ProductId FROM customer_products WHERE(SELECT  Id , name FROM CUSTOMERS WHERE type={type};");
            
        }
        [HttpGet]
        public IActionResult Delete(int Id) 
        {
            try
            {
                var customer = _context.Customer_Products.SingleOrDefault(x => x.Id == Id);
                if (customer != null)
                {
                    var customerView = new CustomerProductViewModel()
                    {
                        Id = customer.Id,
                        CustomerId = customer.CustomerId,
                        ProductId = customer.ProductId,
                    };
                    return View(customerView);
                }
                else
                {
                    TempData["errorMessage"] = $"Customer details are not avaliable with Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            };
        }
        [HttpPost]
        public IActionResult DeleteCustomerProduct(CustomerProductViewModel model) 
        {
            try
            {
                var customerProducts = _context.Customer_Products.SingleOrDefault(x => x.Id == model.Id);
                if (customerProducts != null)
                {
                    _context.Customer_Products.Remove(customerProducts);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Row deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Row  not avaliable with the Id:{model.Id}";
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
