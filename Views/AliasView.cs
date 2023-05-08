using CriminalsProgram.Models.Main;
using CriminalsProgram.Services;
using static CriminalsProgram.Views.GeneralView;

namespace CriminalsProgram.Views
{
  public static class AliasView
  {
    public static void ShowAliases()
    {
      List<Alias> aliases = AliasService.GetAllAliases();
      ListObjects<Alias>(aliases);
    }
    public static void AddAlias()
    {
      int nextId = AliasService.getNextId();
      Alias newAlias = AliasView.PromptAlias(nextId);

      AliasService.AddAlias(newAlias);
      LogSuccess();
      PromptClick();
    }
    public static void UpdateAlias()
    {
      int id = PromptId();
      Alias aliasToUpdate = AliasService.GetAliasById(id); // do the same for criminal

      if (aliasToUpdate != null)
      {
        Log($"Редагування угруповання {aliasToUpdate.Name} (ID: {aliasToUpdate.Id})");
        Alias updatedAlias = AliasView.PromptUpdate(aliasToUpdate);

        AliasService.UpdateAlias(updatedAlias); // consider passing id as argument
      }
      else
      {
        Log("Угруповання з таким ID не знайдено");
        PromptClick();
      }
    }

    public static Alias PromptAlias(int id)
    {
      string name = PromptString("Назва: ");
      Alias newAlias = new Alias(id, name);
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

    public static List<Alias> PromptAliases(List<Alias> aliases = null, List<Alias> chosenAliases = null)
    {
      if (aliases == null) aliases = AliasService.GetAllAliases();
      if (chosenAliases == null) chosenAliases = new List<Alias>();
      Log("Оберіть угруповання:");
      int counter = 1;
      Dictionary<string, Alias> aliasesOptions = new Dictionary<string, Alias>();

      foreach (Alias alias in aliases)
      {
        aliasesOptions.Add(counter.ToString(), alias);
        Log($"{counter}. {alias.Name}");
        counter++;
      }
      aliasesOptions.Add(counter.ToString(), null);
      Log($"{counter}. Завершити вибір");
      string option = PromptString("Оберіть опцію: ");
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