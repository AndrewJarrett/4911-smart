using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using libSMARTMultiTouch.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using libSMARTMultiTouch.Behaviors;
using libSMARTMultiTouch.Table;
using LabBench.language.ui.screens;

namespace LabBench.language.ui.screens
{
    
    public class TitleScreen
    {
        private Canvas mCanvas;
        private Grid mTableLayoutRoot;
        public TitleScreenControl mTitleScreenControl;

        public TitleScreen(TableControl tableControl)
        {
            mCanvas = tableControl.mCanvas;
            mTableLayoutRoot = tableControl.TableLayoutRoot;
            mTitleScreenControl = new TitleScreenControl(tableControl);

            // Clear the Canvas
            mTableLayoutRoot.Children.Remove(mCanvas);

            // Setup the Canvas (main title screen background image)
            ImageBrush mImageBrush = new ImageBrush();
            mImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/main_title_screen.png"));
            mCanvas.Background = mImageBrush;

            // Add the Canvas and UserControl
            mTableLayoutRoot.Children.Add(mCanvas);
            mTableLayoutRoot.Children.Add(mTitleScreenControl);
        }
    }
}
