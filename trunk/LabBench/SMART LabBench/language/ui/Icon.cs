using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using libSMARTMultiTouch.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.control;

namespace LabBench.language
{
    public class Icon : DraggableImage
    {
        private BitmapImage mBitmapImage;
        private ImagePNG mImagePNG;

        private double x, y, angle;
        private double minScale, maxScale;

        public Icon(double x, double y, double angle, BitmapImage mBitmapImage)
            : base(x, y, angle, mBitmapImage, false, 0.5, 2.0)
        {
            minScale = 0.5; maxScale = 2;
            setPose(x, y, angle);
            setScale(minScale, maxScale);
            setSource(mBitmapImage);
            this.IsRotateEnabled = false;
        }

        public Icon(ImagePNG mPNG)
            : base(0, 0, 0, mPNG.Source, false, 0.5, 2.0)
        {
            minScale = 0.5; maxScale = 2;
            setPose(x, y, angle);
            setScale(minScale, maxScale);
            setSource(mPNG.Source);
            mImagePNG = mPNG;
            //setBehavior();
        }

        //private void setBehavior()
        //{
        //    SnapBehavior dbg = new SnapBehavior();
        //    base.Attach(dbg);
        //    base.Attach(new DeletableBehavior());
        //}

        protected void setScale(double minScale, double maxScale) {
            this.minScale = minScale;
            this.maxScale = maxScale;
        }

        public void setPose(double x, double y, double angle)
        {
            this.x = x; this.y = y; this.angle = angle;
        }

        protected void setSource(BitmapImage mBitmapImage)
        {
            this.mBitmapImage = mBitmapImage;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public double getAngle()
        {
            return angle;
        }

        public double getMinScale()
        {
            return minScale;
        }

        public double getMaxScale()
        {
            return maxScale;
        }

        public ImagePNG getSource()
        {
            return mImagePNG;
        }

    }
}
