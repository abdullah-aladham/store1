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
                    TempData["sucessMessage"] = "customerPrdouct details Updated Successully!";
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
        public IActionResult ShowPriceByCustomerType(string type, CustomerProductViewModel model)
        {//SELECT Customers.name,Products.Name,Products.wholesalePrice from customer_products inner join customers on customer_products.CustomerId=customers.Id inner join products on customer_products.ProductId=products.id;

            /*SELECT Customers.name,Customers.type,Products.Name,Products.Price from customer_products inner join customers on customer_products.CustomerId=customers.Id inner join products on customer_products.ProductId=products.id where type="Regular";
             
             *THIS QUERY FOR REGULAR CUSTOMER*/
            //  try
            //{
            //   return View();

            if (type == "Top")
            {
                var TopCustomerquery = _context.Customer_Products
                .Join(
                _context.Customers,
                customerprod => customerprod.CustomerId,
                customer => customer.Id
                , (customerprod, customer) => new
                {
                    CustomerId = customer.Id,
                    CustomerName = customer.Name,
                    CustomerType = customer.type,
                    productId = customerprod.ProductId


                }
                    )
                .Join(_context.Products,
                customerprod => customerprod.productId,

                product => product.Id,
                (customerprod, product) => new
                {
                    name = product.Name,
                   wholesalePrice = product.wholesalePrice
                });
                return View(TopCustomerquery);
            }
            else if(type=="Regular")
            {
                var regularCustomerquery = _context.Customer_Products
                .Join(
                _context.Customers,
                customerprod => customerprod.CustomerId,
                customer => customer.Id
                , (customerprod, customer) => new
                {
                    CustomerId = customer.Id,
                    CustomerName = customer.Name,
                    CustomerType = customer.type,
                    productId = customerprod.ProductId


                }
                    )
                .Join(_context.Products,
                customerprod => customerprod.productId,

                product => product.Id,
                (customerprod, product) => new
                {
                    name = product.Name,

                    Price = product.price
                });
                return View(regularCustomerquery);

            }
            else { return View(); }
            /*foreach(var item in query)
            {
                Name = item.Customer.Name,
                type=item.Customer.type,
                name=item.Product.Name,

            }
            return RedirectToAction("Index");
            }
            //var customer = _context.Customer_Products.FromSqlRaw($"SELECT Customers.name,Customers.type,Products.Name,Products.wholesalePrice from customer_products inner join customers on customer_products.CustomerId=customers.Id inner join products on customer_products.ProductId=products.id where type=\"Regular\";").ToList();
            else if (type == "Regular")
            {
                var query = _context.Customer_Products.FromSqlRaw(regular).ToList();
                return RedirectToAction("Index");
            }*/
          //  return View();
            //}
            //catch (Exception e)
            //{
            //   TempData["error Message"] = e.Message;
            //  return RedirectToAction("Index");
            //}

            // }
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
