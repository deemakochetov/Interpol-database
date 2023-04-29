using System;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Services;
using static CriminalsProgram.Views.GeneralView;
using static CriminalsProgram.Views.AliasView;

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
      dynamic criminalObj = new { };
      Log("Додати нового злочинця:");
      criminalObj.firstName = PromptString("Ім'я: ");
      criminalObj.lastName = PromptString("Прізвище: ");
      criminalObj.nickname = PromptString("Кличка: ");
      criminalObj.height = PromptInt("Зріст: ");
      criminalObj.weight = PromptInt("Вага: ");
      criminalObj.hairColor = PromptString("Колір волосся: ");
      criminalObj.eyesColor = PromptString("Колір очей: ");
      criminalObj.nationality = PromptString("Національність: ");
      criminalObj.birthPlace = PromptString("Місце народження: ");
      criminalObj.lastResidencePlace = PromptString("Останнє місце проживання: ");
      criminalObj.currentLocation = PromptString("Поточне місце знаходження: ");
      criminalObj.languages = PromptString("Знання мов: ");
      criminalObj.criminalJob = PromptString("Кримінальне заняття: ");
      criminalObj.lastCase = PromptString("Останній злочин: ");
      criminalObj.appearance = PromptString("Зовнішній вигляд: ");
      criminalObj.gender = PromptGender();
      criminalObj.dateOfBirth = PromptBirthDate();
      criminalObj.description = PromptString("Опис злочину: ");
      criminalObj.status = PromptStatus();
      criminalObj.aliases = PromptAliases();
      Criminal newCriminal = new Criminal(criminalObj);
      return newCriminal;
    }



    public static CriminalStatus PromptStatus()
    {
      Log("Статус злочинця:");
      Log("1. Діючий");
      Log("2. Виправлений");
      Log("3. Мертвий");
      Log("Оберіть опцію: ");
      int statusOption = int.Parse(Console.ReadLine());
      switch (statusOption)
      {
        case 1:
          return CriminalStatus.Active;
        case 2:
          return CriminalStatus.Archived;
        case 3:
          return CriminalStatus.Dead;
        default:
          Log("Некорректний ввід");
          return PromptStatus();
      }
    }



    public static Gender PromptGender()
    {
      Log("Стать злочинця:");
      Log("1. Чоловіча");
      Log("2. Жіноча");

      string genderOption = Console.ReadLine();
      switch (genderOption)
      {
        case "1":
          return Gender.Male;
        case "2":
          return Gender.Female;
        default:
          Log("Некорректний ввід");
          return PromptGender();
      }
    }

    public static int PromptId()
    {
      Console.Write("Введіть ID злочинця для редагування: ");
      string input = Console.ReadLine();
      int id;
      if (int.TryParse(input, out id))
      {
        return id;
      }
      else
      {
        Console.Write("Невірне ID злочинця");
        return PromptId();
      }
    }

    public static DateOnly PromptBirthDate()
    {
      Console.Write("Дата народження (yyyy-mm-dd): ");
      string input = Console.ReadLine();
      DateOnly dateOfBirth;
      if (DateOnly.TryParse(input, out dateOfBirth))
      {
        return dateOfBirth;
      }
      else
      {
        Console.Write("Некоректний формат");
        return PromptBirthDate();
      }
    }
    public static int CalculateAge(DateOnly dateOfBirth)
    {
      int age = DateTime.Now.Year - dateOfBirth.Year;
      if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
      {
        age--;
      }
      return age;
    }
    public static Criminal PromptUpdate(Criminal criminal)
    {
      Console.WriteLine("Оберіть інформацію, яку ви хочете змінити:");
      Console.WriteLine("1. Імʼя");
      Console.WriteLine("2. Прізвище");
      Console.WriteLine("3. Кличка");
      Console.WriteLine("4. Зріст");
      Console.WriteLine("5. Вага");
      Console.WriteLine("6. Колір волосся");
      Console.WriteLine("7. Колір очей");
      Console.WriteLine("8. Національність");
      Console.WriteLine("9. Місце народження");
      Console.WriteLine("10. Останнє місце проживання");
      Console.WriteLine("11. Поточне місце знаходження");
      Console.WriteLine("12. Знання мов");
      Console.WriteLine("13. Кримінальне заняття");
      Console.WriteLine("14. Останній злочин");
      Console.WriteLine("15. Зовнішній вигляд");
      Console.WriteLine("16. Гендер");
      Console.WriteLine("17. Опис злочину");
      Console.WriteLine("18. Статус");
      Console.WriteLine("19. Дата народження");
      Console.WriteLine("20. Завершити редагування");


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