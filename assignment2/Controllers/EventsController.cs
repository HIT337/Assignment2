using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment2.Data;
using Microsoft.AspNetCore.Authorization;
using assignment2.Models;
using System.Data.SqlClient;

namespace assignment2.Controllers

{
    [Authorize(Roles = "Admin,Member")]
	public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
		//private readonly Coach _coach;

        public EventsController(ApplicationDbContext context/*,Coach coach*/)
        {
            _context = context;
			//_coach = coach;
        }

		// GET: Events
		public ActionResult Index()
		{
			if (User.IsInRole("Coach"))
			{
				var Events = _context.Event.Include(c => c.AllocatedCoach)/**/
				.OrderBy(s => s.Date).ToList();
				//.Where(i. => ;
				var sql = Events.ToString();
				return View(Events.ToList());
			}
			else
			{
				var Events = _context.Event.Include(c => c.AllocatedCoach)/**/
				.OrderBy(s => s.Date).ToList();
				var sql = Events.ToString();
				return View(Events.ToList());
			}
		}
		public ActionResult Enrol(int id)
		{
			return View("index");
		}
		public ActionResult CoachDetails(int? Id)
		{
			return RedirectToAction("Details", "Coaches", new { id = Id });
		}
		// GET: Events/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
			IEnumerable<SelectListItem> items = _context.Coach.Select(c => new SelectListItem
			{
				
				Value = c.CoachId.ToString(),
				Text = c.Name

			});
			ViewBag.CoachName = items;
			return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Name,Description,CoachId,Date")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
			IEnumerable<SelectListItem> items = _context.Coach.Select(c => new SelectListItem
			{

				Value = c.CoachId.ToString(),
				Text = c.Name

			});
			ViewBag.CoachName = items;
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Name,Description,CoachId,Date")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
