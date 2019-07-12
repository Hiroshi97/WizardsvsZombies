using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

//ANDY - NGUYEN THE ANH DINH 2018

namespace MyGame.src
{
    public class Heal : Spell
    {
        //--CONSTRUCTORS--//
        public Heal () : base ("heal")
        {
            Type = SpellType.Heal;
        }

        //--METHODS--//
        public override void Perform(Wizard w)
        {
            w.Health+=10;
            SwinGame.PlaySoundEffect("heal.wav");
        }
    }
}
