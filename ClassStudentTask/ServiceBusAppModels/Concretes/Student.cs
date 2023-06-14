using ServiceBusApp.Models.Abstracts;
using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Models.Concretes
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string ParentName { get; set; } = null!;

        public int ClassId { get; set; }

        public Class Class { get; set; } = null!;

    }
}
