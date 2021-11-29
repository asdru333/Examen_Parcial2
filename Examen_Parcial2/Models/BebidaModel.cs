using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Examen_Parcial2.Models
{
    public class BebidaModel: ComestibleModel
    {
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Es necesario que ingrese la categoria de la bebida")]
        public string categoriaBebida { get; set; }

        [Display(Name = "Litros")]
        [Required(ErrorMessage = "Es necesario que ingrese los litros que contiene la bebida")]
        public double litros { get; set; }
    }
}