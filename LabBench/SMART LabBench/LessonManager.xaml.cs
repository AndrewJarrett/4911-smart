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
using System.Windows.Shapes;

namespace SMART_LabBench
{
    /// <summary>
    /// Interaction logic for LessonManager.xaml
    /// </summary>
    public partial class LessonManager : Window
    {
        private int pageNumber;
        private int totalPages;

        public LessonManager()
        {
            InitializeComponent();

            pageNumber = 1;
            totalPages = 1;

            UpdateText();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Creator mCreator = new Creator();
            mCreator.WindowStyle = WindowStyle.None;
            mCreator.WindowState = WindowState.Maximized;
            mCreator.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber == 1)
            {
                this.Close();
            }
            else
            {
                pageNumber--;
            }

            UpdateText();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber == totalPages)
            {
                pageNumber = 1;
            }
            else
            {
                pageNumber++;
            }

            UpdateText();
        }

        private void UpdateText()
        {
            PageText.Text = "Page " + pageNumber + "/" + totalPages;
        }
    }
}
