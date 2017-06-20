using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }

    }
}