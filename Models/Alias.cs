using System;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Interfaces;

namespace CriminalsProgram.Models.Main
{
  public class Alias : IReviewable
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public Alias(int id, string name)
    {
      Id = id;
      Name = name;
    }

    public string GetReview()
    {
      return $"Id: {Id}\nНазва: {Name}";
    }
  }

}