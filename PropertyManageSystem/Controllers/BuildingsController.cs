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
    public class BuildingsController : Controller
    {
        private readonly WuyeProjectContext _context;

        public BuildingsController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
            var wuyeProjectContext = _context.WBuildings.Include(w => w.Sp);
            return View(await wuyeProjectContext.ToListAsync());
        }

        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WBuildings == null)
            {
                return NotFound();
            }

            var wBuilding = await _context.WBuildings
                .Include(w => w.Sp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wBuilding == null)
            {
                return NotFound();
            }

            return View(wBuilding);
        }

        // GET: Buildings/Create
        public IActionResult Create()
        {
            ViewData["SpId"] = new SelectList(_context.WSystemParams.Where(p=>p.Type=="楼宇信息"), "Id", "Name");
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,RoomName,Floors,Height,Area,Createtime,SpId,Remark")] WBuilding wBuilding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wBuilding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpId"] = new SelectList(_context.WSystemParams, "Id", "Id", wBuilding.SpId);
            return View(wBuilding);
        }

        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WBuildings == null)
            {
                return NotFound();
            }

            var wBuilding = await _context.WBuildings.FindAsync(id);
            if (wBuilding == null)
            {
                return NotFound();
            }
            ViewData["SpId"] = new SelectList(_context.WSystemParams.Where(p => p.Type == "楼宇信息"), "Id", "Name", wBuilding.SpId);
            return View(wBuilding);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomName,Floors,Height,Area,Createtime,SpId,Remark")] WBuilding wBuilding)
        {
            if (id != wBuilding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wBuilding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WBuildingExists(wBuilding.Id))
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
            ViewData["SpId"] = new SelectList(_context.WSystemParams, "Id", "Id", wBuilding.SpId);
            return View(wBuilding);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.WBuildings == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WBuildings'  is null.");
            }
            var wBuilding = await _context.WBuildings.FindAsync(id);
            if (wBuilding != null)
            {
                _context.WBuildings.Remove(wBuilding);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WBuildingExists(int id)
        {
          return (_context.WBuildings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
