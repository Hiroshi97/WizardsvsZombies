using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Teleport : Spell
    {
        //--CONSTRUCTORS--//
        public Teleport() : base("teleport")
        {
            Type = SpellType.Teleport;
        }

        //--METHODS--//
        public override void Perform(Wizard w)
        {
            if (SwinGame.MousePosition().Y <= w.PossibleY && SwinGame.MousePosition().X <= GameDirector.Constants.SCREEN_WIDTH - 20)
            {
                w.Position.X = SwinGame.MousePosition().X;
                w.Position.Y = SwinGame.MousePosition().Y;
                SwinGame.PlaySoundEffect("teleport.wav");
            }
        }
    }
}
