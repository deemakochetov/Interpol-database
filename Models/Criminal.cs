using System;
using CriminalsProgram.Models.Helpers;

namespace CriminalsProgram.Models.Main
{
  public class Criminal
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }

    public string HairColor { get; set; }
    public string EyesColor { get; set; }
    public string Natinality { get; set; }
    public string BirthPlace { get; set; }
    public string LastResidencePlace { get; set; }
    public string CurrentLocation { get; set; }

    public string Languages { get; set; }
    public string CriminalJob { get; set; }
    public string LastCase { get; set; }
    public List<Alias> Aliases { get; set; }
    public string Appearance { get; set; }


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
      Gender = gender;
      Description = description;
      Status = status;
    }

    public override string ToString()
    {
      return $"{Id},{FirstName},{LastName},{DateOfBirth},{Gender},{Description},{Status}";
    }

    public string GetReview()
    {
      return $"Id: {Id}\nІм'я: {FirstName}\nПрізвище: {LastName}\nДата народження: {DateOfBirth}\nГендер: {Gender}\nОпис: {Description}\nСтатус: {Status}";
    }
  }

}