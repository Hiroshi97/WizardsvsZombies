using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

//ANDY - NGUYEN THE ANH DINH 2018

namespace MyGame.src
{
    public abstract class Spell
    {
        //--FIELDS--//
        private string _name;
        private SpellType _type;

        //--CONSTRUCTORS--//
        public Spell(string name)
        {
            _name = name;
        }

        //--ABSTRACT METHODS--//
        public abstract void Perform(Wizard w);

        //--PROPERTIES--//
        public string Name
        {
            get { return _name; }
        }

        public SpellType Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
