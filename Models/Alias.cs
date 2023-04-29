using System;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Models.Repositories;

namespace CriminalsProgram.Models.Main
{
  public class Alias : IReviewable
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public Alias(dynamic obj)
    {
      Id = obj.id;
      Name = obj.name;
    }

    public string GetReview()
    {
      return $"Id: {Id}\nНазва: {Name}";
    }
  }

}