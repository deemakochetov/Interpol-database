using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Repositories;
using CriminalsProgram.Views;

namespace CriminalsProgram.Services
{
  static class CriminalService
  {
    private static CriminalDatabase database = new CriminalDatabase();

    public static List<Criminal> FilterByName(List<Criminal> criminals, string name)
    {
      return criminals.Where(criminal => criminal.FirstName == name).ToList();
    }

    public static List<Criminal> FilterBySurname(List<Criminal> criminals, string surname)
    {
      return criminals.Where(criminal => criminal.LastName == surname).ToList();
    }

    public static List<Criminal> FilterByAge(List<Criminal> criminals, int age)
    {
      return criminals.Where(criminal => criminal.Age == age).ToList();
    }

    public static List<Criminal> FilterCriminals(List<Criminal> criminals, string filterType, string filterValue)
    {
      List<Criminal> filteredCriminals = new List<Criminal>();

      foreach (Criminal criminal in criminals)
      {
        switch (filterType)
        {
          case "age":
            if (criminal.Age.ToString() == filterValue)
            {
              filteredCriminals.Add(criminal);
            }
            break;
          case "gender":
            if (criminal.Gender.ToString() == filterValue)
            {
              filteredCriminals.Add(criminal);
            }
            break;
          case "birth":
            if (criminal.DateOfBirth == DateOnly.Parse(filterValue))
            {
              filteredCriminals.Add(criminal);
            }
            break;
          case "level":
            if (criminal.DangerLevel == byte.Parse(filterValue))
            {
              filteredCriminals.Add(criminal);
            }
            break;
        }
      }
      // && (filter == "" || criminal.Description.Contains(filter) || criminal.Age.ToString() == filter || criminal.Status.ToString().Contains(filter))
      return filteredCriminals;
    }

    public static void ShowActiveCriminals()
    {
      List<Criminal> activeCriminals = database.GetActiveCriminals();
      CriminalView.ShowCriminals(activeCriminals);
    }
    public static List<Criminal> GetActiveCriminals()
    {
      List<Criminal> activeCriminals = database.GetActiveCriminals();
      return activeCriminals;
    }

    public static void ShowArchivedCriminals()
    {
      List<Criminal> archivedCriminals = database.GetArchivedCriminals();
      CriminalView.ShowCriminals(archivedCriminals);
    }
    public static List<Criminal> GetArchivedCriminals()
    {
      List<Criminal> activeCriminals = database.GetActiveCriminals();
      return activeCriminals;
    }

    public static List<Criminal> SearchCriminals(string query)
    {
      List<Criminal> activeCriminals = database.GetActiveCriminals();
      List<Criminal> results = new List<Criminal>();

      foreach (Criminal criminal in activeCriminals)
      {
        if (criminal.FirstName.ToLower().Contains(query.ToLower()) ||
        criminal.LastName.ToLower().Contains(query.ToLower()) ||
            criminal.Description.ToLower().Contains(query.ToLower())
            )
        {
          results.Add(criminal);
        }
      }

      return results;
    }


    public static void AddCriminal()
    {
      Criminal newCriminal = CriminalView.PromptCriminal();

      database.AddCriminal(newCriminal);
      CriminalView.LogSuccess();
    }
  }
}