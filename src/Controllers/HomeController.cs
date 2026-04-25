using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevTrack.Data;
using DevTrack.Models;

namespace DevTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: / - List all tasks
        public async Task<IActionResult> Index(string? status, string? priority)
        {
            var tasks = _context.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(status))
                tasks = tasks.Where(t => t.Status == status);

            if (!string.IsNullOrEmpty(priority))
                tasks = tasks.Where(t => t.Priority == priority);

            ViewBag.StatusFilter = status;
            ViewBag.PriorityFilter = priority;
            ViewBag.TotalTasks = await _context.Tasks.CountAsync();
            ViewBag.PendingTasks = await _context.Tasks.CountAsync(t => t.Status == "Pending");
            ViewBag.InProgressTasks = await _context.Tasks.CountAsync(t => t.Status == "In Progress");
            ViewBag.CompletedTasks = await _context.Tasks.CountAsync(t => t.Status == "Completed");

            return View(await tasks.OrderByDescending(t => t.CreatedAt).ToListAsync());
        }

        // GET: /Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                task.CreatedAt = DateTime.Now;
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Task created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: /Home/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: /Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskItem task)
        {
            if (id != task.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(task);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Task updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // POST: /Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Task deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Home/UpdateStatus
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.Status = status;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
