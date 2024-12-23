﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Repository;
using FoodDelivery.Service.Interface;
using FoodDelivery.Repository.Interface;
using System.Security.Claims;
using FoodDelivery.Domain.DTO;

namespace FoodDelivery.Web.Controllers
{
    public class FoodItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFoodItemService _foodItemService;
        private readonly IRestaurantService _restaurantService;
        private readonly IDeliveryService _deliveryService;

        public FoodItemsController(ApplicationDbContext context, IFoodItemService foodItemService, IRestaurantService restaurantService, IDeliveryService deliveryService)
        {
            _context = context;
            _foodItemService = foodItemService;
            _restaurantService = restaurantService;
            _deliveryService = deliveryService;
        }





        // GET: FoodItems
        public IActionResult Index()
        {
            return View(_foodItemService.GetFoodItems());
        }

        // GET: FoodItems/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = _foodItemService.GetFoodItemById(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        // GET: FoodItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Price,Description,Image,Category,Id")] FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                _foodItemService.CreateNewFoodItem(foodItem);
                return RedirectToAction(nameof(Index));
            }
            return View(foodItem);
        }

        // GET: FoodItems/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = _foodItemService.GetFoodItemById(id);
            if (foodItem == null)
            {
                return NotFound();
            }
            return View(foodItem);
        }

        // POST: FoodItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Price,Description,Image,Category,Id,TimeToPrepareMinutes,RestaurantId")] FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return NotFound();
            }
            if (foodItem?.RestaurantId == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                // Ensure the RestaurantId exists
                var restaurant = _restaurantService.GetRestaurantById(foodItem.RestaurantId);
                if (restaurant == null)
                {
                    ModelState.AddModelError("", "Invalid RestaurantId.");
                    return View(foodItem);
                }

                try
                {
                    _foodItemService.UpdateFoodItem(foodItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodItemExists(foodItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Restaurants", new { id = foodItem.RestaurantId });
            }
            return View(foodItem);
        }

        // GET: FoodItems/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = _foodItemService.GetFoodItemById(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        // POST: FoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            FoodItem foodItem = _foodItemService.GetFoodItemById(id);
            _foodItemService.DeleteFoodItem(id);
            return RedirectToAction("Details", "Restaurants", new { id = foodItem.RestaurantId });
        }
        public IActionResult AddFoodItemToDelivery(Guid Id)
        {
            var result = _deliveryService.GetFoodItemInfo(Id);
            if (result != null)
            {
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddFoodItemToDelivery(AddToDeliveryDTO model)
        {
            var restaurantID = _foodItemService.GetFoodItemById(model.SelectedFoodItemId).RestaurantId;

            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _deliveryService.AddFoodItemToDelivery(customerId, model);

            var refererURL = Request.Headers["Referer"].ToString();

            if (result != null)
            {
                //return RedirectToAction("Index", "DeliveryOrders");
                return RedirectToAction("Details", "Restaurants", new {id = restaurantID});
            }
            else { return View(model); }
        }

        private bool FoodItemExists(Guid id)
        {
            return _foodItemService.GetFoodItemById(id) != null;
        }
    }
}
