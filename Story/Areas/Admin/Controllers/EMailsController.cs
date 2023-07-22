using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Story.Data;

namespace Story.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EMailsController : Controller
    {
        private readonly AppDbContext _context;

        public EMailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/EMails
        public async Task<IActionResult> Index()
        {
              return _context.EMails != null ? 
                          View(await _context.EMails.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.EMails'  is null.");
        }

        // GET: Admin/EMails/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EMails == null)
            {
                return NotFound();
            }

            var eMail = await _context.EMails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eMail == null)
            {
                return NotFound();
            }

            return View(eMail);
        }

        // GET: Admin/EMails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/EMails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Body,Time,Enabled")] EMail eMail)
        {
            if (ModelState.IsValid)
            {
                eMail.Id = Guid.NewGuid();
                _context.Add(eMail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eMail);
        }

        // GET: Admin/EMails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EMails == null)
            {
                return NotFound();
            }

            var eMail = await _context.EMails.FindAsync(id);
            if (eMail == null)
            {
                return NotFound();
            }
            return View(eMail);
        }

        // POST: Admin/EMails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Subject,Body,Time,Enabled")] EMail eMail)
        {
            if (id != eMail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eMail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EMailExists(eMail.Id))
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
            return View(eMail);
        }

        // GET: Admin/EMails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EMails == null)
            {
                return NotFound();
            }

            var eMail = await _context.EMails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eMail == null)
            {
                return NotFound();
            }

            return View(eMail);
        }

        // POST: Admin/EMails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EMails == null)
            {
                return Problem("Entity set 'AppDbContext.EMails'  is null.");
            }
            var eMail = await _context.EMails.FindAsync(id);
            if (eMail != null)
            {
                _context.EMails.Remove(eMail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EMailExists(Guid id)
        {
          return (_context.EMails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
