using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyManageSystem.Models;

namespace PropertyManageSystem.Controllers
{
    public class InstallationsController : Controller
    {
        private readonly WuyeProjectContext _context;

        public InstallationsController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: Installations
        public async Task<IActionResult> Index()
        {
            var wuyeProjectContext = _context.WInstallations.Include(w => w.Sp);
            return View(await wuyeProjectContext.ToListAsync());
        }


        // GET: Installations/Create
        public IActionResult Create()
        {
            ViewData["SpId"] = new SelectList(_context.WSystemParams.Where(p => p.Type == "周边设施"), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,SpId,Name,Phone,MainName,Contents,Title")] WInstallation wInstallation)
        {

            _context.Add(wInstallation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Installations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WInstallations == null)
            {
                return NotFound();
            }

            var wInstallation = await _context.WInstallations.FindAsync(id);
            if (wInstallation == null)
            {
                return NotFound();
            }
            ViewData["SpId"] = new SelectList(_context.WSystemParams.Where(p => p.Type == "周边设施"), "Id", "Name", wInstallation.SpId);
            return View(wInstallation);
        }

        // POST: Installations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id,SpId,Name,Phone,MainName,Contents,Title")] WInstallation wInstallation)
        {
            if (id != wInstallation.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(wInstallation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WInstallationExists(wInstallation.Id))
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

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.WInstallations == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WInstallations'  is null.");
            }
            var wInstallation = await _context.WInstallations.FindAsync(id);
            if (wInstallation != null)
            {
                _context.WInstallations.Remove(wInstallation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WInstallationExists(int id)
        {
            return (_context.WInstallations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
