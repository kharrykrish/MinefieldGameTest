using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Interfaces
{
    public interface ITile
    {

        void Activate(IPlayer player, IDisplay renderer);
        int GetXPosition();
        int GetYPosition();
        string GetXLabel();
        string GetYLabel();
        string GetId();
    }
}
