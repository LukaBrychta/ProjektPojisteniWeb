using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencePojisteniPlnaVerze.Data;
using EvidencePojisteniPlnaVerze.Models;

namespace EvidencePojisteniPlnaVerze.Controllers
{
    public class InsuredsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsuredsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Insureds
        public async Task<IActionResult> Index(string searchFirstName, string searchLastName, string searchCity)
        {
            var insureds = from i in _context.Insured
                           select i;

            if (!string.IsNullOrEmpty(searchFirstName))
            {
                insureds = insureds.Where(i => i.FirstName.Contains(searchFirstName));
            }

            if (!string.IsNullOrEmpty(searchLastName))
            {
                insureds = insureds.Where(i => i.LastName.Contains(searchLastName));
            }

            if (!string.IsNullOrEmpty(searchCity))
            {
                insureds = insureds.Where(i => i.City.Contains(searchCity));
            }
            ViewBag.pocetZaznamu = insureds.Count();

            return insureds != null ? View(await insureds.ToListAsync()) : Problem("Entity set 'ApplicationDbContext.Insured'  is null.");

        }

        // GET: Insureds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insured == null)
            {
                return NotFound();
            }

            var insured = await _context.Insured
                .FirstOrDefaultAsync(m => m.Id == id);

            if (insured == null)
            {
                return NotFound();
            }

            ViewBag.insurances = _context.Insurance
                .Where(i => i.InsuredId == id);

            return View(insured);
        }

        // GET: Insureds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insureds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,Street,HouseNumber,City,Zip")] Insured insured)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insured);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = insured.Id });
            }
            return View(insured);
        }

        // GET: Insureds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Insured == null)
            {
                return NotFound();
            }

            var insured = await _context.Insured.FindAsync(id);
            if (insured == null)
            {
                return NotFound();
            }
            return View(insured);
        }

        // POST: Insureds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Street,HouseNumber,City,Zip")] Insured insured)
        {
            if (id != insured.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insured);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuredExists(insured.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = insured.Id });
            }
            return View(insured);
        }

        // GET: Insureds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Insured == null)
            {
                return NotFound();
            }

            var insured = await _context.Insured
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insured == null)
            {
                return NotFound();
            }

            return View(insured);
        }

        // POST: Insureds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Insured == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Insured'  is null.");
            }

            var insurance = _context.Insurance
            .Where(i => i.InsuredId == id);
            if (insurance != null)
            {
                foreach (var ins in insurance)
                {
                    _context.Insurance.Remove(ins);
                }
            }

            var insured = await _context.Insured.FindAsync(id);
            if (insured != null)
            {
                _context.Insured.Remove(insured);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //// POST: Insureds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Insured == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Insured'  is null.");
        //    }
        //    var insured = await _context.Insured.FindAsync(id);
        //    if (insured != null)
        //    {
        //        _context.Insured.Remove(insured);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool InsuredExists(int id)
        {
            return (_context.Insured?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
