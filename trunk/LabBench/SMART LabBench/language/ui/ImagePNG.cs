using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace LabBench.language.ui
{
    public class ImagePNG
    {
        private BitmapImage mBitmapImage;

        public ImagePNG(String mUrl)
        {
            mBitmapImage = new BitmapImage(new Uri("pack://application:,,,/resources/images/" + mUrl));
        }

        public ImagePNG(String mUrl, int mWidth, int mHeight)
        {
            mBitmapImage = new BitmapImage();
            mBitmapImage.BeginInit();
            mBitmapImage.UriSource = new Uri("pack://application:,,,/resources/images/" + mUrl);
            mBitmapImage.DecodePixelHeight = mHeight;
            mBitmapImage.DecodePixelWidth = mWidth;
            mBitmapImage.EndInit();
        }

        public BitmapImage Source
        {
            set { mBitmapImage = value; }
            get { return mBitmapImage; }
        }
    }
}
