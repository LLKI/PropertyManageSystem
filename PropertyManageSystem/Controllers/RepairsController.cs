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
    public class RepairsController : Controller
    {
        private readonly WuyeProjectContext _context;

        public RepairsController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: Repairs
        public async Task<IActionResult> Index()
        {
            var wuyeProjectContext = _context.WRepairs.Include(w => w.Danyuan).Include(w => w.House).Include(w => w.Louyu).Include(w => w.UidNavigation);
            return View(await wuyeProjectContext.ToListAsync());
        }


        // GET: Repairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WRepairs == null)
            {
                return NotFound();
            }

            var wRepair = await _context.WRepairs.FindAsync(id);
            if (wRepair == null)
            {
                return NotFound();
            }
            ViewData["DanyuanId"] = new SelectList(_context.WSystemParams, "Id", "Id", wRepair.DanyuanId);
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Id", wRepair.HouseId);
            ViewData["LouyuId"] = new SelectList(_context.WBuildings, "Id", "Id", wRepair.LouyuId);
            ViewData["Uid"] = new SelectList(_context.WUsers, "Id", "Id", wRepair.Uid);
            return View(wRepair);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,State,FinalyRepairUser,RepairWorkInfo,MainRepairUser,RepairPhone,PassDetail,RepeatInfo")] WRepair wRepair)
        {
            if (id != wRepair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    WRepair repair = _context.WRepairs.Where(p => p.Id == wRepair.Id).FirstOrDefault();
                    //修改部分字段
                    repair.State=wRepair.State;
                    repair.FinalyRepairUser = wRepair.FinalyRepairUser;
                    repair.RepairWorkInfo = wRepair.RepairWorkInfo;
                    repair.MainRepairUser = wRepair.MainRepairUser;
                    repair.RepairPhone= wRepair.RepairPhone;
                    repair.PassDetail= wRepair.PassDetail;
                    repair.RepeatInfo= wRepair.RepeatInfo;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WRepairExists(wRepair.Id))
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
            ViewData["DanyuanId"] = new SelectList(_context.WSystemParams, "Id", "Id", wRepair.DanyuanId);
            ViewData["HouseId"] = new SelectList(_context.WHouses, "Id", "Id", wRepair.HouseId);
            ViewData["LouyuId"] = new SelectList(_context.WBuildings, "Id", "Id", wRepair.LouyuId);
            ViewData["Uid"] = new SelectList(_context.WUsers, "Id", "Id", wRepair.Uid);
            return View(wRepair);
        }

        //直接审核操作
        public ActionResult EditState(int id)
        {
            if(id!=null)
            {
                //获取当前申请报修的信息
                WRepair repair = _context.WRepairs.Where(p=>p.Id==id).FirstOrDefault();
                //若此时是未审核，可直接通过审核
                if(repair.State==0)
                {
                    repair.State = 1;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content("<script>alert('当前状态，不支持通过审核！');location.href='/Repair/Index';</script>");
                }
            }
            
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.WRepairs == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WRepairs'  is null.");
            }
            var wRepair = await _context.WRepairs.FindAsync(id);
            if (wRepair != null)
            {
                _context.WRepairs.Remove(wRepair);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WRepairExists(int id)
        {
          return (_context.WRepairs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
