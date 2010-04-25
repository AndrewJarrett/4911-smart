using LabBench.language.ui.layout;
using LabBench.language.graph;
using LabBench.language.ui;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LabBench.language.ui.layout
{
    class LabBenchLayout
    {
        private Canvas mCanvas;
        private GridLayout mGridLayout;
        private List<Toolbox> mToolboxes;

        public LabBenchLayout(Canvas mReferenceCanvas)
        {
            mCanvas = mReferenceCanvas;
        }

        public void createLayout()
        {
            mGridLayout = new GridLayout();
            mToolboxes = new List<Toolbox>();
        }

        public void addToolbox(int x, int y)
        {
            mToolboxes.Add(new Toolbox(mCanvas, x, y));
        }

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
