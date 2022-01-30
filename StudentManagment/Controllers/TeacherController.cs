using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagment.Data;
using StudentManagment.Models;

namespace StudentManagment.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Teachers
        public async Task<IActionResult> Index()
        {

            return View(await _context.Teachers.ToListAsync());
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,TeacherName,Contact")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET update Teacher
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var Teacher = await _context.Teachers.FindAsync(id);
            if (Teacher == null)
            {
                return NotFound();
            }
            return View(Teacher);
        }

        // Get Teacher Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Teacher = await _context.Teachers
                .Include(t => t.Departments)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.TeacherId == id);

            if (Teacher == null)
            {
                return NotFound();
            }

            return View(Teacher);
        }

        // GET: Teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Teacher = await _context.Teachers
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (Teacher == null)
            {
                return NotFound();
            }

            return View(Teacher);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Teacher = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(Teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);
        }

    }
}
