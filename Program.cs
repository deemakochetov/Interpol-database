using System;
using System.Collections.Generic;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Repositories;
using CriminalsProgram.Services;
using CriminalsProgram.Views;

namespace CriminalsProgram;
class Program
{
  static void Main(string[] args)
  {

    while (true)
    {
      List<Criminal> criminals = CriminalService.GetActiveCriminals();
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
              List<Criminal> filteredByName = CriminalService.FilterByName(CriminalService.GetActiveCriminals(), nameFilter);
              CriminalView.ShowCriminals(filteredByName);
              break;
            case "2":
              Console.Write("Введіть прізвище для фільтрування: ");
              string surnameFilter = Console.ReadLine();
              List<Criminal> filteredBySurname = CriminalService.FilterBySurname(criminals, surnameFilter);
              CriminalView.ShowCriminals(filteredBySurname);
              break;
            case "3":
              Console.WriteLine("Введіть вік для фільтрування: ");
              int ageFilter = int.Parse(Console.ReadLine());
              List<Criminal> filteredByStatus = CriminalService.FilterByAge(criminals, ageFilter);
              CriminalView.ShowCriminals(filteredByStatus);
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
          List<Criminal> searchResults = CriminalService.SearchCriminals(searchQuery);
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
          CriminalService.UpdateCriminal();
          break;
      }
    }
  }

}
// danger level