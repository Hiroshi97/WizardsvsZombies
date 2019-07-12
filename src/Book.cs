using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.Threading;

//ANDY - NGUYEN THE ANH DINH 2018

namespace MyGame.src
{
    public class Book : GameObject
    {
        //--FIELDS--//
        private Random _rnd;
        private Bitmap _book;

        //--METHODS--//
        public Book(string name) : base(name)
        {
            _rnd = new Random();
            X = _rnd.Next(GameDirector.Constants.SCREEN_WIDTH - 100);
            Y = _rnd.Next(GameDirector.Constants.SCREEN_HEIGHT - 300);
            _book = SwinGame.BitmapNamed("Book_" + name + ".png");
            Thread.Sleep(1000);
        }

        public void DrawBook()
        {
            SwinGame.DrawBitmap(_book, X, Y);
        }

        public void RemoveBook()
        {
            SwinGame.FreeBitmap(_book);
        }


        //--PROPERTIES--//
        public Bitmap BookCollision
        {
            get { return _book; }
        }
    }
}
