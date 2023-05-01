using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CriminalsProgram.Models.Main
{
  public class FileHelper
  {
    public static void SaveCriminals(string fileName, List<Criminal> activeCriminals, List<Criminal> archivedCriminals)
    {
      try
      {
        // Create a new object to hold the criminals data
        var data = new { ActiveCriminals = activeCriminals, ArchivedCriminals = archivedCriminals };

        // Serialize the data to JSON format
        string jsonData = JsonSerializer.Serialize(data);

        // Write the JSON data to the file
        File.WriteAllText(fileName, jsonData);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error writing to file: " + ex.Message);
      }
    }
    public class JsonFormatCriminals
    {
      public List<Criminal> ActiveCriminals { get; set; }
      public List<Criminal> ArchivedCriminals { get; set; }
    }

    public class JsonFormatAliases
    {
      public List<Alias> Aliases { get; set; }
    }
    public static void LoadCriminals(string fileName, out List<Criminal> activeCriminals, out List<Criminal> archivedCriminals)
    {
      try
      {
        // Read the JSON data from the file
        string jsonData = File.ReadAllText(fileName);
        // Console.WriteLine(jsonData);

        // Deserialize the JSON data to an object
        JsonFormatCriminals data = JsonSerializer.Deserialize<JsonFormatCriminals>(jsonData);

        activeCriminals = data.ActiveCriminals;
        archivedCriminals = data.ArchivedCriminals;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error reading from file: " + ex.Message);
        activeCriminals = new List<Criminal>(new Criminal[0]);
        archivedCriminals = new List<Criminal>(new Criminal[0]);

      }
    }

    public static void SaveAliases(string fileName, List<Alias> aliases)
    {
      try
      {
        var data = new { Aliases = aliases };

        // Serialize the data to JSON format
        string jsonData = JsonSerializer.Serialize(data);

        // Write the JSON data to the file
        File.WriteAllText(fileName, jsonData);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error writing to file: " + ex.Message);
      }
    }

    public static void LoadAliases(string fileName, out List<Alias> aliases)
    {
      try
      {
        // Read the JSON data from the file
        string jsonData = File.ReadAllText(fileName);

        // Deserialize the JSON data to an object
        JsonFormatAliases data = JsonSerializer.Deserialize<JsonFormatAliases>(jsonData);

        aliases = data.Aliases;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error reading from file: " + ex.Message);
        aliases = new List<Alias>(new Alias[0]);
      }
    }
  }
}
