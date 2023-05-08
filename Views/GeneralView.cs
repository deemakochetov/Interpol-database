using System;
using CriminalsProgram.Models.Main;
using CriminalsProgram.Models.Helpers;
using CriminalsProgram.Services;
using CriminalsProgram.Interfaces;

namespace CriminalsProgram.Views
{
  public static class GeneralView
  {
    public static void ListObjects<T>(List<T> objects) where T : IReviewable
    {
      if (objects.Count == 0)
      {
        Log("Список порожній.");
      }
      else
      {
        Log($"Знайдено {objects.Count} обʼєктів:");
        foreach (T instance in objects)
        {
          Log(instance.GetReview());
          LogSeparator();
        }
      }
      Log("Натисніть будь-яку клавішу для продовження...");
      Console.ReadKey();
    }
    public static void LogSuccess()
    {
      Log("Операція успішно виконана!");
    }
    public static void Log(string message)
    {
      Console.WriteLine(message);
    }

    public static void Print(string message)
    {
      Console.Write(message);
    }

    public static string PromptString(string message)
    {
      Print(message);
      string input = Console.ReadLine();
      if (string.IsNullOrEmpty(input))
      {
        Log("Введене значення не може бути порожнім");
        return PromptString(message);
      }
      return input;
    }
    public static int PromptInt(string message)
    {
      Print(message);
      string input = Console.ReadLine();
      if (string.IsNullOrEmpty(input))
      {
        Log("Введене значення не може бути порожнім");
        return PromptInt(message);
      }
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

    public static void LogSeparator()
    {
      Log("--------------------------");
    }
    public static void PromptClick()
    {
      Log("Натисніть будь-яку клавішу для продовження...");
      Console.ReadKey();
    }
    public static int PromptId()
    {
      Print("Введіть ID обʼєкта для редагування: ");
      string input = Console.ReadLine();
      int id;
      if (int.TryParse(input, out id))
      {
        return id;
      }
      else
      {
        Log("Невірне ID обʼєкта");
        return PromptId();
      }
    }

    public static DateOnly PromptBirthDate()
    {
      Print("Дата народження (yyyy-mm-dd): ");
      string input = Console.ReadLine();
      DateOnly dateOfBirth;
      if (DateOnly.TryParse(input, out dateOfBirth))
      {
        return dateOfBirth;
      }
      else
      {
        Log("Некоректний формат");
        return PromptBirthDate();
      }
    }
  }
}