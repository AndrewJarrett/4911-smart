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
    class LessonChoice : language.Icon
    {
        private Canvas parent;
        private int locX, locY;

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

        private void Button_ChooseLesson(object sender, TouchContactEventArgs e)
        {

        }

        private void Button_NewLesson(object sender, TouchContactEventArgs e)
        {

        }
    }
}
