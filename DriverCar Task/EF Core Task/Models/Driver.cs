using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Task.Models
{
    public class Driver : BaseEntity
    {

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public int CarId { get; set; }

        public Car Car { get; set; } = null!;
    }
}
