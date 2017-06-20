using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Player : IPlayer
  {
    public string CharacterName;
    public int Score { get; set; }
    public List<Item> Inventory { get; set; }
    public Player()
    {
      CharacterName = NameCharacter();
      Score = 0;
      Inventory = new List<Item>();
    }
    public string NameCharacter()
    {
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("What would you like your character's name to be?\n");
      Console.ForegroundColor = ConsoleColor.White;
      string CharacterName = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("Great! Your character is now named " + CharacterName + "\n");
      Console.ForegroundColor = ConsoleColor.Magenta;
      return CharacterName;
    }
    public void ShowInventory(Player player)
    {
      System.Console.WriteLine("your inventory");
      for(int i = 0; i < player.Inventory.Count; i++){
        System.Console.WriteLine($"{player.Inventory[i].Name}\n {player.Inventory[i].Description}");
      }
    }
  }
}