using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyManageSystem.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace PropertyManageSystem.Controllers
{
    public class DevicesController : Controller
    {
        private readonly WuyeProjectContext _context;

        public DevicesController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index(String keyword="")
        {
            IEnumerable<WDevice> list = await _context.WDevices.OrderBy(p=>p.DeviceId).ToListAsync();
            //不为空则查询
            if (keyword != "")
            {
                //模糊查询
                list = list.Where(p => p.DeviceName.Contains(keyword));
            }
            return View(list);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,DeviceName,DeviceDesc,Createtime")] WDevice wDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wDevice);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WDevices == null)
            {
                return NotFound();
            }

            var wDevice = await _context.WDevices.FindAsync(id);
            if (wDevice == null)
            {
                return NotFound();
            }
            return View(wDevice);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,DeviceName,DeviceDesc,Createtime")] WDevice wDevice)
        {
            if (id != wDevice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WDeviceExists(wDevice.Id))
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
            return View(wDevice);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.WDevices == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WDevices'  is null.");
            }
            var wDevice = await _context.WDevices.FindAsync(id);
            if (wDevice != null)
            {
                _context.WDevices.Remove(wDevice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WDeviceExists(int id)
        {
          return (_context.WDevices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
