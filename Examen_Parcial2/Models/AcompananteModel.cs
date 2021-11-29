using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Examen_Parcial2.Models
{
    public class AcompananteModel: ComestibleModel
    { 
        [Display(Name = "Unidades")]
        [Required(ErrorMessage = "Es necesario que ingrese de cuantas unidades esta compuesto el acompañante")]
        public int unidades { get; set; }
    }
}