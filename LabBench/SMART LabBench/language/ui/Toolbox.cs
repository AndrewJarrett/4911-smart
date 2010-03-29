using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace LabBench.language.ui
{
    class Toolbox
    {
        public Toolbox(Canvas canvas, int locX, int locY)
        {
            for (int i = 0; i < 4; i++)
            {
                canvas.Children.Add(new ToolboxCategory(canvas, locX + (i * 75), locY));
            }
        }
    }
}
