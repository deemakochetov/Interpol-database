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

    // Add a new alias to the database
    public void AddAlias(Alias alias)
    {
      _aliases.Add(alias);
      SaveAliases();
    }

    // Retrieve an alias by its ID
    public Alias GetAliasById(int id)
    {
      return _aliases.FirstOrDefault(a => a.Id == id);
    }

    // Update an existing alias in the database
    public void UpdateAlias(Alias alias)
    {
      var index = _aliases.FindIndex(a => a.Id == alias.Id);
      if (index != -1)
      {
        _aliases[index] = alias;
      }
      SaveAliases();
    }

    // Remove an alias from the database
    public void RemoveAlias(Alias alias)
    {
      _aliases.Remove(alias);
      SaveAliases();
    }

    // Get a list of all aliases in the database
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
