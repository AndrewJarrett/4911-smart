using LabBench.language.ui.layout;
using LabBench.language.graph;
using LabBench.language.ui;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LabBench.language.ui.layout
{
    /// <summary>
    /// overall layout of the UI
    /// </summary>
    class LabBenchLayout
    {
        private Canvas mCanvas;
        private GridLayout mGridLayout;
        private List<Toolbox> mToolboxes;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mReferenceCanvas">the reference canvas to which everything is drawn</param>
        public LabBenchLayout(Canvas mReferenceCanvas)
        {
            mCanvas = mReferenceCanvas;
        }

        /// <summary>
        /// create the grid layout for the lab bench
        /// </summary>
        public void createLayout()
        {
            mGridLayout = new GridLayout();
            mToolboxes = new List<Toolbox>();
        }

        /// <summary>
        /// adds new toolbox to canvas at given x/y coordinates.
        /// </summary>
        public void addToolbox(int x, int y)
        {
            mToolboxes.Add(new Toolbox(mCanvas, x, y));
        }

        /// <summary>
        /// adds the given toolbox to the canvas. toolbox already has x/y coordinates.
        /// </summary>
        public void addToolbox(Toolbox mToolbox)
        {
            mToolboxes.Add(mToolbox);
        }

        #region accessors

        public Canvas Canvas
        {
            set { mCanvas = value; }
            get { return mCanvas; }
        }

        public GridLayout Grid
        {
            set { mGridLayout = value; }
            get { return mGridLayout; }
        }

        #endregion

    }
}
