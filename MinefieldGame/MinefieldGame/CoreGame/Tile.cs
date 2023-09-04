using MinefieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.CoreGame
{
    public class Tile : ITile
    {
        private string _id;
        private int _xPos;
        private int _yPos;
        private string _xLabel;
        private string _yLabel;

        public Tile(int x, int y, string xLabel = null, string yLabel = null)
        {
            _xPos = x;
            _yPos = y;

            if (xLabel != null)
                _xLabel = xLabel;
            else _xLabel = x.ToString();

            if (yLabel != null)
                _yLabel = yLabel;
            else _yLabel = (y + 1).ToString();

            _id = _xLabel + _yLabel;
        }

        public string Id { get; }
        public int GetXPosition() { return _xPos; }
        public int GetYPosition() { return _yPos; }
        public string GetXLabel() { return _xLabel; }
        public string GetYLabel() { return _yLabel; }
        public string GetId() { return _id; }

        public virtual void Activate(IPlayer player, IDisplay renderer)
        {

        }
    }
}
