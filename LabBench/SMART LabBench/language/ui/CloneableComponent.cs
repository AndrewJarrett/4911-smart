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
    class CloneableComponent : libSMARTMultiTouch.ICloneable
    {
        private Component mComponent;

        public CloneableComponent(Component mComponent)
        {
            this.mComponent = mComponent;
        }

        #region ICloneable Members

        public object Clone()
        {
            Component r = new Component(mComponent.Resistivity, mComponent.getSource());
            LessonCreator.ActiveLesson.Circuit.AddNode(r);
            return r;
        }

        #endregion
    }
}
