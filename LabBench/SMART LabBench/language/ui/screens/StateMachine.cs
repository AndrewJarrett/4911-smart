using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabBench.language.ui.screens
{
    public enum Screens
    {
        TitleScreen,
        Manager,
        Picker,
        Creator,
        Player
    }

    public static class StateMachine
    {
        public static Screens mScreen;
    }
}
