using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using winter20_burgershack.Models;

namespace winter20_burgershack.Repositories
{
  public class SideRepository
  {
      public readonly IDbConnection _db;

    public SideRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Side> GetAll()
    {
      string sql = "SELECT * FROM Sides;";
      return _db.Query<Side>(sql);
    }

    internal Side GetSideById(int sideId)
    {
      string sql = "SELECT * FROM Sides WHERE id = @sideId;";
      return _db.QueryFirstOrDefault<Side>(sql, new {sideId});
    }

    internal object CreateSide(Side newSide)
    {
      string sql = @"
      INSERT INTO Sides
      (name, description, price)
      VALUES
      (@name, @description, @price);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newSide);
      newSide.Id = id;
      return newSide;
    }

    internal object Edit(Side original)
    {
      string sql = @"
      UPDATE Sides
      SET
      description = @Description,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM Sides WHERE id =@Id;";
        return _db.QueryFirstOrDefault<Side>(sql, original);
    }

    internal void Delete(Side side)
    {
      string sql = "DELETE FROM Sides WHERE id = @Id;";
      _db.Execute(sql, side);
    }
  }
}