using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace LabBench.language
{
    /// <summary>
    /// data structure for storing PNGs
    /// </summary>
    public class ImagePNG
    {
        private BitmapImage mBitmapImage;

        /// <summary>
        /// class constructors
        /// </summary>
        /// <param name="mUrl">URL to the image on the filesystem</param>
        public ImagePNG(String mUrl)
        {
            mBitmapImage = new BitmapImage(new Uri("pack://application:,,,/resources/images/" + mUrl));
        }

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mUrl">URL to the image on the filesystem</param>
        /// <param name="mWidth">width of image</param>
        /// <param name="mHeight">height of image</param>
        public ImagePNG(String mUrl, int mWidth, int mHeight)
        {
            mBitmapImage = new BitmapImage();
            mBitmapImage.BeginInit();
            mBitmapImage.UriSource = new Uri("pack://application:,,,/resources/images/" + mUrl);
            mBitmapImage.DecodePixelHeight = mHeight;
            mBitmapImage.DecodePixelWidth = mWidth;
            mBitmapImage.EndInit();
        }

        /// <summary>
        /// a bitmap of the image
        /// </summary>
        public BitmapImage Source
        {
            set { mBitmapImage = value; }
            get { return mBitmapImage; }
        }
    }
}
