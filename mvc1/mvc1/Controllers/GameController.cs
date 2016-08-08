using mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc1.Controllers
{
    public class GameController : Controller
    {
        DataContext db = new DataContext();

        // GET: Game
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.Games);
        }

        public ActionResult Details(int id)
        {
            var row = db.Games.Find(id);

            if (row == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            return View(row);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var row = db.Games.Find(id);

            if (row == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            ViewBag.teams1 = new SelectList(db.Teams, "Id", "Name");
            ViewBag.teams2 = new SelectList(db.Teams, "Id", "Name");
            ViewBag.stadiums = new SelectList(db.Stadiums.Select(s => new { s.Id, Name = s.Name + " - " + s.City }), "Id", "Name");

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            var row = db.Games.Find(game.Id);
            row.Team1_Id = game.Team1_Id;
            row.Team2_Id = game.Team2_Id;
            row.StadiumId = game.StadiumId;
            row.DateStart = game.DateStart;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var row = new Game()
            {
                DateStart = DateTime.Now
            };
            ViewBag.teams1 = new SelectList(db.Teams, "Id", "Name");
            ViewBag.teams2 = new SelectList(db.Teams, "Id", "Name");
            ViewBag.stadiums = new SelectList(db.Stadiums.Select(s => new { s.Id, Name = s.Name + " - " + s.City }), "Id", "Name");

            return View("Edit", row);
        }

        [HttpPost]
        public ActionResult Create(Game game)
        {
            var row = db.Games.Add(new Game()
            {
                Team1_Id = game.Team1_Id,
                Team2_Id = game.Team2_Id,
                StadiumId = game.StadiumId,
                DateStart = game.DateStart
            });
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Remove(Game game)
        {
            db.Games.Remove(db.Games.Find(game.Id));
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}