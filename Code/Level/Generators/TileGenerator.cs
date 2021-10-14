using System;
using System.Collections.Generic;
using System.Text;
using Nez;

namespace Acrostic
{
    public static class TileGenerator
    {

        public static void GenerateTileMap(Level level)
        {
            foreach (LevelDataLayer layer in level.Data.layers)
            {
                if (layer.data2D != null)
                {
                    if (layer.name == "tiles")
                    {
                        level.Map = new LevelMap(level, layer.data2D);
                    }

                    for (int r = 0; r <= level.Data.cellHeight - 1; r++)
                    {
                        for (int c = 0; c <= level.Data.cellWidth - 1; c++)
                        {
                            level.AddEntity(new Tile(layer.data2D[r, c], c * App.CellSize, r * App.CellSize));
                        }
                    }
                }
            }
        }

    }
}
