using MinefieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.CoreGame
{
    internal class GameEngine : IGameEngine
    {
        public void Start(IBoard board, IPlayer player)
        {
            board.Setup(8, 8);

            while (player.Alive() && !player.Finished())
            {
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            player.MoveUp();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            player.MoveDown();
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        {
                            player.MoveLeft();
                            break;
                        }
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        {
                            player.MoveRight();
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            board.Setup(8, 8);
                            player.Reset();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }

            End();
        }

        public void End()
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.Enter:
                    {
                        var displayBoard = new Display();
                        var board = new Board(displayBoard);
                        Start(board, new Player(board, displayBoard));
                        break;
                    }
                case ConsoleKey.Escape: { return; }
                default: { End(); break; }
            }
        }
    }
}