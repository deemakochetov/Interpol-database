using System;
using CriminalsProgram.Interfaces;
using CriminalsProgram.Helpers;

namespace CriminalsProgram.Views
{
  public static class GeneralView
  {
    public static string Separator = "---------------------------";
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
      SuggestPrint<T>(objects);
    }
    public static void SuggestPrint<T>(List<T> objects) where T : IReviewable
    {
      Log("Опції:");
      Log("1. Зберегти дані цих обʼєктів до файлу для друку");
      Log("2. Продовжити");
      int option = PromptInt("Оберіть опцію: ");
      switch (option)
      {
        case 1:
          string fileName = PrintHelper.SaveForPrint<T>(objects, Separator);
          Log($"Усі дані обраних обʼєктів були збережені до файлу {fileName} у папці prints");
          PromptClick();
          break;
        case 2:
          return;
        default:
          Log("Некорректний ввід");
          SuggestPrint(objects);
          break;
      }
    }
    public static bool SuggestFilter()
    {
      Log("Опції:");
      Log("1. Додати ще фільтр");
      Log("2. Завершити");
      int option = PromptInt("Оберіть опцію: ");
      switch (option)
      {
        case 1:
          return true;
        case 2:
          return false;
        default:
          Log("Некорректний ввід");
          return SuggestFilter();
      }
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
      string? input = Console.ReadLine();
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
      string? input = Console.ReadLine();
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
      Log(Separator);
    }
    public static void PromptClick()
    {
      Log("Натисніть будь-яку клавішу для продовження...");
      Console.ReadKey();
    }
    public static int PromptId()
    {
      string input = PromptString("Введіть ID обʼєкта: ");
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
      string? input = Console.ReadLine();
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