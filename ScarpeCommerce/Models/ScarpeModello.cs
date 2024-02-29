using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScarpeCommerce.Models
{
    public class ScarpeModello
    {
        public string Nome { get; set; }
        public string Descrizione { get; set; }
     
        public string Copertina { get; set; }
        public decimal Prezzo { get; set; }

        public string AltreImg1File { get; set; }
        public string AltreImg2File { get; set; }

        public bool Disponibile { get; set; }



        public ScarpeModello() { }



       public ScarpeModello(string nome, string descrizione, string copertina, decimal prezzo, string altreImg1File, string altreImg2File, bool disponibile)
        {
           
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