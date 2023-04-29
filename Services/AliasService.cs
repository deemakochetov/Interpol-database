using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Repositories;
using CriminalsProgram.Views;
using static CriminalsProgram.Views.GeneralView;


namespace CriminalsProgram.Services
{
  static class AliasService
  {
    private static AliasDatabase database = new AliasDatabase();
    public static void ShowAliases()
    {
      List<Alias> aliases = database.GetAllAliases();
      AliasView.ShowAliases(aliases);
    }

    public static void AddAlias()
    {
      Alias newAlias = AliasView.PromptAlias();

      database.AddAlias(newAlias);
      LogSuccess();
    }

    public static void UpdateAlias()
    {
      int id = AliasView.PromptId();
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
  }
}