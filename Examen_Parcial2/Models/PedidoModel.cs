using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Examen_Parcial2.Models
{
    public class PedidoModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "pedido")]
        public string nombreComestible { get; set; }

        [Display(Name = "Su nombre")]
        [Required(ErrorMessage = "Es necesario que ingrese su nombre")]
        public string nombreCliente { get; set; }

        [Display(Name = "Su apellido(s)")]
        [Required(ErrorMessage = "Es necesario que ingrese su apellido")]
         public string apellidoCliente { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Es necesario que ingrese su dirección")]
         public string direccion { get; set; }

        [Display(Name = "Precio")]
        public double precio { get; set; }
    }
}