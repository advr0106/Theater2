using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Negocios;
using Capa_Servicios;

namespace Capa_Presentacion.Controllers
{
    public class AdminController : Controller
    {

        List<SelectListItem> DropDownlistGenero = Genero_N.ListarGenero().ConvertAll(c =>
        {
            return new SelectListItem()
            {
                Text = c.Nombre_Genero.ToString(),
                Value = c.Id.ToString(),
                Selected = false
            };
        }
        );

        List<SelectListItem> DropDownlistDirector = Director_N.ListarDirector().ConvertAll(c =>
        {
            return new SelectListItem()
            {
                Text = c.Nombre_Completo.ToString(),
                Value = c.Id.ToString(),
                Selected = false
            };
        }
     );

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.CantidadUsuarios = ConntarUsers();
            ViewBag.CantidadPeli = ConntarPelicula();
            ViewBag.CantidadPeli = ConntarDirector();
            ViewBag.genero = ConntarGenero();

            return View();
        }


        public ActionResult VerPelicula()
        {
            ViewBag.detalle = Pelicula_N.ListarPelicula().ToList();
            return View();
        }


        public ActionResult CrearPelicula()
        {
            ViewBag.ListaGenero = DropDownlistGenero;
            ViewBag.ListaDirector = DropDownlistDirector;
            return View();
        }
        [HttpPost]
        public ActionResult CrearPelicula(Pelicula pelicula)
        {
            try
            {
                Pelicula_N.InsertarPelicula(pelicula);
                return RedirectToAction("VerPelicula");
            }
            catch (Exception)
            {
                return View();
            }
        }

        //Delete Peliculas
        public ActionResult EliminarPelicula(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var Peli = Pelicula_N.GetPelicula(id.Value);
            return View(Peli);
        }
        [HttpPost]
        public ActionResult EliminarPelicula(int id)
        {

            try
            {
                Pelicula_N.EliminarPelicula(id);
                return RedirectToAction("VerPelicula");
            }
            catch
            {
                return View();
            }
        }


        //Edit 
        public ActionResult EditarPeli(int peli)
        {
            var pelibuscada = Pelicula_N.GetPelicula(peli);

            ViewBag.ListaGenero = DropDownlistGenero;
            ViewBag.ListaDirector = DropDownlistDirector;
            return View(pelibuscada);
        }
        
        [HttpPost]
        public ActionResult EditarPerli(Pelicula peli)
        {
            try
            {
                Pelicula_N.EditarPelicula(peli);
                return RedirectToAction("VerPelicula");
            }
            catch
             {
                return View();
            }
        }


        //Detalles
        public ActionResult DetallesPelicula(int id)
        {
            var Detalle = Pelicula_N.GetPelicula(id);
            ViewBag.ListaGenero = DropDownlistGenero;
            ViewBag.ListaDirector = DropDownlistDirector;
            return View(Detalle);
        }



        //Director
        public ActionResult VerDirector()
        {
            var director = Director_N.ListarDirector();
            return View(director);
        }
        public ActionResult CrearDirector()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearDirector(Director director)
        {
            try
            {
                Director_N.AgregarDirector(director);
                return RedirectToAction("VerDirector");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/EliminarDirector/5
        public ActionResult EliminarDirector(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var director = Director_N.GetDirector(id.Value);
            return View(director);
        }

        // POST: Admin/EliminarDirector/5
        [HttpPost]
        public ActionResult EliminarDirector(int id)
        {
            try
            {
                Director_N.EliminarDirector(id);
                return RedirectToAction("VerDirector");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public ActionResult EditarDirector(int id)
        {
            var DirectorEditar = Director_N.GetDirector(id);
            return View(DirectorEditar);
        }

        [HttpPost]
        public ActionResult EditarDirector(Director licencia)
        {
            try
            {
                Director_N.EditarDirector(licencia);

                return RedirectToAction("VerDirector");
            }
            catch
            {
                return View();
            }
        }

        //Metodos
        public int ConntarUsers()
        {
            List<int?> pp = Listar_Pelicula.ContarUsuarios().ToList();
            int s = 0;
            foreach (int i in pp)
            {
                s = i;
            }
            return s;
        }
        public int ConntarPelicula()
        {
            List<int?> pp = Listar_Pelicula.Contpelicula().ToList();
            int s = 0;
            foreach (int i in pp)
            {
                s = i;
            }
            return s;
        }
        public int ConntarGenero()
        {
            List<int?> pp = Listar_Pelicula.Contargenero().ToList();
            int s = 0;
            foreach (int i in pp)
            {
                s = i;
            }
            return s;
        }
        public int ConntarDirector()
        {
            List<int?> pp = Listar_Pelicula.ContarDirector().ToList();
            int s = 0;
            foreach (int i in pp)
            {
                s = i;
            }
            return s;
        }
    }
}