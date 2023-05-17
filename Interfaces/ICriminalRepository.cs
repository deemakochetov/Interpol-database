using System;
using System.Collections.Generic;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;

namespace CriminalsProgram.Interfaces
{
  public interface ICriminalRepository
  {
    void AddCriminal(Criminal criminal);
    bool UpdateCriminal(int id, Criminal updatedCriminal, CriminalStatus lastStatus);
    List<Criminal> SearchCriminals(string query);
    void SaveCriminals();
  }
}