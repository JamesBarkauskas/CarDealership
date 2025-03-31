using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }  // FK

        [ForeignKey("ServiceId")]
        [ValidateNever]
        public Service Service { get; set; }

        public string AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
