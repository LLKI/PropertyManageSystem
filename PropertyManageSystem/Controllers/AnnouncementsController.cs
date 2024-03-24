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
    public class AnnouncementsController : Controller
    {
        private readonly WuyeProjectContext _context;

        public AnnouncementsController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            var wuyeProjectContext = _context.WAnnouncements.Include(w => w.UidNavigation);
            return View(await wuyeProjectContext.OrderByDescending(p=>p.Createtime).ToListAsync());//时间倒序排列
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WAnnouncements == null)
            {
                return NotFound();
            }

            var wAnnouncement = await _context.WAnnouncements
                .Include(w => w.UidNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wAnnouncement == null)
            {
                return NotFound();
            }

            return View(wAnnouncement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            ViewData["Uid"] = new SelectList(_context.WAdmins, "Id", "Id");
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Title,Createtime,Contents,Uid,Nickname")] WAnnouncement wAnnouncement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wAnnouncement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Uid"] = new SelectList(_context.WAdmins, "Id", "Id", wAnnouncement.Uid);
            return View(wAnnouncement);
        }

        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WAnnouncements == null)
            {
                return NotFound();
            }

            var wAnnouncement = await _context.WAnnouncements.FindAsync(id);
            if (wAnnouncement == null)
            {
                return NotFound();
            }
            ViewData["Uid"] = new SelectList(_context.WAdmins, "Id", "Id", wAnnouncement.Uid);
            return View(wAnnouncement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Title,Createtime,Contents,Uid,Nickname")] WAnnouncement wAnnouncement)
        {
            if (id != wAnnouncement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wAnnouncement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WAnnouncementExists(wAnnouncement.Id))
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
            ViewData["Uid"] = new SelectList(_context.WAdmins, "Id", "Id", wAnnouncement.Uid);
            return View(wAnnouncement);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.WAnnouncements == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WAnnouncements'  is null.");
            }
            var wAnnouncement = await _context.WAnnouncements.FindAsync(id);
            if (wAnnouncement != null)
            {
                _context.WAnnouncements.Remove(wAnnouncement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WAnnouncementExists(int id)
        {
          return (_context.WAnnouncements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
