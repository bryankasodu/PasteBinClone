using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPasteBin.Data;
using MvcPasteBin.Models;

namespace PasteBinClone.Controllers
{
    public class PasteBinController : Controller
    {
        private readonly MvcPasteBinContext _context;

        public PasteBinController(MvcPasteBinContext context)
        {
            _context = context;
        }

        // GET: PasteBin
        public async Task<IActionResult> ListPaste()
        {
              return _context.PasteBin != null ? 
                          View(await _context.PasteBin.ToListAsync()) :
                          Problem("Entity set 'MvcPasteBinContext.PasteBin'  is null.");
        }
        

        // GET: PasteBin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Console.WriteLine(id);
            if (id == null || _context.PasteBin == null)
            {
                return NotFound();
            }
            

            var pasteBin = await _context.PasteBin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasteBin == null)
            {
                return NotFound();
            }

            return View(pasteBin);
        }
        public async Task<IActionResult> Link(int? id)
        {
            Console.WriteLine(id);
            if (id == null || _context.PasteBin == null)
            {
                return NotFound();
            }
            

            var pasteBin = await _context.PasteBin
                .FirstOrDefaultAsync(m => m.Url == "/PasteBin/link/"+id.ToString());
            if (pasteBin == null)
            {
                return NotFound();
            }

            return View(pasteBin);
        }

        // GET: PasteBin/Create
        public IActionResult Index()
        {
            return View();
        }

        // POST: PasteBin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,Url,CreateDate,Paste")] PasteBin pasteBin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasteBin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasteBin);
        }

        // GET: PasteBin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PasteBin == null)
            {
                return NotFound();
            }

            var pasteBin = await _context.PasteBin.FindAsync(id);
            if (pasteBin == null)
            {
                return NotFound();
            }
            return View(pasteBin);
        }

        // POST: PasteBin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,CreateDate,Paste")] PasteBin pasteBin)
        {
            if (id != pasteBin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasteBin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasteBinExists(pasteBin.Id))
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
            return View(pasteBin);
        }

        // GET: PasteBin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PasteBin == null)
            {
                return NotFound();
            }

            var pasteBin = await _context.PasteBin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasteBin == null)
            {
                return NotFound();
            }

            return View(pasteBin);
        }

        // POST: PasteBin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PasteBin == null)
            {
                return Problem("Entity set 'MvcPasteBinContext.PasteBin'  is null.");
            }
            var pasteBin = await _context.PasteBin.FindAsync(id);
            if (pasteBin != null)
            {
                _context.PasteBin.Remove(pasteBin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasteBinExists(int id)
        {
          return (_context.PasteBin?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    

    }
}
