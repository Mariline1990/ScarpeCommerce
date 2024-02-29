using ScarpeCommerce.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScarpeCommerce.Controllers
{
    public class HomeController : Controller
    {
        

        [HttpGet]
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionScarpe"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))

                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    conn.Open();

                 

                    cmd.CommandText = "SELECT * FROM Scarpe"; 
                    SqlDataReader reader = cmd.ExecuteReader();
                    Response.Write(reader);

                    List<ScarpeModello> ScarpaList = new List<ScarpeModello>();

                    while (reader.Read())
                    {

                        ScarpeModello Nuovascarpa = new ScarpeModello
                        {
                            Nome = reader["nome"].ToString(),
                            Descrizione = reader["Descrizione"].ToString(),
                            Copertina = reader["Copertina"].ToString(),
                            Prezzo = Convert.ToInt32(reader["Prezzo"]),
                            AltreImg1File = reader["Imm1"].ToString(),
                            AltreImg2File = reader["Imm2"].ToString(),
                            Disponibile = Convert.ToBoolean(reader["Disponibile"]),
                        };

                        ScarpaList.Add(Nuovascarpa);
                    }

                    return View(ScarpaList);
                }
                catch (Exception ex)
                {
                    return View("Error", ex);
                }

         
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}