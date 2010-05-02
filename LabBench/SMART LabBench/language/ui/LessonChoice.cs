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

namespace LabBench
{
    /// <summary>
    ///  
    /// </summary>
    class LessonChoice : language.Icon
    {
        private Canvas parent;
        private int locX, locY;

        /// <summary>
        ///  Default constructor for LessonChoice, used to create a button for making a new lesson.
        /// </summary>
        public LessonChoice(Canvas mainCanvas, int x, int y)
            : base(new language.ImagePNG("ui/plus_sign.png"))
        {
            this.parent = mainCanvas;
            this.locX = x; this.locY = y;

            TransformGroup mTransformGroup = new TransformGroup();
            mTransformGroup.Children.Add(new ScaleTransform(0.5, 0.5));
            mTransformGroup.Children.Add(new TranslateTransform(x - 50, y - 75));

            this.RenderTransform = mTransformGroup;

            TouchInputManager.AddTouchContactDownHandler(this, new TouchContactEventHandler(Button_NewLesson));
        }

        /// <summary>
        ///  Concrete constructor for LessonChoice, tied to a specific lesson, loads it when clicked
        /// </summary>
        public LessonChoice(Canvas mainCanvas, SerializedLesson lesson, int x, int y)
            : base(new language.ImagePNG("ui/plus_sign.png"))
        {
            this.parent = mainCanvas;
            this.locX = x; this.locY = y;

            TransformGroup mTransformGroup = new TransformGroup();
            mTransformGroup.Children.Add(new ScaleTransform(0.5, 0.5));
            mTransformGroup.Children.Add(new TranslateTransform(x - 50, y - 75));

            this.RenderTransform = mTransformGroup;

            TouchInputManager.AddTouchContactDownHandler(this, new TouchContactEventHandler(Button_ChooseLesson));

        }

        /// <summary>
        /// Occurs when you press to select a lesson that exists, loads the chosen lesson.
        /// </summary>
        private void Button_ChooseLesson(object sender, TouchContactEventArgs e)
        {

        }

        /// <summary>
        /// Occurs when you press to select a lesson placeholder, creates a new lesson and clears the screen.
        /// </summary>
        private void Button_NewLesson(object sender, TouchContactEventArgs e)
        {

        }
    }
}
