using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_Parcial2.Models;
using Examen_Parcial2.Handlers;


namespace Examen_Parcial2.Controllers
{
    public class PedidoController : Controller
    {
        [HttpGet]
        public ActionResult recoger(string nombre)
        {
            ComestibleHandler accesoDatos = new ComestibleHandler();
            ComestibleModel comestible = accesoDatos.obtenerComestible(nombre);
            ViewBag.nombreComestible = comestible.nombre;
            ViewBag.precio = comestible.precio;
            return View();
        }

        [HttpPost]
        public ActionResult recoger(PedidoModel pedido)
        {
            PedidoHandler accesoDatos = new PedidoHandler();
            pedido.nombreComestible = Request.Form["nombreComestible"];
            pedido.precio = Double.Parse(Request.Form["precioComestible"]);
            pedido.direccion = "";
            ViewBag.nombreComestible = pedido.nombreComestible;
            ViewBag.precio = pedido.precio;
            ViewBag.exitoAlInscribir = false;
            try
            {
                ViewBag.exitoAlInscribir = accesoDatos.agregarPedido(pedido);
                if (ViewBag.exitoAlInscribir)
                {
                    ViewBag.Message = "El pedido fue realizado con exito";
                    ModelState.Clear();
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult llevar(string nombre)
        {
            ComestibleHandler accesoDatos = new ComestibleHandler();
            ComestibleModel comestible = accesoDatos.obtenerComestible(nombre);
            ViewBag.nombreComestible = comestible.nombre;
            ViewBag.precio = comestible.precio;
            return View();
        }

        [HttpPost]
        public ActionResult llevar(PedidoModel pedido)
        {
            PedidoHandler accesoDatos = new PedidoHandler();
            pedido.nombreComestible = Request.Form["nombreComestible"];
            pedido.precio = Double.Parse(Request.Form["precioComestible"]);
            ViewBag.nombreComestible = pedido.nombreComestible;
            ViewBag.precio = pedido.precio;
            ViewBag.exitoAlInscribir = false;
            try
            {
                ViewBag.exitoAlInscribir = accesoDatos.agregarPedido(pedido);
                if (ViewBag.exitoAlInscribir)
                {
                    ViewBag.Message = "El pedido fue realizado con exito";
                    ModelState.Clear();
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal.";
                return View();
            }
        }
    }
}