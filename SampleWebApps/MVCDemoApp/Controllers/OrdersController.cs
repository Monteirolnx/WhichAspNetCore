using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDemoApp.Models;

namespace MVCDemoApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public OrdersController(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            //Envia a model para a view, porém preenchemos a lista de food para criar o combo.
            List<FoodModel> food = await _foodData.GetFood();

            OrderCreateModel model = new OrderCreateModel();

            food.ForEach(x =>
            {
                model.FoodItens.Add(new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                });
            });

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderModel order)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            //Cálculo
            List<FoodModel> food = await _foodData.GetFood();
            order.Total = order.Quantity * food.Where(x => x.Id == order.FoodId).First().Price;

            int id = await _orderData.CreateOrder(order);

            return RedirectToAction("Create");
        }
    }
}
