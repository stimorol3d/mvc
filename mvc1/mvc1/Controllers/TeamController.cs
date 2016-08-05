using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    public class TeamController : Controller
    {
        DataContext db = new DataContext();

        // GET: Team
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.Teams);
        }

        public ActionResult Details(int id)
        {
            Team row = db.Teams.Find(id);

            if (row == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            return View(row);
            //return View(db.Teams.SingleOrDefault(t => t.Id == id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Team row = db.Teams.Find(id);

            if (row == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            Team row = db.Teams.Find(team.Id);
            row.Name = team.Name;
            db.SaveChanges();

            return RedirectToAction("List");
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", null);
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            Team row = db.Teams.Add(new Team() { Name = team.Name } );
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Remove(Team team)
        {
            db.Teams.Remove(db.Teams.Find(team.Id));
            db.SaveChanges();

            return RedirectToAction("List");
        }

    }
}