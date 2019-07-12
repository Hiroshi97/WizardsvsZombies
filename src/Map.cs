using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

//ANDY - NGUYEN THE ANH DINH 2018

namespace MyGame.src
{
    public class Map
    {
        //--FIELDS--//
        private List<Book> _books;
        private List<Zombie> _zombies;
        private int _countout = 0, _countkill;
        private Wizard _wizard;
        private List<Fireball_Sprite> _fireballspr;

        //--CONSTRUCTOR--//
        public Map()
        {
            _books = new List<Book>();
            _zombies = new List<Zombie>();
            //_wizards = new List<Wizard>();
            _fireballspr = new List<Fireball_Sprite>();
        }

        //--METHODS--//
        public void DrawMap()
        {
            SwinGame.DrawBitmap("background.png", 0, 0);
        }
        public void UpdateMap()
        {
            Book temp = null;
            Spell tmpspell = null;
            Zombie tmpzom = null;
            

            Wizard.UpdateWizard();
            if (Wizard.Dead || _countout == GameDirector.TotalZombie/2 + 1 || (Zombies.Count == 0 && GameDirector.TotalZombie == CountKilledZom + CountOutZom)) //If a wizard is dead or half of total zombies accessed to tower --> LOSE. Otherwise --> WIN
            {
                Wizard.RemoveWizard();                             //Remove Wizard
                this.Wizard = null;
            }
            else
            {
                foreach (Book b in Books)                           //Loop for checking to remove collected book
                {
                    b.DrawBook();                                       //If collision occurs, book will be collected
                    if (SwinGame.BitmapCollision(_wizard.WizardCollision, _wizard.X, _wizard.Y, b.BookCollision, b.X, b.Y))
                    {
                        SwinGame.PlaySoundEffect("hit.wav");
                        temp = b;
                        b.RemoveBook();                             //Remove displayed Book bitmap on screen
                        switch (b.Name)                             //Create a specific spell, depends on each collected book and add spells to wizard
                        {
                            case "heal":
                                {
                                    tmpspell = new Heal();
                                    Wizard.AddSpell(tmpspell);
                                }
                                break;
                            case "teleport":
                                {
                                    tmpspell = new Teleport();
                                    Wizard.AddSpell(tmpspell);
                                }
                                break;
                        }
                    }
                }
                Books.Remove(temp);                                 //Remove book object in Map

                foreach (Zombie z in Zombies)                       //Loop to check if zombie is dead or out of range then remove that zom                                                                //Check if zombie died or accessed to the tower
                {
                    z.UpdateZombie();
                    if (z.Dead || z.Out)
                    {
                        tmpzom = z;
                        if (z.Out)
                            _countout++;
                        else
                            _countkill++;
                    }
                }
                Zombies.Remove(tmpzom);                             //Remove zom object in Map

                foreach (Fireball_Sprite spr in FireBallSpr)        //Loop to display every single fireball in Map
                {
                    spr.UpdateSpr();
                    if (spr.Out)
                    {
                        FireBallSpr.Remove(spr);                    //Remove fireball spr object in Map
                        break;
                    }
                }
            }
        }

        //ADD OBJECTS TO MAP
        public void AddZombie(Zombie zom)
        {
            Zombies.Add(zom);
            zom.Map = this;
            SwinGame.PlaySoundEffect("zombie.wav");
        }

        public void AddWizard(Wizard wiz)
        {
            Wizard = wiz;
            wiz.Map = this;
        }

        public void AddFireballSpr(Fireball_Sprite spr)
        {
            FireBallSpr.Add(spr);
        }

        //--PROPERTIES--//
        public List<Zombie> Zombies
        {
            get { return _zombies; }
            set { _zombies = value; }
        }

        public Wizard Wizard
        {
            get { return _wizard; }
            set { _wizard = value; }
        }

        public List<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }

        public List<Fireball_Sprite> FireBallSpr
        {
            get { return _fireballspr; }
            set { _fireballspr = value; }
        }

        public int CountOutZom
        {
            get { return _countout; }
        }

        public int CountKilledZom
        {
            get { return _countkill; }
        }
    }
}
