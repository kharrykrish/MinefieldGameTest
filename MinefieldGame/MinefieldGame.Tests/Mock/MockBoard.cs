using MinefieldGame.Interfaces;
using MinefieldGame.CoreGame;

namespace MinefieldGame.Tests.Mock
{
    public class MockBoard : IBoard
    {
        private ITile[,] _tiles;
        private ITile _currentTile;
        private ITile _finishTile;
        private int _boardWidth;
        private int _boardHeight;

        public void GenerateBoard()
        {
            Console.WriteLine("");
        }

        public ITile GenerateFinishTile(int endPosX, int boardHeight)
        {
            return new Tile(0, 0);
        }

        public ITile[,] GenerateTiles(int boardWidth, int boardHeight, int startPosX = 0)
        {
            return new Tile[0, 0];
        }

        public ITile GetActiveTile()
        {
            return new Tile(0, 0);
        }

        public ITile GetFinishedTile()
        {
            return new Tile(0, 0);
        }

        public void GetMineProximity()
        {
        }

        public void SetActiveTile(int xPos, int yPos)
        {

        }

        public void Setup(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;
            _tiles = new Tile[_boardWidth, _boardHeight];
            _currentTile = new EndTitle(0, 0);
            _finishTile = new EndTitle(width == 0 ? 0 : 1, 0);
        }

        public bool MoveTileDown()
        {
            return true;
        }

        public bool MoveTileLeft()
        {
            return true;
        }

        public bool MoveTileRight()
        {
            return true;
        }

        public bool MoveTileUp()
        {
            return true;
        }
    }
}
