using AccentureAcademyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademyLibrary.Controllers
{
    public class LibroController : Controller
    {
        AccentureAcademyBooksEntities db = new AccentureAcademyBooksEntities();

        public ActionResult JsonListar()
        {

            
            var books = db.Libros.ToList();

            var librosFiltro = books.Select(lib => new {

                Id = lib.Id,
                Isbn = lib.Isbn,
                Titulo = lib.NombreLibro,
                ApellidoAutor = lib.Autores.Select(aut => aut.Apellido),
                EditorialLibro = lib.Editoriales.Select(ed => ed.NombreEditorial),
                GeneroLibro = lib.Generos.Select(gen => gen.NombreGenero),
                Idioma = lib.Idioma,
                Anio = lib.AñoEdicion


            }).ToList();
            return Json(librosFiltro, JsonRequestBehavior.AllowGet);
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
        public ActionResult Agregar(Libros libro, IEnumerable<int> autores, IEnumerable<int> editoriales, IEnumerable<int> generos)
        {

            foreach (int autorActual in autores)
            {
                Autores autor = db.Autores.Find(autorActual);
                libro.Autores.Add(autor);
            }

            foreach (int editorialActual in editoriales)
            {
                Editoriales editorial = db.Editoriales.Find(editorialActual);
                libro.Editoriales.Add(editorial);
            }

            foreach (int generoActual in generos)
            {
                Generos genero = db.Generos.Find(generoActual);
                libro.Generos.Add(genero);
            }

            db.Libros.Add(libro);
            db.SaveChanges();

            return RedirectToAction("JsonListar");
        }

        public ActionResult Editar(int id)
        {
            Libros book = db.Libros.Find(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Editar(Libros book, IEnumerable<int> autores, IEnumerable<int> editoriales, IEnumerable<int> generos)
        {

            Libros libro = db.Libros.Find(book.Id);
            libro.NombreLibro = book.NombreLibro;
            libro.Isbn = book.Isbn;
            libro.Idioma = book.Idioma;
            libro.AñoEdicion = book.AñoEdicion;
            libro.Autores.Clear();
            libro.Generos.Clear();
            libro.Editoriales.Clear();

            foreach (int autorActual in autores)
            {
                Autores escritoPor = db.Autores.Find(autorActual);
                libro.Autores.Add(escritoPor);
            }

            foreach (int generoActual in generos)
            {
                Generos g = db.Generos.Find(generoActual);
                libro.Generos.Add(g);
            }

            foreach (int editorialActual in editoriales)
            {
                Editoriales e = db.Editoriales.Find(editorialActual);
                libro.Editoriales.Add(e);
            }


            

                this.db.SaveChanges();
                return RedirectToAction("Listar");
            
           

        }




        








        public ActionResult Eliminar(int id)
        {
            this.ViewBag.Titulo = "Eliminar Libro";
            Libros libro = this.db.Libros.Find(id);
            this.db.Libros.Remove(libro);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

    }
}





