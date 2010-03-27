using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabBench.DataStructures
{
    class ID
    {
        private int id;

        public ID(int id)
        {
            this.id = id;
        }

        public int Value
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
