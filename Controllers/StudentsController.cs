using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Batch_Advisory.Data;
using Batch_Advisory.Models;
using Batch_Advisory.Services;
using System.Data.SqlClient;

namespace Batch_Advisory.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Batch_AdvisoryContext _context;

        public StudentsController(Batch_AdvisoryContext context)
        {
            _context = context;
        }

        // GET: Students
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        public IActionResult EligibleCourses(string id)
        {                        
            var list = _context.AvailableCourses.FromSqlRaw<AvailableCourse>("EligibleCourses {0}", id).ToList();
            
            EligibleCourse eligibleCourses= new EligibleCourse();

            eligibleCourses.CoursesList = list.Select(item => new CheckboxEligibleCourses()
            {
                CourseCode = item.CourseCode,
                CourseName = item.CourseName,
                CreditHour = item.CreditHour,
                BatchTakingCourse = item.BatchTakingCourse,
                isRegistered = false

            }).ToList();


            var student = _context.Students
                .Include(s => s.BatchNavigation) 
                .FirstOrDefault(m => m.Src == id);
            
            if (student == null)
            {
                return NotFound();
            }

            eligibleCourses.Src = id;
            eligibleCourses.student = student;
            
            return View(eligibleCourses);
        }

        //POST: Students/EligibleCourse
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EligibleCourses(EligibleCourse eligibleCourse, Student student)
        //{
        //    foreach (var course in eligibleCourse.CoursesList)
        //    {
        //        if (course.isRegistered)
        //        {
        //            CoursesRegistered coursesRegistered = new CoursesRegistered(eligibleCourse.Src, course.CourseCode);
        //            _context.CoursesRegistereds.Add(coursesRegistered);
        //            _context.SaveChanges();
        //        }
        //    }
        //    ViewBag.AddedSucssesfully = true;
        //    return View(eligibleCourse);

        //}


        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.BatchNavigation)
                .FirstOrDefaultAsync(m => m.Src == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["Batch"] = new SelectList(_context.Batches, "BatchId", "BatchId");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Src,Name,Batch,Gpa,Password,CoursesCompleted")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Batch"] = new SelectList(_context.Batches, "BatchId", "BatchId", student.Batch);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["Batch"] = new SelectList(_context.Batches, "BatchId", "BatchId", student.Batch);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Src,Name,Batch,Gpa,Password,CoursesCompleted")] Student student)
        {
            if (id != student.Src)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Src))
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
            ViewData["Batch"] = new SelectList(_context.Batches, "BatchId", "BatchId", student.Batch);
            return View(student);
        }


        public async Task<IActionResult> ChangePassword(string id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var changePassword = new Passwords();
            changePassword.Src=student.Src;
            
            //ViewData["Batch"] = new SelectList(_context.Batches, "BatchId", "BatchId", student.Batch);

            return View(changePassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(Passwords changePassword)
        {
            SecurityService ss = new SecurityService();

            if (!ss.IsValid(changePassword.Src, changePassword.Password))
            {
                ModelState.AddModelError("Password", "Password entered is wrong");
                //return View(changePassword);
            }
           
            if (ModelState.IsValid)
            {
                var student = await _context.Students.FindAsync(changePassword.Src);
                if (student == null)
                {
                    return NotFound();
                }
                student.Password = changePassword.NewPassword;

                try
                {
                    _context.Attach(student);
                    _context.Entry(student).Property(x => x.Password).IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                ViewBag.IsSuccess=true;               
            }

            return View(changePassword);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.BatchNavigation)
                .FirstOrDefaultAsync(m => m.Src == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'Batch_AdvisoryContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return (_context.Students?.Any(e => e.Src == id)).GetValueOrDefault();
        }
    }
}
