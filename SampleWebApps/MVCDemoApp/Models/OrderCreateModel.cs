﻿using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoApp.Models
{
    public class OrderCreateModel
    {
        public OrderModel Order { get; set; } = new OrderModel();
        public List<SelectListItem> FoodItens { get; set; } = new List<SelectListItem>();
    }
}
