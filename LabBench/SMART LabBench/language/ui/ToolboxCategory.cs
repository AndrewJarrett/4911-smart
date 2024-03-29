﻿using System;
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
    /// <summary>
    /// Represents a toolbox category. Is a button that, when clicked, opens an object drawer.
    /// </summary>
    class ToolboxCategory : Icon
    {
        private Canvas parent;
        private int locX, locY;
        private bool open;
        private List<ComponentFactory> visibleToolboxItems;
        private List<String> mIcons;

        private Dictionary<String, String> mComponentList;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="mainCanvas">Canvas to draw on</param>
        /// <param name="mComponentList">List of components for this category</param>
        /// <param name="x">x coordinate on canvas for this category</param>
        /// <param name="y">y coordinate on canvas for this category</param>
        public ToolboxCategory(Canvas mainCanvas, Dictionary<String, String> mComponentList, int x, int y)
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

            this.mComponentList = mComponentList;

            TouchInputManager.AddTouchContactDownHandler(this, new TouchContactEventHandler(Button_TouchContactDown));

        }

        /// <summary>
        /// Secondary constructor, takes in a list of Serializeable Items
        /// </summary>
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

        /// <summary>
        /// Responds to touching the category. Determines whether to open or close the menu based upon its state.
        /// </summary>
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

        /// <summary>
        /// Draws the selection choice UI elements for the given category.
        /// </summary>
        public void openMenu()
        {
            double offset = 75;
            for (int i = 1; i < mComponentList.Keys.Count+1; i++)
            {
                String key = mComponentList.Keys.ElementAt(i - 1);
                Component mComponent = new Component(mComponentList[key], new ImagePNG(key));
                ComponentFactory mComponentFactory = new ComponentFactory(key, this.parent, mComponent, mComponent, this.locX, this.locY + offset);
                offset += (mComponent.Height / 2.0) * 1.2;
                visibleToolboxItems.Add(mComponentFactory);
            }
            this.open = true;
        }

        /// <summary>
        /// Closes the drawer by removing all of its elements from the canvas.
        /// </summary>
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
