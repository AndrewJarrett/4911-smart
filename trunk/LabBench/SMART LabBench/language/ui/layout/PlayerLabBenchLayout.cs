using LabBench.language.ui.layout;
using LabBench.language.graph;
using LabBench.language.ui;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LabBench.language.ui.layout
{
    /// <summary>
    /// layout for the Player LabBench
    /// </summary>
    class PlayerLabBenchLayout
    {
        private Canvas mCanvas;
        private PlayerGridLayout mGridLayout;
        private List<Toolbox> mToolboxes;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mReferenceCanvas">Canvas to draw all UI elements to</param>
        public PlayerLabBenchLayout(Canvas mReferenceCanvas)
        {
            mCanvas = mReferenceCanvas;
        }

        /// <summary>
        /// create the layout for the Player UI
        /// </summary>
        public void createLayout()
        {
            mGridLayout = new PlayerGridLayout();
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

        public PlayerGridLayout Grid
        {
            set { mGridLayout = value; }
            get { return mGridLayout; }
        }

        #endregion

    }
}
