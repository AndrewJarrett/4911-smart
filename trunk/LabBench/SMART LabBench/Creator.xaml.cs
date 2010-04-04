using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using libSMARTMultiTouch.Controls;
using LabBench.language.ui;

namespace LabBench
{
    /// <summary>
    /// Interaction logic for Creator.xaml
    /// </summary>
    public partial class Creator : Window
    {
        // private IconFactory mIconFactory;
        // private Canvas mCanvas;

        public Creator()
        {
            /*
            mCanvas.Background = new SolidColorBrush(Colors.Transparent);

            InitializeComponent();

            mCanvas = new Canvas();
            
            // Add the Canvas to the Window
            base.TableLayoutRoot.Children.Add(mCanvas);

            // Add a lemon to demo the IconFactory
            Icon mIcon = new Icon(new ImagePNG("lemon.png"));
            mIconFactory = new IconFactory(mCanvas, mIcon, 400, 400);

            // Add the Toolbox
            Toolbox mToolbox = new Toolbox(mCanvas, 100, 100);
            */
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
