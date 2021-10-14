using System;
using System.Collections.Generic;
using System.Text;

namespace Acrostic
{
    public class Input
    {
        public bool Enabled = true;

        public virtual void Clear()
        {
        }

        public virtual void Update()
        {
        }

        public void Lock()
        {
            Enabled = false;
        }

        public void Disable()
        {
            Clear();
            Enabled = false;
        }

        public void Enable()
        {
            Enabled = true;
        }
    }
}
