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
using libSMARTMultiTouch.Controls;
using libSMARTMultiTouch.Input;
using libSMARTMultiTouch.Table;
using LabBench.language.ui;
using LabBench.language.ui.screens;
using LabBench.demo;

namespace LabBench
{
    /// <summary>
    /// Interaction logic for TableControl.xaml
    /// </summary>
    public partial class TableControl : TableApplicationControl
    {
        public Canvas mCanvas;
        public TitleScreen mTitleScreen;
        public Manager mManager;
        public Picker mPicker;
        public Creator mCreator;
        public Player mPlayer;

        /// <summary>
        /// default constructor, creates the canvas and initializes the state machine
        /// </summary>
        public TableControl()
        {
            StateMachine.mScreen = Screens.TitleScreen;
            mCanvas = new Canvas();
            InitializeComponent();
        }

        /// <summary>
        /// Executed upon application launch, controls the state machine
        /// </summary>
        public void TableApplicationControl_Loaded(object sender, RoutedEventArgs e)
        {
            bool displayMenu = true;
            bool displayEditor = false;

            if (displayMenu)
            {
                switch (StateMachine.mScreen)
                {
                    case Screens.TitleScreen:
                        mTitleScreen = new TitleScreen(this);
                        InitializeComponent();
                        break;
                    case Screens.Manager:
                        this.showLessonEditor();
                        //mManager = new Manager(this);
                        //InitializeComponent();
                        break;
                    case Screens.Picker:
                        this.showLessonPlayer();
                        //mPicker = new Picker(this);
                        //InitializeComponent();
                        break;
                    case Screens.Creator:
                        this.showLessonEditor();
                        //mCreator = new Creator(this);
                        break;
                    case Screens.Player:
                        mPlayer = new Player(this);
                        InitializeComponent();
                        break;
                }
            }

            if (displayEditor)
                showLessonEditor();
                
        }

       /// <summary>
        /// Draws the graphical compontents of the lesson editor.
        /// </summary>
        private void showLessonPlayer()
        {
            LessonPlayer mLessonPlayer = new LessonPlayer(this);
            mLessonPlayer.createLesson();
        }

        /// <summary>
        /// Draws the graphical compontents of the lesson editor.
        /// </summary>
        private void showLessonEditor()
        {
            //TableLayoutRoot.Children.Add(mCanvas);

            LessonCreator mLessonCreator = new LessonCreator(this);
            mLessonCreator.createLesson();


            Dictionary<String, String> cat1 = new Dictionary<String, String>();
            cat1.Add("lemon.png", "conductor");
            cat1.Add("paperclip.png", "conductor");
            cat1.Add("nail.png", "conductor");
            cat1.Add("penny.png", "conductor");

            Dictionary<String, String> cat2 = new Dictionary<String, String>();
            cat2.Add("plastic_toy_brick.png", "insulator");
            cat2.Add("playing_card.png", "insulator");
            cat2.Add("barmagnet.png", "insulator");

            Dictionary<String, String> cat3 = new Dictionary<String, String>();
            cat3.Add("light_bulb_off.png", "output");
            cat3.Add("light_dimmer.png", "conductor");
            cat3.Add("nine_volt_battery.png", "input");
            cat3.Add("push_button_up.png", "insulator");
            cat3.Add("rocker_switch_0.png", "conductor");

            Dictionary<String, String>[] mCategories = new Dictionary<String, String>[3];
            mCategories[0] = cat1;
            mCategories[1] = cat2;
            mCategories[2] = cat3;

            // Draw Toolbox
            Toolbox t = new Toolbox(LessonCreator.ActiveLesson.LabBench.Canvas, mCategories, 200, 0);
        }
    }
}
