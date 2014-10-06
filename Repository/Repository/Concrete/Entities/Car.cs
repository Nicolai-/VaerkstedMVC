using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete.Entities
{
    public class Car
    {
        public int Id { get; set; }

        public string PlateNumber { get; set; }

        public string ChassisNumber { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public int Year { get; set; }

        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
