using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabBench.language.ui.screens
{
    /// <summary>
    /// clollection of states
    /// </summary>
    public enum Screens
    {
        TitleScreen,
        Manager,
        Picker,
        Creator,
        Player
    }

    /// <summary>
    /// data structure for all available states
    /// </summary>
    public static class StateMachine
    {
        public static Screens mScreen;
    }
}
