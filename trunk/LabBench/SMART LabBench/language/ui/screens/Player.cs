using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using libSMARTMultiTouch.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using libSMARTMultiTouch.Behaviors;
using libSMARTMultiTouch.Table;
using LabBench.language.ui.screens;

namespace LabBench.language.ui.screens
{
    /// <summary>
    /// Player start up screen
    /// </summary>
    public class Player
    {
        private Canvas mCanvas;
        private Grid mTableLayoutRoot;
        private TableControl mTableControl;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="tableControl">table control from application</param>
        public Player(TableControl tableControl)
        {
            mTableControl = tableControl;
            mCanvas = new Canvas();
            mTableLayoutRoot = mTableControl.TableLayoutRoot;

            // Clear the layout
            mTableLayoutRoot.Children.Clear();

            // Setup the layout
            mTableControl.mCanvas = mCanvas;
            ImageBrush mImageBrush = new ImageBrush();
            mImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/background.png"));
            mTableControl.mCanvas.Background = mImageBrush;
            mTableControl.mCanvas.Margin = new Thickness(20);

            //Icon mBackIcon = new Icon(new ImagePNG("design/back_arrow.png", 100, 100));
            //mBackIcon. += new RoutedEventHandler(this.mBackIcon_Click);

            // Add to the layout
            //mTableControl.mCanvas.Children.Add(mBackIcon);
            mTableLayoutRoot.Children.Add(mCanvas);
        }

        /// <summary>
        /// event handler for clicking on the back icon
        /// </summary>
        /// <param name="sender">back icon</param>
        /// <param name="e">click event</param>
        private void mBackIcon_Click(object sender, EventArgs e)
        {
            StateMachine.mScreen = Screens.Picker;
            mTableControl.TableApplicationControl_Loaded(null, null);
        }
    }
}
