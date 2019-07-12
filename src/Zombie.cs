using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

//ANDY - NGUYEN THE ANH DINH 2018

namespace MyGame.src
{
    public class Zombie : GameObject
    {
        //--FIELDS--//
        private const int DEFAULT_HEALTH = 40;
        private int _health;
        private Bitmap _zombie;
        private Map _map;

        //--CONSTRUCTORS--//
        public Zombie(float x, float y) : base("zombie")
        {
            _health = DEFAULT_HEALTH;                               //Health = 100;
            base.X = x;                                             //Location of Zombies
            base.Y = y;
            _zombie = SwinGame.BitmapNamed("zombie.png");           //Bitmap of Zombies
        }

        //--METHODS--//
        public void DrawZombie()                                    //Draw zombies
        {
           SwinGame.DrawBitmap(_zombie, base.X, base.Y);
           DrawHealthBar();
        }

        public void UpdateZombie()                                  //Update zombies
        {

            if (!Out && !Dead)                                      //Zombies will go from right to left
            {
                X--;
            }
            else
            {
                RemoveZombie();                                     //Delete zombies if they died or accessed the castle
            }

            foreach (Fireball_Sprite spr in Map.FireBallSpr)        //Check fireball spr in Map
            {                                                       //If collision occurs, Zombies will take damage
                if (SwinGame.BitmapCollision(ZombieCollision, X, Y, spr.FireBallSprCollision, spr.X, spr.Y))
                {
                    IsDamaged();
                    Map.FireBallSpr.Remove(spr);
                    break;
                }
            }

            DrawZombie();

        }

        public void RemoveZombie()
        {
            SwinGame.FreeBitmap(_zombie);
        }

        public void IsDamaged()
        {
            Health -= 10;
            SwinGame.PlaySoundEffect("hit.wav");
        }

        public void DrawHealthBar()                             //Draw health bar
        {
            SwinGame.FillRectangle(Color.White, X + 32f, Y - 5, DEFAULT_HEALTH, 5f);
            SwinGame.FillRectangle(Color.Red, X + 32f, Y - 5, Health, 5f);
        }

        //--PROPERTIES--//
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }

        public bool Dead
        {
            get
            {
                return (Health == 0);     
            }
        }

        public bool Out
        {
            get
            {
                if (X <= 0)
                    return true;
                else return false;
            }
        }
        public Bitmap ZombieCollision
        {
            get { return _zombie; }
        }
    }
}
