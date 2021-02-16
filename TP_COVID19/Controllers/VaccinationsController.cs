using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_COVID19.ORM;
using TP_COVID19.Web.Models;

namespace TP_COVID19.Web.Controllers
{
    public class VaccinationsController : Controller
    {
        private readonly Context _context = new Context();

        // GET: Vaccinations
        public async Task<IActionResult> Index()
        {
            var context = _context.Vaccinations.Include(v => v.IDPatient).Include(v => v.IDVaccin);
            return View(await context.ToListAsync());
        }

        // GET: Vaccinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccination = await _context.Vaccinations
                .Include(v => v.IDPatient)
                .Include(v => v.IDVaccin)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vaccination == null)
            {
                return NotFound();
            }

            return View(vaccination);
        }

        // GET: Vaccinations/Create
        public IActionResult Create()
        {
            ViewData["IDPatientId"] = new SelectList(_context.Personnes, "ID", "ID");
            ViewData["IDVaccinId"] = new SelectList(_context.Vaccins, "ID", "ID");
            ViewData["IDPatientNom"] = new SelectList(_context.Personnes, "ID", "Nom");
            ViewData["IDVaccinNom"] = new SelectList(_context.Vaccins, "ID", "Nom");
            return View();
        }

        // POST: Vaccinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDVaccinId,IDPatientId,Date,Rappel")] Vaccination vaccination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDPatientId"] = new SelectList(_context.Personnes, "ID", "ID", vaccination.IDPatientId);
            ViewData["IDVaccinId"] = new SelectList(_context.Vaccins, "ID", "ID", vaccination.IDVaccinId);
            return View(vaccination);
        }

        // GET: Vaccinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccination = await _context.Vaccinations.FindAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }
            ViewData["IDPatientId"] = new SelectList(_context.Personnes, "ID", "ID", vaccination.IDPatientId);
            ViewData["IDVaccinId"] = new SelectList(_context.Vaccins, "ID", "ID", vaccination.IDVaccinId);
            return View(vaccination);
        }

        // POST: Vaccinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDVaccinId,IDPatientId,Date,Rappel")] Vaccination vaccination)
        {
            if (id != vaccination.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinationExists(vaccination.ID))
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
            ViewData["IDPatientId"] = new SelectList(_context.Personnes, "ID", "ID", vaccination.IDPatientId);
            ViewData["IDVaccinId"] = new SelectList(_context.Vaccins, "ID", "ID", vaccination.IDVaccinId);
            return View(vaccination);
        }

        // GET: Vaccinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccination = await _context.Vaccinations
                .Include(v => v.IDPatient)
                .Include(v => v.IDVaccin)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vaccination == null)
            {
                return NotFound();
            }

            return View(vaccination);
        }

        // POST: Vaccinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccination = await _context.Vaccinations.FindAsync(id);
            _context.Vaccinations.Remove(vaccination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationExists(int id)
        {
            return _context.Vaccinations.Any(e => e.ID == id);
        }
    }
}
