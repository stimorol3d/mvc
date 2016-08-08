using mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc1.Controllers
{
    public class StadiumController : Controller
    {
        DataContext db = new DataContext();

        // GET: Stadium
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.Stadiums);
        }

        public ActionResult Details(int id)
        {
            Stadium row = db.Stadiums.Find(id);

            if (row == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            return View(row);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Stadium row = db.Stadiums.Find(id);

            if (row == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Stadium stadium)
        {
            Stadium row = db.Stadiums.Find(stadium.Id);
            row.Name = stadium.Name;
            row.City = stadium.City;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", null);
        }

        [HttpPost]
        public ActionResult Create(Stadium stadium)
        {
            Stadium row = db.Stadiums.Add(new Stadium() {
                Name = stadium.Name,
                City = stadium.City
            });
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Remove(Stadium stadium)
        {
            db.Stadiums.Remove(db.Stadiums.Find(stadium.Id));
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}