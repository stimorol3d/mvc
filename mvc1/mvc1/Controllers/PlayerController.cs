using mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    public class PlayerController : Controller
    {
        DataContext db = new DataContext();

        // GET: Player
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(int? teamId)
        {
            ViewBag.teams = new SelectList(db.Teams, "Id", "Name", teamId);

            IEnumerable<Player> rows = null;

            if (teamId == null)
                rows = from p in db.Players
                       orderby p.Team.Name, p.Name
                       select p;
            else
                rows = from p in db.Players
                       orderby p.Team.Name, p.Name
                       where p.TeamId == teamId
                       select p;
            
            return View(rows);
        }

        public ActionResult Details(int id)
        {
            var row = db.Players.Find(id);

            if (row == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            return View(row);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var row = db.Players.Find(id);

            if (row == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            ViewBag.teams = new SelectList(db.Teams, "Id", "Name");

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            var row = db.Players.Find(player.Id);
            row.TeamId = player.TeamId;
            row.Name = player.Name;
            row.Age = player.Age;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var row = new Player()
            {
                Name = "New player",
                Age = 18
            };
            ViewBag.teams = new SelectList(db.Teams, "Id", "Name");
            return View("Edit", row);
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            var row = db.Players.Add(new Player() {
                TeamId = player.TeamId,
                Name = player.Name,
                Age = player.Age
            });
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Remove(Player player)
        {
            db.Players.Remove(db.Players.Find(player.Id));
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}