using AccentureAcademyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademyLibrary.Controllers
{
    public class AutorController : Controller
    {
        AccentureAcademyBooksEntities db = new AccentureAcademyBooksEntities();

        public ActionResult JsonListar()
        {
            var autores = db.Autores.Select(aut => new {

                Id = aut.Id,
                Apellido = aut.Apellido,
                Nombre = aut.Nombre,
                Nacionalidad = aut.Nacionalidad,
                AnioNacimiento = aut.AñoNacimiento,
                AnioFallecimiento = aut.AñoFallecimiento

            }).ToList();
            return Json(autores, JsonRequestBehavior.AllowGet);
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
        public ActionResult Agregar(Autores autor)
        {
            db.Autores.Add(autor);
            db.SaveChanges();

            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            Autores autor = db.Autores.Find(id);
            return View(autor);
        }

        [HttpPost]
        public ActionResult Editar(Autores autor)
        {

            Autores author = db.Autores.Find(autor.Id);
            author.Apellido = autor.Apellido;
            author.Nombre = autor.Nombre;
            author.Nacionalidad = autor.Nacionalidad;
            author.AñoNacimiento = autor.AñoNacimiento;
            author.AñoFallecimiento = autor.AñoFallecimiento;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {

            this.ViewBag.Titulo = "Eliminar Libro";
            Autores autor = this.db.Autores.Find(id);
            var librosEliminar = autor.Libros.ToList();

            foreach (var lib in librosEliminar)
            {
                var CantAutores = lib.Autores.ToList();
                if (CantAutores.Count() < 2)
                {
                    db.Libros.Remove(lib);
                }
            }
            this.db.Autores.Remove(autor);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}