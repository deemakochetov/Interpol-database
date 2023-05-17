using System;
using System.Text.Json;
using CriminalsProgram.Models.Main;

namespace CriminalsProgram.Helpers
{
  public class FileHelper
  {
    public static void SaveCriminals(string fileName, List<Criminal> activeCriminals, List<Criminal> archivedCriminals)
    {
      try
      {
        var data = new { ActiveCriminals = activeCriminals, ArchivedCriminals = archivedCriminals };

        string jsonData = JsonSerializer.Serialize(data);

        File.WriteAllText(fileName, jsonData);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Помилка при записуванні даних до файлу: " + ex.Message);
      }
    }
    public class JsonFormatCriminals
    {
      public List<Criminal> ActiveCriminals { get; set; } = new List<Criminal>();
      public List<Criminal> ArchivedCriminals { get; set; } = new List<Criminal>();
    }

    public class JsonFormatAliases
    {
      public List<Alias> Aliases { get; set; } = new List<Alias>();
    }
    public static void LoadCriminals(string fileName, out List<Criminal> activeCriminals, out List<Criminal> archivedCriminals)
    {
      try
      {
        string jsonData = File.ReadAllText(fileName);

        JsonFormatCriminals? data = JsonSerializer.Deserialize<JsonFormatCriminals>(jsonData);
        if (data == null) throw new Exception();

        activeCriminals = data.ActiveCriminals;
        archivedCriminals = data.ArchivedCriminals;
      }
      catch (Exception ex)
      {
        if (ex.Message.Contains("Could not find file")) Console.WriteLine("Файл не був знайдений. Він буде створений при додаванні нових злочинців");
        else Console.WriteLine("Помилка читання з фалу: " + ex.Message);
        activeCriminals = new List<Criminal>(new Criminal[0]);
        archivedCriminals = new List<Criminal>(new Criminal[0]);
      }
    }

    public static void SaveAliases(string fileName, List<Alias> aliases)
    {
      try
      {
        var data = new { Aliases = aliases };

        string jsonData = JsonSerializer.Serialize(data);

        File.WriteAllText(fileName, jsonData);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Помилка при записуванні даних до файлу: " + ex.Message);
      }
    }

    public static void LoadAliases(string fileName, out List<Alias> aliases)
    {
      try
      {
        string jsonData = File.ReadAllText(fileName);

        JsonFormatAliases? data = JsonSerializer.Deserialize<JsonFormatAliases>(jsonData);
        if (data == null) throw new Exception();

        aliases = data.Aliases;
      }
      catch (Exception ex)
      {
        if (ex.Message.Contains("Could not find file")) Console.WriteLine("Файл не був знайдений. Він буде створений при додаванні нових угруповань");
        else Console.WriteLine("Помилка читання з фалу: " + ex.Message);
        aliases = new List<Alias>(new Alias[0]);
      }
    }

    public static string SaveStringToFile(string text)
    {
      string fileName = Path.GetRandomFileName();
      string filePath = Path.Combine("prints", fileName);

      Directory.CreateDirectory("prints");

      File.WriteAllText(filePath, text);

      return fileName;
    }
  }
}
