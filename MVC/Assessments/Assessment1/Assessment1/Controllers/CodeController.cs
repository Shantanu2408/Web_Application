using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment1.Models;

namespace Assessment1.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities1 Rs = new NorthwindEntities1();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GermanCustomers()
        {
            var germanCustomers = Rs.Customers.Where(cd => cd.Country == "Germany").ToList();
            return View(germanCustomers);
        }

        public ActionResult CustomerWithOrder10248()
        {
            var customer = Rs.Orders.Where(od => od.OrderID == 10248).Select(od => od.Customer).FirstOrDefault();
            return View(customer);
        }
    }
}