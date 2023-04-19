using System.Collections.Generic;
using CriminalsProgram.Models.Main;

namespace CriminalsProgram.Models.Repositories
{
  public interface ICriminalRepository
  {
    void AddCriminal(Criminal criminal);
    // void EditCriminal(Criminal criminalToUpdate, Criminal updatedCriminal);

    bool UpdateCriminal(int id, Criminal updatedCriminal);
    List<Criminal> SearchCriminals(string query);
    void SaveCriminals();
    // void LoadCriminals();

  }
}