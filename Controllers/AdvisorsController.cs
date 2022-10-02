using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Batch_Advisory.Data;
using Batch_Advisory.Models;

namespace Batch_Advisory.Controllers
{
    public class AdvisorsController : Controller
    {
        private readonly Batch_AdvisoryContext _context;

        public AdvisorsController(Batch_AdvisoryContext context)
        {
            _context = context;
        }

        // GET: Advisors
        public async Task<IActionResult> Index()
        {
            var batch_AdvisoryContext = _context.Advisors.Include(a => a.AssignedBatchNavigation);
            return View(await batch_AdvisoryContext.ToListAsync());
        }

        public async Task<IActionResult> Dashboard(int id)
        {
            if (id == null || _context.Advisors == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisors
                .Include(a => a.AssignedBatchNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }

        // GET: Advisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Advisors == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisors
                .Include(a => a.AssignedBatchNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }

        public async Task<IActionResult> StudentDetails(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisors
                .Include(a => a.AssignedBatchNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }

        // GET: Advisors/Create
        public IActionResult Create()
        {
            ViewData["AssignedBatch"] = new SelectList(_context.Batches, "BatchId", "BatchId");
            return View();
        }

        // POST: Advisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AssignedBatch,Password")] Advisor advisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedBatch"] = new SelectList(_context.Batches, "BatchId", "BatchId", advisor.AssignedBatch);
            return View(advisor);
        }

        // GET: Advisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Advisors == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor == null)
            {
                return NotFound();
            }
            ViewData["AssignedBatch"] = new SelectList(_context.Batches, "BatchId", "BatchId", advisor.AssignedBatch);
            return View(advisor);
        }

        // POST: Advisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AssignedBatch,Password")] Advisor advisor)
        {
            if (id != advisor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvisorExists(advisor.Id))
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
            ViewData["AssignedBatch"] = new SelectList(_context.Batches, "BatchId", "BatchId", advisor.AssignedBatch);
            return View(advisor);
        }

        // GET: Advisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Advisors == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisors
                .Include(a => a.AssignedBatchNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }

        // POST: Advisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Advisors == null)
            {
                return Problem("Entity set 'Batch_AdvisoryContext.Advisors'  is null.");
            }
            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor != null)
            {
                _context.Advisors.Remove(advisor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvisorExists(int id)
        {
          return _context.Advisors.Any(e => e.Id == id);
        }
    }
}
