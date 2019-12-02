using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccentureAcademyLibrary.Models
{
    class LibrosMetadata
    {
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Longitud incorrecta")]
        [Display(Name = "Isbn")]
        public string Isbn { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
        [Display(Name = "Título")]
        public string NombreLibro { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Longitud incorrecta")]
        [Display(Name = "Idioma")]
        public string Idioma { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(1, 2100, ErrorMessage = "Año incorrecto")]
        [Display(Name = "Año de Edición")]
        public int AñoEdicion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Autor")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autores> Autores { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Editorial")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Editoriales> Editoriales { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Género")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Generos> Generos { get; set; }
    }
    [MetadataType(typeof(LibrosMetadata))]
    public partial class Libros
    {


    }
}