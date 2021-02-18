using System;
using System.Collections.Generic;
using System.Data;
using winter20_burgershack.Models;

namespace winter20_burgershack.Repositories
{
    public class DrinkRepository
    {
        public readonly IDbConnection _db;

    public DrinkRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Drink> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Drink GetById(int drinkId)
    {
      throw new NotImplementedException();
    }

    internal object CreateDrink(Drink newDrink)
    {
      throw new NotImplementedException();
    }

    internal object EditDrink(Drink original)
    {
      throw new NotImplementedException();
    }

    internal void DeleteDrink(Drink drink)
    {
      throw new NotImplementedException();
    }
  }

}