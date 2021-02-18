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
      throw new NotImplementedException();
    }

    internal object Edit(Side original)
    {
      throw new NotImplementedException();
    }

    internal void Delete(Side side)
    {
      throw new NotImplementedException();
    }
  }
}