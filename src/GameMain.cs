using System;
using SwinGameSDK;
using System.Threading;

//ANDY - NGUYEN THE ANH DINH 2018

namespace MyGame.src
{
    public class GameMain
    {
        public static void Main()
        {
            GameInterface.Launch();
            //Open the game window
            SwinGame.OpenGraphicsWindow("WizardsvsZombies", GameDirector.Constants.SCREEN_WIDTH, GameDirector.Constants.SCREEN_HEIGHT);
            SwinGame.ShowSwinGameSplashScreen();
            

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen();
                SwinGame.DrawFramerate(0,0);

                //Draw
                GameInterface.Update();

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}