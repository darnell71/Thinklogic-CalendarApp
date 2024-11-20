using Microsoft.AspNetCore.Mvc;
using CalendarApp.Models;
using System.Linq;

namespace CalendarApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly CalendarDbContext _context;

        public EventsController(CalendarDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event model)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var eventModel = _context.Events.Find(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Event model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
