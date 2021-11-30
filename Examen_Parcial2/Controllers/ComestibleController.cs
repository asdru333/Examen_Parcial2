using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_Parcial2.Models;
using Examen_Parcial2.Handlers;

namespace Examen_Parcial2.Controllers
{
    public class ComestibleController : Controller
    {
        public ActionResult listaComestibles()
        {
            ComestibleHandler accesoDatos = new ComestibleHandler();
            ViewBag.pizza = accesoDatos.obtenerPizzas();
            ViewBag.bebida = accesoDatos.obtenerBebidas();
            ViewBag.acompanante = accesoDatos.obtenerAcompanantes();
            return View();
        }

        [HttpGet]
        public ActionResult AgregarPizza()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPizza(PizzaModel pizza, string ingredientes)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ComestibleHandler accesoDatos = new ComestibleHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.agregarPizza(pizza);
                    if (ViewBag.ExitoAlCrear)
                    {
                        foreach (var variable in pizza.ingredientes)
                        {
                            accesoDatos.agregarIngredientes(pizza.nombre, variable);
                        }
                        ViewBag.Message = "La pizza " + pizza.nombre + " fue creada con éxito.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear la pizza";
                return View();
            }
        }

        [HttpGet]
        public ActionResult AgregarBebida()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarBebida(BebidaModel bebida)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ComestibleHandler accesoDatos = new ComestibleHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.agregarBebida(bebida);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "La bebida " + bebida.nombre + " fue creada con éxito.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear la bebida";
                return View();
            }
        }

        [HttpGet]
        public ActionResult AgregarAcompanante()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarAcompanante(AcompananteModel acompanante)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ComestibleHandler accesoDatos = new ComestibleHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.agregarAcompanante(acompanante);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El acompañante " + acompanante.nombre + " fue creado con éxito.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear el acompañante";
                return View();
            }
        }
    }
}