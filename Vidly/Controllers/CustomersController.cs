﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            
            return View("CustomerForm",viewModel);   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save (Customer customer) 
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer, 
                    MembershipTypes= _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter= customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");  
        }
        public ActionResult Index()
        {
            var viewModel = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(v => v.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else 
                return View(customer);
        }

        public ActionResult Edit(int id)
        { 
            var customer = _context.Customers.SingleOrDefault(v => v.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel() 
            {
                Customer = customer,
                MembershipTypes= _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public void AddNewCustomer()
        {
            RedirectToAction("New", "Customers");
        }
    }
}