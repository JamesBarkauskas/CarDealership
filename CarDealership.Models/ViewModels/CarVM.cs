﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.ViewModels
{
    public class CarVM
    {
        public Car Car { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CarModelList { get; set; }
    }
}
