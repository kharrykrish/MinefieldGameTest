using MinefieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Tests.Mock
{
    public class MockDisplay : IDisplay
    {
        public void Clear()
        {
        }

        public void ShowCurrentPosition(ITile currentTile)
        {
        }

        public void ShowFinalScoreBoard(int score)
        {
        }

        public void ShowGameOverOnBoard()
        {
        }

        public void DrawGrid(ITile[,] tiles, ITile currentTile, ITile finishTile)
        {
        }

        public void ShowGameStartMessage()
        {
        }

        public void ShowHitByMine()
        {
        }

        public void ShowLeftLives(int livesLeft)
        {
        }

        public void ShowMoveTakenByUser(int movesTaken)
        {
        }

        public void ShowProximityStatus(int distance)
        {
        }
    }
}
