using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mom3._2.Data;
using Mom3._2.Models;

namespace Mom3._2.Controllers
{
    public class LoansController : Controller
    {
        private readonly AlbumContext _context;

        public LoansController(AlbumContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var albumContext = _context.Loan.Include(l => l.Album);
            return View(await albumContext.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .Include(l => l.Album)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Album
                .Where(p => p.Available == true), "AlbumId", "AlbumTitle");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,LoanDate,FriendName,AlbumId")] Loan loan)
        {
            if (ModelState.IsValid)
            {

                var recordId = loan.AlbumId;
                var changebool = _context.Album
                    .Where(p => p.AlbumId == recordId)
                    .FirstOrDefault();

                changebool.Available = false;
                _context.SaveChanges();

                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Album, "AlbumId", "AlbumTitle", loan.AlbumId);
            return View(loan);
        }

       

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .Include(l => l.Album)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var loan = await _context.Loan.FindAsync(id);
            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            var recordId = loan.AlbumId;
            var changebool = _context.Album
                .Where(p => p.AlbumId == recordId)
                .FirstOrDefault();

            changebool.Available = true;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.LoanId == id);
        }
    }
}
