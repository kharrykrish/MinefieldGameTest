using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Interfaces
{
    public interface IBoard
    {

        void Setup(int width, int height);
        ITile[,] GenerateTiles(int boardWidth, int boardHeight, int startPosX = 0);
        ITile GenerateFinishTile(int endPosX, int boardHeight);
        bool MoveTileUp();
        bool MoveTileDown();
        bool MoveTileLeft();
        bool MoveTileRight();
        void GetMineProximity();
        void SetActiveTile(int xPos, int yPos);
        ITile GetActiveTile();
        ITile GetFinishedTile();
        void GenerateBoard();
    }
}
