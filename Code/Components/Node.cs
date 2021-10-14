using Microsoft.Xna.Framework;
using Nez;

namespace Acrostic
{
    public class Node : Component
    {
        public Vector2 Position;

        public Node(Vector2 position)
        {
            Position = position;
        }
    }
}
