using System;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Services;
using static CriminalsProgram.Views.GeneralView;
using static CriminalsProgram.Views.AliasView;
using CriminalsProgram.Interfaces;

namespace CriminalsProgram.Views
{
  public static class CriminalView
  {
    public static void AddCriminal()
    {
      int nextId = CriminalService.getNextId();
      Criminal newCriminal = CriminalView.PromptCriminal(nextId);

      CriminalService.AddCriminal(newCriminal);
      LogSuccess();
    }
    public static void ShowActiveCriminals()
    {
      List<Criminal> activeCriminals = CriminalService.GetActiveCriminals();
      ListObjects<Criminal>(activeCriminals);
    }
    public static void ShowArchivedCriminals()
    {
      List<Criminal> archivedCriminals = CriminalService.GetArchivedCriminals();
      ListObjects<Criminal>(archivedCriminals);

    }
    public static void ShowSearchMenu()
    {
      Console.Write("Введіть пошуковий запит: ");
      string searchQuery = Console.ReadLine();
      List<Criminal> searchResults = CriminalService.SearchCriminals(searchQuery);
      if (searchResults.Count == 0)
      {
        Log("Збігів не знайдено.");
      }
      else
      {
        Log($"Знайдено {searchResults.Count} збігів:");
        foreach (Criminal criminal in searchResults)
        {
          Log(criminal.GetReview());
          LogSeparator();
        }
      }
      Log("Натисніть будь-яку клавішу для продовження...");
      Console.ReadKey();
    }
    public static void ShowFilterMenu()
    {
      List<Criminal> criminals = CriminalService.GetAllCriminals();
      Console.Clear();
      Log("Фільтрування злочинців");
      Log("1. Фільтрувати за імʼям");
      Log("2. Фільтрувати за прізвищем");
      Log("3. Фільтрувати за коліром волосся");
      Log("4. Фільтрувати за коліром очей");
      Log("5. Фільтрувати за національністю");
      Log("6. Фільтрувати за кримінальним заняттям");
      Log("7. Фільтрувати за роком народження");
      Log("8. Повернутися до меню");

      string filterChoice = PromptString("Виберіть опцію: ");
      switch (filterChoice)
      {
        case "1":
          string nameFilter = PromptString("Введіть ім'я для фільтрування: ");
          List<Criminal> filteredByName = CriminalService.FilterByName(CriminalService.GetActiveCriminals(), nameFilter);
          ListObjects<Criminal>(filteredByName);
          break;
        case "2":
          string surnameFilter = PromptString("Введіть прізвище для фільтрування: ");
          List<Criminal> filteredBySurname = CriminalService.FilterBySurname(criminals, surnameFilter);
          ListObjects<Criminal>(filteredBySurname);
          break;
        case "3":
          string hairColorFilter = PromptString("Введіть колір волосся для фільтрування: ");
          List<Criminal> filteredByHairColor = CriminalService.FilterByHairColor(CriminalService.GetActiveCriminals(), hairColorFilter);
          ListObjects<Criminal>(filteredByHairColor);
          break;
        case "4":
          string eyesColorFilter = PromptString("Введіть колір очей для фільтрування: ");
          List<Criminal> filteredByEyesColor = CriminalService.FilterByEyesColor(criminals, eyesColorFilter);
          ListObjects<Criminal>(filteredByEyesColor);
          break;
        case "5":
          string nationalityFilter = PromptString("Введіть національність для фільтрування: ");
          List<Criminal> filteredByNationality = CriminalService.FilterByNationality(criminals, nationalityFilter);
          ListObjects<Criminal>(filteredByNationality);
          break;
        case "6":
          string criminalJobFilter = PromptString("Введіть кримінальне заняття для фільтрування: ");
          List<Criminal> filteredByCriminalJob = CriminalService.FilterByCriminalJob(criminals, criminalJobFilter);
          ListObjects<Criminal>(filteredByCriminalJob);
          break;
        case "7":
          int ageFilter = PromptInt("Введіть вік для фільтрування: ");
          List<Criminal> filteredByAge = CriminalService.FilterByAge(criminals, ageFilter);
          ListObjects<Criminal>(filteredByAge);
          break;
        default:
          Log("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
          Console.ReadKey();
          ShowFilterMenu();
          break;
      }

    }
    public static Criminal PromptCriminal(int id)
    {
      Log("Додати нового злочинця:");
      string firstName = PromptString("Ім'я: ");
      string lastName = PromptString("Прізвище: ");
      string nickname = PromptString("Кличка: ");
      int height = PromptInt("Зріст: ");
      int weight = PromptInt("Вага: ");
      string hairColor = PromptString("Колір волосся: ");
      string eyesColor = PromptString("Колір очей: ");
      string nationality = PromptString("Національність: ");
      string birthPlace = PromptString("Місце народження: ");
      string lastResidencePlace = PromptString("Останнє місце проживання: ");
      string currentLocation = PromptString("Поточне місце знаходження: ");
      string languages = PromptString("Знання мов: ");
      string criminalJob = PromptString("Кримінальне заняття: ");
      string lastCase = PromptString("Останній злочин: ");
      string appearance = PromptString("Зовнішній вигляд: ");
      Gender gender = PromptGender();
      DateOnly dateOfBirth = PromptBirthDate();
      string description = PromptString("Опис злочину: ");
      CriminalStatus status = PromptStatus();
      List<Alias> aliases = AliasService.PromptAliases();
      var criminalBuilder = new CriminalBuilder();

      var newCriminal = criminalBuilder
                      .WithId(id)
                      .WithFirstName(firstName)
                      .WithLastName(lastName)
                      .WithNickname(nickname)
                      .WithHeight(height)
                      .WithWeight(weight)
                      .WithHairColor(hairColor)
                      .WithEyesColor(eyesColor)
                      .WithNationality(nationality)
                      .WithBirthPlace(birthPlace)
                      .WithLastResidencePlace(lastResidencePlace)
                      .WithCurrentLocation(currentLocation)
                      .WithLanguages(languages)
                      .WithCriminalJob(criminalJob)
                      .WithLastCase(lastCase)
                      .WithAliases(aliases)
                      .WithAppearance(appearance)
                      .WithGender(gender)
                      .WithDescription(description)
                      .WithStatus(status)
                      .WithDateOfBirth(dateOfBirth)
                      .Build();
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
      Log("Оберіть інформацію, яку ви хочете змінити:");
      Log("1. Імʼя");
      Log("2. Прізвище");
      Log("3. Кличка");
      Log("4. Зріст");
      Log("5. Вага");
      Log("6. Колір волосся");
      Log("7. Колір очей");
      Log("8. Національність");
      Log("9. Місце народження");
      Log("10. Останнє місце проживання");
      Log("11. Поточне місце знаходження");
      Log("12. Знання мов");
      Log("13. Кримінальне заняття");
      Log("14. Останній злочин");
      Log("15. Зовнішній вигляд");
      Log("16. Гендер");
      Log("17. Опис злочину");
      Log("18. Статус");
      Log("19. Дата народження");
      Log("20. Угруповання");
      Log("21. Завершити редагування");


      int fieldOption = PromptInt("Оберіть опцію: ");
      // cahnge/ update
      switch (fieldOption)
      {
        case 1:
          string firstName = PromptString("Ім'я: ");
          criminal.FirstName = firstName;
          break;
        case 2:
          string lastName = PromptString("Прізвище: ");
          criminal.LastName = lastName;
          break;
        case 3:
          string nickname = PromptString("Кличка: ");
          criminal.Nickname = nickname;
          break;
        case 4:
          int height = PromptInt("Зріст: ");
          criminal.Height = height;
          break;
        case 5:
          int weight = PromptInt("Вага: ");
          criminal.Weight = weight;
          break;
        case 6:
          string hairColor = PromptString("Колір волосся: ");
          criminal.HairColor = hairColor;
          break;
        case 7:
          string eyesColor = PromptString("Колір очей: ");
          criminal.EyesColor = eyesColor;
          break;
        case 8:
          string nationality = PromptString("Національність: ");
          criminal.Nationality = nationality;
          break;
        case 9:
          string birthPlace = PromptString("Місце народження: ");
          criminal.BirthPlace = birthPlace;
          break;
        case 10:
          string lastResidencePlace = PromptString("Останнє місце проживання: ");
          criminal.LastResidencePlace = lastResidencePlace;
          break;
        case 11:
          string currentLocation = PromptString("Поточне місце знаходження: ");
          criminal.CurrentLocation = currentLocation;
          break;
        case 12:
          string languages = PromptString("Знання мов: ");
          criminal.Languages = languages;
          break;
        case 13:
          string criminalJob = PromptString("Кримінальне заняття: ");
          criminal.CriminalJob = criminalJob;
          break;
        case 14:
          string lastCase = PromptString("Останній злочин: ");
          criminal.LastCase = lastCase;
          break;
        case 15:
          string appearance = PromptString("Зовнішній вигляд: ");
          criminal.Appearance = appearance;
          break;
        case 16:
          Gender gender = PromptGender();
          criminal.Gender = gender;
          break;
        case 17:
          string description = PromptString("Опис злочину: ");
          criminal.Description = description;
          break;
        case 18:
          CriminalStatus status = PromptStatus();
          criminal.Status = status;
          break;
        case 19:
          DateOnly dateOfBirth = PromptBirthDate();
          criminal.DateOfBirth = dateOfBirth;
          break;
        case 20:
          List<Alias> aliases = AliasService.PromptAliases();
          criminal.Aliases = aliases;
          break;
        case 21:
          return criminal;
        default:
          Log("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
          Console.ReadKey();
          break;
      }

      return PromptUpdate(criminal);
    }
  }


}