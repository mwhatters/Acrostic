using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Acrostic
{
    public class MoveInput : ButtonInput
    {
        public enum InputDirections
        {
            Up,
            Down,
            Left,
            Right
        }

        public VirtualButton Move;

        public MoveInput(InputDirections direction)
        {
            SetupInput(direction);
            GraceFrames = 7;
            Button = Move;
        }

        private void SetupInput(InputDirections direction)
        {
            Move = new VirtualButton();

            switch (direction)
            {
                case InputDirections.Up:
                    Move.Nodes.Add(new VirtualButton.KeyboardKey(Keys.W));
                    Move.Nodes.Add(new VirtualButton.KeyboardKey(Keys.Up));
                    Move.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.DPadUp));
                    Move.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.LeftThumbstickUp));
                    break;
                case InputDirections.Down:
                    Move.Nodes.Add(new VirtualButton.KeyboardKey(Keys.S));
                    Move.Nodes.Add(new VirtualButton.KeyboardKey(Keys.Down));
                    Move.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.DPadDown));
                    Move.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.LeftThumbstickDown));
                    break;
                case InputDirections.Left:
                    Move.Nodes.Add(new VirtualButton.KeyboardKey(Keys.A));
                    Move.Nodes.Add(new VirtualButton.KeyboardKey(Keys.Left));
                    Move.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.DPadLeft));
                    Move.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.LeftThumbstickLeft));
                    break;
                case InputDirections.Right:
                    Move.Nodes.Add(new VirtualButton.KeyboardKey(Keys.D));
                    Move.Nodes.Add(new VirtualButton.KeyboardKey(Keys.Right));
                    Move.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.DPadRight));
                    Move.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.LeftThumbstickRight));
                    break;
            }
        }
    }
}
