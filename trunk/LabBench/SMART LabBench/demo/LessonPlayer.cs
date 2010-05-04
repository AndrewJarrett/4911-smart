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
    /// <summary>
    /// Lesson Player mode
    /// </summary>
    class LessonPlayer
    {
        private static PlayableLesson mActiveLesson;

        private Grid mGrid;
        private List<PlayableLesson> mLessonList = new List<PlayableLesson>();

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mTableControl">table control from application</param>
        public LessonPlayer(TableControl mTableControl)
        {
            mGrid = mTableControl.TableLayoutRoot;
        }


        /// <summary>
        /// create a new lesson
        /// </summary>
        public void createLesson()
        {
            PlayableLesson mLesson = new PlayableLesson(new Canvas());
            mLessonList.Add(mLesson);
            mGrid.Children.Add(mLesson.LabBench.Canvas);
            mActiveLesson = mLesson;
            mLesson.initialize();
        }

        /// <summary>
        /// delete a lesson
        /// </summary>
        /// <param name="mLesson">lesson to be deleted</param>
        public void deleteLesson(PlayableLesson mLesson)
        {
            mGrid.Children.Remove(mLesson.LabBench.Canvas);
            mLessonList.Remove(mLesson);
        }

        /// <summary>
        /// the currently played lesson
        /// </summary>
        public static PlayableLesson ActiveLesson
        {
            set { mActiveLesson = value; }
            get { return mActiveLesson; }
        }

    }
}
