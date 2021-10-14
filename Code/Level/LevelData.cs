using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Acrostic
{
    public class LevelData
    {
        public string ogmoVersion;
        public int width;
        public int height;
        public int cellWidth;
        public int cellHeight;
        public int offsetX;
        public int offsetY;
        public int tileOffsetX;
        public int tileOffsetY;
        public LevelDataLayer[] layers;
        public int Seed = 0;

        public static LevelData Create(string levelName)
        {
            string levelPath = "Content/ogmo/levels/" + levelName + ".json";
            string json = File.ReadAllText(levelPath);
            LevelData data = JsonConvert.DeserializeObject<LevelData>(json);
            data.Initialize();
            return data;
        }

        public void Initialize()
        {
            cellWidth =  width  / App.CellSize;
            cellHeight = height / App.CellSize;
        }
    }

    public class LevelDataLayer
    {
        public string name;
        public string _eid;
        public int offsetX;
        public int offsetY;
        public int gridCellWidth;
        public int gridCellHeight;
        public int gridCellsX;
        public int gridCellsY;
        public string tileset;
        public int[,] data2D;
        public EntityData[] entities;
        public int exportMode;
        public int arrayMode;

    }

    // ------------- //
    // ENTITY DATA
    // ------------- //

    public class EntityData
    {
        public string name;
        public int id;
        public string _eid;
        public int x = 0;
        public int y = 0;
        public int width = 0;
        public int height = 0;
        public int originX = 0;
        public int originY = 0;
        public float rotation = 0f;
        public EntityNode[] nodes;
        public JObject values;
    }

    public class EntityNode
    {
        public Vector2 Position;

        public EntityNode(int x, int y)
        {
            Position = new Vector2(x, y);
        }
    }

}
