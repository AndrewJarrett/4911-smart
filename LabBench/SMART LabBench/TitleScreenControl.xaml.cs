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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabBench
{
    /// <summary>
    /// Interaction logic for TitleScreenControl.xaml
    /// </summary>
    public partial class TitleScreenControl : UserControl
    {
        public TitleScreenControl()
        {
            InitializeComponent();
        }

        private void lessonManager_Click(object sender, RoutedEventArgs e)
        {
            LessonManager mLessonManager = new LessonManager();
            mLessonManager.WindowStyle = WindowStyle.None;
            mLessonManager.WindowState = WindowState.Maximized;
            mLessonManager.Show();
        }

        private void lessonPicker_Click(object sender, RoutedEventArgs e)
        {
            LessonPicker mLessonPicker = new LessonPicker();
            mLessonPicker.WindowStyle = WindowStyle.None;
            mLessonPicker.WindowState = WindowState.Maximized;
            mLessonPicker.Show();
        }
    }
}
