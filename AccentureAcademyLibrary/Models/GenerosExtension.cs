using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccentureAcademyLibrary.Models
{
    [MetadataType(typeof(GenerosMetadata))]
    public partial class Generos
    {
        class GenerosMetadata
        {
            [Required(ErrorMessage = "Campo requerido")]
            [StringLength(40, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
            [Display(Name = "Género")]
            public string NombreGenero { get; set; }
        }
    }
}