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

namespace LabBench
{
    /// <summary>
    /// Interaction logic for LessonPicker.xaml
    /// </summary>
    public partial class LessonPicker : Window
    {
        private int pageNumber;     // Keeps track of the current page we are on
        private int totalPages;     // Keeps track of the total number of pages

        public LessonPicker()
        {
            InitializeComponent();
            pageNumber = 1;
            totalPages = 1;         // This will be computed eventually, but for now I'm setting it to 1

            // Set the initial Text (Page 1/x)
            UpdateText();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

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
