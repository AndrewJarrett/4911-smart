using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSMARTMultiTouch.Controls;

namespace LabBench.language.circuit
{
    /// <summary>
    /// Describes a wired connection between two Components
    /// </summary>
    public class Connection
    {
        public Component src, dst;
        public DraggableBorder wire;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="s">source</param>
        /// <param name="d">destination</param>
        /// <param name="w">visual wire</param>
        public Connection(Component s, Component d, DraggableBorder w)
        {
            src = s; dst = d; wire = w;
        }
    }
}
