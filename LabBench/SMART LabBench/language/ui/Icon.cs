﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using libSMARTMultiTouch.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.control;

namespace LabBench.language.ui
{
    public class Icon : DraggableImage
    {
        private BitmapImage mBitmapImage;

        private double x, y, angle;
        private double minScale, maxScale;

        public Icon(double x, double y, double angle, BitmapImage mBitmapImage)
            : base(x, y, angle, mBitmapImage, false, 0.5, 2.0)
        {
            minScale = 0.5; maxScale = 2;
            setPose(x, y, angle);
            setScale(minScale, maxScale);
            setSource(mBitmapImage);
            setBehavior();
            this.IsRotateEnabled = false;
        }

        public Icon(ImagePNG mPNG)
            : base(0, 0, 0, mPNG.Source, false, 0.5, 2.0)
        {
            minScale = 0.5; maxScale = 2;
            setPose(x, y, angle);
            setScale(minScale, maxScale);
            setSource(mPNG.Source);
            setBehavior();
        }

        private void setBehavior()
        {
            SnapBehavior dbg = new SnapBehavior();
            base.Attach(dbg);
            base.Attach(new DeletableBehavior());
        }

        private void setScale(double minScale, double maxScale) {
            this.minScale = minScale;
            this.maxScale = maxScale;
        }

        private void setPose(double x, double y, double angle)
        {
            this.x = x; this.y = y; this.angle = angle;
        }

        private void setSource(BitmapImage mBitmapImage)
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

        public BitmapImage getSource()
        {
            return mBitmapImage;
        }

    }
}
