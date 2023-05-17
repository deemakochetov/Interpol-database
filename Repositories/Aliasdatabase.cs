using CriminalsProgram.Models.Main;

namespace CriminalsProgram.Repositories
{
  public class AliasDatabase
  {
    private List<Alias> _aliases;
    private string fileName;
    public AliasDatabase()
    {
      _aliases = new List<Alias>();
      fileName = "aliases.json";
      LoadAliases();
    }
    public void AddAlias(Alias alias)
    {
      _aliases.Add(alias);
      SaveAliases();
    }
    public Alias? GetAliasById(int id)
    {
      return _aliases.FirstOrDefault(a => a.Id == id);
    }

    public void UpdateAlias(Alias alias)
    {
      var index = _aliases.FindIndex(a => a.Id == alias.Id);
      if (index != -1)
      {
        _aliases[index] = alias;
      }
      SaveAliases();
    }

    public void RemoveAlias(Alias alias)
    {
      _aliases.Remove(alias);
      SaveAliases();
    }

    public List<Alias> GetAllAliases()
    {
      return _aliases.ToList();
    }

    public void SaveAliases()
    {
      FileHelper.SaveAliases(fileName, _aliases);
    }
    private void LoadAliases()
    {
      FileHelper.LoadAliases(fileName, out _aliases);
    }
  }
}
