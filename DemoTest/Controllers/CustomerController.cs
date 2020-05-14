using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoTest.Models;
using DemoTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoTest.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private Qlhd db;
        public CustomerController(Qlhd _db)
        {
            db = _db;
        }
        [Route("~/")]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.cs = db.Customer.ToList();
            return View();
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            var customers = db.Customer.Select(a => new
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
            var ordersViewModel = new OrdersViewModel
            {
                orders = new Orders()
                {
                    Payments = "cash"
                },

                customers = new SelectList(customers, "Id", "Name")
            };
            return View("Add", ordersViewModel);
        }
        [Route("add")]
        [HttpPost]
        public IActionResult Add(OrdersViewModel ordersViewModel)
        {
            ordersViewModel.orders.Datecreation = DateTime.Now;
            db.Orders.Add(ordersViewModel.orders);
            db.SaveChanges();
            return RedirectToAction("Index", "orders");
            
        }
    }
}