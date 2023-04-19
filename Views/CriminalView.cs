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
    public static void Log(string message)
    {
      Console.WriteLine(message);
    }
    public static int PromptId()
    {
      Console.Write("Введіть ID злочинця для редагування: ");
      int id = int.Parse(Console.ReadLine());
      // add check
      return id;
    }

    public static Criminal PromptUpdate(Criminal criminal)
    {
      Console.WriteLine("Оберіть інформацію, яку ви хочете змінити:");
      Console.WriteLine("1. Імʼя");
      Console.WriteLine("2. Прізвище");
      Console.WriteLine("3. Вік");
      Console.WriteLine("4. Гендер");
      Console.WriteLine("5. Опис злочину");
      Console.WriteLine("6. Статус");
      Console.WriteLine("7. Дата народження");
      Console.WriteLine("8. Завершити редагування");


      Console.Write("Оберіть опцію: ");
      int fieldOption = int.Parse(Console.ReadLine());

      switch (fieldOption)
      {
        case 1:
          Console.Write("Ім'я: ");
          string firstName = Console.ReadLine();
          criminal.FirstName = firstName;
          break;
        case 2:
          Console.Write("Прізвище: ");
          string lastName = Console.ReadLine();
          criminal.LastName = lastName;
          break;
        case 3:
          Console.Write("Вік: ");
          int age = int.Parse(Console.ReadLine());
          criminal.Age = age;
          break;
        case 4:
          Console.WriteLine("Стать злочинця:");
          Console.WriteLine("1. Чоловіча");
          Console.WriteLine("2. Жіноча");
          // do reuse questionss
          string genderOption = Console.ReadLine();
          Gender gender = criminal.Gender; // default
          switch (genderOption)
          {
            case "1":
              gender = Gender.Male;
              break;
            case "2":
              gender = Gender.Female;
              break;
          }
          criminal.Gender = gender;
          break;
        case 5:
          Console.Write("Злочин: ");
          string crime = Console.ReadLine();
          criminal.Description = crime;
          break;
        case 6:
          Console.WriteLine("Статус злочинця:");
          Console.WriteLine("1. Діючий");
          Console.WriteLine("2. Виправлений");
          Console.WriteLine("3. Мертвий");
          Console.Write("Оберіть опцію: ");
          int statusOption = int.Parse(Console.ReadLine());
          CriminalStatus status = criminal.Status;
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
          criminal.Status = status;
          break;
        case 7:
          Console.Write("Дата народження (yyyy-mm-dd): ");
          DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
          criminal.DateOfBirth = dateOfBirth;
          break;
        case 8:
          break;
        // exit
        default:
          Console.WriteLine("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
          Console.ReadKey();
          break;
      }

      return criminal;
    }
  }


}