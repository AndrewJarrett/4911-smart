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
using libSMARTMultiTouch.Input;
using LabBench.language.ui;

namespace SMART_LabBench
{
    /// <summary>
    /// Interaction logic for TableControl.xaml
    /// </summary>
    public partial class TableControl : TableApplicationControl
    {
        private Canvas canvas = new Canvas();

        public TableControl()
        {
            canvas.Background = new SolidColorBrush(Colors.Transparent);
            InitializeComponent();
        }

        private void TableApplicationControl_Loaded(object sender, RoutedEventArgs e)
        {
            TableLayoutRoot.Children.Add(canvas);

            InteractiveBorder mInteractiveBorder = new InteractiveBorder();
            mInteractiveBorder.Width = 75; mInteractiveBorder.Height = 75;
            mInteractiveBorder.Background = new SolidColorBrush(Colors.Red);

            Rectangle mRectangle = new Rectangle();
            mRectangle.Height = mInteractiveBorder.Height;
            mRectangle.Width = mInteractiveBorder.Width;
            mRectangle.Fill = new SolidColorBrush(Colors.Red);

            TouchCloner mTouchCloner = new TouchCloner(mRectangle);
            mTouchCloner.Source = new ClonableRectangle(mInteractiveBorder);

            TranslateTransform mTranslateTransform = new TranslateTransform();
            mTranslateTransform.X = 400;
            mTranslateTransform.Y = 400;
            mTouchCloner.RenderTransform = mTranslateTransform;

            canvas.Children.Add(mTouchCloner);

            // Draw Toolbox
            Toolbox t = new Toolbox(canvas, 100, 100);
        }

    }
}
