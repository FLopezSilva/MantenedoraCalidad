using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MantenedoraCalidad.Models;
using System.Data.SqlClient;
using System.Web.Security;

namespace MantenedoraCalidad.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source = 10.130.14.248; Initial Catalog =NuevaQA; User ID = NRFT; Password = Nrft2019$";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USUARIO acc)
        {
            if (ModelState.IsValid)
            {
                using (NuevaQAEntities1 db = new NuevaQAEntities1())
                {
                    var obj = db.USUARIO.Where(a => a.rut_usuario.Equals(acc.rut_usuario) && a.contr_usuario.Equals(acc.contr_usuario)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["rut_usuario"] = obj.rut_usuario.ToString();
                        Session["nom_usuario"] = obj.nom_usuario.ToString();
                        Session["apell_usuario"] = obj.apell_usuario.ToString();
                        FormsAuthentication.SetAuthCookie(acc.rut_usuario, true);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login", new {  message = "No encontramos tus datos"});

                    }
                }
            }
            return View(acc);
        }
        //    if (!string.IsNullOrEmpty(acc.rut_usuario) && !string.IsNullOrEmpty(acc.contr_usuario))
        //    {
        //        connectionString();
        //        con.Open();
        //        com.Connection = con;
        //        com.CommandText = "select * from USUARIO where rut_usuario = '" + acc.rut_usuario + "' and contr_usuario = '" + acc.contr_usuario + "' and id_rol = 1;";
        //        dr = com.ExecuteReader();

        //        if (dr.Read())
        //        {
        //            con.Close();
        //            FormsAuthentication.SetAuthCookie(acc.rut_usuario, true);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            con.Close();
        //            return RedirectToAction("Login", new {  message = "No encontramos tus datos"});

        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", new { message = "Llene los campos correspondientes" });
        //    }

        //}

        public ActionResult UserDashBoard()
        {
            if (Session["rut_usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }


    }
}