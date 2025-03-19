using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string NameOfService { get; set; }

        [Required]
        public double Price { get; set; }

        public string? Description { get; set; }
    }
}
