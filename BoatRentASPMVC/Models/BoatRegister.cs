using System;
using System.Collections.Generic;

namespace BoatRentASPMVC.Models
{
    public partial class BoatRegister
    {
        public int Id { get; set; }
        public string BoatName { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public int HourlyRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
