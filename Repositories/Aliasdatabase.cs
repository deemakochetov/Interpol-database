using System;
using System.Collections.Generic;
using System.Linq;
using CriminalsProgram.Models.Helpers;

namespace CriminalsProgram.Models.Main
{
  public class AliasDatabase
  {
    private readonly List<Alias> _aliases;

    public AliasDatabase()
    {
      _aliases = new List<Alias>();
    }

    // Add a new alias to the database
    public void AddAlias(Alias alias)
    {
      _aliases.Add(alias);
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
    }

    // Remove an alias from the database
    public void RemoveAlias(Alias alias)
    {
      _aliases.Remove(alias);
    }

    // Get a list of all aliases in the database
    public List<Alias> GetAllAliases()
    {
      return _aliases.ToList();
    }
  }
}
