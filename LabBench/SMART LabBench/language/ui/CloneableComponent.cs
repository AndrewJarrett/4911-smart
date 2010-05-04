using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using libSMARTMultiTouch.Controls;
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.control;
using LabBench.demo;
using System.Windows;

namespace LabBench.language.ui
{
    /// <summary>
    /// Component that can be cloned
    /// </summary>
    class CloneableComponent : libSMARTMultiTouch.ICloneable
    {
        private Component mComponent;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mComponent">Component to be cloned</param>
        public CloneableComponent(Component mComponent)
        {
            this.mComponent = mComponent;
        }

        #region ICloneable Members

        /// <summary>
        /// create a new clone 
        /// </summary>
        /// <returns>cloned object</returns>
        public object Clone()
        {
            Component r = new Component(mComponent.Resistivity, mComponent.getSource());
            LessonCreator.ActiveLesson.Circuit.AddNode(r);
            return r;
        }

        #endregion
    }
}
