using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Oprettet")]
        public DateTime CreatedStamp { get; set; }

        [Required(ErrorMessage = "Oprettet af skal udfyldes")]
        [Display(Name = "Oprettet af")]
        public string CreatedBy { get; set; }

        [Display(Name = "Afsluttet")]
        public DateTime? DoneStamp { get; set; }

        [Required(ErrorMessage = "Opgavens beskrivelse skal udfyldes")]
        [UIHint("MultilineText")]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Display(Name = "Kommentar")]
        public string Comments { get; set; }

        public int? CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
