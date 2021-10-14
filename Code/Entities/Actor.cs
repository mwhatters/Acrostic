using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acrostic.Code.Entities
{
    class Actor : OgmoEntity
    {
        public delegate void Collision();

        public void Move(Vector2 direction, Collision onCollide)
        {

        }
    }
}
