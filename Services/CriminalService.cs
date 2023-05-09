using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Repositories;
using CriminalsProgram.Views;

using static CriminalsProgram.Views.GeneralView;

namespace CriminalsProgram.Services
{
  static class CriminalService
  {
    private static int nextId = -1;

    private static CriminalDatabase database = new CriminalDatabase();

    public static List<Criminal> FilterByName(List<Criminal> criminals, string name)
    {
      return criminals.Where(criminal => criminal.FirstName.ToLower() == name.ToLower()).ToList();
    }

    public static List<Criminal> FilterBySurname(List<Criminal> criminals, string surname)
    {
      return criminals.Where(criminal => criminal.LastName.ToLower() == surname.ToLower()).ToList();
    }

    public static List<Criminal> FilterByEyesColor(List<Criminal> criminals, string eyesColor)
    {
      return criminals.Where(criminal => criminal.EyesColor.ToLower() == eyesColor.ToLower()).ToList();
    }

    public static List<Criminal> FilterByHairColor(List<Criminal> criminals, string hairColor)
    {
      return criminals.Where(criminal => criminal.HairColor.ToLower() == hairColor.ToLower()).ToList();
    }

    public static List<Criminal> FilterByNationality(List<Criminal> criminals, string nationality)
    {
      return criminals.Where(criminal => criminal.Nationality.ToLower() == nationality.ToLower()).ToList();
    }
    public static List<Criminal> FilterByCriminalJob(List<Criminal> criminals, string criminalJob)
    {
      return criminals.Where(criminal => criminal.CriminalJob.ToLower() == criminalJob.ToLower()).ToList();
    }
    public static List<Criminal> FilterByBirthYear(List<Criminal> criminals, int birthYear)
    {
      return criminals.Where(criminal => criminal.DateOfBirth.Year == birthYear).ToList();
    }
    public static List<Criminal> GetActiveCriminals()
    {
      List<Criminal> activeCriminals = database.GetActiveCriminals();
      return activeCriminals;
    }

    public static List<Criminal> GetAllCriminals()
    {
      List<Criminal> activeCriminals = database.GetActiveCriminals();
      List<Criminal> archivedCriminals = database.GetArchivedCriminals();
      return activeCriminals.Concat(archivedCriminals).ToList();
    }

    public static List<Criminal> GetArchivedCriminals()
    {
      List<Criminal> archivedCriminals = database.GetArchivedCriminals();
      return archivedCriminals;
    }

    public static List<Criminal> SearchCriminals(string query)
    {
      List<Criminal> activeCriminals = database.GetActiveCriminals();
      List<Criminal> results = new List<Criminal>();

      foreach (Criminal criminal in activeCriminals)
      {
        if (criminal.FirstName.ToLower().Contains(query.ToLower()) ||
        criminal.LastName.ToLower().Contains(query.ToLower()) ||
        criminal.CriminalJob.ToLower().Contains(query.ToLower()) ||
            criminal.Description.ToLower().Contains(query.ToLower())
            )
        {
          results.Add(criminal);
        }
      }

      return results;
    }
    public static int getNextId()
    {
      if (nextId == -1) nextId = getLatestId();
      nextId++;
      return nextId;
    }
    public static int getLatestId()
    {
      List<Criminal> activeCriminals = GetActiveCriminals();
      List<Criminal> archivedCriminals = GetArchivedCriminals();
      int latestId = Math.Max(activeCriminals.LastOrDefault()?.Id ?? 0, archivedCriminals.LastOrDefault()?.Id ?? 0);
      return latestId;
    }

    public static void AddCriminal(Criminal newCriminal)
    {
      database.AddCriminal(newCriminal);
    }
    public static void UpdateCriminal(int id, Criminal newCriminal, CriminalStatus lastStatus)
    {
      database.UpdateCriminal(id, newCriminal, lastStatus);
    }
    public static List<Criminal> GetAliasMembers(int id)
    {
      List<Criminal> members = database.GetAliasMembers(id);
      return members;
    }
  }
}