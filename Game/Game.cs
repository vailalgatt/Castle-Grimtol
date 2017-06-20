using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        // public Dictionary<string, Room> Rooms = new Dictionary<string, Room>();
        //public Dictionary<string, Item> Inventory = new Dictionary<string, Item>();

        public void Reset()
        {
        }

        public void Setup()
        {
            Console.Clear();
            Console.WriteLine("\n---------Vail's Console Game ----------\n");
            Console.WriteLine("Hi, this is my console game");
            CurrentPlayer = new Player();
            Help();
        }

        public string GetUserInput()
        {
            System.Console.WriteLine("Where do you want to go?");
            string input = Console.ReadLine();
            return input;
        }



        public Boolean Quit(Boolean playing)
        {
            System.Console.WriteLine("Leave the game? Y/N");
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                return playing = false;
            }
            else
            {
                System.Console.WriteLine("OK");
                return playing = true;
            }
        }
        public void Look(Room room)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.WriteLine($"{room.Name}:\n{room.Description}");
            for (int i = 0; i < room.Items.Count; i++)
            {
                System.Console.WriteLine($"Items: {room.Items[i].Name}\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Help()
        {
            System.Console.WriteLine("Valid actions are north and south.\nEX: north or south.\nLOOK or l: allows you to scan the room. \nHELP or h: displays a list of all the commands needed for this game.\nTAKE or t: adds an item to your inventory list. EX: Take Potato.\nINVENTORY or i: Views the items in your inventory.\nQUIT or q: leaves the game.\n");
        }


        public void BuildRooms()
        {
            Room path = new Room("Path", "You begin on a path, there is no other direction than forward to move. You look around for anything to entertain you on your journey. (hint: use 'look')");
            Room bridge = new Room("Bridge", "This is a bridge");
            Room canyon = new Room("Canyon", "This is a canyon");
            Room tree = new Room("Tree", "This is a tree");

            BuildExits();
            BuildItems();


            void BuildExits()
            {
                path.Door("north", bridge);
                bridge.Door("south", path);
                bridge.Door("north", canyon);
                canyon.Door("south", bridge);
                canyon.Door("north", tree);
                tree.Door("south", canyon);
            }
            void BuildItems()
            {

                //Items
                Item potato = new Item("Potato", "A magical potato");
                path.Items.Add(potato);
            }
            CurrentRoom = path;
        }

        public void UseItem(string itemName)
        {

            // Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
            // if (item != null)
            // {
            //     CurrentRoom.Items.Remove(item);
            //     CurrentPlayer.Inventory.Add(item);
            // }
        }

        public void Take(string itemName)
        {
            Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
            if (item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
            }
        }
    }
}
