using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCareHub.Models
{
    public class Veteran
    {
        public int VeteranId { get; set; }
        public string VeteranName { get; set; }
        public string VeteranPlace { get; set; }



        // veterans can make many appointments

        public ICollection<Appointment> Appointments { get; set; }
    }
    public class VeternDto
    {
        public int VeteranId { get; set; }
        public string VeteranName { get; set; }
        public string VeteranPlace { get; set; }
    }
}