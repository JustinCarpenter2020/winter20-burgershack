using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
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
      string sql = "SELECT * FROM Drinks;";
      return _db.Query<Drink>(sql);
    }

    internal Drink GetById(int drinkId)
    {
      string sql = "SELECT * FROM Drinks WHERE id = @drinkId;";
       return _db.QueryFirstOrDefault<Drink>(sql, new { drinkId });

    }

    internal object CreateDrink(Drink newDrink)
    {
      string sql = @"
      INSERT INTO drinks
      (name, description, price)
      VALUES
      (@name, @description, @price);
      SELECT LAST_INSERTED_ID();";
      int id = _db.ExecuteScalar<int>(sql, newDrink);
      newDrink.Id = id;
      return newDrink; 
    }

    internal object EditDrink(Drink original)
    {
      throw new NotImplementedException();
    }

    internal void DeleteDrink(Drink drink)
    {
       string sql = "DELETE FROM drinks WHERE id = @Id";
      _db.Execute(sql, drink);
    }
  }

}