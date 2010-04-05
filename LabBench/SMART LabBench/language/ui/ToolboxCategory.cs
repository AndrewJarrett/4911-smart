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
        //private List<Component> objects;
        private int locX, locY;
        private bool open;
        //private List<TouchCloner> visibleToolboxItems;
        private List<IconFactory> visibleToolboxItems;
        private List<String> mIcons;

        public ToolboxCategory(Canvas mainCanvas, List<String> mIcons, int x, int y)
        {
            this.visibleToolboxItems = new List<IconFactory>(); //TouchCloner>();
            this.open = false;
            this.parent = mainCanvas;
            this.Width = 75; this.Height = 75;
            this.locX = x; this.locY = y;
            this.RenderTransform = new TranslateTransform(x, y);
            this.Background = new SolidColorBrush(Colors.Orange);

            this.mIcons = mIcons;

            TouchInputManager.AddTouchContactDownHandler(this, new TouchContactEventHandler(Button_TouchContactDown));

        }

        public ToolboxCategory(Canvas mainCanvas, List<SerializableItem> objects, int x, int y)
        {
            this.visibleToolboxItems = new List<IconFactory>(); //TouchCloner>();
            this.open = false;
            this.parent = mainCanvas;
            this.Width = 75; this.Height = 75;
            this.locX = x; this.locY = y;
            this.RenderTransform = new TranslateTransform(x, y);
            this.Background = new SolidColorBrush(Colors.Orange);

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
                Icon mIcon = new Icon(new ImagePNG(mIcons[i-1]));
                IconFactory mIconFactory = new IconFactory(this, this.parent, mIcon, this.locX, this.locY + offset);
                offset += (mIcon.Height / 2.0) * 1.2;
                visibleToolboxItems.Add(mIconFactory);
            }
            this.open = true;
        }

        public void closeMenu()
        {
            foreach (IconFactory t in this.visibleToolboxItems)
            {
                this.parent.Children.Remove(t.Source);
            }
            this.visibleToolboxItems = new List<IconFactory>();
            this.open = false;
        }
    }
}
