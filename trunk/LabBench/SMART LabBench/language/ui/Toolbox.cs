using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace LabBench.language.ui
{
    class Toolbox
    {
        BinaryFormatter bformatter;
        Stream stream;

        public Toolbox(Canvas canvas, List<String>[] icons, int locX, int locY)
        {
            for (int i = 0; i < icons.Length; i++)
            {
                canvas.Children.Add(new ToolboxCategory(canvas, icons[i], locX + (i * 150), locY));
            }
        }


        public Toolbox(Canvas canvas, int locX, int locY)
        {
            bformatter = new BinaryFormatter();
            string objectDirectory = "objects";

            int i = 0;
            foreach (string catDirectory in System.IO.Directory.GetDirectories(objectDirectory))
            {
                // Category Nodes
                Console.WriteLine(catDirectory);
                string catName = catDirectory.Split('\\').Last();

                List<SerializableItem> objects = new List<SerializableItem>();
                foreach (string objLocation in System.IO.Directory.GetFiles(catDirectory))
                {
                    if (! objLocation.Split('\\').Contains(".svn"))
                        objects.Add(deserializeItem(objLocation));
                }

                // ignore subversion files
                if (catName != ".svn")
                {
                    canvas.Children.Add(new ToolboxCategory(canvas, objects, locX + (i * 150), locY));
                    i += 1;
                }
 
            }
        }

        private SerializableItem deserializeItem(string objLocation)
        {
            stream = File.Open(objLocation, FileMode.Open);

            SerializableItem obj = (SerializableItem)bformatter.Deserialize(stream);

            stream.Close();
            return obj;
        }
    }
}
