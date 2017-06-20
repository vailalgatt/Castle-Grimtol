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
            System.Console.WriteLine("Valid actions are north and south.\nEX: north or south.\nLOOK or l: allows you to scan the room. \nHELP or h: displays a list of all the commands needed for this game.\nTAKE or t: adds an item to your inventory list. EX: Take Gold.\nINVENTORY or i: Views the items in your inventory.\nQUIT or q: leaves the game.\n");
        }

        //create rooms
        //var path = new Room(....)
        //var bridge = new Room(..)

        // establish directions maybe dictionary
        // path.Exits.Add<"north", bridge>

        //create items
        //var sword = new Item(...)
        //bridge.Items.Add(sword)

        //currentRoom = path


        public void BuildRooms()
        {
            // var Path = new Room("path", "this is a path");
            // Rooms.Add("Path", Path);
            // var Bridge = new Room("bridge", "this is a bridge");
            // Rooms.Add("Bridge", Bridge);
            // var Canyon = new Room("canyon", "this is a canyon");
            // Rooms.Add("Canyon", Canyon);
            // var Tree = new Room("tree", "this is a tree");
            // Rooms.Add("Tree", Tree);

            Room path = new Room("Path", "This is a path");
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

        // public void Go(string direction)
        // {
        //     if (CurrentRoom.Exits[direction] != null)
        //     {
        //         Console.WriteLine($"{CurrentRoom}");
        //         CurrentRoom = CurrentRoom.Exits[direction];
        //         Look();
        //     }
        //     //changes current room IF direction is valid
        //     //if currentroom.direction has valid direction -- change current room to value of that property
        //     //return current.room.description 
        // }
        public void UseItem(string itemName)
        {
            Item item = CurrentRoom.Items.Find(Item => Item.Name == itemName);
            if (item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
            }
        }

        // public void Take(Item item){
        //     Console.WriteLine($"{item.Name}:\n{item.Description}");
        //     Console.WriteLine("Item added to your inventory!");
        // }

        // public void AddItems(Item item)
        // {
        //     if(CurrentPlayer.Inventory[Items] != null)
        //     {
        //         Console.WriteLine
        //     }
    }
}
