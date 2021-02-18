using System;
using System.ComponentModel.DataAnnotations;
namespace winter20_burgershack.Models
{
    public class Side
    {
     public Side ()
    {

    }
    public Side(double price, string name, string description)
    {
      Price = price;
      Name = name;
      Description = description;
    }

public int Id { get; set; }
[Required]
    public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}