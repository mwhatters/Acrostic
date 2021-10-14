using System;
using System.Collections.Generic;
using System.Text;
using Nez;

namespace Acrostic
{
    public static class EntityGenerator
    {

        public static void GenerateEntities(Level level)
        {
            foreach (LevelDataLayer layer in level.Data.layers)
            {
                if (layer.entities != null)
                {
                    foreach (EntityData entity in layer.entities)
                    {
                        GenerateEntity(level, entity);
                    }
                }
            }
        }

        public static OgmoEntity GenerateEntity(Level level, EntityData entity)
        {
            switch (entity.name) 
            {
                case "player":
                    return level.AddEntity(new Player(entity));
                case "box":
                    return level.AddEntity(new Box(entity));
            }

            return null;
        }

    }
}
