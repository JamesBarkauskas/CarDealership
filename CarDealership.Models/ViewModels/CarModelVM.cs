using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.ViewModels
{
    public class CarModelVM
    {
        // use VMs for when we need additional information for a specific view...
        public CarModel CarModel { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CarMakeList { get; set; }    // gives a drop down of available makes..
    }
}
