using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_Portfolio.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        [HttpGet] 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            var values = db.TblAdmin.FirstOrDefault(x=>x.AdminName== admin.AdminName && x.AdminPassword==admin.AdminPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.AdminName, false);
                Session["AdminName"] = values.AdminName.ToString();
                return RedirectToAction("Index", "Message");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}