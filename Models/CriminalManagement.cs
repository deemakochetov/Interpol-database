using System;

namespace CriminalsProgram.Models.Helpers
{
  // public class Gender
  // {
  //   public static readonly Gender Male = new Gender("Man");
  //   public static readonly Gender Female = new Gender("Female");

  //   private readonly string name;

  //   // private Gender(string name)
  //   // {
  //   //   this.name = name;
  //   // }

  // public override string ToString()
  // {
  //   return name;
  // }
  // }
  public enum CriminalStatus
  {
    Active,
    Archived,
    Dead
  }
  public enum Gender
  {
    Male,
    Female,
  }
  // public class CriminalStatusTest
  // {
  //   public static readonly CriminalStatus Active = new CriminalStatus("Active");
  //   public static readonly CriminalStatus Archived = new CriminalStatus("Archived");
  //   public static readonly CriminalStatus Dead = new CriminalStatus("Dead");

  //   private readonly string name;

  //   private CriminalStatus(string name)
  //   {
  //     this.name = name;
  //   }

  //   public override string ToString()
  //   {
  //     return name;
  //   }
  // }
}