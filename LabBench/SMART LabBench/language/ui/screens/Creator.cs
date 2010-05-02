using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using libSMARTMultiTouch.Controls;
using libSMARTMultiTouch.Input;
using libSMARTMultiTouch.Behaviors;
using libSMARTMultiTouch.Table;

using LabBench.language;
using LabBench.language.ui.screens;
using LabBench.language.ui;
using LabBench.demo;

/// <summary>
/// a UI screen which is used for creating lessons.
/// </summary>
namespace LabBench.language.ui.screens
{
    public class Creator
    {
        private Canvas mCanvas;
        private Grid mTableLayoutRoot;
        private TableControl mTableControl;

        /// <summary>
        /// Lesson creator default constructor
        /// </summary>
        public Creator(TableControl tableControl)
        {
            mTableControl = tableControl;
            mCanvas = new Canvas();
            mTableLayoutRoot = mTableControl.TableLayoutRoot;

            // Clear the layout
            mTableLayoutRoot.Children.Clear();

            // Setup
            mTableLayoutRoot.Children.Add(mCanvas);

            mCanvas.Background = new SolidColorBrush(Colors.DarkGray);

            Rectangle mRectangle = new Rectangle();
            mRectangle.Height = 960;
            mRectangle.Width = 1280;

            TranslateTransform mTranslateTransform = new TranslateTransform();
            mTranslateTransform.X = 60;
            mTranslateTransform.Y = 45;

            mRectangle.RenderTransform = mTranslateTransform;

            mRectangle.Fill = new SolidColorBrush(Colors.White);

            mCanvas.Children.Add(mRectangle);

            LessonCreator mLessonCreator = new LessonCreator(mTableControl);
            //mSandbox.activate();

            List<String> cat1 = new List<String>();
            cat1.Add("lemon.png");
            cat1.Add("paperclip.png");
            cat1.Add("nail.png");
            cat1.Add("penny.png");

            List<String> cat2 = new List<String>();
            cat2.Add("plastic_toy_brick.png");
            cat2.Add("playing_card.png");
            cat2.Add("barmagnet.png");

            List<String> cat3 = new List<String>();
            cat3.Add("light_bulb_off.png");
            cat3.Add("light_dimmer.png");
            cat3.Add("nine_volt_battery.png");
            cat3.Add("push_button_up.png");
            cat3.Add("rocker_switch_0.png");

            List<String>[] mIcons = new List<String>[3];
            mIcons[0] = cat1;
            mIcons[1] = cat2;
            mIcons[2] = cat3;

            // Draw Toolbox
            Toolbox t = new Toolbox(mCanvas, mIcons, 600, 0);

            Border saveButton = new Border();
            saveButton.Width = 75; saveButton.Height = 75;
            saveButton.RenderTransform = new TranslateTransform(200, 200);
            saveButton.Background = new SolidColorBrush(Colors.Green);
            TouchInputManager.AddTouchContactDownHandler(saveButton, new TouchContactEventHandler(Button_SaveLesson));

            mCanvas.Children.Add(saveButton);
        }

        /// <summary>
        /// Save button listener
        /// </summary>
        private void Button_SaveLesson(object sender, TouchContactEventArgs e)
        {
            // remove buttons from canvas
            List<UIElement> toRemove = new List<UIElement>();
            foreach (UIElement elem in mCanvas.Children)
            {
                if (elem.GetType() == (new Border()).GetType())
                    toRemove.Add(elem);
            }
            // need to get elements before removing them due to bad WPF Collections implementation
            foreach (UIElement elem in toRemove)
            {
                mCanvas.Children.Remove(elem);
            }

            // take screenshot
            RenderTargetBitmap screenshot = new RenderTargetBitmap(200, 200, 96, 96, PixelFormats.Pbgra32);
            screenshot.Render(mCanvas);
            WriteableBitmap screenShot = new WriteableBitmap(screenshot);
            //BitmapFrame screenshotframe = BitmapFrame.Create(screenshot);

            // save canvas + screenshot as Lesson
            saveLesson(mCanvas, screenShot);
        }

        /// <summary>
        /// Lesson save helper function.
        /// </summary>
        private void saveLesson(Canvas canvas, WriteableBitmap screenshot)
        {
            String directory = "lessons";
            int cnt = 0;
            foreach (string lessonName in System.IO.Directory.GetFiles(directory))
            {
                if (lessonName != ".svn")
                    cnt++;
            }

            String filePath = directory + "/lesson_" + cnt + ".bin";

            SerializedLesson savedlesson = new SerializedLesson(canvas);

        }
    }
}
