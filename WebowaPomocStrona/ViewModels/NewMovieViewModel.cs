using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebowaPomocStrona.Models;

namespace WebowaPomocStrona.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Zajecia> zajecia { get; set; }
        public Zadanie zadanie { get; set; }
    }
}