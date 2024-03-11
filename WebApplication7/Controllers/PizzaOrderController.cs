using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using System;

namespace WebApplication7.Controllers
{
    public class PizzaOrderController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmOrder(User user)
        {
            if (IsValidUser(user))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult ProcessOrder(Product[] products)
        {
            if (IsInvalidProducts(products))
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                DisplayProductDetails(products);
                return View(products);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool IsValidUser(User user)
        {
            return user.Age > 16;
        }

        private bool IsInvalidProducts(Product[] products)
        {
            return products == null || products.Length == 0;
        }

        private void DisplayProductDetails(Product[] products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }
    }
}
