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
    /// lesson picker screen
    /// </summary>
    public class Picker
    {
        private Canvas mCanvas;
        private Grid mTableLayoutRoot;
        private TableControl mTableControl;
        private TextBlock mTextBlock;
        private int pageNumber;
        private int totalPages;

        private const int BUTTON_WIDTH = 232;
        private const int BUTTON_HEIGHT = 200;
        private const int NAV_BUTTON_WIDTH = 100;
        private const int NAV_BUTTON_HEIGHT = 100;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="tableControl">table control from application</param>
        public Picker(TableControl tableControl)
        {
            mTableControl = tableControl;
            mCanvas = new Canvas();
            mTableLayoutRoot = mTableControl.TableLayoutRoot;

            pageNumber = 1;
            totalPages = 1;

            // Clear the layout
            mTableLayoutRoot.Children.Clear();

            // Setup the layout
            mTableControl.mCanvas = mCanvas;
            mTableControl.mCanvas.Background = new SolidColorBrush(Colors.Transparent);

            Grid mGrid = new Grid();
            ImageBrush mImageBrush = new ImageBrush();
            mImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/background.png"));
            mGrid.Background = mImageBrush;
            mGrid.Margin = new Thickness(20);
            mGrid.ShowGridLines = false;

            ColumnDefinition mColumnDefinition1 = new ColumnDefinition();
            ColumnDefinition mColumnDefinition2 = new ColumnDefinition();
            ColumnDefinition mColumnDefinition3 = new ColumnDefinition();
            mColumnDefinition1.Width = new GridLength(328);
            mColumnDefinition2.Width = new GridLength(328);
            mColumnDefinition3.Width = new GridLength(328);
            mGrid.ColumnDefinitions.Add(mColumnDefinition1);
            mGrid.ColumnDefinitions.Add(mColumnDefinition2);
            mGrid.ColumnDefinitions.Add(mColumnDefinition3);
            
            RowDefinition mRowDefinition1 = new RowDefinition();
            RowDefinition mRowDefinition2 = new RowDefinition();
            RowDefinition mRowDefinition3 = new RowDefinition();
            mRowDefinition1.Height = new GridLength(242.66);
            mRowDefinition2.Height = new GridLength(242.66);
            mRowDefinition3.Height = new GridLength(242.66);
            mGrid.RowDefinitions.Add(mRowDefinition1);
            mGrid.RowDefinitions.Add(mRowDefinition2);
            mGrid.RowDefinitions.Add(mRowDefinition3);

            Button mButton1 = new Button();
            ImageBrush mImageBrush1 = new ImageBrush();
            mImageBrush1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/question_mark_box.png"));
            mButton1.Background = mImageBrush1;
            mButton1.Width = BUTTON_WIDTH;
            mButton1.Height = BUTTON_HEIGHT;
            mButton1.HorizontalAlignment = HorizontalAlignment.Center;
            mButton1.VerticalAlignment = VerticalAlignment.Center;
            mButton1.Click += new RoutedEventHandler(this.mButton1_Click);
            Grid.SetRow(mButton1, 0);
            Grid.SetColumn(mButton1, 0);
            
            Button mButton2 = new Button();
            ImageBrush mImageBrush2 = new ImageBrush();
            mImageBrush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/question_mark_box.png"));
            mButton2.Background = mImageBrush2;
            mButton2.Width = BUTTON_WIDTH;
            mButton2.Height = BUTTON_HEIGHT;
            mButton2.HorizontalAlignment = HorizontalAlignment.Center;
            mButton2.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(mButton2, 0);
            Grid.SetColumn(mButton2, 1);

            Button mButton3 = new Button();
            ImageBrush mImageBrush3 = new ImageBrush();
            mImageBrush3.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/question_mark_box.png"));
            mButton3.Background = mImageBrush3;
            mButton3.Width = BUTTON_WIDTH;
            mButton3.Height = BUTTON_HEIGHT;
            mButton3.HorizontalAlignment = HorizontalAlignment.Center;
            mButton3.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(mButton3, 0);
            Grid.SetColumn(mButton3, 2);
            
            Button mButton4 = new Button();
            ImageBrush mImageBrush4 = new ImageBrush();
            mImageBrush4.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/question_mark_box.png"));
            mButton4.Background = mImageBrush4;
            mButton4.Width = BUTTON_WIDTH;
            mButton4.Height = BUTTON_HEIGHT;
            mButton4.HorizontalAlignment = HorizontalAlignment.Center;
            mButton4.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(mButton4, 1);
            Grid.SetColumn(mButton4, 0);

            Button mButton5 = new Button();
            ImageBrush mImageBrush5 = new ImageBrush();
            mImageBrush5.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/question_mark_box.png"));
            mButton5.Background = mImageBrush5;
            mButton5.Width = BUTTON_WIDTH;
            mButton5.Height = BUTTON_HEIGHT;
            mButton5.HorizontalAlignment = HorizontalAlignment.Center;
            mButton5.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(mButton5, 1);
            Grid.SetColumn(mButton5, 1);

            Button mButton6 = new Button();
            ImageBrush mImageBrush6 = new ImageBrush();
            mImageBrush6.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/question_mark_box.png"));
            mButton6.Background = mImageBrush6;
            mButton6.Width = BUTTON_WIDTH;
            mButton6.Height = BUTTON_HEIGHT;
            mButton6.HorizontalAlignment = HorizontalAlignment.Center;
            mButton6.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(mButton6, 1);
            Grid.SetColumn(mButton6, 2);

            Button mPreviousButton = new Button();
            ImageBrush mImageBrushPrev = new ImageBrush();
            mImageBrushPrev.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/back_arrow.png"));
            mPreviousButton.Background = mImageBrushPrev;
            mPreviousButton.Width = NAV_BUTTON_WIDTH;
            mPreviousButton.Height = NAV_BUTTON_HEIGHT;
            mPreviousButton.HorizontalAlignment = HorizontalAlignment.Center;
            mPreviousButton.VerticalAlignment = VerticalAlignment.Center;
            mPreviousButton.Click += new RoutedEventHandler(this.mPreviousButton_Click);
            Grid.SetRow(mPreviousButton, 2);
            Grid.SetColumn(mPreviousButton, 0);

            mTextBlock = new TextBlock();
            mTextBlock.FontSize = 60;
            Grid.SetRow(mTextBlock, 2);
            Grid.SetColumn(mTextBlock, 1);
            mTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            mTextBlock.VerticalAlignment = VerticalAlignment.Center;

            Button mNextButton = new Button();
            ImageBrush mImageBrushNext = new ImageBrush();
            mImageBrushNext.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/forward_arrow.png"));
            mNextButton.Background = mImageBrushNext;
            mNextButton.Width = NAV_BUTTON_WIDTH;
            mNextButton.Height = NAV_BUTTON_HEIGHT;
            mNextButton.HorizontalAlignment = HorizontalAlignment.Center;
            mNextButton.VerticalAlignment = VerticalAlignment.Center;
            mNextButton.Click += new RoutedEventHandler(this.mNextButton_Click);
            Grid.SetRow(mNextButton, 2);
            Grid.SetColumn(mNextButton, 2);

            // Add to the layout
            mGrid.Children.Add(mButton1);
            mGrid.Children.Add(mButton2);
            mGrid.Children.Add(mButton3);
            mGrid.Children.Add(mButton4);
            mGrid.Children.Add(mButton5);
            mGrid.Children.Add(mButton6);
            mGrid.Children.Add(mPreviousButton);
            mGrid.Children.Add(mTextBlock);
            mGrid.Children.Add(mNextButton);

            mTableLayoutRoot.Children.Add(mCanvas);
            mTableLayoutRoot.Children.Add(mGrid);

            UpdateText();
        }

        /// <summary>
        /// event handler for clicking on button
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">touch event</param>
        private void mButton1_Click(object sender, EventArgs e)
        {
            StateMachine.mScreen = Screens.Player;
            mTableControl.TableApplicationControl_Loaded(null, null);
        }

        /// <summary>
        /// event handler for clicking on button
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">touch event</param>
        private void mPreviousButton_Click(object sender, EventArgs e)
        {
            if (pageNumber == 1)
            {
                // Go back to the title screen
                StateMachine.mScreen = Screens.TitleScreen;
                mTableControl.TableApplicationControl_Loaded(null, null);
            }
            else
                pageNumber--;

            UpdateText();
        }

        /// <summary>
        /// event handler for clicking on button
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">touch event</param>
        private void mNextButton_Click(object sender, EventArgs e)
        {
            if (pageNumber == totalPages)
                pageNumber = 1;
            else
                pageNumber++;

            UpdateText();
        }

        /// <summary>
        /// update the text indicating the page number
        /// </summary>
        private void UpdateText()
        {
            mTextBlock.Text = "Page " + pageNumber + "/" + totalPages;
        }
    }
}
