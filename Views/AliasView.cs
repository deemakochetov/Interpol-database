using System;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Services;
using static CriminalsProgram.Views.GeneralView;

namespace CriminalsProgram.Views
{
  public static class AliasView
  {




    public static List<Alias> PromptAliases()
    {
      Log("Оберіть угруповання:");
      List<Alias> aliases = AliasD
      Log("1. Діючий");
      Log("2. Виправлений");
      Log("3. Створити нове");
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



  }
}