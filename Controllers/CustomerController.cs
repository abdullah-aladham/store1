using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store1.Data;
using store1.Models.MViews;
using store1.Models;

namespace store1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            List<CustomerViewModel> customerList = new List<CustomerViewModel>();

            if (customers != null)
            {
               
                    foreach (var customer in customers)
                    {
                        var CustomerViewModel = new CustomerViewModel()
                        {
                            Id = customer.Id,
                            Name = customer.Name,
                            type = customer.type,
                        };
                        customerList.Add(CustomerViewModel);
                    }
                    return View(customerList);
                }
            return View(customerList);


            
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerViewModel customerData)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer()
                    {
                        Id = customerData.Id,
                        Name = customerData.Name,
                        type = customerData.type,
                    };
                    _context.Customers.Add(customer);
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
                return View("Index");
            }

        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CustomercreateModal()
        {
            Customer customer = new Customer();
            return PartialView("MPcreate", customer);
        }

        [HttpPost]

        public IActionResult UpdateCustomer(CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var customer = new Customer()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        type = model.type,
                    };
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                    TempData["sucessMessage"] = "customer details Updated Successully!";
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
            //return View();

        }
        public IActionResult Update(int Id)
        {
            try
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
                if (customer != null)
                {
                    var CustomerView = new CustomerViewModel()
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        type=customer.type,

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
        public IActionResult QuickEdit(int Id)
        {
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
                    return PartialView("QuickEdit",CustomerView);
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
        public IActionResult Delete(int Id)
        {
            try
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
                if (customer != null)
                {
                    var customerView = new CustomerViewModel()
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        type=customer.type,
                    };
                    return View(customerView);
                }
                else
                {
                    TempData["errorMessage"] = "Customer details are not avaliable with Id:{Id}";
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
        public IActionResult DeleteCustomer(CustomerViewModel model)
        {
            try
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == model.Id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Customer deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Customer details not avaliable with the Id:{model.Id}";
                    return RedirectToAction("Index");
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
