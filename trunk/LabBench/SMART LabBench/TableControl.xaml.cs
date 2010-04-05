﻿using System;
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
        
        public TableControl()
        {
            StateMachine.mScreen = Screens.TitleScreen;
            mCanvas = new Canvas();
            InitializeComponent();
        }

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
                        mManager = new Manager(this);
                        InitializeComponent();
                        break;
                    case Screens.Picker:
                        mPicker = new Picker(this);
                        InitializeComponent();
                        break;
                    case Screens.Creator:
                        mCreator = new Creator(this);
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

        private void showLessonEditor()
        {
            TableLayoutRoot.Children.Add(mCanvas);

            mCanvas.Background = new SolidColorBrush(Colors.DarkGray);

            Rectangle mRectangle = new Rectangle();
            mRectangle.Height = 960;
            mRectangle.Width = 1280;

            TranslateTransform mTranslateTransform = new TranslateTransform();
            mTranslateTransform.X = 60;
            mTranslateTransform.Y = 45;

            mRectangle.RenderTransform = mTranslateTransform;

            mRectangle.Fill = new SolidColorBrush(Colors.White);

            mCanvas.Children.Add(mRectangle);

            //InteractiveBorder mInteractiveBorder = new InteractiveBorder();
            //mInteractiveBorder.Width = 75; mInteractiveBorder.Height = 75;
            //mInteractiveBorder.Background = new SolidColorBrush(Colors.Red);

            //Rectangle mRectangle = new Rectangle();
            //mRectangle.Height = mInteractiveBorder.Height;
            //mRectangle.Width = mInteractiveBorder.Width;
            //mRectangle.Fill = new SolidColorBrush(Colors.Red);

            //mIconFactories = new List<IconFactory>();

            //Icon mIcon = new Icon(new ImagePNG("lemon.png"));
            //IconFactory mIconFactory = new IconFactory(canvas, mIcon, 0, 0);
            //mIconFactories.Add(mIconFactory);

            //mIcon = new Icon(new ImagePNG("barmagnet.png"));
            //mIconFactory = new IconFactory(canvas, mIcon, 200, 20);
            //mIconFactories.Add(mIconFactory);
            Sandbox mSandbox = new Sandbox(mCanvas);
            mSandbox.activate();

            List<String> cat1 = new List<String>();
            cat1.Add("lemon.png");
            cat1.Add("paperclip.png");
            cat1.Add("nail.png");
            cat1.Add("penny.png");

            List<String> cat2 = new List<String>();
            cat2.Add("plastic_toy_brick.png");
            cat2.Add("playing_card.png");
            cat2.Add("barmagnet.png");

            List<String> cat3 = new List<String>();
            cat3.Add("light_bulb_off.png");
            cat3.Add("light_dimmer.png");
            cat3.Add("nine_volt_battery.png");
            cat3.Add("push_button_up.png");
            cat3.Add("rocker_switch_0.png");

            List<String>[] mIcons = new List<String>[3];
            mIcons[0] = cat1;
            mIcons[1] = cat2;
            mIcons[2] = cat3;

            // Draw Toolbox
            Toolbox t = new Toolbox(mCanvas, mIcons, 600, 0);
        }
    }
}
