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

        public Point Check;
        public Point Receives;
        public bool IsConnected;

        // components
        private SpriteRenderer sprite;
        private ConnectorType Connector;

        public Box(EntityData data) : base(data)
        {
            Value = LevelMap.Values.Box;
            Connector = Calc.ETS<ConnectorType>((string)data.values["connectorType"]);

            Check = Connector switch
            {
                ConnectorType.CornerBL => new Point(1,-1),
                ConnectorType.CornerTL => new Point(1,1),
                ConnectorType.CornerBR => new Point(-1,-1),
                ConnectorType.CornerTR => new Point(-1,1),
                _ => new Point(0,0)
            };

            Receives = Connector switch
            {
                ConnectorType.CornerBL => new Point(-1, 1),
                ConnectorType.CornerTL => new Point(-1, -1),
                ConnectorType.CornerBR => new Point(1, 1),
                ConnectorType.CornerTR => new Point(1, -1),
                _ => new Point(0, 0)
            };
        }

        public override void OnAddedToScene()
        {
            base.OnAddedToScene();
            LoadSprite();
            SetIsConnected();
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

        private void UpdateTexture()
        {
            if (IsConnected)
            {
                Debug.Log("Connected!");
                sprite.Color = Color.Blue;
            }
            else
            {
                sprite.Color = Color.White;
            }
        }

        internal override void AfterMove()
        {
            Debug.Log("hello");
            SetIsConnected();
            UpdateTexture();
        }

        internal override void BeforeMove()
        {
            SetIsConnected();
            UpdateTexture();
        }

        private void SetIsConnected()
        {
            Point cp = CellPosition();
            var checkX = false;
            var checkY = false;
            if (Check.X != 0)
            {
                OgmoEntity c1 = levelMap.EntityAtCell(cp.Y, cp.X + Check.X);
                if (c1 is Box)
                {
                    checkX = (c1 as Box).Receives.X == Check.X;
                }
            }

            if (Check.Y != 0)
            {
                OgmoEntity c2 = levelMap.EntityAtCell(cp.Y + Check.Y, cp.X);
                if (c2 is Box)
                {
                    checkY = (c2 as Box).Receives.Y == Check.Y;
                }
            }

            IsConnected = checkX && checkY;
        }

    }
}
