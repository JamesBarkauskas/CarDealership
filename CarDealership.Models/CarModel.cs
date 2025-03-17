using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Engine { get; set; }

        [Required]
        public string Trim { get; set; }

        public string? Description { get; set; }

        [DisplayName("Car Make")]
        public int CarMakeId { get; set; }  // FK

        [ForeignKey("CarMakeId")]
        [ValidateNever]
        public CarMake CarMake { get; set; }    // Nav property
    }
}
