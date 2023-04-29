using System;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Services;
using System.Collections.Generic;
using static CriminalsProgram.Views.GeneralView;

namespace CriminalsProgram.Views
{
  public static class AliasView
  {

    public static Alias PromptAlias()
    {
      dynamic aliasObj = new { };
      aliasObj.name = PromptString("Назва: ");
      Alias newAlias = new Alias(aliasObj);
      return newAlias;
    }
    public static Alias PromptUpdate(Alias aliasToUpdate)
    {
      Log("Оберіть інформацію, яку ви хочете змінити:");
      Log("1. Імʼя");
      Log("2. Завершити редагування");
      int fieldOption = PromptInt("Оберіть опцію: ");

      switch (fieldOption)
      {
        case 1:
          string name = PromptString("Ім'я: ");
          aliasToUpdate.Name = name;
          break;
        case 2:
          return aliasToUpdate;
        default:
          Log("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
          Console.ReadKey();
          break;
      }

      return PromptUpdate(aliasToUpdate);
    }

    public static List<Alias> PromptAliases(List<Alias> aliases, List<Alias> chosenAliases)
    {
      Log("Оберіть угруповання:");
      int counter = 0;
      Dictionary<string, Alias> aliasesOptions = new Dictionary<string, Alias>();

      foreach (Alias alias in aliases)
      {
        aliasesOptions.Add(counter.ToString(), alias);
        Log($"{counter}. {alias.Name}");
        counter++;
      }
      aliasesOptions.Add(counter.ToString(), null);
      Log($"{counter}. Завершити вибір");
      string option = Console.ReadLine();
      if (aliasesOptions.ContainsKey(option))
      {
        if (aliasesOptions[option] == null)
        {
          return chosenAliases;
        }
        if (!chosenAliases.Contains(aliasesOptions[option]))
        {
          chosenAliases.Add(aliasesOptions[option]);
        }
        return PromptAliases(aliases, chosenAliases);
      }
      else
      {
        return PromptAliases(aliases, chosenAliases);
      }

    }







  }
}