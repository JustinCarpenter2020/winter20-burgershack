using System;
using System.Collections.Generic;
using winter20_burgershack.Models;
using winter20_burgershack.Repositories;

namespace winter20_burgershack.Services
{
  public class SideService
  {
      private readonly SideRepository _repo;
      public SideService(SideRepository repo)
      {
          _repo = repo;
      }
    internal IEnumerable<Side> Get()
    {
      return _repo.GetAll();
    }

    internal Side GetSideById(int sideId)
    {
      Side side = _repo.GetSideById(sideId);
      if(side != null)
      {
          return side;
      }
      throw new Exception("invalid Id");

    }

    internal object CreateSide(Side newSide)
    {
      return _repo.CreateSide(newSide);
    }

    internal object EditSide(Side newSide)
    {
        //FIXME
        Side original = GetSideById(newSide.Id);
          original.Name = newSide.Name != null ? newSide.Name : original.Name;
      original.Description = newSide.Description != null ? newSide.Description : original.Description;
      original.Price = newSide.Price > 0 ? newSide.Price : original.Price;

      return _repo.Edit(original);
    }

    internal object DeleteSide(int sideId)
    {
       Side side = GetSideById(sideId);
      _repo.Delete(side);
      return "Deleted";
    }
  }
}