using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Acrostic
{
    class Tile : Entity
    {
        public int TileId;
        private SpriteRenderer sprite;

        public int renderLayer;

        public static int bgId = 1;
        public static float currentRow = 0f;

        public Tile(int val, int x, int y) : base()
        {
            TileId = val;
            Position = new Vector2(x, y);
        }

        public override void OnAddedToScene()
        {
            base.OnAddedToScene();
            TrackBackgroundPosition();
            LoadSprite();
        }

        private void LoadSprite()
        {
            sprite = new SpriteRenderer(GetTexture());
            sprite.SetOrigin(Vector2.Zero);
            sprite.SetRenderLayer(renderLayer);
            AddComponent(sprite);
        }

        private Texture2D GetTexture()
        {
            switch (TileId) 
            {
                case 0:
                    renderLayer = RenderLayers.MGTiles;
                    return Scene.Content.LoadTexture("Graphics/tiles/main");
                default:
                    renderLayer = RenderLayers.BGTiles;
                    return Scene.Content.LoadTexture("Graphics/tiles/bg" + bgId.ToString());
            }
        }

        private void TrackBackgroundPosition()
        {
            if (currentRow != Position.Y)
            {
                currentRow = Position.Y;
            }
            else
            {
                bgId = bgId == 1 ? 2 : 1;
            }
        }
    }
}
