using System;
using System.Text.Json;
using CriminalsProgram.Interfaces;

namespace CriminalsProgram.Helpers
{
  public class PrintHelper
  {
    public static string SaveForPrint<T>(List<T> objects, string Divider) where T : IReviewable
    {
      string stringForPrint = "";
      foreach (T singleObject in objects)
      {
        stringForPrint += singleObject.GetReview();
        stringForPrint += $"\n{Divider}\n";
      }
      string fileName = FileHelper.SaveStringToFile(stringForPrint);
      return fileName;
    }
  }
}
