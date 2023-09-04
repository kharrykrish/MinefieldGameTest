using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Interfaces
{
    public interface IGameEngine
    {

        void Start(IBoard board, IPlayer player);

        void End();
    }
}
