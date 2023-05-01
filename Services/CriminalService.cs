using CriminalsProgram.Models.Main;
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
      return criminals.Where(criminal => criminal.FirstName == name).ToList();
    }

    public static List<Criminal> FilterBySurname(List<Criminal> criminals, string surname)
    {
      return criminals.Where(criminal => criminal.LastName == surname).ToList();
    }

    public static List<Criminal> FilterByEyesColor(List<Criminal> criminals, string eyesColor)
    {
      return criminals.Where(criminal => criminal.EyesColor == eyesColor).ToList();
    }

    public static List<Criminal> FilterByHairColor(List<Criminal> criminals, string hairColor)
    {
      return criminals.Where(criminal => criminal.HairColor == hairColor).ToList();
    }

    public static List<Criminal> FilterByNationality(List<Criminal> criminals, string nationality)
    {
      return criminals.Where(criminal => criminal.Nationality == nationality).ToList();
    }
    public static List<Criminal> FilterByCriminalJob(List<Criminal> criminals, string criminalJob)
    {
      return criminals.Where(criminal => criminal.CriminalJob == criminalJob).ToList();
    }
    public static List<Criminal> FilterByAge(List<Criminal> criminals, int age)
    {
      int currentYear = DateTime.Now.Year;
      int filterBirthYear = currentYear - age;
      return criminals.Where(criminal => criminal.DateOfBirth.Year == filterBirthYear).ToList();
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
      int latestId = Math.Max(activeCriminals.Last().Id, archivedCriminals.Last().Id);
      return latestId;
    }

    public static void AddCriminal(Criminal newCriminal)
    {
      database.AddCriminal(newCriminal);
    }
    public static void UpdateCriminal(int id, Criminal newCriminal)
    {
      database.UpdateCriminal(id, newCriminal);
    }


  }
}