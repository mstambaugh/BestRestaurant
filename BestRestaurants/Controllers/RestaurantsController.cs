  
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
  public class RestaurantController : Controller
  {
    private readonly BestRestaurantContext _db;

    public RestaurantController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
        List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Type");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
        _db.Restaurants.Add(restaurant);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.Id == id);
        ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Type");
        return View(thisRestaurant);
    }

    public ActionResult Details(int id)
    {
        Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
        return View(thisRestaurant);
    }

    public ActionResult Delete(int id)
    {
        var thisRestaurant = _db.Restaurant.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
        return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
        _db.Restaurants.Remove(thisRestaurant);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}