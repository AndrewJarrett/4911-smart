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
    public class SerializedLesson
    {
        public List<language.Icon> mObjects;
        //byte[] mPixels;
        //int mPixelWidth, mPixelHeight;
        //double mDpiX, mDpiY;
        //BitmapPalette mBitmapPalette;
        //PixelFormat mPixelFormat;

        public SerializedLesson()
        {
        }

        public SerializedLesson(Canvas canvas)
        {
            // save WB info
            //mPixelWidth = screenshot.PixelWidth;
            //mPixelHeight = screenshot.PixelHeight;
            //mDpiX = screenshot.DpiX;
            //mDpiY = screenshot.DpiY;
            //mBitmapPalette = screenshot.Palette;
            //mPixelFormat = screenshot.Format;

            // copy wb data into byte array

            // convert screenshot to byte array for serializing
            //int bytesPerPixel = (screenshot.Format.BitsPerPixel + 7) / 8;
            // Stride is bytes per pixel times the number of pixels.
            // Stride is the byte width of a single rectangle row.
            //int stride = screenshot.PixelWidth * bytesPerPixel;

            //int arraySize = stride * screenshot.PixelHeight;
            //mPixels = new byte[arraySize];

            // add icons to serialized list
            mObjects = new List<language.Icon>();
            foreach (UIElement elem in canvas.Children)
            {
                if (elem.GetType() == Type.GetType("Icon"))
                {
                    MessageBox.Show("OMG", "OMG");
                    mObjects.Add((language.Icon)elem);
                }
            }
        }

        public byte[] ConvertToByteArray(WriteableBitmap bmp)
        {
            int[] p = new int[4];
            int len = p.Length * 4;
            byte[] result = new byte[len]; // ARGB
            Buffer.BlockCopy(p, 0, result, 0, len);
            return result;
        }

        public void ConvertFromByteArray(WriteableBitmap bmp, byte[] buffer)
        {
            //Buffer.BlockCopy(buffer, 0, bmp.Pixels, 0, buffer.Length);
        }


        public WriteableBitmap getImage()
        {
            //WriteableBitmap ret = new WriteableBitmap(mPixelWidth, mPixelHeight, mDpiX, mDpiY, mPixelFormat, mBitmapPalette);
            return null;
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
            catch (Exception ex) { }
            return false;
        }

        public bool loadFile(String filePath)
        {
            SerializedLesson sl = new SerializedLesson();
            try
            {
                Stream stream = File.Open(filePath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                sl = (SerializedLesson)bf.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            this.mObjects = new List<language.Icon>();
            foreach (language.Icon ic in sl.mObjects)
            {
                this.mObjects.Add(ic);
            }
            return true;
        }
    }
}
