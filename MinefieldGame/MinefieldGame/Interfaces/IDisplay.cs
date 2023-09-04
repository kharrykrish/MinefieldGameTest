using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Interfaces
{
    public interface IDisplay
    {

        void Clear();
        void DrawGrid(ITile[,] tiles, ITile currentTile, ITile finishTile);
        void ShowLeftLives(int livesLeft);
        void ShowCurrentPosition(ITile currentTile);
        void ShowMoveTakenByUser(int movesTaken);
        void ShowHitByMine();
        void ShowProximityStatus(int distance);
        void ShowGameOverOnBoard();
        void ShowFinalScoreBoard(int score);
        void ShowGameStartMessage();
    }
}
