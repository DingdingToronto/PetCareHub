using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetCareHub.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public string AppointmentTitle { get; set; }
        public string AppointmentDescription { get; set; } 
        public DateTime AppointmentDate { get; set; }


        // an appointment can be taken by many vet

        public ICollection<Veteran> Veterans { get; set; }

    }
}