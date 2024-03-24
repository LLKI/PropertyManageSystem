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
    public class UsersController : Controller
    {
        private readonly WuyeProjectContext _context;

        public UsersController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var wuyeProjectContext = _context.WUsers.Include(w => w.Building).Include(w => w.Danyuan).Include(w => w.House);
            return View(await wuyeProjectContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WUsers == null)
            {
                return NotFound();
            }

            var wUser = await _context.WUsers
                .Include(w => w.Building)
                .Include(w => w.Danyuan)
                .Include(w => w.House)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wUser == null)
            {
                return NotFound();
            }

            return View(wUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["BuildingId"] = new SelectList(_context.WBuildings, "Id", "RoomName");
            ViewData["DanyuanId"] = new SelectList(_context.WSystemParams.Where(p => p.Type == "单元信息"), "Id", "Name");
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,BuildingId,DanyuanId,HouseId,UserName,HouseNumber,Phone,Email,IdNumber,WorkAddress,LinkAddress,Username1,Password,Remark,Createtime")] WUser wUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.WBuildings, "Id", "Id", wUser.BuildingId);
            ViewData["DanyuanId"] = new SelectList(_context.WSystemParams, "Id", "Id", wUser.DanyuanId);
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Id", wUser.HouseId);
            return View(wUser);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WUsers == null)
            {
                return NotFound();
            }

            var wUser = await _context.WUsers.FindAsync(id);
            if (wUser == null)
            {
                return NotFound();
            }
            ViewData["BuildingId"] = new SelectList(_context.WBuildings, "Id", "RoomName", wUser.BuildingId);
            ViewData["DanyuanId"] = new SelectList(_context.WSystemParams.Where(p=>p.Type=="单元信息"), "Id", "Name", wUser.DanyuanId);
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Title", wUser.HouseId);
            return View(wUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuildingId,DanyuanId,HouseId,UserName,HouseNumber,Phone,Email,IdNumber,WorkAddress,LinkAddress,Username1,Password,Remark,Createtime")] WUser wUser)
        {
            if (id != wUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WUserExists(wUser.Id))
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
            ViewData["BuildingId"] = new SelectList(_context.WBuildings, "Id", "Id", wUser.BuildingId);
            ViewData["DanyuanId"] = new SelectList(_context.WSystemParams, "Id", "Id", wUser.DanyuanId);
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Id", wUser.HouseId);
            return View(wUser);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.WUsers == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WUsers'  is null.");
            }
            var wUser = await _context.WUsers.FindAsync(id);
            if (wUser != null)
            {
                _context.WUsers.Remove(wUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WUserExists(int id)
        {
          return (_context.WUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
