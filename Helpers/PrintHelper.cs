using System;
using System.Text.Json;
using CriminalsProgram.Interfaces;

namespace CriminalsProgram.Helpers
{
  public class PrintHelper
  {
    public static string Separator = "---------------------------";
    public static string SaveForPrint<T>(List<T> objects) where T : IReviewable
    {
      string stringForPrint = "";
      foreach (T singleObject in objects)
      {
        stringForPrint += singleObject.GetReview();
        stringForPrint += $"\n{Separator}\n";
      }
      string fileName = FileHelper.SaveStringToFile(stringForPrint);
      return fileName;
    }

    public static void SaveToBackup<T>(T singleObject) where T : IReviewable
    {
      string stringForPrint = "";

      stringForPrint += singleObject.GetReview();
      stringForPrint += $"\n{Separator}\n";

      FileHelper.SaveStringToBackup(stringForPrint);
    }
  }
}
