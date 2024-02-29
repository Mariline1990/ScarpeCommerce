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
                if (Copertina != null && Copertina.ContentLength > 0) //errore qui
                {
                    string _Copertina = Path.GetFileName(Copertina.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _Copertina);
                    
                    Copertina.SaveAs(_path);  // STO SALVANDO IL FILE DENTRO LA CARTELLA               
                }


                if (AltreImg1 != null && AltreImg1.ContentLength > 0)
                {
                    string _AltreImg1 = Path.GetFileName(AltreImg1.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _AltreImg1);
                    AltreImg1.SaveAs(_path);

                }

                if (AltreImg2 != null && AltreImg2.ContentLength > 0)
                {
                    string _AltreImg2 = Path.GetFileName(AltreImg2.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _AltreImg2);
                    AltreImg2.SaveAs(_path);
                }
                string query = "INSERT INTO Scarpe  (Nome, Descrizione , Copertina, Prezzo, Imm1, Imm2, Disponibile) VALUES ( @NomeProdotto, @DescrizioneDettagliata, @Copertina, @Prezzo, @AltreImg1, @AltreImg2, @Disponibile)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NomeProdotto", model.Nome);
                cmd.Parameters.AddWithValue("@DescrizioneDettagliata", model.Descrizione);
                cmd.Parameters.AddWithValue("@Copertina", model.Copertina);             
                cmd.Parameters.AddWithValue("@Prezzo", model.Prezzo);
                cmd.Parameters.AddWithValue("@AltreImg1", model.AltreImg1File);
                cmd.Parameters.AddWithValue("@AltreImg2", model.AltreImg2File);
                cmd.Parameters.AddWithValue("@Disponibile", model.Disponibile);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Errore nella richiesta SQL");
                return View(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index", "ScarpeModello");
        }
    }
}
