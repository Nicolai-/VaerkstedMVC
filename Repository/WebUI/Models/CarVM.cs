using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class CarVM
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        [RegularExpression(@"(?i)^[a-z]{2}\d{5}$", ErrorMessage = "Ugyldig nummer plade")]
        [Display(Name = "Nummer plade")]
        public string PlateNumber { get; set; }

        [Display(Name = "Stel nr")]
        public string ChassisNumber { get; set; }

        [Required(ErrorMessage = "Bilens model skal udfyldes")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Bilens mærke skal udfyldes")]
        [Display(Name = "Bil mærke")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Bilens årgang skal udfyldes")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Ugyldigt årstal")]
        [Display(Name = "Årgang")]
        public int Year { get; set; }
    }
}