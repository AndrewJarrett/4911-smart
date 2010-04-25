using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSMARTMultiTouch.Controls;

namespace LabBench.language.circuit
{
    public class Connection
    {
        public Component src, dst;
        public DraggableBorder wire;

        public Connection(Component s, Component d, DraggableBorder w)
        {
            src = s; dst = d; wire = w;
        }
    }
}
