using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyManageSystem.Models;

namespace PropertyManageSystem.Controllers
{
    public class SystemController : Controller
    {
        private readonly WuyeProjectContext _context;

        public SystemController(WuyeProjectContext context)
        {
            _context = context;
        }

        // GET: System
        public async Task<IActionResult> Index( String type="")
        {
            IEnumerable<WSystemParam>list= await _context.WSystemParams.ToListAsync();
            //type不为空则查询
            if(!string.IsNullOrEmpty(type))
            {
                list = list.Where(p=>p.Type == type);
            }
            return View(list);
            //return _context.WSystemParams != null ?
            //            View(await _context.WSystemParams.ToListAsync()) :
            //            Problem("Entity set 'WuyeProjectContext.WSystemParams'  is null.");
        }

        // GET: System/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WSystemParams == null)
            {
                return NotFound();
            }

            var wSystemParam = await _context.WSystemParams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wSystemParam == null)
            {
                return NotFound();
            }

            return View(wSystemParam);
        }

        // GET: System/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: System/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Type")] WSystemParam wSystemParam)
        {

            _context.Add(wSystemParam);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                //保存成功
                return Content("<script>alert('系统参数保存成功！');window.location.href='/System/Index';</script>", contentType: "text/html", Encoding.UTF8);
            }
            else
            {
                ViewBag.notice = "系统参数保存失败！请重试。";
            }
            return RedirectToAction("Index");
        }

        // GET: System/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WSystemParams == null)
            {
                return NotFound();
            }

            var wSystemParam = await _context.WSystemParams.FindAsync(id);
            if (wSystemParam == null)
            {
                return NotFound();
            }
            return View(wSystemParam);
        }

        // POST: System/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Type")] WSystemParam wSystemParam)
        {
            if (id != wSystemParam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wSystemParam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WSystemParamExists(wSystemParam.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(wSystemParam);
        }


        // POST: System/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WSystemParams == null)
            {
                return Problem("Entity set 'WuyeProjectContext.WSystemParams'  is null.");
            }
            var wSystemParam = await _context.WSystemParams.FindAsync(id);
            if (wSystemParam != null)
            {
                _context.WSystemParams.Remove(wSystemParam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WSystemParamExists(int id)
        {
            return (_context.WSystemParams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
