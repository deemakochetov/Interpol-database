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
    public string Nationality { get; set; }
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

    public Criminal(dynamic obj)
    {
      Id = obj.id;
      FirstName = obj.firstName;
      LastName = obj.lastName;
      Nickname = obj.nickname;
      Height = obj.height;
      Weight = obj.weight;
      HairColor = obj.hairColor;
      EyesColor = obj.eyesColor;
      Nationality = obj.nationality;
      BirthPlace = obj.birthPlace;
      LastResidencePlace = obj.lastResidencePlace;
      CurrentLocation = obj.currentLocation;
      Languages = obj.languages;
      CriminalJob = obj.criminalJob;
      LastCase = obj.lastCase;
      Aliases = obj.aliases;
      Appearance = obj.appearance;
      Gender = obj.gender;
      Description = obj.description;
      Status = obj.status;
      DateOfBirth = obj.dateOfBirth;
    }

    public override string ToString()
    {
      return $"{Id};;{FirstName};;{LastName};;{Nickname};;{Height};;{Weight};;{HairColor};;{EyesColor};;{Nationality};;{BirthPlace};;{LastResidencePlace};;{CurrentLocation};;{Languages};;{CriminalJob};;{LastCase};;{Aliases};;{Appearance};;{Gender};;{Description};;{Status};;{DateOfBirth}";
    }

    public string GetReview()
    {
      return $"Id: {Id}\nІм'я: {FirstName}\nПрізвище: {LastName}\nЗріст: {Height}\nВага: {Weight}\nКолір волосся: {HairColor}\nКолір очей: {EyesColor}\nНаціональність: {Nationality}\nМісце народження: {BirthPlace}\nОстаннє місце проживання: {LastResidencePlace}\nПоточне місце знаходження: {CurrentLocation}\nЗнання мов: {Languages}\nКримінальне заняття: {CriminalJob}\nОстанній злочин: {LastCase}\nУгруповання: {Aliases}\nЗовнішній вигляд: {Appearance}\nГендер: {Gender}\nОпис злочину: {Description}\nСтатус: {Status}\nДата народження: {DateOfBirth}";
    }
  }

}