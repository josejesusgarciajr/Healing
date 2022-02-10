using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Healing.Models;

namespace Healing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayProgress()
        {
            QueryDB queryDB = new QueryDB();
            List<Note> notes = queryDB.GetNotes();

            // SORT THE NOTES BY DATE
            notes.Sort((x, y) => DateTime.Compare(x.DateTime, y.DateTime));

            return View(notes);
        }

        public IActionResult AddNoteView()
        {
            return View();
        }

        public IActionResult AddOldNote()
        {
            return View();
        }

        public IActionResult EditNoteView(int id)
        {
            QueryDB queryDB = new QueryDB();
            Note note = queryDB.GetNote(id);

            return View(note);
        }

        public IActionResult EditDBNote(Note note)
        {
            QueryDB queryDB = new QueryDB();
            //note.DateString = note.CleanUpApostrophe();
            queryDB.EditNote(note);

            return RedirectToAction("Dashboard", "Home");
        }

        public IActionResult Dashboard()
        {
            QueryDB queryDB = new QueryDB();
            List<Note> notes = queryDB.GetNotes();

            // sort notes by date
            notes.Sort((a, b) => DateTime.Compare(a.DateTime, b.DateTime));
            return View(notes);
        }

        public IActionResult AddNoteToDB(Note note)
        {
            if(note.DateString != null)
            {
                Console.WriteLine($"Note Date: {note.DateString}");

                QueryDB queryDB = new QueryDB();
                queryDB.AddNoteToDB(note);
            } else
            {
                note.DateTime = DateTime.Now;
                Console.WriteLine($"Date: {note.DateTime.ToString("f")}, note: {note.Expression}");

                QueryDB queryDB = new QueryDB();
                queryDB.AddNoteToDB(note);
            }


            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
