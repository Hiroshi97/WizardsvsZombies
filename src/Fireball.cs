using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Fireball : Spell
    {
        private Fireball_Sprite _fireballspr;

        //--CONSTRUCTORS--//
        public Fireball() : base("fireball")
        {
            Type = SpellType.Fireball;
            _fireballspr = new Fireball_Sprite();                   // Fireball sprite of spell Fireball
        }

        //--METHODS--//
        public override void Perform(Wizard w)
        {
            _fireballspr = new Fireball_Sprite();
            _fireballspr.IsLeft = w.IsLeft;
            if (_fireballspr.IsLeft)
            {
                SwinGame.PlaySoundEffect("fireball.wav");
                _fireballspr.X = w.X - 30;
                _fireballspr.Y = w.Y + 20;
            }
            else
            {
                SwinGame.PlaySoundEffect("fireball.wav");
                _fireballspr.X = w.X + 90;
                _fireballspr.Y = w.Y + 20;
            }
            w.Map.AddFireballSpr(_fireballspr);
            
        }

    }
}
