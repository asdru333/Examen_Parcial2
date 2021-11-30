using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Examen_Parcial2.Models
{
    public class ComboModel: ComestibleModel
    { 
        [Display(Name = "Pizza")]
        [Required(ErrorMessage = "Es necesario que ingrese el nombre de la pizza")]
        public string pizza{ get; set; }

        [Display(Name = "Bebida")]
        [Required(ErrorMessage = "Es necesario que ingrese el nombre de la pizza")]
        public string bebida { get; set; }

        [Display(Name = "Acompanante")]
        [Required(ErrorMessage = "Es necesario que ingrese el nombre de la pizza")]
        public string acompanante { get; set; }
    }
}