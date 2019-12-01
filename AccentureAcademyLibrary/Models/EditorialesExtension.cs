using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccentureAcademyLibrary.Models
{
    [MetadataType(typeof(EditorialesMetadata))]
    public partial class Editoriales
    {
        class EditorialesMetadata
        {
            [Required(ErrorMessage = "Campo requerido")]
            [StringLength(40, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
            [Display(Name = "Nombre de Editorial")]
            public string NombreEditorial { get; set; }

            [Required(ErrorMessage = "Campo requerido")]
            [StringLength(40, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
            [Display(Name = "Nombre del País de la Editorial")]
            public string Pais { get; set; }

            [Required(ErrorMessage = "Campo requerido")]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
            [Display(Name = "Sitio Web")]
            public string Website { get; set; }
        }
    }
}