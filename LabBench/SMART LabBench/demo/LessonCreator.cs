using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using libSMARTMultiTouch.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.control;
using LabBench.language.ui.layout;
using LabBench.language;

namespace LabBench.demo
{

    class LessonCreator
    {
        private static Lesson mActiveLesson;

        private Grid mGrid;
        private List<Lesson> mLessonList = new List<Lesson>();

        public LessonCreator(TableControl mTableControl)
        {
            mGrid = mTableControl.TableLayoutRoot;
        }

        public void createLesson()
        {
            Lesson mLesson = new Lesson(new Canvas());
            mLessonList.Add(mLesson);
            mGrid.Children.Add(mLesson.LabBench.Canvas);
            mActiveLesson = mLesson;
            mLesson.initialize();
        }

        public void deleteLesson(Lesson mLesson)
        {
            mGrid.Children.Remove(mLesson.LabBench.Canvas);
            mLessonList.Remove(mLesson);
        }

        public static Lesson ActiveLesson
        {
            set { mActiveLesson = value; }
            get { return mActiveLesson; }
        }
            
    }
}
