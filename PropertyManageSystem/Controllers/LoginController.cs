using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManageSystem.Models;
namespace PropertyManageSystem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("NickName")==null)
            //{
            //    return Redirect("/Login/Index");
            //}
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.notice = "账号或密码不能为空！";
                return View();
            }
            else
            {
                //判断用户是否存在
                using (var context = new WuyeProjectContext())
                {
                    WAdmin data = context.WAdmins.FirstOrDefault(p => p.UserName == username);
                    if (data == null)
                    {
                        ViewBag.notice = "用户不存在！";
                    }
                    else if (data.Pass != password)
                    {
                        ViewBag.notice = "密码错误！";
                    }
                    else
                    {
                        //登录成功
                        //跳转到路径 普通用户跳转到前台页面 管理员用户跳转到后台页面
                        HttpContext.Session.SetString("NickName", data.NickName);
                        Console.WriteLine(HttpContext.Session.GetString("NickName"));

                        return RedirectToAction("Index", "AdminController");
                    }
                }
            }
            return View();
        }
        public ActionResult LoginOut()
        {
            HttpContext.Session.SetString("NickName", "");
            return Redirect("/Login/Index");
        }
    }
}
