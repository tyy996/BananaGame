using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BananaTheGame.Terrain.Generators
{
    public interface IChunkGenerator
    {
        void Generate(Chunk chunk);
    }
}
