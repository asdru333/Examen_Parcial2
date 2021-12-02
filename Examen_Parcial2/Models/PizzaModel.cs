using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Examen_Parcial2.Models
{
    public class PizzaModel: ComestibleModel
    {
        [Display(Name = "Salsa")]
        [Required(ErrorMessage = "Es necesario que ingrese el tipo de salsa de la pizza")]
        public string salsa { get; set; }

        [Display(Name = "Ingredientes")]
        public IList<string> ingredientes { get; set; }

        public PizzaModel()
        {
            ingredientes = new List<string>();
        }
    }
}