using BackEnd.BLL;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {



        private IUserBLL userBLL;

        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Autherize(UserViewModel userModel)
        {

            userBLL = new UserBLLImpl();
            var userDetails = userBLL.getUser(userModel.UserName, userModel.Password);


            Session.Abandon();
            FormsAuthentication.SignOut();


            if (userDetails == null)
            {
                userModel.LoginErrorMessage = "Nombre de Usuario o Password Incorrectos";
                return View("Index", userModel);
            }
            else
            {

                Session["userID"] = userDetails.UserId;
                Session["userName"] = userDetails.UserName;
                var authTicket = new FormsAuthenticationTicket(userDetails.UserName, true, 100000);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                            FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);
                var name = User.Identity.Name; // line 4
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            //int userId = (int)Session["userID"];
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}