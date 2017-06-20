using System;
using System.Collections.Generic;


namespace CastleGrimtol.Game
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        //instantiate new dictionary
        public Dictionary<string, Room> Exits = new Dictionary<string, Room>();
        //public Dictionary<string, Item> Items = new Dictionary<string, Item>();


        public void UseItem(Item item)
        {
        }

        public Room(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
            this.Items = new List<Item>();

        }

        public void Door(string direction, Room room)
        {
            Exits.Add(direction, room);
        }

        // public void Stuff(string name, Room room)
        // {
        //     InUse.Add(name, room);
        // }


        //dictionary of direction
        //first value a string
        //second value a room
        //Dictionary<string, object, exits>
    }
}
