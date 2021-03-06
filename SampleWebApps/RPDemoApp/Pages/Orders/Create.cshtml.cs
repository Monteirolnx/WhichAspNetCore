﻿using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPDemoApp.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public List<SelectListItem> FoodItens { get; set; }

        [BindProperty]
        public OrderModel Order { get; set; }

        public CreateModel(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }

        public async Task OnGet()
        {
            List<FoodModel> food = await _foodData.GetFood();

            FoodItens = new List<SelectListItem>();

            food.ForEach(f =>
            {
                FoodItens.Add(new SelectListItem { Value = f.Id.ToString(), Text = f.Title });
            });
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            List<FoodModel> food = await _foodData.GetFood();
            Order.Total = Order.Quantity * food.Where(x => x.Id == Order.FoodId).First().Price;

            int id = await _orderData.CreateOrder(Order);

            return RedirectToPage("./Display", new { Id = id});
        }
    }
}