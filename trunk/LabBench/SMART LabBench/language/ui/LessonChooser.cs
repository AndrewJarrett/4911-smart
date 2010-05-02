using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Media;
using libSMARTMultiTouch.Input;

namespace LabBench.language.ui
{
    class LessonChooser
    {
        List<Icon> visible;
        List<SerializedLesson> lessonchoices;

        BinaryFormatter bformatter;
        Stream stream;

        Canvas canvas;
        int x, y;
        int currentPage;

        public LessonChooser(Canvas canvas, int x, int y)
        {
            this.canvas = canvas;
            this.x = x; this.y = y;

            bformatter = new BinaryFormatter();
            lessonchoices = new List<SerializedLesson>();
            visible = new List<Icon>();
            string lessonDirectory = "lessons";

            foreach (string file in System.IO.Directory.GetFiles(lessonDirectory))
            {
                if (!file.Split('\\').Contains(".svn"))
                    lessonchoices.Add(deserializeItem(file));
            }
            this.currentPage = 0;
            this.displayLessons(0);

        }

        public void displayLessons(int page)
        {
            this.clearLessons();
            if (page > 0)
                showLeftArrow();
            showRightArrow();

            for (int i = 0; i < 6; i++)
            {
                LessonChoice element;
                int index = (6 * page) + i;
                int posx = x + (i * 100) - (300 * (i / 3));
                int posy = y + ((i / 3) * 100);
                if (index < lessonchoices.Count)
                    element = new LessonChoice(canvas, lessonchoices.ElementAt(index), posx, posy);
                else
                    element = new LessonChoice(canvas, posx, posy);

                canvas.Children.Add(element);
                visible.Add(element);
            }
        }

        private void showRightArrow()
        {
            language.Icon right_arrow = new language.Icon(new language.ImagePNG("ui/right_arrow.png"));

            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(new ScaleTransform(0.5, 0.5));
            transformGroup.Children.Add(new TranslateTransform(x + 270, y - 20));

            right_arrow.RenderTransform = transformGroup;

            TouchInputManager.AddTouchContactDownHandler(right_arrow, new TouchContactEventHandler(Button_NextPage));

            canvas.Children.Add(right_arrow);
            visible.Add(right_arrow);
        }

        private void showLeftArrow()
        {
            language.Icon left_arrow = new language.Icon(new language.ImagePNG("ui/left_arrow.png"));

            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(new ScaleTransform(0.5, 0.5));
            transformGroup.Children.Add(new TranslateTransform(x - 100, y - 20));

            left_arrow.RenderTransform = transformGroup;

            TouchInputManager.AddTouchContactDownHandler(left_arrow, new TouchContactEventHandler(Button_PrevPage));

            canvas.Children.Add(left_arrow);
            visible.Add(left_arrow);
        }

        private void Button_NextPage(object sender, TouchContactEventArgs e)
        {
            currentPage = currentPage + 1;
            this.displayLessons(currentPage);
        }

        private void Button_PrevPage(object sender, TouchContactEventArgs e)
        {
            currentPage = currentPage - 1;
            this.displayLessons(currentPage);
        }

        public void clearLessons()
        {
            foreach (Icon lesson in visible)
            {
                canvas.Children.Remove(lesson);
            }
            visible = new List<Icon>();
        }

        private SerializedLesson deserializeItem(string objLocation)
        {
            stream = File.Open(objLocation, FileMode.Open);

            SerializedLesson obj = (SerializedLesson)bformatter.Deserialize(stream);

            stream.Close();
            return obj;
        }
    }
}
