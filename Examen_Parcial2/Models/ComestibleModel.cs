using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Examen_Parcial2.Models
{
    public class ComestibleModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Es necesario que ingrese el nombre del comestible")]
        public string nombre { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Es necesario que ingrese el precio del comestible")]
        public double precio { get; set; }

        [Display(Name = "Foto del funcionario")]
        [Required(ErrorMessage = "Es necesario que ingrese la foto del comestible")]
        public HttpPostedFileBase fotoArchivo { get; set; }

        public string fotoTipo { get; set; }
    }
}