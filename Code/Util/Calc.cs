using System;
using System.Collections.Generic;
using System.Text;

namespace Acrostic
{
    public static class Calc
    {
        // enum to string
        //
        public static T ETS<T>(string str)
        {
            return (T)Enum.Parse(typeof(T), str);
        }
    }
}
