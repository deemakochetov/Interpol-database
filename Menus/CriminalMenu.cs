using System;
using System.Collections.Generic;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Repositories;
using CriminalsProgram.Services;
using CriminalsProgram.Views;
using static CriminalsProgram.Views.GeneralView;

namespace CriminalsProgram.Menus
{
  class CriminalMenu
  {
    public static void ShowMenu()
    {
      List<Criminal> criminals = CriminalService.GetActiveCriminals();
      Log("Головне меню");
      Log("1. Показати усіх діючих злочинців");
      Log("2. Подивитися список злочинців в архіві");
      Log("3. Додати злочинця");
      Log("4. Фільтрувати злочинців");
      Log("5. Пошук злочинців");
      Log("6. Редагувати злочинця");
      Log("7. Покинути меню злочинця");

      string choice = PromptString("Виберіть опцію: ");

      switch (choice)
      {
        case "1":
          CriminalService.ShowActiveCriminals();
          break;
        case "2":
          CriminalService.ShowArchivedCriminals();
          break;
        case "3":
          CriminalService.AddCriminal();
          break;
        case "4":
          // Реалізувати фільтрування злочинців
          Console.Clear();
          Log("Фільтрування злочинців");
          Log("1. Фільтрувати за ім'ям");
          Log("2. Фільтрувати за прізвищем");
          // Log("3. Фільтрувати за віком");
          Console.Write("Виберіть опцію: ");
          string filterChoice = Console.ReadLine();
          // auto age
          switch (filterChoice)
          {
            case "1":
              Console.Write("Введіть ім'я для фільтрування: ");
              string nameFilter = Console.ReadLine();
              List<Criminal> filteredByName = CriminalService.FilterByName(CriminalService.GetActiveCriminals(), nameFilter);
              ListObjects<Criminal>(filteredByName);
              break;
            case "2":
              Console.Write("Введіть прізвище для фільтрування: ");
              string surnameFilter = Console.ReadLine();
              List<Criminal> filteredBySurname = CriminalService.FilterBySurname(criminals, surnameFilter);
              ListObjects<Criminal>(filteredBySurname);
              break;
            // case "3":
            //   Log("Введіть вік для фільтрування: ");
            //   int ageFilter = int.Parse(Console.ReadLine());
            //   List<Criminal> filteredByStatus = CriminalService.FilterByAge(criminals, ageFilter);
            //   ListObjects<Criminal>(filteredByStatus);
            //   break;
            default:
              Log("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
              Console.ReadKey();
              break;
          }
          break;
        // add db
        case "5":
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
            }
          }
          Log("Натисніть будь-яку клавішу для продовження...");
          Console.ReadKey();
          break;
        case "6":
          CriminalService.UpdateCriminal();
          break;
        case "7":
          return;
        default:
          Log("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
          Console.ReadKey();
          break;
      }
      ShowMenu();

    }
  }
}