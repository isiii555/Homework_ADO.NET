using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Task.Models
{
    public class Car : BaseEntity
    {
        public string SerialNumber { get; set; } = null!;

        public string Vendor { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int SeatCount { get; set; }

        public Driver Driver { get; set; } = null!;
    }
}
