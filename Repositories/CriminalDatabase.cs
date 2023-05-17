using System.Collections.Generic;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Interfaces;


namespace CriminalsProgram.Repositories
{
  class CriminalDatabase : ICriminalRepository
  {
    private List<Criminal> activeCriminals;
    private List<Criminal> archivedCriminals;
    private string fileName;

    public CriminalDatabase()
    {
      activeCriminals = new List<Criminal>();
      archivedCriminals = new List<Criminal>();
      fileName = "criminals.json";
      LoadCriminals();
    }

    public List<Criminal> GetActiveCriminals()
    {
      return activeCriminals;
    }

    public List<Criminal> GetArchivedCriminals()
    {
      return archivedCriminals;
    }

    public void AddCriminal(Criminal criminal)
    {
      if (criminal.Status == CriminalStatus.Dead) return;
      if (criminal.Status == CriminalStatus.Archived)
      {
        archivedCriminals.Add(criminal);
      }
      else
      {
        activeCriminals.Add(criminal);
      }
      SaveCriminals();
    }
    private void EditCriminal(Criminal criminalToUpdate, Criminal updatedCriminal)
    {
      criminalToUpdate.FirstName = updatedCriminal.FirstName;
      criminalToUpdate.LastName = updatedCriminal.LastName;
      criminalToUpdate.Gender = updatedCriminal.Gender;
      criminalToUpdate.Description = updatedCriminal.Description;
      criminalToUpdate.DateOfBirth = updatedCriminal.DateOfBirth;
      criminalToUpdate.Status = updatedCriminal.Status;
    }
    public bool UpdateCriminal(int id, Criminal updatedCriminal, CriminalStatus lastStatus)
    {
      Criminal? criminalToUpdate = activeCriminals.Find(criminal => criminal.Id == id);
      if (criminalToUpdate == null)
      {
        criminalToUpdate = archivedCriminals.Find(criminal => criminal.Id == id);
      }
      if (criminalToUpdate == null) return false;

      if (updatedCriminal.Status == CriminalStatus.Active)
      {
        if (lastStatus == CriminalStatus.Archived)
        {
          archivedCriminals.Remove(criminalToUpdate);
          activeCriminals.Add(criminalToUpdate);
        }
      }
      if (updatedCriminal.Status == CriminalStatus.Archived)
      {
        if (lastStatus == CriminalStatus.Active)
        {
          activeCriminals.Remove(criminalToUpdate);
          archivedCriminals.Add(criminalToUpdate);
        }
      }
      if (updatedCriminal.Status == CriminalStatus.Dead)
      {
        if (lastStatus == CriminalStatus.Active)
        {
          activeCriminals.Remove(criminalToUpdate);
        }
        if (lastStatus == CriminalStatus.Archived)
        {
          archivedCriminals.Remove(criminalToUpdate);
        }
      }
      SaveCriminals();
      return true;
    }

    public List<Criminal> SearchCriminals(string query)
    {
      List<Criminal> results = new List<Criminal>();

      foreach (Criminal criminal in activeCriminals)
      {
        if ((criminal.FirstName + " " + criminal.LastName).ToLower().Contains(query.ToLower()) ||
            criminal.Description.ToLower().Contains(query.ToLower()))
        {
          results.Add(criminal);
        }
      }

      return results;
    }

    public void SaveCriminals()
    {
      FileHelper.SaveCriminals(fileName, activeCriminals, archivedCriminals);
    }

    private void LoadCriminals()
    {
      FileHelper.LoadCriminals(fileName, out activeCriminals, out archivedCriminals);
    }
    public List<Criminal> GetAliasMembers(int id)
    {
      return activeCriminals.Where(criminal => criminal.Aliases.Select(alias => alias.Id).Contains(id)).ToList();
    }
  }
}