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
      Alias aliasToUpdate = AliasService.GetAliasById(id);

      if (aliasToUpdate != null)
      {
        Log($"Редагування угруповання {aliasToUpdate.Name} (ID: {aliasToUpdate.Id})");
        Alias updatedAlias = AliasView.PromptUpdate(aliasToUpdate);

        AliasService.UpdateAlias(updatedAlias);
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
    public static List<Criminal> GetMembers(int id)
    {
      List<Criminal> members = CriminalService.GetAliasMembers(id);
      return members;
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
    public static void ShowMembers()
    {
      int id = PromptId();
      Alias alias = AliasService.GetAliasById(id);
      if (alias != null)
      {
        List<Criminal> members = CriminalService.GetAliasMembers(id);
        ListObjects<Criminal>(members);
      }
      else
      {
        Log("Угруповання з таким ID не знайдено");
        PromptClick();
      }
    }
    public static List<Alias> PromptAliases(List<Alias> aliases = null, List<Alias> chosenAliases = null)
    {
      if (aliases == null) aliases = AliasService.GetAllAliases();
      if (aliases.Count == 0)
      {
        Log("Угруповань не знайдено");
        return aliases;
      }
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
        else
        {
          Log($"Це угруповання вже було обрано");
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