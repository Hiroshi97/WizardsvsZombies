using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public abstract class GameObject : Sprite 
    {
        //--FIELDS--//
        private string _name;

        //--CONSTRUCTORS--//
        public GameObject(string name) : base("", "")
        {
            _name = name;
        }

        //--PROPERTIES--//
        public new string Name
        {
            get { return _name; }
        }
    }
}
