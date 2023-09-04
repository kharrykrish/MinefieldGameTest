using MinefieldGame.Interfaces;
using System;
namespace MinefieldGame.CoreGame
{
    public class Display : IDisplay
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void ShowGameStartMessage()
        {
            Console.WriteLine();
            Console.WriteLine(" Welcome to Minefield Game ...!");
            Console.WriteLine(" Press Enter to restart, or Escape to exit");
        }

        public void DrawGrid(ITile[,] tiles, ITile currentTile, ITile finishTile)
        {
            Console.CursorVisible = false;

            var width = tiles.GetLength(0);
            var height = tiles.GetLength(1) - 1;

            Console.WriteLine();

            for (var y = height; y >= 0; y--)
            {
                Console.Write(" ");
                Console.Write(tiles[0, y].GetYLabel());
                Console.Write(" ");
                for (var x = 0; x < width; x++)
                {
                    if (tiles[x, y] == currentTile)
                        Console.Write("[x]");
                    else if (tiles[x, y] == finishTile)
                        Console.Write("[o]");
                    else
                        Console.Write("[ ]");
                }
                Console.WriteLine();
            }

            Console.Write("    ");

            for (var x = 0; x < width; x++)
            {
                Console.Write(tiles[x, 0].GetXLabel());
                Console.Write("  ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void ShowLeftLives(int livesLeft)
        {
            Console.WriteLine($" Lives left: {livesLeft}");
        }

        public void ShowHitByMine()
        {
            Console.WriteLine("You've been hit by a hidden mine!");
        }

        public void ShowCurrentPosition(ITile currentTile)
        {
            Console.WriteLine($" Current position: {currentTile.GetId()}");
        }

        public void ShowMoveTakenByUser(int movesTaken)
        {
            Console.WriteLine($" You have taken {movesTaken} Moves");
        }


        public void ShowProximityStatus(int distance)
        {
            switch (distance)
            {
                case 1:
                    {
                        Console.WriteLine("You are very close to a mine");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("You are close to a mine");
                        break;
                    }
            }
        }

        public void ShowFinalScoreBoard(int score)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("************************************************");
            Console.WriteLine(" You reached the end of the game with lives left ");
            Console.WriteLine($" Final Score (moves taken): {score}");
            Console.WriteLine(" Press Enter to play again, or Escape to exit");
            Console.WriteLine("************************************************");
        }

        public void ShowGameOverOnBoard()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("************************************************");
            Console.WriteLine(" GAME OVER!");
            Console.WriteLine(" You have no lives left!");
            Console.WriteLine(" Press Enter to play again, or Escape to exit");
            Console.WriteLine("************************************************");
        }
    }
}
