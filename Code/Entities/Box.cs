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
        // components
        private SpriteRenderer sprite;

        public Box(EntityData data) : base(data)
        {
        }

        public override void OnAddedToScene()
        {
            base.OnAddedToScene();
            LoadSprite();
        }

        private void LoadSprite()
        {
            Texture2D texture = Scene.Content.LoadTexture("Graphics/entities/box");
            sprite = new SpriteRenderer(texture);
            sprite.SetOrigin(Vector2.Zero);
            sprite.SetRenderLayer(RenderLayers.MGObject);
            AddComponent(sprite);
        }

    }
}
