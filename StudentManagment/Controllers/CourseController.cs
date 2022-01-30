using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagment.Data;
using StudentManagment.Models;

namespace StudentManagment.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _context.Courses.ToListAsync());
        }

        // GET Method For Course.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // POST Method For Course.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CourseName, CourseCode")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var Course = await _context.Courses
                .SingleOrDefaultAsync(m => m.CourseId == id);
            
            if (Course == null)
            {
                return NotFound();
            }

            return View(Course);
        }

        //GET for Delete Course
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var Course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);

            if (Course == null)
            {
                return NotFound();
            }

            return View(Course);
        }

        //POST for Delete Course
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            var Course = await _context.Courses.FindAsync(id);
            _context.Remove(Course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 
    }
}
