using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoatRentASPMVC.Models;

namespace BoatRentASPMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly BoatRentDBContext _context;

        public HomeController(BoatRentDBContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
              return _context.BoatRegisters != null ? 
                          View(await _context.BoatRegisters.ToListAsync()) :
                          Problem("Entity set 'BoatRentDBContext.BoatRegisters'  is null.");
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BoatRegisters == null)
            {
                return NotFound();
            }

            var boatRegister = await _context.BoatRegisters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boatRegister == null)
            {
                return NotFound();
            }

            return View(boatRegister);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoatName,CustomerName,HourlyRate,StartDate,EndDate")] BoatRegister boatRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boatRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boatRegister);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BoatRegisters == null)
            {
                return NotFound();
            }

            var boatRegister = await _context.BoatRegisters.FindAsync(id);
            if (boatRegister == null)
            {
                return NotFound();
            }
            return View(boatRegister);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoatName,CustomerName,HourlyRate,StartDate,EndDate")] BoatRegister boatRegister)
        {
            if (id != boatRegister.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boatRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatRegisterExists(boatRegister.Id))
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
            return View(boatRegister);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BoatRegisters == null)
            {
                return NotFound();
            }

            var boatRegister = await _context.BoatRegisters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boatRegister == null)
            {
                return NotFound();
            }

            return View(boatRegister);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BoatRegisters == null)
            {
                return Problem("Entity set 'BoatRentDBContext.BoatRegisters'  is null.");
            }
            var boatRegister = await _context.BoatRegisters.FindAsync(id);
            if (boatRegister != null)
            {
                _context.BoatRegisters.Remove(boatRegister);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoatRegisterExists(int id)
        {
          return (_context.BoatRegisters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
