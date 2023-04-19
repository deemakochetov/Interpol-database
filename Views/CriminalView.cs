using System;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Services;

namespace CriminalsProgram.Views
{
  public static class CriminalView
  {
    public static void ShowCriminals(List<Criminal> criminals)
    {
      if (criminals.Count == 0)
      {
        Console.WriteLine("Список порожній.");
      }
      else
      {
        Console.WriteLine($"Знайдено {criminals.Count} злочинців:");
        foreach (Criminal criminal in criminals)
        {
          Console.WriteLine(criminal.GetReview());
          Console.WriteLine("--------------------------");
        }
      }
      Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
      Console.ReadKey();
    }

    public static Criminal PromptCriminal()
    {
      Console.WriteLine("Додати нового злочинця:");
      Console.Write("Ім'я: ");
      string firstName = Console.ReadLine();
      Console.Write("Прізвище: ");
      string lastName = Console.ReadLine();
      Console.Write("Дата народження (yyyy-mm-dd): ");
      DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
      Console.Write("Вік: ");
      // add validity check
      int age = int.Parse(Console.ReadLine());
      Console.WriteLine("Стать злочинця:");
      Console.WriteLine("1. Чоловіча");
      Console.WriteLine("2. Жіноча");

      string genderOption = Console.ReadLine();
      Gender gender = Gender.Male; // default
      switch (genderOption)
      {
        case "1":
          gender = Gender.Male;
          break;
        case "2":
          gender = Gender.Female;
          break;
      }
      Console.Write("Опис злочину: ");
      string description = Console.ReadLine();
      CriminalStatus status = CriminalStatus.Active;

      // запит користувача щодо статусу злочинця
      Console.WriteLine("Статус злочинця:");
      Console.WriteLine("1. Діючий");
      Console.WriteLine("2. Виправлений");
      Console.WriteLine("3. Мертвий");
      Console.Write("Оберіть опцію: ");
      int statusOption = int.Parse(Console.ReadLine());
      switch (statusOption)
      {
        case 1:
          status = CriminalStatus.Active;
          break;
        case 2:
          status = CriminalStatus.Archived;
          break;
        case 3:
          status = CriminalStatus.Dead;
          break;
      }
      // default case

      Criminal newCriminal = new Criminal(0, firstName, lastName, dateOfBirth, age, gender, description, status);
      return newCriminal;
    }

    public static void LogSuccess()
    {
      Console.WriteLine("Операція успішно виконана!");
    }
  }


}