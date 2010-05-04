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

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mTableControl">top level table control structure</param>
        public LessonCreator(TableControl mTableControl)
        {
            mGrid = mTableControl.TableLayoutRoot;
        }

        /// <summary>
        /// create a new lesson
        /// </summary>
        public void createLesson()
        {
            Lesson mLesson = new Lesson(new Canvas());
            mLessonList.Add(mLesson);
            mGrid.Children.Add(mLesson.LabBench.Canvas);
            mActiveLesson = mLesson;
            mLesson.initialize();
        }

        /// <summary>
        /// delete a Lesson
        /// </summary>
        /// <param name="mLesson">Lesson to be deleted</param>
        public void deleteLesson(Lesson mLesson)
        {
            mGrid.Children.Remove(mLesson.LabBench.Canvas);
            mLessonList.Remove(mLesson);
        }

        /// <summary>
        /// accessor to the ActiveLesson
        /// </summary>
        public static Lesson ActiveLesson
        {
            set { mActiveLesson = value; }
            get { return mActiveLesson; }
        }
            
    }
}
