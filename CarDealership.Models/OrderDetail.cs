using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class OrderDetail
    {
        // details about the order like what was ordered
        public int Id { get; set; }

        [Required]
        public int OrderHeaderId { get; set; }  // each orderDetail will belong to an orderHeader..
        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        [ValidateNever]
        public Service Service { get; set; }

        public double Price { get; set; }
    }
}
