using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using libSMARTMultiTouch.Controls;
using libSMARTMultiTouch.Input;
using LabBench.language.circuit;

namespace LabBench.language.ui
{
    class ToolboxCategory : Icon
    {
        private Canvas parent;
        private int locX, locY;
        private bool open;
        private List<ComponentFactory> visibleToolboxItems;
        private List<String> mIcons;

        public ToolboxCategory(Canvas mainCanvas, List<String> mIcons, int x, int y)
            : base(new ImagePNG("ui/drawer.png"))
        {
            this.visibleToolboxItems = new List<ComponentFactory>(); //TouchCloner>();
            this.open = false;
            this.parent = mainCanvas;
            //this.Width = 75; this.Height = 75;
            this.locX = x; this.locY = y;

            TransformGroup mTransformGroup = new TransformGroup();
            mTransformGroup.Children.Add(new ScaleTransform(0.4, 0.4));
            mTransformGroup.Children.Add(new TranslateTransform(x-50, y-62.5));

            this.RenderTransform = mTransformGroup;

            this.mIcons = mIcons;

            TouchInputManager.AddTouchContactDownHandler(this, new TouchContactEventHandler(Button_TouchContactDown));

        }

        public ToolboxCategory(Canvas mainCanvas, List<SerializableItem> objects, int x, int y)
            : base(new ImagePNG("ui/drawer.png"))
        {
            this.visibleToolboxItems = new List<ComponentFactory>(); //TouchCloner>();
            this.open = false;
            this.parent = mainCanvas;
            //this.Width = 75; this.Height = 75;
            this.locX = x; this.locY = y;
            //this.RenderTransform = new TranslateTransform(x, y);
            //this.Background = new SolidColorBrush(Colors.Orange);

            TransformGroup mTransformGroup = new TransformGroup();
            mTransformGroup.Children.Add(new ScaleTransform(0.5, 0.5));
            mTransformGroup.Children.Add(new TranslateTransform(x - 50, y - 75));

            this.RenderTransform = mTransformGroup;

            this.mIcons = null;

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
            double offset = 75;
            for (int i = 1; i < mIcons.Count+1; i++)
            {
                Component mComponent = new Component(new ImagePNG(mIcons[i-1]));
                ComponentFactory mComponentFactory = new ComponentFactory(mIcons[i-1], this.parent, mComponent, mComponent, this.locX, this.locY + offset);
                offset += (mComponent.Height / 2.0) * 1.2;
                visibleToolboxItems.Add(mComponentFactory);
            }
            this.open = true;
        }

        public void closeMenu()
        {
            foreach (ComponentFactory t in this.visibleToolboxItems)
            {
                this.parent.Children.Remove(t.Source);
            }
            this.visibleToolboxItems = new List<ComponentFactory>();
            this.open = false;
        }
    }
}
