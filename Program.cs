using System;
using CriminalsProgram.Menus;
using static CriminalsProgram.Views.GeneralView;

namespace CriminalsProgram;
class Program
{
  static void Main(string[] args)
  {
    Console.Clear();
    Console.WriteLine("Головне меню");
    Console.WriteLine("1. Відкрити меню злочинців");
    Console.WriteLine("2. Відкрити меню угруповань");

    string choice = PromptString("Виберіть опцію: ");

    switch (choice)
    {
      case "1":
        CriminalMenu.ShowMenu();
        break;
      case "2":
        AliasMenu.ShowMenu();
        break;
      default:
        Log("Невірний вибір опції. Натисніть будь-яку клавішу для продовження...");
        Console.ReadKey();
        break;
    }
  }

}
// danger level