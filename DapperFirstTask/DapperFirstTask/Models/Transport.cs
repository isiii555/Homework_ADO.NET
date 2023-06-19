using DapperFirstTask.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperFirstTask.Models
{
    public class Transport : BaseEntity
    {
        public string TransportName { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id} {TransportName}";
        }
    }
}
