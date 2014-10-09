using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Display(Name = "Oprettet")]
        public DateTime CreatedStamp { get; set; }

        [Display(Name = "Oprettet af")]
        public string CreatedBy { get; set; }

        [Display(Name = "Afsluttet")]
        public DateTime? DoneStamp { get; set; }

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Display(Name = "Kommentar")]
        public string Comments { get; set; }

        public int? CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
