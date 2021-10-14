using System;
using System.Collections.Generic;
using System.Text;
using Nez;
using Microsoft.Xna.Framework;

namespace Acrostic
{
    public class GameLoader : BaseScene
    {
        public override void Initialize()
        {
            base.Initialize();
            LoadNextScene(new Level("1"));
        }
    }
}
