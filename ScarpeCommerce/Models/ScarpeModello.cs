using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScarpeCommerce.Models
{
    public class ScarpeModello
    {
        public int ID_Prodotto { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
     
        public HttpPostedFileBase Copertina { get; set; }
        public string Prezzo { get; set; }
   
        public HttpPostedFileBase AltreImg1File { get; set; }
        public HttpPostedFileBase AltreImg2File { get; set; }

        public bool Disponibile { get; set; }

        public ScarpeModello() { }

       public ScarpeModello(int iD_Prodotto, string nome, string descrizione, HttpPostedFileBase copertina, string prezzo, HttpPostedFileBase altreImg1File, HttpPostedFileBase altreImg2File, bool disponibile)
        {
            ID_Prodotto = iD_Prodotto;
            Nome = nome;
            Descrizione = descrizione;
            Copertina = copertina;
            Prezzo = prezzo;
            AltreImg1File = altreImg1File;
            AltreImg2File = altreImg2File;
            Disponibile = disponibile;
        }
    }
}