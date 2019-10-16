using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurants.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantContext _db;

    public CuisinesController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
        _db.Cuisines.Add(cuisine);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
        Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
        return View(thisCuisine);
    }
    public ActionResult Edit (int id)
      {
          Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
          return View(thisCuisine);
      }

    public ActionResult Delete(int id)
    {
        var thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
        return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
        _db.Cuisines.Remove(thisCuisine);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}