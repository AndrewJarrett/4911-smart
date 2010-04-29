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
    [Serializable]
    public class SerializableItem
    {
        public bool conductive, magnetic, ferrous;
        public int charge;
        public String iconName;
        public string name;
        public double x, y, angle;


        public SerializableItem()
        {
            conductive = false;
            magnetic = false;
            ferrous = false;
            charge = 0;
            x = 0.0;
            y = 0.0;
        }

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
            }
            return false;
        }

        public bool loadFile(String filePath)
        {
            SerializableItem SO = new SerializableItem();
            try
            {
                Stream stream = File.Open(filePath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                SO = (SerializableItem)bf.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            this.conductive = SO.conductive;
            this.magnetic = SO.magnetic;
            this.ferrous = SO.ferrous;
            this.charge = SO.charge;
            this.iconName = SO.iconName;
            this.name = SO.name;

            return true;
        }
    }
}
