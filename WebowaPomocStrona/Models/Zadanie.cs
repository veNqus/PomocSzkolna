using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebowaPomocStrona.Models
{
    public class Zadanie
    {
        public int Id { get; set; }
        public string Temat { get; set; }
        public string Informacje { get; set; }
        public Zajecia Zajecia { get; set; }

        [Display(Name = "Nazwa przedmiotu")]
        public int ZajeciaId { get; set; }

        //public int IdZajec { get; set; }

        [Display(Name = "Termin Zadania")]
        public DateTime? Termin { get; set; }

        [Display(Name = "Data Dodania")]
        public DateTime DataDodania { get; set; }

        [Display(Name = "Czy Zrobione?")]
        public bool CzyZrobione { get; set; } = false;

        public string IdUzytkownika { get; set; }
    }
}