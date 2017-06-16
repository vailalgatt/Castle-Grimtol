using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Game : IGame
    {
        Room IGame.CurrentRoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Player IGame.CurrentPlayer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void IGame.Reset()
        {
            throw new NotImplementedException();
        }

        void IGame.Setup()
        {
            //create rooms
            //var path = new Room(....)
            //var bridge = new Room(..)

            // establish directions maybe dictionary
            // path.Exits.Add<"north", bridge>

            //create items
            //var sword = new Item(...)
            //bridge.Items.Add(sword)

            //currentRoom = path
            var Path = new Room();
            var Bridge = new Room();
            var Canyon = new Room();
            var Tree = new Room();

            Path.Exits.Add("North", Bridge);
            Bridge.Exits.Add("South", Path);
            Bridge.Exits.Add("North", Canyon);
            Canyon.Exits.Add("North", Tree);
            Canyon.Exits.Add("South", Bridge);
            Tree.Exits.Add("South", Canyon);


            //Items
            var Sword = new Item();
            var Potato = new Item();
            var Shoes = new Item();
            var Gold = new Item();

            Sword.Items.Add("Sword", Path);
            Potato.Items.Add("Potato", Bridge);
            Shoes.Items.Add("Fancy Shoes", Canyon);
            Gold.Items.Add("Gold", Tree);

            //var Default = Rooms.DefaultRoom;


            
            //Players
            var User = new Player();
            var Troll = new Player();
            
            User.Players.Add("You", Tree);
            User.Players.Add("You", Path);
            User.Players.Add("You", Canyon);
            User.Players.Add("You", Bridge);

            Troll.Players.Add("Troll", Tree);
            Troll.Players.Add("Troll", Path);
            Troll.Players.Add("Troll", Canyon);
            Troll.Players.Add("Troll", Bridge);






        }

        void IGame.UseItem(string itemName)
        {
            throw new NotImplementedException();
        }
    }
}