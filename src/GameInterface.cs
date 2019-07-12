using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public static class GameInterface
    {
        //--FIELDS--//
        private static Map _map = null;

        //--METHODS--//

        public static void Launch()
        {
            Wizard w = new Wizard("Hiroshi", 300, 400);
            Map map = new Map();
            Book book_teleport = new Book("teleport");
            Book book_heal = new Book("heal");
            map.Books.Add(book_heal);
            map.Books.Add(book_teleport);
            map.AddWizard(w);
            AddMap(map);
        }
        public static void AddMap(Map m)
        {
            Map = m;
        }

        public static void AddWizard(Wizard w)
        {
            Map.AddWizard(w);
        }

        public static void AddZombie(Zombie z)
        {
            Map.AddZombie(z);
        }

        public static void Draw()
        {
            Map.DrawMap();
        }

        public static void Update()
        {
            Draw();
            if (Map.Wizard != null)
            {
                Map.UpdateMap();
                GameDirector.Update();
            }
            else if (Map.Zombies.Count == 0 && Map.CountOutZom < (GameDirector.TotalZombie / 2) + 1)
            {
                SwinGame.DrawBitmap("win.png", 250, 250);          //Draw "You Win"
            }
            else
            {
                SwinGame.DrawBitmap("lose.png", 150, 150);         //Draw "You Lose"
            }
        }

        //--PROPERTIES--//
        public static Map Map
        {
            get { return _map; }
            set { _map = value; }
        }
    }
}
