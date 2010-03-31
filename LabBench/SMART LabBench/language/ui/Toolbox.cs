using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace LabBench.language.ui
{
    class Toolbox
    {
        public Toolbox(Canvas canvas, List<String> icons, int locX, int locY)
        {
            for (int i = 0; i < 1; i++)
            {
                canvas.Children.Add(new ToolboxCategory(canvas, icons, locX + (i * 150), locY));
            }
        }
    }
}
