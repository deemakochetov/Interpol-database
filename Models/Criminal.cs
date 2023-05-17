using System;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Interfaces;

namespace CriminalsProgram.Models.Main
{
  public class Criminal : IReviewable
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
    public CriminalStatus Status { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public Criminal()
    {
    }
    public string getAliasesNames()
    {
      return string.Join(", ", Aliases.Select(alias => alias.Name));
    }
    public string GetReview()
    {
      return $"Id: {Id}\nІм'я: {FirstName}\nПрізвище: {LastName}\nЗріст: {Height}\nВага: {Weight}\nКолір волосся: {HairColor}\nКолір очей: {EyesColor}\nНаціональність: {Nationality}\nМісце народження: {BirthPlace}\nОстаннє місце проживання: {LastResidencePlace}\nПоточне місце знаходження: {CurrentLocation}\nЗнання мов: {Languages}\nКримінальне заняття: {CriminalJob}\nОстанній злочин: {LastCase}\nУгруповання: {getAliasesNames()}\nЗовнішній вигляд: {Appearance}\nГендер: {Gender}\nОпис злочину: {Description}\nСтатус: {Status}\nДата народження: {DateOfBirth}";
    }
  }
}