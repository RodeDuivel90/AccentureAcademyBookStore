using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccentureAcademyLibrary.Models
{
    [MetadataType(typeof(AutoresMetadata))]
    public partial class Autores
    {
        class AutoresMetadata
        {
            [Required(ErrorMessage = "Campo requerido")]
            [StringLength(30, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
            [Display(Name = "Apellido")]
            public string Apellido { get; set; }
            [Required(ErrorMessage = "Campo requerido")]
            [StringLength(50, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
            [Display(Name = "Nombre")]
            public string Nombre { get; set; }
            [Required(ErrorMessage = "Campo requerido")]
            [StringLength(40, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
            [Display(Name = "Nacionalidad")]
            public string Nacionalidad { get; set; }
            [Required(ErrorMessage = "Campo requerido")]
            [Range(1, 2100, ErrorMessage = "Año incorrecto")]
            [Display(Name = "Año de Nacimiento")]
            public int AñoNacimiento { get; set; }
            [Range(1, 2100, ErrorMessage = "Año incorrecto")]
            [Display(Name = "Año de Fallecimiento")]
            public Nullable<int> AñoFallecimiento { get; set; }
        }
    }
}