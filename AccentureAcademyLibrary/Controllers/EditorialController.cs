using AccentureAcademyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademyLibrary.Controllers
{
    public class EditorialController : Controller
    {

        AccentureAcademyBooksEntities db = new AccentureAcademyBooksEntities();

        public ActionResult JsonListar()
        {
            var editoriales = db.Editoriales.Select(edi => new {

                Id = edi.Id,
                NombreEditorial = edi.NombreEditorial,
                Pais = edi.Pais,
                Website = edi.Website,

            }).ToList();
            return Json(editoriales, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            return View("Editar");
        }


        [HttpPost]
        public ActionResult Agregar(Editoriales editorial)
        {
            db.Editoriales.Add(editorial);
            db.SaveChanges();

            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            Editoriales editorial = db.Editoriales.Find(id);
            return View(editorial);
        }

        [HttpPost]
        public ActionResult Editar(Editoriales editorial)
        {

            Editoriales publisher = db.Editoriales.Find(editorial.Id);
            publisher.NombreEditorial = editorial.NombreEditorial;
            publisher.Pais = editorial.Pais;
            publisher.Website = editorial.Website;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {

            this.ViewBag.Titulo = "Eliminar Libro";
            Editoriales editorial = this.db.Editoriales.Find(id);
            var librosEliminar = editorial.Libros.ToList();
            foreach (var lib in librosEliminar)
            {
                db.Libros.Remove(lib);
            }
            this.db.Editoriales.Remove(editorial);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}