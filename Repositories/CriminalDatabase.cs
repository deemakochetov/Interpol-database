using System.Collections.Generic;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Models.Repositories;


namespace CriminalsProgram.Repositories
{
  class CriminalDatabase : ICriminalRepository
  {
    private List<Criminal> activeCriminals;
    private List<Criminal> archivedCriminals;
    private int nextId;

    public CriminalDatabase()
    {
      activeCriminals = new List<Criminal>();
      archivedCriminals = new List<Criminal>();
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
      criminal.Id = nextId;
      nextId++;
      if (criminal.Status == CriminalStatus.Dead)
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
      criminalToUpdate.DangerLevel = updatedCriminal.DangerLevel;
      criminalToUpdate.DateOfBirth = updatedCriminal.DateOfBirth;
      criminalToUpdate.Status = updatedCriminal.Status;
    }
    public bool UpdateCriminal(int id, Criminal updatedCriminal)
    {
      // Find the criminal to be updated
      Criminal criminalToUpdate = activeCriminals.Find(criminal => criminal.Id == id);
      if (criminalToUpdate == null)
      {
        criminalToUpdate = archivedCriminals.Find(criminal => criminal.Id == id);
      }
      if (criminalToUpdate == null) return false;




      if (updatedCriminal.Status == CriminalStatus.Active)
      {
        if (criminalToUpdate.Status == CriminalStatus.Archived)
        {
          archivedCriminals.Remove(criminalToUpdate);
          EditCriminal(criminalToUpdate, updatedCriminal);
          activeCriminals.Add(criminalToUpdate);
        }
      }
      if (updatedCriminal.Status == CriminalStatus.Archived)
      {
        if (criminalToUpdate.Status == CriminalStatus.Active)
        {
          activeCriminals.Remove(criminalToUpdate);
          EditCriminal(criminalToUpdate, updatedCriminal);
          archivedCriminals.Add(criminalToUpdate);
        }
      }
      if (updatedCriminal.Status == CriminalStatus.Dead)
      {
        if (criminalToUpdate.Status == CriminalStatus.Active)
        {
          activeCriminals.Remove(criminalToUpdate);
        }
        if (criminalToUpdate.Status == CriminalStatus.Archived)
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
      {// optimize name
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
      using (StreamWriter sw = new StreamWriter("criminals.txt"))
      {
        foreach (Criminal criminal in activeCriminals)
        {
          sw.WriteLine(criminal.ToString());
        }

        foreach (Criminal criminal in archivedCriminals)
        {
          sw.WriteLine(criminal.ToString() + ",archived");
        }
      }
    }

    private void LoadCriminals()
    {
      if (!File.Exists("criminals.txt"))
      {
        return;
      }

      using (StreamReader sr = new StreamReader("criminals.txt"))
      {
        while (!sr.EndOfStream)
        {
          string line = sr.ReadLine();
          string[] parts = line.Split(',');

          int id = int.Parse(parts[0]);
          string firstName = parts[1];
          string lastName = parts[2];
          DateOnly dateOfBirth = DateOnly.Parse(parts[3]);
          // condider byte
          int age = int.Parse(parts[4]);
          string gender = parts[5];
          string description = parts[6];
          // dont use commas
          CriminalStatus status = (CriminalStatus)Enum.Parse(typeof(CriminalStatus), parts[7], true);
          Criminal criminal = new Criminal(id, firstName, lastName, dateOfBirth, age, (Gender)Enum.Parse(typeof(Gender), gender, true), description, status);

          if (parts.Length > 5 && parts[7] == CriminalStatus.Dead.ToString())
          {
            archivedCriminals.Add(criminal);
          }
          else
          {
            activeCriminals.Add(criminal);
          }
        }
      }
    }
  }
}