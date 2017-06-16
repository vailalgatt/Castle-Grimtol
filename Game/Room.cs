using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //instantiate new dictionary
        public Dictionary<string, string> Exits = new Dictionary<string, string>();

        List<Item> IRoom.Items { get; set; }


        public void UseItem(Item item)
        {
        }
        //dictionary of direction
        //first value a string
        //second value a room
        //Dictionary<string, object, exits>
}
}
