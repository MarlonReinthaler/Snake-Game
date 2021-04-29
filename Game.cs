using System;
using System.Threading;

namespace SnakeGame
{
    public class Game
    {
        public static void gameMode()
        {
            bool gameStat = true;
            Multiplayer multPlayer;
            SinglePlayer singlePlayer;

            while (gameStat)
            {
                Console.Write("(1) Singleplayer\n(2) Multiplayer\n(3) Exit\n");
                char gameOpt = Console.ReadKey().KeyChar;
                switch (gameOpt)
                {
                    case '1':
                        // Singleplayer
                        singlePlayer = new SinglePlayer();
                        singlePlayer.singlePlayerGame();
                        gameStat = false;
                        break;
                    case '2':
                        // Multiplayer
                        multPlayer = new Multiplayer();
                        multPlayer.multPlayerGame();
                        gameStat = false;
                        break;
                    case '3':
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}