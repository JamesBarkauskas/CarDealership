using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Car
    {
        public int Id { get; set; }

        [DisplayName("Car Model")]
        public int CarModelId { get; set; }    // FK

        [ValidateNever]
        [ForeignKey("CarModelId")]
        public CarModel CarModel { get; set; }  // nav property, what we include in 'includeProperties'

        public int MSRP { get; set; }
        public int OurPrice { get; set; }
        public string StockNumber { get; set; }
        public string VIN { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public int Miles { get; set; }
        public string Drivetrain { get; set; }
        public string? ImageUrl { get; set; }
        public bool? Used { get; set; }
    }
}
