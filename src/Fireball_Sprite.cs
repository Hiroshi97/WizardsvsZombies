using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

//ANDY - NGUYEN THE ANH DINH 2018

namespace MyGame.src
{
    public class Fireball_Sprite : GameObject
    {
        //--FIELDS--//
        private Bitmap _fireballspr;
        private bool _left = false;

        //--METHODS--//
        public Fireball_Sprite() : base("fireballspr")
        {
            _fireballspr = SwinGame.BitmapNamed("Fireball.png");
        }

        public void DrawSpr()
        {
            SwinGame.DrawBitmap(_fireballspr, X, Y);
        }

        public void UpdateSpr()
        {
            DrawSpr();
            if (X < 800 && !IsLeft)
                X += 5;
            else if (X > 0 && IsLeft)
                X -= 5;
        }

        public void RemoveSpr()
        {
            SwinGame.FreeBitmap(_fireballspr);
        }

        public bool IsLeft
        {
            get { return _left; }
            set { _left = value; }
        }

        public Bitmap FireBallSprCollision
        {
            get { return _fireballspr; }
        }

        public bool Out
        {
            get
            {
                if (X <= 0 || X >= 800)
                    return true;
                else return false;
            }
        }
    }
}
