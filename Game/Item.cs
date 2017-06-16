using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Dictionary<string, int> Items = new Dictionary<string, int>();

    }
}