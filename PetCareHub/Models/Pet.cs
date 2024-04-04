using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetCareHub.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }
        public string PetType { get; set;}
        public int PetAge { get; set; }
        public bool PetAdoptionStatus { get; set; }

        // A pet belongs to one Veteran
        // a veteran can have many pets

       [ForeignKey("Veteran")]
        public int VeteranID { get; set; }

       public virtual Veteran Veteran { get; set; }

    }

    public class PetDto
    {
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }
        public string PetType { get; set; }
        public int PetAge { get; set; }
        public bool PetAdoptionStatus { get; set; }

        public string VeteranName { get; set; }

    }
}