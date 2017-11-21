using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebowaPomocStrona.Models
{
    public class ZadaniaDoApi
    {
        public string Temat { get; set; }
        public string Informacje { get; set; }
        public string NazwaZajec { get; set; }
        public DateTime? Termin { get; set; }
        public DateTime DataDodania { get; set; }
        public bool CzyZrobione { get; set; } = false;
        public string IdUzytkownika { get; set; }
    }
}