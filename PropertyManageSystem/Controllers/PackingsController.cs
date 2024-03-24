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
    public class PackingsController : Controller
    {
        private readonly WuyeProjectContext _context;

        public PackingsController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: Packings
        public async Task<IActionResult> Index(String keyword="")
        {
            IEnumerable<WPacking> list = await _context.WPackings.Include(w=>w.Packin).ToListAsync();
            //type不为空则查询
            if (keyword != "")
            {
                //模糊查询
                list = list.Where(p=>p.PackingLot.Contains(keyword));
            }
            return View(list);
        }

        // GET: Packings/Create
        public IActionResult Create()
        {
            ViewData["PackingUid"] = new SelectList(_context.WUsers, "Id", "UserName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,PackingName,PackingLot,PackingLotId,PackingState,PackingType,PackingArea,PackingUid")] WPacking wPacking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wPacking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackingUid"] = new SelectList(_context.WUsers, "Id", "Id", wPacking.PackingUid);
            return View(wPacking);
        }

        // GET: Packings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WPackings == null)
            {
                return NotFound();
            }

            var wPacking = await _context.WPackings.FindAsync(id);
            if (wPacking == null)
            {
                return NotFound();
            }
            ViewData["PackingUid"] = new SelectList(_context.WUsers, "Id", "UserName", wPacking.PackingUid);
            return View(wPacking);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PackingName,PackingLot,PackingLotId,PackingState,PackingType,PackingArea,PackingUid")] WPacking wPacking)
        {
            if (id != wPacking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wPacking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WPackingExists(wPacking.Id))
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
            ViewData["PackingUid"] = new SelectList(_context.WUsers, "Id", "Id", wPacking.PackingUid);
            return View(wPacking);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (_context.WPackings == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WPackings'  is null.");
            }
            var wPacking = await _context.WPackings.FindAsync(id);
            if (wPacking != null)
            {
                _context.WPackings.Remove(wPacking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WPackingExists(int id)
        {
          return (_context.WPackings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
