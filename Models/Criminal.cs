using System;
using CriminalsProgram.Models.Helpers;

namespace CriminalsProgram.Models.Main
{
  public class Criminal
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string Description { get; set; }
    public CriminalStatus Status { get; set; } // "active", "archived", "dead"
    public byte DangerLevel { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public Criminal(int id, string firstName, string lastName, DateOnly dateOfBirth, int age, Gender gender, string description, CriminalStatus status)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      DateOfBirth = dateOfBirth;
      Age = age;
      Gender = gender;
      Description = description;
      Status = status;
    }

    public override string ToString()
    {
      return $"{Id},{FirstName},{LastName},{DateOfBirth},{Age},{Gender},{Description},{Status}";
    }

    public string GetReview()
    {
      return $"Id: {Id}\nІм'я: {FirstName}\nПрізвище: {LastName}\nДата народження: {DateOfBirth}\nВік: {Age}\nГендер: {Gender}\nОпис: {Description}\nСтатус: {Status}";
    }
  }

}