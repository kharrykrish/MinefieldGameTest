using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Interfaces
{
    public interface IPlayer
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void ReduceLives(int numOfLives);
        int GetMovesTaken();
        bool Alive();
        void Reset();
        bool Finished();

    }
}
