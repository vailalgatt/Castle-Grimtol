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
        public Boolean Playing = true;

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Valid actions are north and south.\nEX: north or south.\nLOOK or l: allows you to scan the room. \nHELP or h: displays a list of all the commands needed for this game.\nTAKE or t: adds an item to your inventory list. EX: Take Potato.\nINVENTORY or i: Views the items in your inventory.\nQUIT or q: leaves the game.\n");
        }


        public void BuildRooms()
        {
            Room path = new Room("Path", "You begin on a path, there is no other direction than forward to move. You look around for anything to entertain you on your journey. (hint: use 'look')");
            Room bridge = new Room("Bridge", "You walk a little ways until you find a small bridge crossing a raging river.");
            Room hill = new Room("Hill", "After you cross the bridge, you make your way up a hill. As you're trekking you are accosted by a mean little troll. The troll is relentless, look in your inventory to use something to get rid of the troll. (hint: use 'inventory')");
            Room tree = new Room("Tree", "You're encounter with the troll has left you exhausted. You sluggishly approach a tall redwood tree. There is a soft patch of grass at the base of the tree. You curl up on the patch of grass and take a nap. :) THE END");

            BuildExits();
            BuildItems();
            //ItemToRoom();


            void BuildExits()
            {
                path.Door("north", bridge);
                bridge.Door("south", path);
                bridge.Door("north", hill);
                hill.Door("south", bridge);
                hill.Door("north", tree);
                tree.Door("south", hill);
            }
            void BuildItems()
            {
                Item potato = new Item("Potato", "A magical potato");
                path.Items.Add(potato);

                Item nap = new Item("Nap", "For emergencies only");
                path.Items.Add(nap);
            }

            CurrentRoom = path;
        }

        public void UseItem(string itemName)
        {
            string potatoWin = "potato";
            string napLose = "nap";
            if (itemName.ToLower() == potatoWin)
            {
                Console.WriteLine("The magical properties of this potato causes the owner of the potato to become repellent to any kind of conversation. You are safe from social interaction.");
            }
            if(itemName.ToLower() == napLose)
            {
                Console.WriteLine("Go home, GRANDMA!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER");
                Playing = false;
            }
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
