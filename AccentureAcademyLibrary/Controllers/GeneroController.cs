using AccentureAcademyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademyLibrary.Controllers
{
    public class GeneroController : Controller
    {
        AccentureAcademyBooksEntities db = new AccentureAcademyBooksEntities();

        public ActionResult JsonListar()
        {
            var generos = db.Generos.Select(gen => new {

                Id = gen.Id,
                NombreGenero = gen.NombreGenero,

            }).ToList();
            return Json(generos, JsonRequestBehavior.AllowGet);
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
        public ActionResult Agregar(Generos genero)
        {
            db.Generos.Add(genero);
            db.SaveChanges();

            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            Generos genero = db.Generos.Find(id);
            return View(genero);
        }

        [HttpPost]
        public ActionResult Editar(Generos genero)
        {

            Generos genre = db.Generos.Find(genero.Id);
            genre.NombreGenero = genero.NombreGenero;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {

            this.ViewBag.Titulo = "Eliminar Libro";
            Generos genero = this.db.Generos.Find(id);
            var librosEliminar = genero.Libros.ToList();
            foreach (var lib in librosEliminar)
            {
                db.Libros.Remove(lib);
            }
            this.db.Generos.Remove(genero);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}