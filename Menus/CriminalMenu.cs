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
      Console.Clear();
      Console.WriteLine('\n');

      List<Criminal> criminals = CriminalService.GetActiveCriminals();
      Log("Головне меню");
      Log("1. Показати усіх діючих злочинців");
      Log("2. Подивитися список виправлених злочинців");
      Log("3. Додати злочинця");
      Log("4. Фільтрувати злочинців");
      Log("5. Пошук злочинців");
      Log("6. Редагувати злочинця");
      Log("7. Покинути меню злочинця");

      string choice = PromptString("Виберіть опцію: ");

      switch (choice)
      {
        case "1":
          CriminalView.ShowActiveCriminals();
          break;
        case "2":
          CriminalView.ShowArchivedCriminals();
          break;
        case "3":
          CriminalView.AddCriminal();
          break;
        case "4":
          CriminalView.ShowFilterMenu();
          break;
        case "5":
          CriminalView.ShowSearchMenu();
          break;
        case "6":
          CriminalView.UpdateCriminal();
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