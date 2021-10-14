using System;
using System.Collections.Generic;
using System.Text;
using Nez;

namespace Acrostic
{
    public class PlayerControls : Component, IUpdatable
    {

        List<Input> Inputs;
        public MoveInput Up;
        public MoveInput Down;
        public MoveInput Left;
        public MoveInput Right;

        public PlayerControls() : base()
        {
            Inputs = new List<Input>();
            Inputs.Add(Up =     new MoveInput(MoveInput.InputDirections.Up));
            Inputs.Add(Down =   new MoveInput(MoveInput.InputDirections.Down));
            Inputs.Add(Left =   new MoveInput(MoveInput.InputDirections.Left));
            Inputs.Add(Right =  new MoveInput(MoveInput.InputDirections.Right));
        }

        void IUpdatable.Update()
        {
            foreach (Input input in Inputs)
            {
                input.Update();
            }
        }

        public void Clear()
        {
            foreach (Input input in Inputs)
            {
                input.Clear();
            }
        }
    }
}
