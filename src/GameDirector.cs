using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SwinGameSDK;

//ANDY - NGUYEN THE ANH DINH 2018

namespace MyGame.src
{
    public static class GameDirector
    {
        //--FIELDS--//
        private static SwinGameSDK.Timer _time;
        private static int _count, _total;
        private static Random _rnd;

        //--METHODS--//
        public static class Constants
        {
            public const int SCREEN_WIDTH = 800;
            public const int SCREEN_HEIGHT = 600;
        }

        static GameDirector()
        {
            _rnd = new Random();
            _time = new SwinGameSDK.Timer();
            _time.Start();
            _total = _rnd.Next(4, 10);
            _count = 1;
        }

        public static void Update()
        {
            if (_time.Ticks > 5000 && _count <= _total)
            {
                SpawnZombies();
                _time.Reset();
                _time.Start();
                _count++;
            }
            DrawUI();
        }

        public static void SpawnZombies()
        {
            Zombie z = new Zombie(GameDirector.Constants.SCREEN_WIDTH, 350);
            GameInterface.AddZombie(z);
        }

        public static void DrawUI()
        {
            SwinGame.DrawBitmap("logo_wizard.png", (Constants.SCREEN_WIDTH / 2) - 160, 520);
            SwinGame.DrawBitmap("logo_fireball.png", (Constants.SCREEN_WIDTH / 2) - 79, 551);
            SwinGame.DrawBitmap("FrameUI.png", (Constants.SCREEN_WIDTH / 2) - 80, 550);
            SwinGame.DrawBitmap("FrameUI.png", (Constants.SCREEN_WIDTH / 2) - 30, 550);
            SwinGame.DrawBitmap("FrameUI.png", (Constants.SCREEN_WIDTH / 2) + 20, 550);
            SwinGame.DrawText("Q", Color.White, (Constants.SCREEN_WIDTH / 2) - 76, 554);
            SwinGame.DrawText("W", Color.White, (Constants.SCREEN_WIDTH / 2) - 26, 554);
            SwinGame.DrawText("E", Color.White, (Constants.SCREEN_WIDTH / 2) + 24, 554);
            SwinGame.DrawBitmap("ADlogo.png", 0, 560);
            SwinGame.DrawBitmap("head.png", 700, 0);
            SwinGame.DrawText(" X " + (GameDirector.TotalZombie - (GameInterface.Map.CountKilledZom + GameInterface.Map.CountOutZom)).ToString(), Color.White, 735, 15);
            SwinGame.DrawText(" Killed: " + GameInterface.Map.CountKilledZom.ToString(), Color.White, 700, 40);
            SwinGame.DrawText(" Accessed: " + GameInterface.Map.CountOutZom.ToString(), Color.White, 700, 50);
        }

        public static void DrawSkill(string name)
        {
            switch (name)
            {
                case "heal":
                    SwinGame.DrawBitmap("logo_heal.png",(Constants.SCREEN_WIDTH / 2) - 29, 551);
                    break;
                case "teleport":
                    SwinGame.DrawBitmap("logo_teleport.png", (Constants.SCREEN_WIDTH / 2) + 21, 551);
                    break;
                default: return;
            }
        }

        //--PROPERTIES--//
        public static int TotalZombie
        {
            get { return _total; }
            set { _total = value; }
        }

    }
}
