using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acrostic
{
    class Player : OgmoEntity
    {
        // components
        private SpriteRenderer sprite;
        public PlayerControls Controls;
        private Timer T_MoveTimer;

        public Player(EntityData data) : base(data)
        {
        }

        public override void OnAddedToScene()
        {
            base.OnAddedToScene();
            AddComponent(Controls = new PlayerControls());
            AddComponent(T_MoveTimer = new Timer(0.2f).Clear());
            LoadSprite();
        }

        private void LoadSprite()
        {
            Texture2D texture = Scene.Content.LoadTexture("Graphics/entities/player");
            sprite = new SpriteRenderer(texture);
            sprite.SetOrigin(Vector2.Zero);
            sprite.SetRenderLayer(RenderLayers.Player);
            AddComponent(sprite);
        }

        public override void Update()
        {
            base.Update();
            HandlePressedInput();
            HandleHeldInput();
        }

        private void HandlePressedInput()
        {
            if (Controls.Up.Pressed)
            {
                T_MoveTimer.Reset();
                Controls.Clear();
                Move(new Vector2(0, -1));
            }
            else if (Controls.Down.Pressed)
            {
                T_MoveTimer.Reset();
                Controls.Clear();
                Move(new Vector2(0, 1));
            }
            else if (Controls.Left.Pressed)
            {
                T_MoveTimer.Reset();
                Controls.Clear();
                Move(new Vector2(-1, 0));
            }
            else if (Controls.Right.Pressed)
            {
                T_MoveTimer.Reset();
                Controls.Clear();
                Move(new Vector2(1, 0));
            }
        }

        private void HandleHeldInput()
        {
            if (T_MoveTimer.Stopped)
            {
                if (Controls.Up.Held)
                {
                    T_MoveTimer.Reset();
                    Move(new Vector2(0, -1));
                }
                else if (Controls.Down.Held)
                {
                    T_MoveTimer.Reset();
                    Move(new Vector2(0, 1));
                }
                else if (Controls.Left.Held)
                {
                    T_MoveTimer.Reset();
                    Move(new Vector2(-1, 0));
                }
                else if (Controls.Right.Held)
                {
                    T_MoveTimer.Reset();
                    Move(new Vector2(1, 0));
                }
            }
        }

        private void Move(Vector2 direction)
        {
            level.Map.Move(CellPosition().Y, CellPosition().X, direction);
        }
    }
}
