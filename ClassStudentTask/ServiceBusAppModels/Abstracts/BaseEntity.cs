using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Models.Abstracts
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } 
        public DateTime LastModifiedTime { get; set; }
    }
}
