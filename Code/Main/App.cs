using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Acrostic
{
    public class App : Core
    {
        public static App Main;
        public const int GameWidth = 192;
        public const int GameHeight = 108;
        public const int CellSize = 12;

        public App(int width = 192, int height = 108, bool isFullScreen = false, string windowTitle = "Camel", string contentDirectory = "Content")
            : base(width, height, isFullScreen, windowTitle, contentDirectory)
        {
            Main = this;
        }

        protected override void Initialize()
        {
            base.Initialize();

            Scene.SetDefaultDesignResolution(GameWidth, GameHeight, Scene.SceneResolutionPolicy.ShowAll);
            SetWindowed();

            ExitOnEscapeKeypress = false;
            Batcher.UseFnaHalfPixelMatrix = true; // fixes 12x12 rendering... for now

            IsFixedTimeStep = true;
            IsMouseVisible = true;
            Scene = new GameLoader();
        }

        private void SetWindowed()
        {
            Screen.PreferredBackBufferWidth = GameWidth;
            Screen.PreferredBackBufferHeight = GameHeight;
            Screen.IsFullscreen = false;
            Screen.ApplyChanges();
            Screen.SetSize(GameWidth * 4, GameHeight * 4);
            Window.AllowUserResizing = true;
        }

        private void SetFullscreen()
        {
            Screen.PreferredBackBufferWidth = Core.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            Screen.PreferredBackBufferHeight = Core.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            Screen.IsFullscreen = true;
            Screen.ApplyChanges();
            Window.AllowUserResizing = false;
        }
    }
}
