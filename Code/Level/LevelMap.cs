using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Text;
using Nez.Tweens;

namespace Acrostic
{
    public class LevelMap
    {
        public enum Values 
        {
            Empty = -1,
            Wall = 0,
            Player = 1,
            Box = 2,
        }

        private Level Level;
        private int[,] Data;
        private int maxRows;
        private int maxCols;
        
        public LevelMap(Level level, int[,] initialData)
        {
            Level = level;
            Data = initialData;
            maxRows = Data.GetLength(0) - 1;
            maxCols = Data.GetLength(1) - 1;
        }

        public Values ValueAt(int row, int col)
        {
            return (Values)Data[row, col];
        }

        public int IntValueAt(int row, int col)
        {
            return Data[row, col];
        }

        public void Add(Values val, int row, int col)
        {
            Data[row, col] = (int)val;
        }

        public void RemoveAt(int row, int col)
        {
            Data[row, col] = (int)Values.Empty;
        }

        public bool Move(int row, int col, Vector2 direction)
        {
            Values currentVal = ValueAt(row, col);

            int moveY = row + (int)direction.Y;
            int moveX = col + (int)direction.X;

            // check for level bounds
            //
            if (moveY > maxRows || moveX > maxCols)
            {
                return false;
            }

            Values moveVal = ValueAt(moveY, moveX);

            // check for walls
            //
            if (moveVal == Values.Wall)
            {
                return false;
            }

            if (moveVal == Values.Box)
            {
                if (!Move(moveY, moveX, direction))
                {
                    return false;
                }
            }

            // finally, update map, move entity
            //
            OgmoEntity entity = EntityAtCell(row, col);
            entity.TweenPositionTo(entity.Position + (direction * 12), 0.02f).Start();
            RemoveAt(row, col);
            Add(currentVal, moveY, moveX);
            DebugPrintMap();
            return true;

        }

        private void DebugPrintMap()
        {
            string row = "";
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    row += " " + DebugIntToSymbol(Data[i, j]) + " ";
                }
                Debug.Log(row);
                row = "";
            }

            for (int j = 0; j < Data.GetLength(1); j++)
            {
                row += "-" + "-" + "-";
            }
            Debug.Log(row);
        }

        private string DebugIntToSymbol(int n)
        {
            switch (n)
            {
                case (int)Values.Empty:
                    return " ";
                case (int)Values.Wall:
                    return "O";
                case (int)Values.Player:
                    return "■";
                case (int)Values.Box:
                    return "b";
                default:
                    return "?";
            }
        }

        private OgmoEntity EntityAtCell(int row, int col)
        {
            return Level.EntitiesOfType<OgmoEntity>().Find((obj) => obj.CellPosition().Y == row && obj.CellPosition().X == col);
        }
    }
}
