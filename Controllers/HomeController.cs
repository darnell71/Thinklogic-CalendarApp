using Microsoft.AspNetCore.Mvc;
using CalendarApp.Models;
using System.Linq;

namespace CalendarApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CalendarDbContext _context;

        public HomeController(CalendarDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? selectedDate)
        {
            selectedDate ??= DateTime.Today;
            ViewBag.SelectedDate = selectedDate;
            var events = _context.Events
                                 .Where(e => e.StartDate.Date == selectedDate.Value.Date)
                                 .OrderBy(e => e.StartDate)
                                 .ToList();
            return View(events);
        }
    }
}
