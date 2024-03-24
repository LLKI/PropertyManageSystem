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
    public class UserPaymoneysController : Controller
    {
        private readonly WuyeProjectContext _context;

        public UserPaymoneysController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: UserPaymoneys
        public async Task<IActionResult> Index()
        {
            var wuyeProjectContext = _context.WUserPaymoneys.Include(w => w.By).Include(w => w.House);
            return View(await wuyeProjectContext.ToListAsync());
        }


        // GET: UserPaymoneys/Create
        public IActionResult Create()
        {
            ViewData["ById"] = new SelectList(_context.WAdmins, "Id", "Id");
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Id");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,HouseId,Number,Price,ShouldPay,RealyPay,NoPay,StartPayTime,ById,Title")] WUserPaymoney wUserPaymoney)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wUserPaymoney);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ById"] = new SelectList(_context.WAdmins, "Id", "Id", wUserPaymoney.ById);
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Id", wUserPaymoney.HouseId);
            return View(wUserPaymoney);
        }

        // GET: UserPaymoneys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WUserPaymoneys == null)
            {
                return NotFound();
            }

            var wUserPaymoney = await _context.WUserPaymoneys.FindAsync(id);
            if (wUserPaymoney == null)
            {
                return NotFound();
            }
            ViewData["ById"] = new SelectList(_context.WAdmins, "Id", "Id", wUserPaymoney.ById);
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Id", wUserPaymoney.HouseId);
            return View(wUserPaymoney);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HouseId,Number,Price,ShouldPay,RealyPay,NoPay,StartPayTime,ById,Title")] WUserPaymoney wUserPaymoney)
        {
            if (id != wUserPaymoney.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wUserPaymoney);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WUserPaymoneyExists(wUserPaymoney.Id))
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
            ViewData["ById"] = new SelectList(_context.WAdmins, "Id", "Id", wUserPaymoney.ById);
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Id", wUserPaymoney.HouseId);
            return View(wUserPaymoney);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (_context.WUserPaymoneys == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WUserPaymoneys'  is null.");
            }
            var wUserPaymoney = await _context.WUserPaymoneys.FindAsync(id);
            if (wUserPaymoney != null)
            {
                _context.WUserPaymoneys.Remove(wUserPaymoney);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WUserPaymoneyExists(int id)
        {
          return (_context.WUserPaymoneys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
