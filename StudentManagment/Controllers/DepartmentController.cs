using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagment.Data;
using StudentManagment.Models;


namespace StudentManagment.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        // GET: Department/Create
        public IActionResult Create()
        {
           var Teacher =  _context.Departments
                .Include(t => t.Teacher);
            var TeacherList = _context.Teachers.ToList();
            ViewBag.TeacherList = new SelectList(TeacherList, "TeacherId", "TeacherName");

            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeprtmentName, TeacherId")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // Get: Teacher according to Department
        public async Task<IActionResult> Details(int? id)
        {
    
            if (id == null)
            {
                return NotFound();
            }

            var Department = await _context.Departments
                .Include(d => d.Teacher)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (Department == null)
            {
                return NotFound();
            }

            return View(Department);
        }

        //Get Method for Update department
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments.FindAsync(id);
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);

        }

        //Post Update Method For departments
        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("DepartmentId, DeprtmentName, TeacherId")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    if (!DepartmentExists(department.DepartmentId))
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
            return View(department);
        }


        // GET: Students/Delete/5
        public async Task<IActionResult?> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Department = await _context.Departments
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (Department == null)
            {
                return NotFound();
            }

            return View(Department);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(Department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }

    }
}

