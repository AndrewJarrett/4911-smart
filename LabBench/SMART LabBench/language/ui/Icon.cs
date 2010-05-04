using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows;
using libSMARTMultiTouch.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.control;

namespace LabBench.language
{
    /// <summary>
    /// Image (Icon) UI element
    /// </summary>
    public class Icon : DraggableImage
    {
        private BitmapImage mBitmapImage;
        private ImagePNG mImagePNG;
        private String mImageName;

        private double x, y, angle;
        private double minScale, maxScale;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="angle">angular orientation</param>
        /// <param name="mBitmapImage">Bitmap reference of image</param>
        public Icon(double x, double y, double angle, BitmapImage mBitmapImage)
            : base(x, y, angle, mBitmapImage, false, 0.5, 2.0)
        {
            minScale = 0.5; maxScale = 2;
            setPose(x, y, angle);
            setScale(minScale, maxScale);
            setSource(mBitmapImage);
            this.IsRotateEnabled = false;
        }
        
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mPNG">PNG reference of image</param>
        public Icon(ImagePNG mPNG)
            : base(0, 0, 0, mPNG.Source, false, 0.5, 2.0)
        {

            minScale = 0.5; maxScale = 2;
            setPose(x, y, angle);
            setScale(minScale, maxScale);
            setSource(mPNG.Source);
            mImagePNG = mPNG;
 
            mImageName = mImagePNG.Source.ToString().Split('/').Last();

            //setBehavior();
        }

        //private void setBehavior()
        //{
        //    SnapBehavior dbg = new SnapBehavior();
        //    base.Attach(dbg);
        //    base.Attach(new DeletableBehavior());
        //}

        /// <summary>
        /// sets the scale that the Icon can be drawn
        /// </summary>
        /// <param name="minScale">minimum scale</param>
        /// <param name="maxScale">maximum scale</param>
        protected void setScale(double minScale, double maxScale) {
            this.minScale = minScale;
            this.maxScale = maxScale;
        }

        /// <summary>
        /// set the position of the UI elemement
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="angle">orientation</param>
        public void setPose(double x, double y, double angle)
        {
            this.x = x; this.y = y; this.angle = angle;
        }

        /// <summary>
        /// set the bitmap reference of the image
        /// </summary>
        /// <param name="mBitmapImage">Bitmap reference of image</param>
        protected void setSource(BitmapImage mBitmapImage)
        {
            this.mBitmapImage = mBitmapImage;
        }

        /// <summary>
        /// return x coordinate
        /// </summary>
        /// <returns>x coordinate</returns>
        public double getX()
        {
            return x;
        }

        /// <summary>
        /// return y coordinate
        /// </summary>
        /// <returns>y coordinate</returns>
        public double getY()
        {
            return y;
        }

        /// <summary>
        /// return anglular rotation (orientation)
        /// </summary>
        /// <returns>orientation</returns>
        public double getAngle()
        {
            return angle;
        }

        /// <summary>
        /// return the minimum scale
        /// </summary>
        /// <returns>minimum scale</returns>
        public double getMinScale()
        {
            return minScale;
        }

        /// <summary>
        /// return max scale
        /// </summary>
        /// <returns>max scale</returns>
        public double getMaxScale()
        {
            return maxScale;
        }

        /// <summary>
        /// return the source of the image
        /// </summary>
        /// <returns>PNG reference to image</returns>
        public ImagePNG getSource()
        {
            return mImagePNG;
        }

        public SerializableItem getSerialData()
        {
            SerializableItem ret = new SerializableItem();
            ret.x = x;
            ret.y = y;
            ret.iconName = mImageName;
            ret.angle = angle;

            return ret;
        }

    }
}
