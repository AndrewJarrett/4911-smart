using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabBench.language.ui
{
    [Serializable]
    public class SerializableItem
    {
        public bool conductive, magnetic, ferrous;
        public int charge;
        public Image icon;
        public string name;

        public SerializableItem()
        {
            conductive = false;
            magnetic = false;
            ferrous = false;
            charge = 0;
        }
    }
}
