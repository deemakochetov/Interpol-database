using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Repositories;
using CriminalsProgram.Views;
using static CriminalsProgram.Views.GeneralView;


namespace CriminalsProgram.Services
{
  static class AliasService
  {
    private static int nextId = -1;
    private static AliasDatabase database = new AliasDatabase();

    public static int getNextId()
    {
      if (nextId == -1) nextId = getLatestId();
      nextId++;
      return nextId;
    }
    public static int getLatestId()
    {
      List<Alias> aliases = GetAllAliases();
      int latestId = aliases.LastOrDefault()?.Id ?? 0;
      return latestId;
    }
    public static void AddAlias(Alias newAlias)
    {
      database.AddAlias(newAlias);
    }

    public static void UpdateAlias(Alias updatedAlias)
    {
      database.UpdateAlias(updatedAlias);
    }
    public static Alias? GetAliasById(int id)
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