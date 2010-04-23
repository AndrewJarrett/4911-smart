using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Interop;
using System.Linq;
using System.Text;

namespace LabBench.language
{
    [Serializable]
    class SerializedLesson
    {
        List<Icon> mObjects;
        byte[] mPixels;
        int mPixelWidth, mPixelHeight;
        double mDpiX, mDpiY;
        BitmapPalette mBitmapPalette;
        PixelFormat mPixelFormat;

        public SerializedLesson(Canvas canvas, WriteableBitmap screenshot)
        {
            // save WB info
            mPixelWidth = screenshot.PixelWidth;
            mPixelHeight = screenshot.PixelHeight;
            mDpiX = screenshot.DpiX;
            mDpiY = screenshot.DpiY;
            mBitmapPalette = screenshot.Palette;
            mPixelFormat = screenshot.Format;

            // copy wb data into byte array

            // convert screenshot to byte array for serializing
            int bytesPerPixel = (screenshot.Format.BitsPerPixel + 7) / 8;
            // Stride is bytes per pixel times the number of pixels.
            // Stride is the byte width of a single rectangle row.
            int stride = screenshot.PixelWidth * bytesPerPixel;

            int arraySize = stride * screenshot.PixelHeight;
            mPixels = new byte[arraySize];

            // add icons to serialized list
            mObjects = new List<Icon>();
            foreach (UIElement elem in canvas.Children)
            {
                if (elem.GetType() == Type.GetType("Icon"))
                {
                    MessageBox.Show("OMG", "OMG");
                    mObjects.Add((Icon)elem);
                }
            }
        }

        public static byte[] ToByteArray(this WriteableBitmap bmp)
        {
            int[] p = bmp;
            int len = p.Length * 4;
            byte[] result = new byte[len]; // ARGB
            Buffer.BlockCopy(p, 0, result, 0, len);
            return result;
        }

        public static void FromByteArray(this WriteableBitmap bmp, byte[] buffer)
        {
            Buffer.BlockCopy(buffer, 0, bmp.Pixels, 0, buffer.Length);
        }


        public WriteableBitmap getImage()
        {
            WriteableBitmap ret = new WriteableBitmap(mPixelWidth, mPixelHeight, mDpiX, mDpiY, mPixelFormat, mBitmapPalette);
            if (mPixels != null)
            {

            }
            return ret;
        }
    }
}
