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

    public static int getNextId()
    {
      nextId++;
      return nextId;
    }
    public static void AddAlias(Alias newAlias)
    {
      database.AddAlias(newAlias);
    }

    public static void UpdateAlias(Alias updatedAlias)
    {
      database.UpdateAlias(updatedAlias); // consider passing id as argument
    }
    public static Alias GetAliasById(int id)
    {
      return database.GetAliasById(id);
    }

    public static List<Alias> GetAllAliases()
    {
      List<Alias> aliases = database.GetAllAliases();
      return aliases;
    }
  }
}