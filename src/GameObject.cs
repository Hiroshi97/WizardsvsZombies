using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

//ANDY - NGUYEN THE ANH DINH 2018

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
