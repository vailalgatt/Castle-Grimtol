using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Player : IPlayer
    {
        public int Score { get; set; }
        List<Item> IPlayer.Inventory { get; set; }

        public Dictionary<string, string> Players = new Dictionary<string, string>();

    }
}