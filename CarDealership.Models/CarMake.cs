using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarMake
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Car Make")]
        public string Name { get; set; }
    }
}
