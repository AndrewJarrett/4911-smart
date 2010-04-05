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
using LabBench.language.ui.screens;
using libSMARTMultiTouch.Table;

namespace LabBench
{
    /// <summary>
    /// Interaction logic for TitleScreenControl.xaml
    /// </summary>
    public partial class TitleScreenControl : UserControl
    {
        private TableControl mTableControl;
        
        public TitleScreenControl(TableControl tableControl)
        {
            mTableControl = tableControl;
            InitializeComponent();
        }

        private void lessonManager_Click(object sender, RoutedEventArgs e)
        {
            StateMachine.mScreen = Screens.Manager;
            mTableControl.TableApplicationControl_Loaded(null, null);
        }

        private void lessonPicker_Click(object sender, RoutedEventArgs e)
        {
            StateMachine.mScreen = Screens.Picker;
            mTableControl.TableApplicationControl_Loaded(null, null);
        }
    }
}
