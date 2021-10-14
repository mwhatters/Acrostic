using System;
using Nez;

namespace Acrostic
{
    public class Timer : Component, IUpdatable
    {
        private float InitTime;
        public float InstanceTimer = 0f;
        public bool Running;
        public bool Stopped;
        public bool Paused = false;

        public Timer(float initTime)
        {
            InitTime = initTime;
            InstanceTimer = InitTime;
            SetState();
        }

        public Timer Clear()
        {
            InstanceTimer = 0f;
            Stopped = true;
            Running = false;
            return this;
        }

        public void ForceDecrementTimer()
        {
            if (InstanceTimer > 0)
            {
                InstanceTimer = Math.Max(InstanceTimer - Time.DeltaTime, 0);
                if (InstanceTimer == 0)
                {
                    Stopped = true;
                    Running = false;
                }
            }
        }

        public void Reset(float newTime = 0f)
        {
            if (newTime != 0f)
            {
                InitTime = newTime;
            }

            InstanceTimer = InitTime;
            SetState();
        }

        void IUpdatable.Update()
        {
            if (Paused)
            {
                return;
            }

            ForceDecrementTimer();
        }

        private void SetState()
        {
            if (InstanceTimer == 0f)
            {
                Running = false;
                Stopped = true;
            }
            else
            {
                Running = true;
                Stopped = false;
            }
        }

        public void Pause()
        {
            Paused = true;
        }

        public void UnPause()
        {
            Paused = false;
        }


    }
}