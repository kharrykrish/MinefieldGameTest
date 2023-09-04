using MinefieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.CoreGame
{
    public class MineTile : Tile
    {

        public MineTile(int x, int y, string _xLabel = null, string _yLabel = null) : base(x, y, _xLabel, _yLabel)
        {
        }

        public override void Activate(IPlayer player, IDisplay renderer)
        {
            player.ReduceLives(1);
            renderer.ShowHitByMine();
        }
    }
}
