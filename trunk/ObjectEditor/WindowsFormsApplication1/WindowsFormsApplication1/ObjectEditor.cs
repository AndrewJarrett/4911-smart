using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void FileChoser_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                // Initial Node "Categories"
                TreeNode categoryList = new TreeNode("Categories");
                this.objectBrowser.Nodes.Add(categoryList);

                foreach (string catDirectory in System.IO.Directory.GetDirectories(folderBrowser.SelectedPath))
                {
                    // Category Nodes
                    TreeNode newCategory = new TreeNode(catDirectory.Split('\\').Last());
                    categoryList.Nodes.Add(newCategory);

                    // Object Nodes
                    foreach (string objLocation in System.IO.Directory.GetFiles(catDirectory))
                    {
                        TreeNode newObject = new TreeNode(objLocation.Split('\\').Last().Split('.').First());
                        newObject.Tag = objLocation;
                        newCategory.Nodes.Add(newObject);
                    }
                }

                // Expand Category List
                categoryList.Expand();
            }

        }

        private void sldVoltage_Scroll(object sender, EventArgs e)
        {
            txtVoltage.Text = sldVoltage.Value.ToString();
        }

        private void txtVoltage_TextChanged(object sender, EventArgs e)
        {
            int voltValue = Math.Min(System.Convert.ToInt32(txtVoltage.Text), 200);
            sldVoltage.Value = voltValue;
            txtVoltage.Text = voltValue.ToString();
        }

        private void objectBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (objectBrowser.SelectedNode.Tag != null)
            {
                objectModifier.Visible = true;
            }
            else
            {
                objectModifier.Visible = false;
            }
        }
    }
}
