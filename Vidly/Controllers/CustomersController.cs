using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        private List<Customer> customers = new List<Customer>() {
                new Customer{ Name = "John Smith", Id = 1},
                new Customer{ Name = "Jane Doe", Id = 2}
            };
        //private List<Customer> customers1 = new List<Customer>();
        public ActionResult Index()
        {
            var viewModel = new CustomersList();
            viewModel.Customers = customers;
            //return Content("URL is working");
            return View(viewModel);
        }

        public ActionResult Details(int id) 
        {
            if (customers.Count >= id)
            {
                return View(customers.Where(v => v.Id == id).ToList().First());
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}