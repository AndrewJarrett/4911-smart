using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Interop;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LabBench
{
    [Serializable]
    public class SerializedLesson
    {
        public List<SerializableItem> mObjects;

        public SerializedLesson()
        {
            mObjects = new List<SerializableItem>();
        }

        public SerializedLesson(Canvas canvas)
        {
            // add icons to serialized list
            // be sure to ignore non-object items on screen
            mObjects = new List<SerializableItem>();
            foreach (UIElement elem in canvas.Children)
            {
                String type = elem.GetType().ToString();
                if (type.Contains("Component"))
                {
                    mObjects.Add(((language.Icon)elem).getSerialData());
                }
            }
        }

        public bool saveFile(String filePath)
        {
            try {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool loadFile(String filePath)
        {
            SerializedLesson sl = new SerializedLesson();
            try {
                Stream stream = File.Open(filePath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                sl = (SerializedLesson)bf.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            this.mObjects = new List<SerializableItem>();
            foreach (SerializableItem ic in sl.mObjects)
            {
                this.mObjects.Add(ic);
            }
            return true;
        }
    }
}
