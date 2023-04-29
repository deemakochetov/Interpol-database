using System;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Services;

namespace CriminalsProgram.Views
{
  public static class GeneralView
  {
    public static void LogSuccess()
    {
      Console.WriteLine("Операція успішно виконана!");
    }
    public static void Log(string message)
    {
      Console.WriteLine(message);
    }
    public static string PromptString(string message)
    {
      Console.Write(message);
      string input = Console.ReadLine();
      return input;
    }
    public static int PromptInt(string message)
    {
      Log(message);
      string input = Console.ReadLine();
      int number;
      if (int.TryParse(input, out number))
      {
        return number;
      }
      else
      {
        Log("Значення повинне бути числом");
        return PromptInt(message);
      }
    }
  }
}