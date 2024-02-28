// ScarpeModelloController.cs

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ScarpeCommerce.Models;

namespace ScarpeCommerce.Controllers
{
    public class ScarpeModelloController : Controller
    {
        // ... altri metodi del controller



        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ScarpeModello model, HttpPostedFileBase Copertina, HttpPostedFileBase AltreImg1, HttpPostedFileBase AltreImg2)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionScarpe"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                // Salvataggio delle immagini sul server
                if (Copertina != null && Copertina.ContentLength > 0)
                {
                    string _File = Path.GetFileName(Copertina.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _File);
                    Copertina.SaveAs(_path);
                    
                }

                
                string query = "INSERT INTO Scarpe (Nome, Descrizione , Copertina, Prezzo, Imm1, Imm2, Disponibile) " +
                               "VALUES (@NomeProdotto, @Prezzo, @DescrizioneDettagliata, @Copertina, @AltreImg1, @AltreImg2, @Disponibile)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NomeProdotto", model.Nome);
                cmd.Parameters.AddWithValue("@Prezzo", model.Prezzo);
                cmd.Parameters.AddWithValue("@DescrizioneDettagliata", model.Descrizione);
                cmd.Parameters.AddWithValue("@Copertina", model.Copertina);
           
                cmd.Parameters.AddWithValue("@Disponibile", model.Disponibile);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Errore nella richiesta SQL");
                ViewBag.Message = "Si è verificato un errore di connessione durante l'inserimento: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index", "ScarpeModello");
        }
    }
}
