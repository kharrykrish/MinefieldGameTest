using MinefieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.CoreGame
{
    public class Player : IPlayer
    {
        IBoard _board;
        IDisplay _display;
        private int _movesTaken = 0;
        private int _maxLives;
        private int _livesRemaining;

        public Player(IBoard board, IDisplay display, int lives = 5)
        {
            _board = board;
            _display = display;
            _livesRemaining = lives;
            _maxLives = lives;
        }

        public void MoveUp()
        {
            if (_board.MoveTileUp())
            {
                Move();
            }
        }

        public void MoveDown()
        {
            if (_board.MoveTileDown())
            {
                Move();
            }
        }

        public void MoveLeft()
        {
            if (_board.MoveTileLeft())
            {
                Move();
            }
        }

        public void MoveRight()
        {
            if (_board.MoveTileRight())
            {
                Move();
            }
        }

        private void Move()
        {
            _movesTaken++;
            _display.ShowMoveTakenByUser(_movesTaken);
            _board.GetMineProximity();
            _board.GetActiveTile().Activate(this, _display);

            if (!Finished()) _display.ShowLeftLives(_livesRemaining);

            if (_livesRemaining == 0) _display.ShowGameOverOnBoard();
        }

        public void ReduceLives(int numOfLives)
        {
            _livesRemaining -= numOfLives;
        }

        public int GetMovesTaken()
        {
            return _movesTaken;
        }

        public int GetLivesLeft()
        {
            return _livesRemaining;
        }

        public bool Alive()
        {
            return _livesRemaining > 0 ? true : false;
        }

        public void Reset()
        {
            _livesRemaining = _maxLives;
            _movesTaken = 0;
        }

        public bool Finished()
        {
            return _board.GetActiveTile() == _board.GetFinishedTile();
        }
    }
}
