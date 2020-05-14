using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoTest.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        private Qlhd db;
        public OrdersController(Qlhd _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.os = db.Orders.Where(s => s.Customerid == id).ToList();
            return View();
        }
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Orders.Remove(db.Orders.Find(id));
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}