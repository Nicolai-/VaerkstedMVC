using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repository.Concrete.Entities
{
    public class Customer
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kundens navn skal udfyldes")]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Display(Name = "Firmanavn")]
        public string Company { get; set; }

        [RegularExpression(@"^\d{8}$", ErrorMessage = "Ugyldigt telefon nummer")]
        [Required(ErrorMessage = "Kundens telefon nummber skal udfyldes")]
        [UIHint("PhoneNumber")]
        [Display(Name = "Telefon")]
        public int Phone { get; set; }

        public virtual IList<Car> Cars { get; private set; }
    }
}
