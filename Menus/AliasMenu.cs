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
  class AliasMenu
  {
    public static void ShowMenu()
    {
      Console.Clear();
      Log("Головне меню");
      Log("1. Показати усі угруповання");
      Log("2. Додати угруповання");
      Log("3. Редагувати угруповання");
      Log("4. Покинути меню угруповань");

      string choice = PromptString("Виберіть опцію: ");

      switch (choice)
      {
        case "1":
          AliasService.ShowAliases();
          break;
        case "2":
          AliasService.AddAlias();
          break;
        case "3":
          AliasService.UpdateAlias();
          break;
        case "4":
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