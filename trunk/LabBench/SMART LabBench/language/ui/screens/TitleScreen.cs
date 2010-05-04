using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using libSMARTMultiTouch.Behaviors;
using libSMARTMultiTouch.Table;
using libSMARTMultiTouch.Input;
using libSMARTMultiTouch.Controls;

using LabBench.language.ui.screens;

namespace LabBench.language.ui.screens
{
    
    /// <summary>
    /// Title Screen of the application
    /// </summary>
    public class TitleScreen
    {
        #region Object Declarations for the TitleScreen State
        private Canvas mCanvas;
        private Grid mTableLayoutRoot;
        private TableControl mTableControl;
        private StackPanel mStackPanel;
        private Border mManagerOuterBorder;
        private Border mManagerInnerBorder;
        private Border mPickerOuterBorder;
        private Border mPickerInnerBorder;
        private InteractiveControl mManagerButton;
        private InteractiveControl mPickerButton;
        #endregion

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="tableControl">table control from the application</param>
        public TitleScreen(TableControl tableControl)
        {
            #region Setup all the variables for this state
            mCanvas = tableControl.mCanvas;
            mTableLayoutRoot = tableControl.TableLayoutRoot;
            mTableControl = tableControl;
            mStackPanel = new StackPanel();
            mManagerOuterBorder = new Border();
            mManagerInnerBorder = new Border();
            mPickerOuterBorder = new Border();
            mPickerInnerBorder = new Border();
            mManagerButton = new InteractiveControl();
            mPickerButton = new InteractiveControl();
            #endregion

            #region Setup the Canvas
            mTableLayoutRoot.Children.Remove(mCanvas);
            ImageBrush mImageBrush = new ImageBrush();
            mImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/design/main_title_screen.png"));
            mCanvas.Background = mImageBrush;
            mCanvas.VerticalAlignment = VerticalAlignment.Stretch;
            mCanvas.HorizontalAlignment = HorizontalAlignment.Stretch;
            #endregion

            #region Construct the UI Elements
            mManagerButton.FontSize = 22;
            mManagerButton.Content = "Create a Lesson!";
            mManagerButton.HorizontalAlignment = HorizontalAlignment.Center;
            
            mPickerButton.FontSize = 22;
            mPickerButton.Content = "Play a Lesson!";
            mPickerButton.HorizontalAlignment = HorizontalAlignment.Center;
            
            mManagerInnerBorder.Background = new SolidColorBrush(Colors.DarkGray);
            mManagerInnerBorder.BorderThickness = new Thickness(5);
            mManagerInnerBorder.Padding = new Thickness(10);
            mManagerInnerBorder.CornerRadius = new CornerRadius(18);
            mManagerInnerBorder.Opacity = .6;

            mPickerInnerBorder.Background = new SolidColorBrush(Colors.DarkGray);
            mPickerInnerBorder.BorderThickness = new Thickness(5);
            mPickerInnerBorder.Padding = new Thickness(10);
            mPickerInnerBorder.CornerRadius = new CornerRadius(18);
            mPickerInnerBorder.Opacity = .6;

            SolidColorBrush mRedTransparentBrush = new SolidColorBrush(Colors.Red);
            mRedTransparentBrush.Opacity = .6;

            mManagerOuterBorder.Background = mRedTransparentBrush;
            mManagerOuterBorder.BorderThickness = new Thickness(0, 0, 2, 2);
            mManagerOuterBorder.CornerRadius = new CornerRadius(18);
            mManagerOuterBorder.Margin = new Thickness(10);

            mPickerOuterBorder.Background = mRedTransparentBrush;
            mPickerOuterBorder.BorderThickness = new Thickness(0, 0, 2, 2);
            mPickerOuterBorder.CornerRadius = new CornerRadius(18);
            mPickerOuterBorder.Margin = new Thickness(10);
            
            mStackPanel.VerticalAlignment = VerticalAlignment.Center;
            mStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            mStackPanel.Width = 300;
            #endregion

            #region Connect UI Elements to the Table
            mManagerInnerBorder.Child = mManagerButton;
            mManagerOuterBorder.Child = mManagerInnerBorder;
            mPickerInnerBorder.Child = mPickerButton;
            mPickerOuterBorder.Child = mPickerInnerBorder;
            mStackPanel.Children.Add(mManagerOuterBorder);
            mStackPanel.Children.Add(mPickerOuterBorder);
            mTableLayoutRoot.Children.Add(mCanvas);
            mTableLayoutRoot.Children.Add(mStackPanel);
            #endregion

            #region Add Touch Event Handlers to the TouchInputManager
            TouchInputManager.AddTouchContactUpHandler(mManagerButton, new TouchContactEventHandler(ManagerButton_TouchContactUp));
            TouchInputManager.AddTouchContactUpHandler(mPickerButton, new TouchContactEventHandler(PickerButton_TouchContactUp));
            #endregion
        }

        #region Touch Event Handlers
        /// <summary>
        /// handle touch releases on the Manager Button
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">touch event</param>
        private void ManagerButton_TouchContactUp(object sender, TouchContactEventArgs e)
        {
            StateMachine.mScreen = Screens.Manager;
            mTableControl.TableApplicationControl_Loaded(null, null);
        }
        /// <summary>
        /// handle touch releases on the Lesson Picker button
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">touch event</param>
        private void PickerButton_TouchContactUp(object sender, TouchContactEventArgs e)
        {
            StateMachine.mScreen = Screens.Picker;
            mTableControl.TableApplicationControl_Loaded(null, null);
        }
        #endregion
    }
}
