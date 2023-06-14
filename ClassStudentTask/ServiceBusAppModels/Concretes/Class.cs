using ServiceBusApp.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Models.Concretes
{
    public class Class : BaseEntity
    {
        public string Name { get; set; } = null!;
        public IEnumerable<Student>? Students { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
