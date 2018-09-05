using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    class InterfaceSettings
    {

        public enum InterfaceSkin
        {
            Dark, Light, Blue
        }

        public InterfaceSkin skin = InterfaceSkin.Dark;

    }
}
