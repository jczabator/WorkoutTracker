using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Controllers
{
    public class WorkoutProgressesController : Controller
    {
        private readonly WorkoutTrackerContext _context;

        public WorkoutProgressesController(WorkoutTrackerContext context)
        {
            _context = context;
        }

        // GET: WorkoutProgresses
        public async Task<IActionResult> Index()
        {
            var workoutTrackerContext = _context.WorkoutProgresses.Include(w => w.Exercise).Include(w => w.User);
            return View(await workoutTrackerContext.ToListAsync());
        }

        // GET: WorkoutProgresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutProgress = await _context.WorkoutProgresses
                .Include(w => w.Exercise)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutProgress == null)
            {
                return NotFound();
            }

            return View(workoutProgress);
        }

        // GET: WorkoutProgresses/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: WorkoutProgresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Repetitions,Sets,Weight,EquipmentType,TempoTraining,UserId,ExerciseId")] WorkoutProgress workoutProgress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutProgress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "Id", "Id", workoutProgress.ExerciseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", workoutProgress.UserId);
            return View(workoutProgress);
        }

        // GET: WorkoutProgresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutProgress = await _context.WorkoutProgresses.FindAsync(id);
            if (workoutProgress == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "Id", "Id", workoutProgress.ExerciseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", workoutProgress.UserId);
            return View(workoutProgress);
        }

        // POST: WorkoutProgresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Repetitions,Sets,Weight,EquipmentType,TempoTraining,UserId,ExerciseId")] WorkoutProgress workoutProgress)
        {
            if (id != workoutProgress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutProgress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutProgressExists(workoutProgress.Id))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "Id", "Id", workoutProgress.ExerciseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", workoutProgress.UserId);
            return View(workoutProgress);
        }

        // GET: WorkoutProgresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutProgress = await _context.WorkoutProgresses
                .Include(w => w.Exercise)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutProgress == null)
            {
                return NotFound();
            }

            return View(workoutProgress);
        }

        // POST: WorkoutProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutProgress = await _context.WorkoutProgresses.FindAsync(id);
            _context.WorkoutProgresses.Remove(workoutProgress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutProgressExists(int id)
        {
            return _context.WorkoutProgresses.Any(e => e.Id == id);
        }
    }
}
