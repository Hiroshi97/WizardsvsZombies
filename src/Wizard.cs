using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Wizard : GameObject
    {
        //--FIELD--//
        private const int DEFAULT_HEALTH = 100;
        private int _health;
        private float _possibleX, _possibleY;
        private string _name;
        private Bitmap _wizard;
        private Map _map;
        private List<Spell> _spells;
        private bool _left = false;
        private bool _jump = false;
        private float _force;
        private Spell _fireballskill;

        //----CONSTRUCTORS----//
        public Wizard(string name, float x, float y) : base(name)
        {
            X = x;                                                  //Location X, Y
            Y = y;
            _possibleX = 790;
            _possibleY = y;
            _name = name;                                           //Name
            _health = 100;                                          //Health = 100
            //_life = DEFAULT_LIFE;                                 //Life = 3
            _wizard = SwinGame.BitmapNamed("wizard_right.png");     //Load Bitmap
            _force = 0.1f;                                          //Force === Gravity when jump
            _spells = new List<Spell>();                            // List of learned spells
            _fireballskill = new Fireball();
            AddSpell(_fireballskill);                               // Fireball is a default skill
        }

        //----METHODS----//

        public void DrawWizard()                                                //Draw a player
        {
            SwinGame.DrawBitmap(_wizard, X, Y);
            DrawInformation();
        }

        public void UpdateWizard()                                              //Update a player
        {
            if (!Dead)
            {
                if ((SwinGame.KeyDown(KeyCode.LeftKey)|| SwinGame.KeyDown(KeyCode.AKey)) && X >= 0)
                {
                    _wizard = SwinGame.BitmapNamed("wizard_left.png");              //Move Left
                    _left = true;
                    Position.X -= 3;
                }
                if ((SwinGame.KeyDown(KeyCode.RightKey) || SwinGame.KeyDown(KeyCode.DKey) && X <= PossibleX))
                {
                    _wizard = SwinGame.BitmapNamed("wizard_right.png");             //Move Right
                    _left = false;
                    Position.X += 3;
                }

                if (SwinGame.KeyDown(KeyCode.SpaceKey) && Y >= 0)                    //Jump
                {
                    _jump = true;
                    Y -= _force;
                    _force += 1f;
                }
                else if (Y < PossibleY)
                {
                    _force = 0.1f;
                    Y += 5;
                    _jump = false;
                }

                if (SwinGame.KeyTyped(KeyCode.QKey))                              //Cast Spells - Q
                {
                    if (_left)
                        _wizard = SwinGame.BitmapNamed("wizard_attack_left.png");
                    else _wizard = SwinGame.BitmapNamed("wizard_attack_right.png");
                    CastSpell(SpellType.Fireball);
                }

                if (SwinGame.KeyReleased(KeyCode.QKey))                         //After casting spell
                {
                    if (_left)
                        _wizard = SwinGame.BitmapNamed("wizard_left.png");
                    else _wizard = SwinGame.BitmapNamed("wizard_right.png");
                }

                if (SwinGame.KeyTyped(KeyCode.WKey))                           //Cast Spells - W
                {
                    CastSpell(SpellType.Heal);
                }

                if (SwinGame.KeyTyped(KeyCode.EKey))                           //Cast Spells - E
                {
                    CastSpell(SpellType.Teleport);
                }

                //Collision + Hud
                foreach (Zombie z in Map.Zombies)
                {                                                               //If collision occurs, Wizard will take damage
                    if (SwinGame.BitmapCollision(WizardCollision, X, Y, z.ZombieCollision, z.X, z.Y)) 
                    {
                        IsDamaged();
                    }
                }

                foreach (Spell s in Spells)                                                                         //Draw learned spell
                {
                    GameDirector.DrawSkill(s.Name);
                }

                DrawWizard();
            }
        }

        public void DrawInformation()                                           //Draw health bar + player's name
        {
            SwinGame.FillRectangle(Color.White, Position.X + 10f, Position.Y + 10f, DEFAULT_HEALTH, 5);
            SwinGame.FillRectangle(Color.Red, Position.X + 10f, Position.Y + 10f, Health, 5);
            SwinGame.DrawText(Name, Color.Black, Position.X + 32.5f, Position.Y - 10f);
            SwinGame.DrawRectangle(Color.Black, 320, 533, DEFAULT_HEALTH * 1.47f + 2, 17);
            SwinGame.FillRectangle(Color.Red, 321, 534, Health * 1.47f, 15);
            SwinGame.DrawText(Health.ToString() + "/" + DEFAULT_HEALTH.ToString(), Color.White, 365, 540f);
        }

        public void AddSpell(Spell s)                                           //Add spells
        {
            Spells.Add(s);
        }

        public void CastSpell(SpellType type)                                   //Cast Spell with SpellType
        {
            foreach(Spell s in _spells)
            {
                if (s.Type == type)
                    s.Perform(this);
            }
        }

        public void IsDamaged()
        {
            Health--;
        }

        public void RemoveWizard()
        {
            SwinGame.FreeBitmap(_wizard);
        }

        //----PROPERTIES----//

        public bool Dead                                                        //Check if player is dead or not
        {
            get
            {
                return (Health == 0);
            }
        }

        public int Health
        {
            get
            {
                if (_health >= 100)
                    return 100;
                else if (_health <= 0)
                    return 0;
                return _health;
            }
            set { _health = value; }
        }

        public List<Spell> Spells
        {
            get { return _spells; }
        }

        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }

        public Bitmap WizardCollision
        {
            get { return _wizard; }
        }

        public float PossibleX
        {
            get { return _possibleX; }
            set { _possibleX = value; }
        }

        public float PossibleY
        {
            get { return _possibleY; }
            set { _possibleY = value; }
        }

        public bool IsLeft
        {
            get { return _left; }
        }    
    }
}
