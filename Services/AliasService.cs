using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Repositories;
using CriminalsProgram.Views;
using static CriminalsProgram.Views.GeneralView;


namespace CriminalsProgram.Services
{
  static class AliasService
  {
    private static int nextId = 0;
    private static AliasDatabase database = new AliasDatabase();
    public static void ShowAliases()
    {
      List<Alias> aliases = database.GetAllAliases();
      ListObjects<Alias>(aliases);
    }

    public static void AddAlias()
    {
      Alias newAlias = AliasView.PromptAlias(nextId);
      nextId++;

      database.AddAlias(newAlias);
      LogSuccess();
    }

    public static void UpdateAlias()
    {
      int id = PromptId();
      Alias aliasToUpdate = database.GetAliasById(id); // do the same for criminal

      if (aliasToUpdate != null)
      {
        Log($"Редагування угруповання {aliasToUpdate.Name} (ID: {aliasToUpdate.Id})");
        Alias updatedAlias = AliasView.PromptUpdate(aliasToUpdate);

        database.UpdateAlias(updatedAlias); // consider passing id as argument
      }
      else
      {
        Log("Not found");
      }
    }

    public static List<Alias> PromptAliases()
    {
      List<Alias> aliases = database.GetAllAliases();
      List<Alias> chosenAliases = new List<Alias>();
      return AliasView.PromptAliases(aliases, chosenAliases);
    }

  }
}