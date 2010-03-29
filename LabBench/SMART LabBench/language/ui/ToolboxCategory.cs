using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using libSMARTMultiTouch.Controls;
using libSMARTMultiTouch.Input;

namespace LabBench.language.ui
{
    class ToolboxCategory : Border
    {
        private Canvas parent;
        private List<Component> objects;
        private int locX, locY;
        private bool open;
        private List<TouchCloner> visibleToolboxItems;

        public ToolboxCategory(Canvas mainCanvas, int x, int y)
        {
            this.visibleToolboxItems = new List<TouchCloner>();
            this.open = false;
            this.parent = mainCanvas;
            this.Width = 75; this.Height = 75;
            this.locX = x; this.locY = y;
            this.RenderTransform = new TranslateTransform(x, y);
            this.Background = new SolidColorBrush(Colors.Orange);

            TouchInputManager.AddTouchContactDownHandler(this, new TouchContactEventHandler(Button_TouchContactDown));

        }

        private void Button_TouchContactDown(object sender, TouchContactEventArgs e)
        {
            if (this.open)
            {
                this.closeMenu();
            }
            else
            {
                this.openMenu();
            }
        }

        public void openMenu()
        {
            for (int i = 1; i < 6; i++)
            {
                Rectangle mRectangle = new Rectangle();
                mRectangle.Height = 75; mRectangle.Width = 75;
                mRectangle.Fill = new SolidColorBrush(Colors.Blue);

                TouchCloner mTouchCloner = new TouchCloner(mRectangle);
                mTouchCloner.Source = new ToolboxItem();

                TranslateTransform mTranslateTransform = new TranslateTransform();
                mTranslateTransform.X = this.locX;
                mTranslateTransform.Y = this.locY + (i * 75);
                mTouchCloner.RenderTransform = mTranslateTransform;

                visibleToolboxItems.Add(mTouchCloner);
                this.parent.Children.Add(mTouchCloner);
            }
            this.open = true;
        }

        public void closeMenu()
        {
            foreach (TouchCloner t in this.visibleToolboxItems)
            {
                this.parent.Children.Remove(t);
            }
            this.visibleToolboxItems = new List<TouchCloner>();
            this.open = false;
        }
    }
}
