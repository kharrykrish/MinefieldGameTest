using MinefieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.CoreGame
{
    public class Board : IBoard
    {

        private IDisplay _renderer;
        private ITile[,] _tiles;
        private ITile _currentTile;
        private ITile _finishTile;
        private Dictionary<int, string> _boardLabelMap;
        private int _boardWidth;
        private int _boardHeight;
        private const int _randomNumberMatch = 6;
        private const int _startPosY = 0;

        public Board(IDisplay renderer)
        {
            _renderer = renderer;
        }


        public void GenerateBoard()
        {
            _boardLabelMap = new Dictionary<int, string>()
            {
                { 0, "A"}, { 1, "B"}, { 2, "C"}, { 3, "D"},
                { 4, "E"}, { 5, "F"}, { 6, "G"}, { 7, "H"},
                { 8, "I"}, { 9, "J"}, { 10, "K"}, { 11, "L"},
                { 12, "M"}, { 13, "N"}, { 14, "O"}, { 15, "P"},
                { 16, "Q"}, { 17, "R"}, { 18, "S"}, { 19, "T"},
                { 20, "U"}, { 21, "V"}, { 22, "W"}, { 23, "X"},
                { 24, "Y"}, { 25, "Z"}
            };
        }
        private void GenerateBoardLabelMap()
        {
            _boardLabelMap = new Dictionary<int, string>()
            {
                { 0, "A"}, { 1, "B"}, { 2, "C"}, { 3, "D"},
                { 4, "E"}, { 5, "F"}, { 6, "G"}, { 7, "H"},
                { 8, "I"}, { 9, "J"}, { 10, "K"}, { 11, "L"},
                { 12, "M"}, { 13, "N"}, { 14, "O"}, { 15, "P"},
                { 16, "Q"}, { 17, "R"}, { 18, "S"}, { 19, "T"},
                { 20, "U"}, { 21, "V"}, { 22, "W"}, { 23, "X"},
                { 24, "Y"}, { 25, "Z"}
            };
        }

        private int GetRandomNumber(int min = 0, int max = 0)
        {
            return new Random().Next(min, max);
        }


        public ITile[,] GenerateTiles(int boardWidth, int boardHeight, int startPosX = 0)
        {
            var tiles = new ITile[boardWidth, boardHeight];

            if (_boardLabelMap == null) GenerateBoard();
             

            for (var x = 0; x < boardWidth; x++)
            {
                for (var y = 0; y < boardHeight; y++)
                {

                    var rolledMine = GetRandomNumber(1, _randomNumberMatch + 1) == _randomNumberMatch ? true : false;

                    if (x == startPosX & y == _startPosY || !rolledMine)
                    {
                        tiles[x, y] = new Tile(x, y, _boardLabelMap[x]);
                    }
                    else
                    {
                        tiles[x, y] = new MineTile(x, y, _boardLabelMap[x]);
                    }
                }
            }

            return tiles;
        }

        public ITile GenerateFinishTile(int endPosX, int boardHeight)
        {
            if (_boardLabelMap == null) GenerateBoard();
             

            return new EndTitle(endPosX, boardHeight - 1, _boardLabelMap[endPosX]);
        }


        public void Setup(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;

            var startPosX = GetRandomNumber(0, _boardWidth);
            var endPosX = GetRandomNumber(0, _boardWidth);
            var endPosY = height - 1;

            _tiles = GenerateTiles(_boardWidth, _boardHeight, startPosX);


            _currentTile = _tiles[startPosX, _startPosY];


            _finishTile = GenerateFinishTile(endPosX, _boardHeight);
            _tiles[endPosX, endPosY] = _finishTile;

            Redraw();
        }

        public void Redraw()
        {
            _renderer.Clear();
            _renderer.ShowGameStartMessage();
            _renderer.DrawGrid(_tiles, _currentTile, _finishTile);
            _renderer.ShowCurrentPosition(_currentTile);
        }

        public bool MoveTileLeft()
        {
            if (_currentTile.GetXPosition() > 0)
            {
                _currentTile = _tiles[_currentTile.GetXPosition() - 1, _currentTile.GetYPosition()];
                Redraw();
                return true;
            }
            return false;
        }

        public bool MoveTileRight()
        {
            if (_currentTile.GetXPosition() < _boardWidth - 1)
            {
                _currentTile = _tiles[_currentTile.GetXPosition() + 1, _currentTile.GetYPosition()];
                Redraw();
                return true;
            }
            return false;
        }

        public bool MoveTileUp()
        {
            if (_currentTile.GetYPosition() < _boardHeight - 1)
            {
                _currentTile = _tiles[_currentTile.GetXPosition(), _currentTile.GetYPosition() + 1];
                Redraw();
                return true;
            }
            return false;
        }

        public bool MoveTileDown()
        {
            if (_currentTile.GetYPosition() > 0)
            {
                _currentTile = _tiles[_currentTile.GetXPosition(), _currentTile.GetYPosition() - 1];
                Redraw();
                return true;
            }
            return false;
        }

        public void SetActiveTile(int xPos, int yPos)
        {
            _currentTile = _tiles[xPos, yPos];
        }

        public ITile GetActiveTile()
        {
            return _currentTile;
        }

        public ITile GetFinishedTile()
        {
            return _finishTile;
        }


        public void GetMineProximity()
        {
            int xPos = _currentTile.GetXPosition();
            int yPos = _currentTile.GetYPosition();

            if (CheckMineTiles(xPos, yPos, (int)MineProximity.VeryClose))
            {
                _renderer.ShowProximityStatus((int)MineProximity.VeryClose);
            }
            else if (CheckMineTiles(xPos, yPos, (int)MineProximity.Close))
            {
                _renderer.ShowProximityStatus((int)MineProximity.Close);
            }
        }

        private bool CheckMineTiles(int xPos, int yPos, int distance)
        {
            return CheckMineTile(xPos + distance, yPos)
                || CheckMineTile(xPos - distance, yPos)
                || CheckMineTile(xPos, yPos + distance)
                || CheckMineTile(xPos, yPos - distance);
        }

        private bool CheckMineTile(int xPos, int yPos)
        {
            if (xPos >= 0 && xPos < _boardWidth && yPos > 0 && yPos < _boardHeight)
                return _tiles[xPos, yPos] is MineTile;
            return false;
        }

        public enum MineProximity
        {
            VeryClose = 1,
            Close = 2
        }
    }
}
