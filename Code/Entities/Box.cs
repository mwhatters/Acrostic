using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acrostic
{
    class Box : OgmoEntity
    {
        public enum ConnectorType
        {
            CornerBL,
            CornerTL,
            CornerBR,
            CornerTR
        }

        // components
        private SpriteRenderer sprite;
        private ConnectorType Connector;

        public Box(EntityData data) : base(data)
        {
            Value = LevelMap.Values.Box;
            Connector = Calc.ETS<ConnectorType>((string)data.values["connectorType"]);
        }

        public override void OnAddedToScene()
        {
            base.OnAddedToScene();
            LoadSprite();
        }

        private void LoadSprite()
        {
            sprite = new SpriteRenderer(GetTexture());
            sprite.SetOrigin(Vector2.Zero);
            sprite.SetRenderLayer(RenderLayers.MGObject);
            AddComponent(sprite);
        }

        private Texture2D GetTexture()
        {
            string type = Connector switch
            {
                ConnectorType.CornerBL => "cornerbl",
                ConnectorType.CornerTL => "cornertl",
                ConnectorType.CornerBR => "cornerbr",
                ConnectorType.CornerTR => "cornertr",
                _ => "box"
            };

            return Scene.Content.LoadTexture("Graphics/entities/connectors/" + type);
        }

    }
}
