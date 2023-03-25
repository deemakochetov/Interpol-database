using System;
using System.Collections.Generic;

namespace CriminalsProgram;
class Program
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
      return $"Id: {Id}\nІм'я: {FirstName}\nПрізвище: {LastName}\nДата народження: {DateOfBirth}\nВік: {Age}\nГендер: {Gender}Опис: {Description}\nСтатус: {Status}";
    }
  }
  public class CriminalStatus
  {
    public static readonly CriminalStatus Active = new CriminalStatus("Active");
    public static readonly CriminalStatus Archived = new CriminalStatus("Archived");
    public static readonly CriminalStatus Dead = new CriminalStatus("Dead");

    private readonly string name;

    private CriminalStatus(string name)
    {
      this.name = name;
    }

    public override string ToString()
    {
      return name;
    }
  }

  public class Gender
  {
    public static readonly Gender Male = new Gender("Man");
    public static readonly Gender Female = new Gender("Female");

    private readonly string name;

    private Gender(string name)
    {
      this.name = name;
    }

    public override string ToString()
    {
      return name;
    }
  }

  public static class CriminalHelper
  {
    public static List<Criminal> FilterByName(List<Criminal> criminals, string name)
    {
      return criminals.Where(criminal => criminal.FirstName == name).ToList();
    }

    public static List<Criminal> FilterBySurname(List<Criminal> criminals, string surname)
    {
      return criminals.Where(criminal => criminal.LastName == surname).ToList();
    }

    public static List<Criminal> FilterByAge(List<Criminal> criminals, int age)
    {
      return criminals.Where(criminal => criminal.Age == age).ToList();
    }

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
        }
      }
      Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
      Console.ReadKey();
    }
  }
  class CriminalDatabase
  {
    private List<Criminal> activeCriminals;
    private List<Criminal> archivedCriminals;
    private int nextId;

    public CriminalDatabase()
    {
      activeCriminals = new List<Criminal>();
      archivedCriminals = new List<Criminal>();
      LoadCriminals();
    }

    public List<Criminal> GetActiveCriminals()
    {
      return activeCriminals;
    }

    public List<Criminal> GetArchivedCriminals()
    {
      return archivedCriminals;
    }

    public void AddCriminal(Criminal criminal)
    {
      criminal.Id = nextId;
      nextId++;
      activeCriminals.Add(criminal);
      SaveCriminals();
    }
    private void EditCriminal(Criminal criminalToUpdate, Criminal updatedCriminal)
    {
      criminalToUpdate.FirstName = updatedCriminal.FirstName;
      criminalToUpdate.LastName = updatedCriminal.LastName;
      criminalToUpdate.Age = updatedCriminal.Age;
      criminalToUpdate.Gender = updatedCriminal.Gender;
      criminalToUpdate.Description = updatedCriminal.Description;
      criminalToUpdate.DangerLevel = updatedCriminal.DangerLevel;
      criminalToUpdate.DateOfBirth = updatedCriminal.DateOfBirth;
      criminalToUpdate.Status = updatedCriminal.Status;
    }
    public bool UpdateCriminal(int id, Criminal updatedCriminal)
    {
      // Find the criminal to be updated
      Criminal criminalToUpdate = activeCriminals.Find(criminal => criminal.Id == id);
      if (criminalToUpdate == null)
      {
        criminalToUpdate = archivedCriminals.Find(criminal => criminal.Id == id);
      }
      if (criminalToUpdate == null) return false;




      if (updatedCriminal.Status == CriminalStatus.Active)
      {
        if (criminalToUpdate.Status == CriminalStatus.Archived)
        {
          archivedCriminals.Remove(criminalToUpdate);
          EditCriminal(criminalToUpdate, updatedCriminal);
          activeCriminals.Add(criminalToUpdate);
        }
      }
      if (updatedCriminal.Status == CriminalStatus.Archived)
      {
        if (criminalToUpdate.Status == CriminalStatus.Active)
        {
          activeCriminals.Remove(criminalToUpdate);
          EditCriminal(criminalToUpdate, updatedCriminal);
          archivedCriminals.Add(criminalToUpdate);
        }
      }
      if (updatedCriminal.Status == CriminalStatus.Dead)
      {
        if (criminalToUpdate.Status == CriminalStatus.Active)
        {
          activeCriminals.Remove(criminalToUpdate);
        }
        if (criminalToUpdate.Status == CriminalStatus.Archived)
        {
          archivedCriminals.Remove(criminalToUpdate);
        }
      }
      SaveCriminals();
      return true;
    }

    public List<Criminal> SearchCriminals(string query)
    {
      List<Criminal> results = new List<Criminal>();

      foreach (Criminal criminal in activeCriminals)
      {// optimize name
        if ((criminal.FirstName + " " + criminal.LastName).ToLower().Contains(query.ToLower()) ||
            criminal.Description.ToLower().Contains(query.ToLower()) ||
            criminal.Age.ToString().ToLower().Contains(query.ToLower()))
        {
          results.Add(criminal);
        }
      }

      return results;
    }

    public void SaveCriminals()
    {
      using (StreamWriter sw = new StreamWriter("criminals.txt"))
      {
        foreach (Criminal criminal in activeCriminals)
        {
          sw.WriteLine(criminal.ToString());
        }

        foreach (Criminal criminal in archivedCriminals)
        {
          sw.WriteLine(criminal.ToString() + ",archived");
        }
      }
    }

    private void LoadCriminals()
    {
      if (!File.Exists("criminals.txt"))
      {
        return;
      }

      using (StreamReader sr = new StreamReader("criminals.txt"))
      {
        while (!sr.EndOfStream)
        {
          string line = sr.ReadLine();
          string[] parts = line.Split(',');

          int id = int.Parse(parts[0]);
          string firstName = parts[1];
          string lastName = parts[2];
          DateOnly dateOfBirth = DateOnly.Parse(parts[3]);
          // condider byte
          int age = int.Parse(parts[4]);
          string gender = parts[5];
          string description = parts[6];

          CriminalStatus status = (CriminalStatus)Enum.Parse(typeof(CriminalStatus), parts[7], true);
          Criminal criminal = new Criminal(id, firstName, lastName, dateOfBirth, age, gender, description, status);

          if (parts.Length > 5 && parts[7] == "archived")
          {
            archivedCriminals.Add(criminal);
          }
          else
          {
            activeCriminals.Add(criminal);
          }
        }
      }
    }
  }
  private static CriminalDatabase database = new CriminalDatabase();


  static void Main(string[] args)
  {
    while (true)
    {
      List<Criminal> criminals = database.GetActiveCriminals();
      Console.Clear();
      Console.WriteLine("Головне меню");
      Console.WriteLine("1. Показати усіх діючих злочинців");
      Console.WriteLine("2. Подивитися список злочинців в архіві");
      Console.WriteLine("3. Додати злочинця");
      Console.WriteLine("4. Фільтрувати злочинців");
      Console.WriteLine("5. Пошук злочинців");
      Console.WriteLine("6. Редагувати злочинця");

      Console.Write("Виберіть опцію: ");

      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          ShowActiveCriminals();
          break;
        case "2":
          ShowArchivedCriminals();
          break;
        case "3":
          // Реалізувати додавання нового злочинця
          break;
        case "4":
          // Реалізувати фільтрування злочинців
          Console.Clear();
          Console.WriteLine("Фільтрування злочинців");
          Console.WriteLine("1. Фільтрувати за ім'ям");
          Console.WriteLine("2. Фільтрувати за прізвищем");
          Console.WriteLine("3. Фільтрувати за віком");
          Console.Write("Виберіть опцію: ");
          string filterChoice = Console.ReadLine();
          // auto age
          switch (filterChoice)
          {
            case "1":
              Console.Write("Введіть ім'я для фільтрування: ");
              string nameFilter = Console.ReadLine();
              List<Criminal> filteredByName = CriminalHelper.FilterByName(database.GetActiveCriminals(), nameFilter);
              CriminalHelper.ShowCriminals(filteredByName);
              break;
            case "2":
              Console.Write("Введіть прізвище для фільтрування: ");
              string surnameFilter = Console.ReadLine();
              List<Criminal> filteredBySurname = CriminalHelper.FilterBySurname(criminals, surnameFilter);
              CriminalHelper.ShowCriminals(filteredBySurname);
              break;
            case "3":
              Console.WriteLine("Введіть вік для фільтрування: ");
              int ageFilter = int.Parse(Console.ReadLine());
              List<Criminal> filteredByStatus = CriminalHelper.FilterByAge(criminals, ageFilter);
              CriminalHelper.ShowCriminals(filteredByStatus);
              break;
            default:
              Console.WriteLine("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
              Console.ReadKey();
              break;
          }
          break;
        // add db
        case "5":
          Console.Write("Введіть пошуковий запит: ");
          string searchQuery = Console.ReadLine();
          List<Criminal> searchResults = database.SearchCriminals(searchQuery);
          if (searchResults.Count == 0)
          {
            Console.WriteLine("Збігів не знайдено.");
          }
          else
          {
            Console.WriteLine($"Знайдено {searchResults.Count} збігів:");
            foreach (Criminal criminal in searchResults)
            {
              Console.WriteLine(criminal.GetReview());
            }
          }
          Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
          Console.ReadKey();
          break;
        case "6":
          Console.Write("Введіть ID злочинця для редагування: ");
          int id = int.Parse(Console.ReadLine());

          Criminal criminalToUpdate = database.GetActiveCriminals().Find(c => c.Id == id);

          if (criminalToUpdate != null)
          {
            Console.WriteLine($"Редагування злочинця {criminalToUpdate.FirstName} {criminalToUpdate.LastName} (ID: {criminalToUpdate.Id})");

            Console.Write("Ім'я: ");
            string name = Console.ReadLine();

            Console.Write("Вік: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Стать злочинця:");
            Console.WriteLine("1. Чоловіча");
            Console.WriteLine("2. Жіноча");
            // do reuse questionss
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

            Console.Write("Злочин: ");
            string crime = Console.ReadLine();

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
            database.UpdateCriminal() // do that;
          }
          break;

        default:
          Console.WriteLine("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
          Console.ReadKey();

          break;
      }
    }
  }

  public List<Criminal> FilterCriminals(List<Criminal> criminals, string filterType, string filterValue)
  {
    List<Criminal> filteredCriminals = new List<Criminal>();

    foreach (Criminal criminal in criminals)
    {
      switch (filterType)
      {
        case "age":
          if (criminal.Age.ToString() == filterValue)
          {
            filteredCriminals.Add(criminal);
          }
          break;
        case "gender":
          if (criminal.Gender.ToString() == filterValue)
          {
            filteredCriminals.Add(criminal);
          }
          break;
        case "birth":
          if (criminal.DateOfBirth == DateOnly.Parse(filterValue))
          {
            filteredCriminals.Add(criminal);
          }
          break;
        case "level":
          if (criminal.DangerLevel == byte.Parse(filterValue))
          {
            filteredCriminals.Add(criminal);
          }
          break;
      }
    }
    // && (filter == "" || criminal.Description.Contains(filter) || criminal.Age.ToString() == filter || criminal.Status.ToString().Contains(filter))
    return filteredCriminals;
  }
  public List<Criminal> SearchCriminals(string query)
  {
    List<Criminal> activeCriminals = database.GetActiveCriminals();
    List<Criminal> results = new List<Criminal>();

    foreach (Criminal criminal in activeCriminals)
    {
      if (criminal.FirstName.ToLower().Contains(query.ToLower()) ||
      criminal.LastName.ToLower().Contains(query.ToLower()) ||
          criminal.Description.ToLower().Contains(query.ToLower())
          )
      {
        results.Add(criminal);
      }
    }

    return results;
  }
  public static void ShowActiveCriminals()
  {
    Console.WriteLine("Список діючих злочинців:");
    List<Criminal> activeCriminals = database.GetActiveCriminals();
    foreach (Criminal criminal in activeCriminals)
    {
      if ((criminal.Status == CriminalStatus.Active))
      {
        Console.WriteLine(criminal.ToString());
        Console.WriteLine("-------------------------------------------");
      }
    }
  }
  // maybe delete
  public static void ShowArchivedCriminals()
  {
    List<Criminal> archiveCriminals = database.GetArchivedCriminals();

    Console.WriteLine("Список злочинців в архіві:");
    foreach (Criminal criminal in archiveCriminals)
    {
      if (criminal.Status == CriminalStatus.Archived)
      {
        Console.WriteLine(criminal.ToString());
        Console.WriteLine("-------------------------------------------");
      }
    }
  }
  private static void AddCriminal(List<Criminal> criminals)
  {
    Console.WriteLine("Додати нового злочинця:");
    Console.Write("Ім'я: ");
    string firstName = Console.ReadLine();
    Console.Write("Прізвище: ");
    string lastName = Console.ReadLine();
    Console.Write("Дата народження (yyyy-mm-dd): ");
    DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
    Console.Write("Вік: ");
    int age = int.Parse(Console.ReadLine());
    Console.WriteLine("Стать злочинця:");
    Console.WriteLine("1. Чоловіча");
    Console.WriteLine("2. Жіноча");
    // do reuse questionss
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

    Criminal newCriminal = new Criminal(0, firstName, lastName, dateOfBirth, age, gender, description, status);
    database.AddCriminal(newCriminal);
    Console.WriteLine("Злочинець успішно доданий до списку!");
  }

}
// danger level