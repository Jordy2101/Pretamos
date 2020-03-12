using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRESTAMOSYA.Models;
using System.Data.SqlClient;

namespace PRESTAMOSYA.Controllers
{
 
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand(); 
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source = LAPTOP-IGI5AAIF; database = PRESTAMOSYA; integrated security = SSPI";
        }

        [HttpPost]
        public ActionResult Verify(Empleado acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Empleados where Nombre_Empleado='"+acc.Nombre_Empleado+"' and Contraseña='"+acc.Contraseña+"'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return View("Index");
            }
            else
            {
                con.Close();
                return View("Error");
            }
         
           
        }

    }
}