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
using FoodDelivery.Domain.DTO;

namespace FoodDelivery.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IFoodItemService _foodItemService;

        public RestaurantsController(IRestaurantService restaurantService, IFoodItemService foodItemService)
        {
            _restaurantService = restaurantService;
            _foodItemService = foodItemService;
        }



        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            return View(_restaurantService.GetRestaurants());
        }

        // GET: Restaurants/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetRestaurantById(id);
            ShowFoodItemsInRestaurantDTO showFoodItemsInRestaurantDTO = new ShowFoodItemsInRestaurantDTO()
            {
                Restaurant = restaurant,
                FoodItemsInRestaurant = _foodItemService.ShowFoodItemsInRestaurant((Guid)id)
            };
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(showFoodItemsInRestaurantDTO);
        }

        public IActionResult AddFoodItemToRestaurant(Guid id)
        {
            AddFoodItemToRestaurantDTO addFoodItemToRestaurantDTO = new AddFoodItemToRestaurantDTO
            {
                RestaurantId = id
            };


            return View(addFoodItemToRestaurantDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFoodItemToRestaurant(AddFoodItemToRestaurantDTO addFoodItemToRestaurantDTO)
        {
            if (ModelState.IsValid)
            {
                _foodItemService.AddFoodItemToRestaurant(addFoodItemToRestaurantDTO);
                return RedirectToAction("Details", new {id = addFoodItemToRestaurantDTO.RestaurantId});
            }
            return View(addFoodItemToRestaurantDTO);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Address,PhoneNumber,Description,Image,Rating,Id")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _restaurantService.CreateNewRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Address,PhoneNumber,Description,Image,Rating,Id")] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _restaurantService.UpdateRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _restaurantService.DeleteRestaurant(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(Guid id)
        {
            return _restaurantService.GetRestaurantById(id) != null;
        }
    }
}
