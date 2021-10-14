using System;
using System.Collections.Generic;
using System.Text;
using Nez;
using Microsoft.Xna.Framework;

namespace Acrostic
{
    public class Level : BaseScene
    {
        public LevelData Data;
        public LevelMap Map;

        public Level(string name) : base()
        {
            Data = LevelData.Create(name);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();
            TileGenerator.GenerateTileMap(this);
            EntityGenerator.GenerateEntities(this);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
