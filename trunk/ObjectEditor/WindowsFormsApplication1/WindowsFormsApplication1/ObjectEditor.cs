using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace WindowsFormsApplication1
{
    public partial class mainWindow : Form
    {
        string objectDirectory, currentCategory, currentObject;

        public mainWindow()
        {
            InitializeComponent();
        }

        private void FileChoser_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                // expose new category and object buttons
                createNewCategory.Visible = true;
                createNewObject.Visible = true;

                objectDirectory = folderBrowser.SelectedPath;

                refreshTreeView();
            }

        }

        private void refreshTreeView()
        {
            // clear list
            this.objectBrowser.Nodes.Clear();

            // Initial Node "Categories"
            TreeNode categoryList = new TreeNode("Categories");
            this.objectBrowser.Nodes.Add(categoryList);

            foreach (string catDirectory in System.IO.Directory.GetDirectories(objectDirectory))
            {
                // Category Nodes
                TreeNode newCategory = new TreeNode(catDirectory.Split('\\').Last());

                // ignore subversion files
                if (newCategory.Text != ".svn")
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

        private void sldVoltage_Scroll(object sender, EventArgs e)
        {
            txtVoltage.Text = sldVoltage.Value.ToString();
        }

        private void txtVoltage_TextChanged(object sender, EventArgs e)
        {
            int voltValue = 0;
            try { voltValue = Math.Min(System.Convert.ToInt32(txtVoltage.Text), 200); }
            catch (Exception exception) {}
            sldVoltage.Value = voltValue;
            txtVoltage.Text = voltValue.ToString();
        }

        private void objectBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (objectBrowser.SelectedNode.Tag != null)
            {
                currentCategory = objectBrowser.SelectedNode.Parent.Text;
                currentObject = objectBrowser.SelectedNode.Text;
                objectModifier.Visible = true;
                loadCurrentObject();
            }
            else
            {
                if (objectBrowser.SelectedNode.Parent.Text == "Categories")
                    currentCategory = objectBrowser.SelectedNode.Text;
                objectModifier.Visible = false;
            }
        }

        private void imageChooser_Click(object sender, EventArgs e)
        {
            if (pictureSelector.ShowDialog() == DialogResult.OK) {
                imageChooser.Image = new Bitmap(pictureSelector.FileName);
            }
        }

        private void pictureSelector_FileOk(object sender, CancelEventArgs e)
        {

        }

        // Serializes currently selected object to "Root directory" / "category" / "objectname" .bin
        private void saveCurrentObject()
        {
            string filePath = objectDirectory + "/" + currentCategory + "/" + currentObject + ".bin";

            SerializableItem SO = new SerializableItem();
            SO.conductive = chkConductive.Checked;
            SO.magnetic = chkMagnetic.Checked;
            SO.ferrous = chkFerrous.Checked;
            SO.charge = sldVoltage.Value;
            SO.icon = imageChooser.Image;
            SO.name = txtName.Text;

            Stream stream = File.Open(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, SO);
            stream.Close();
        }

        // Reads in currently selected object at "Root directory" / "category" / "objectname" .bin
        // sets gui compontents with values from file
        private void loadCurrentObject()
        {
            string filePath = objectDirectory + "/" + currentCategory + "/" + currentObject + ".bin";
            Stream stream = File.Open(filePath, FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();
            SerializableItem SO = (SerializableItem)bf.Deserialize(stream);

            chkConductive.Checked = SO.conductive;
            chkMagnetic.Checked = SO.magnetic;
            chkFerrous.Checked = SO.ferrous;
            sldVoltage.Value = SO.charge;
            imageChooser.Image = SO.icon;
            txtName.Text = SO.name;

            stream.Close();
        }

        private void saveObject_Click(object sender, EventArgs e)
        {
            saveCurrentObject();
        }

        // Creates a new object category directory
        private void createNewCategory_Click(object sender, EventArgs e)
        {
            string catName = Microsoft.VisualBasic.Interaction.InputBox("Enter the category name", "New Category", "Default", 0, 0);
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(objectDirectory, catName));

            refreshTreeView();
        }

        private void createNewObject_Click(object sender, EventArgs e)
        {
            string objName = Microsoft.VisualBasic.Interaction.InputBox("Enter the object name", "New Object", "Default", 0, 0);
            string filePath = objectDirectory + "/" + currentCategory + "/" + objName + ".bin";
            SerializableItem SO = new SerializableItem();

            SO.name = objName;
            Stream stream = File.Open(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, SO);
            stream.Close();

            refreshTreeView();
        }

        [Serializable]
        public class SerializableItem
        {
            public bool conductive, magnetic, ferrous;
            public int charge;
            public Image icon;
            public string name;

            public SerializableItem()
            {
                conductive = false;
                magnetic = false;
                ferrous = false;
                charge = 0;
            }
        }
    }
}
