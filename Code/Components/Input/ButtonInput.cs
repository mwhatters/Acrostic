using System;
using System.Collections.Generic;
using System.Text;
using Nez;

namespace Acrostic
{
    public class ButtonInput : Input
    {

        public VirtualButton Button;

        public int GraceFrames;

        public bool Held = false;
        public bool Pressed = false;
        private int PressedBufferFrames = 0;

        public ButtonInput()
        {
        }

        public override void Update()
        {
            if (Enabled)
            {
                HandlePressed();
                Held = Button.IsDown || Pressed;
            }
        }

        public void HandlePressed()
        {
            PressedBufferFrames = Math.Max(PressedBufferFrames - 1, 0);

            if (Button.IsPressed || CustomPressConditionMet())
            {
                PressedBufferFrames = GraceFrames;
            }

            Pressed = PressedBufferFrames > 0;
        }

        public override void Clear()
        {
            Pressed = false;
            PressedBufferFrames = 0;
        }

        internal virtual bool CustomPressConditionMet()
        {
            return false;
        }
    }
}
