using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Nez;

namespace Acrostic
{
    public class OgmoEntity : Entity
    {
        public Vector2 WorldOffset;
        public Vector2 Origin;
        public EntityData Data;
        public int TotalNodes;
        public bool HasNodes = false;
        public int Width;
        public int Height;
        public int HalfWidth;
        public int HalfHeight;
        public int RotationInDegrees;
        public Collider HitBox;
        public List<Node> Nodes;
        public Node OriginNode;
        public LevelMap.Values Value;

        // references
        internal Level level;

        public OgmoEntity(EntityData data)
        {
            Data = data;
            Position = new Vector2(Data.x, Data.y);
            Origin = new Vector2(data.originX, data.originY);
            Width = data.width;
            Height = data.height;
            HalfWidth = (int)Math.Floor(Width / 2f);
            HalfHeight = (int)Math.Floor(Height / 2f);
            Transform.Rotation = data.rotation;
            RotationInDegrees = (int)(Transform.Rotation * (180f / Math.PI));
            Nodes = new List<Node>();
        }

        public override void OnAddedToScene()
        {
            base.OnAddedToScene();

            Point point = CellPosition();
            int row = point.Y;
            int col = point.X;
            level = (Scene as Level);
            level.Map.Add(Value, row, col);

            OriginNode = AddComponent(new Node(new Vector2(Data.x, Data.y)));
            if (Data.nodes != null)
            {
                TotalNodes = Data.nodes.Length;
                HasNodes = true;

                foreach (EntityNode node in Data.nodes)
                {
                    Nodes.Add(AddComponent(new Node(node.Position)));
                }
            }

        }

        public OgmoEntity()
        {
        }

        public virtual void Awake() { }

        internal Point CellPosition()
        {
            return new Point((int)Position.X / App.CellSize, (int)Position.Y / App.CellSize);
        }
    }
}
