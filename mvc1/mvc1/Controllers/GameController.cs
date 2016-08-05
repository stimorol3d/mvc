using mvc.Models;
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
    }
}