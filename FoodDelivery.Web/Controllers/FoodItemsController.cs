using System;
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

namespace FoodDelivery.Web.Controllers
{
    public class FoodItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFoodItemService _foodItemService;
        private readonly IRepository<RestaurantFoodItem> _Repository;

        public FoodItemsController(ApplicationDbContext context, IFoodItemService foodItemService, IRepository<RestaurantFoodItem> repository)
        {
            _context = context;
            _foodItemService = foodItemService;
            _Repository = repository;
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
        public IActionResult Create([Bind("Name,Price,Description,Image,Id")] FoodItem foodItem)
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
        public IActionResult Edit(Guid id, [Bind("Name,Price,Description,Image,Id")] FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _foodItemService.UpdateFoodItem(foodItem);
                //return RedirectToAction(nameof(Index));
                var restaurantId = _context.RestaurantFoodItems
                    .Where(rfi => rfi.FoodItemId == foodItem.Id)
                    .Select(rfi => rfi.RestaurantId)
                    .FirstOrDefault();

                return RedirectToAction("Details", "Restaurants", new { id = restaurantId });
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
            _foodItemService.DeleteFoodItem(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FoodItemExists(Guid id)
        {
            return _foodItemService.GetFoodItemById(id) != null;
        }
    }
}
