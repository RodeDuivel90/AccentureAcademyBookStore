using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccentureAcademyLibrary.Models
{
    public class ListarViewModel
    {
        public string FiltroIsbn { get; set; }
        public string FiltroTitulo { get; set; }
        public int? FiltroAutor { get; set; }
        public int? FiltroGenero { get; set; }
        public int? FiltroEditorial { get; set; }
        public string FiltroIdioma { get; set; }
        public int? FiltroAnio { get; set; }

    }
}