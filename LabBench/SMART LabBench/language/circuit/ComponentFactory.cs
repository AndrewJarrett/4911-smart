using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabBench.language.ui;
using System.Windows.Controls;

namespace LabBench.language.circuit
{
    class ComponentFactory : IconFactory
    {
        private String mComponentName;

        public ComponentFactory(String mComponentName, Canvas mCanvas, Icon mBase, Icon mClone, double x, double y)
            : base(mCanvas, mBase, mClone, x, y)
        {
            this.mComponentName = mComponentName;
        }

    }

}
