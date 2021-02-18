using System;
using System.Collections.Generic;
using winter20_burgershack.Models;
using winter20_burgershack.Repositories;

namespace winter20_burgershack.Services
{
  public class DrinkService
  {
       private readonly DrinkRepository _repo;

    public DrinkService(DrinkRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Drink> Get()
    {
      return _repo.GetAll();
    }

    internal Drink GetDrinkById(int drinkId)
    {
      Drink drink = _repo.GetById(drinkId);
      if(drink != null)
      {
          return drink;
      }
       throw new Exception("invalid Id");
    }

    internal object CreateDrink(Drink newDrink)
    {
      return _repo.CreateDrink(newDrink);
    }

    internal object EditDrink(Drink updatedDrink)
    {
        Drink original = GetDrinkById(updatedDrink.Id);
        original.Name = updatedDrink.Name != null ? updatedDrink.Name : original.Name;
      original.Description = updatedDrink.Description != null ? updatedDrink.Description : original.Description;
      original.Price = updatedDrink.Price > 0 ? updatedDrink.Price : original.Price;

      return _repo.EditDrink(original);

    }

    internal string Delete(int drinkId)
    {
         Drink drink = GetDrinkById(drinkId);
         _repo.DeleteDrink(drink);
         return "Deleted";
    }


  }
}