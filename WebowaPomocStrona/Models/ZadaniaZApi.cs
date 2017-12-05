using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebowaPomocStrona.Models
{
    public class ZadaniaZApi
    {
        public string Temat { get; set; }
        public string Szczególy { get; set; }
        public int IdPrzedmiotu { get; set; }
        public string Termin { get; set; }
        public string IdUzytkownika { get; set; }
        public bool CzyZrobione { get; set; }
    }
}