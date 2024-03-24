using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManageSystem.Models;
using System.Text;
using System.Text.Unicode;

namespace PropertyManageSystem.Controllers
{
    public class AdminController : Controller
    {

        WuyeProjectContext context = new WuyeProjectContext();

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 小区管理部分
        /// </summary>
        /// <returns></returns>
        /// 

        ///小区管理首页
        public IActionResult RoomIndex()
        {
            //获取一条数据
            WRoomInfo data = context.WRoomInfos.FirstOrDefault();

            //强视图返回
            return View(data);
        }

        //实现添加小区
        public ActionResult AddRoom()
        {
            return View();
        }

        //实现添加小区操作
        [HttpPost]
        public ActionResult AddRoom(WRoomInfo room)
        {
            context.WRoomInfos.Add(room);
            int result = context.SaveChanges();//记得保存！
            if (result > 0)
            {
                //保存成功
                return Content("<script>alert('信息保存成功！');window.location.href='/Admin/RoomIndex';</script>", contentType: "text/html" ,Encoding.UTF8);
            }
            else
            {
                ViewBag.notice = "信息保存失败！请重试。";
            }
            return View();
        }

        public ActionResult UpdateRoom()
        {
            //获取信息
            WRoomInfo data = context.WRoomInfos.FirstOrDefault();
            if (data == null)
            {
                //信息为空则无法编辑
                return Content("<script>alert('未找到需要编辑的小区信息，请先新增小区！');window.location.href='/Admin/AddRoom';</script>",contentType: "text/html" , Encoding.UTF8);
            }
            return View(data);//编辑前先获取信息，返回到视图
        }

        //实现编辑小区操作
        [HttpPost]
        public ActionResult UpdateRoom(WRoomInfo room)
        {
            //context.WRoomInfos.Update(room);
            context.Entry(room).State = EntityState.Modified;
            int result = context.SaveChanges();//记得保存！
            if (result > 0)
            {
                //保存成功
                return Content("<script>alert('编辑信息保存成功！');window.location.href='/Admin/RoomIndex';</script>" ,contentType: "text/html" , Encoding.UTF8);
            }
            else
            {
                ViewBag.notice = "编辑信息保存失败！请重试。";
            }
            return View();
        }
    }
}
