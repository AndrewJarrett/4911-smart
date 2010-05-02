using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media.Imaging;
using System.Windows;

namespace LabBench
{
    /// <summary>
    /// Represents an item which can be serialized. Stores the information mabout the object, its position, and the file name of the image used.
    /// </summary>
    [Serializable]
    public class SerializableItem
    {
        public bool conductive, magnetic, ferrous;
        public int charge;
        public String iconName;
        public string name;
        public double x, y, angle;

        /// <summary>
        /// Default constructor, needs no parameters (are to be specified after instantiation).
        /// </summary>
        public SerializableItem()
        {
            conductive = false;
            magnetic = false;
            ferrous = false;
            charge = 0;
            x = 0.0;
            y = 0.0;
        }

        /// <summary>
        /// helper function to save the item at a given path. 
        /// returns true if the save operation is successful.
        /// </summary>
        public bool saveFile(String filePath)
        {
            try
            {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, this);
                stream.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// loads the information stored in an item at the given file path.
        /// returns true if the load operation is successful.
        /// </summary>
        public bool loadFile(String filePath)
        {
            SerializableItem SO = new SerializableItem();
            try
            {
                Stream stream = File.Open(filePath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                SO = (SerializableItem)bf.Deserialize(stream);
                stream.Close();
                this.conductive = SO.conductive;
                this.magnetic = SO.magnetic;
                this.ferrous = SO.ferrous;
                this.charge = SO.charge;
                this.iconName = SO.iconName;
                this.name = SO.name;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
