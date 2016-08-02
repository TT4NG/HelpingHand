using HelpingHand.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpingHand.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetCustomerID()
        {
            var db = new ApplicationDbContext();
            var currentUser = User.Identity.GetUserId();
            var currentID = db.CustomerModels.Where(x => x.UserID == currentUser).SingleOrDefault();

            return RedirectToAction("Edit", "Customer", new { Id = currentID.ID });
        }

        public ActionResult GetDriverID()
        {
            var db = new ApplicationDbContext();
            var currentUser = User.Identity.GetUserId();
            var currentID = db.DriverModels.Where(x => x.UserID == currentUser).SingleOrDefault();

            return RedirectToAction("Edit", "Driver", new { Id = currentID.ID });
        }

    }
}