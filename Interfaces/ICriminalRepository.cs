using System.Collections.Generic;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;

namespace CriminalsProgram.Interfaces
{
  public interface ICriminalRepository
  {
    void AddCriminal(Criminal criminal);
    // void EditCriminal(Criminal criminalToUpdate, Criminal updatedCriminal);

    bool UpdateCriminal(int id, Criminal updatedCriminal, CriminalStatus lastStatus);
    List<Criminal> SearchCriminals(string query);
    void SaveCriminals();
    // void LoadCriminals();

  }
}