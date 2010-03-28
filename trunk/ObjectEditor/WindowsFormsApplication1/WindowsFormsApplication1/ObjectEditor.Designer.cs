namespace WindowsFormsApplication1
{
    partial class mainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FileChoser = new System.Windows.Forms.Button();
            this.objectBrowser = new System.Windows.Forms.TreeView();
            this.objectModifier = new System.Windows.Forms.Panel();
            this.txtVoltage = new System.Windows.Forms.TextBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.sldVoltage = new System.Windows.Forms.TrackBar();
            this.chkMagnetic = new System.Windows.Forms.CheckBox();
            this.chkFerrous = new System.Windows.Forms.CheckBox();
            this.chkConductive = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.imageChooser = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureSelector = new System.Windows.Forms.OpenFileDialog();
            this.createNewCategory = new System.Windows.Forms.Button();
            this.createNewObject = new System.Windows.Forms.Button();
            this.saveObject = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.objectModifier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sldVoltage)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.createNewObject);
            this.splitContainer1.Panel1.Controls.Add(this.createNewCategory);
            this.splitContainer1.Panel1.Controls.Add(this.FileChoser);
            this.splitContainer1.Panel1.Controls.Add(this.objectBrowser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.objectModifier);
            this.splitContainer1.Size = new System.Drawing.Size(424, 395);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.TabIndex = 0;
            // 
            // FileChoser
            // 
            this.FileChoser.Location = new System.Drawing.Point(3, 6);
            this.FileChoser.Name = "FileChoser";
            this.FileChoser.Size = new System.Drawing.Size(198, 26);
            this.FileChoser.TabIndex = 1;
            this.FileChoser.Text = "Choose Object Directory";
            this.FileChoser.UseVisualStyleBackColor = true;
            this.FileChoser.Click += new System.EventHandler(this.FileChoser_Click);
            // 
            // objectBrowser
            // 
            this.objectBrowser.Location = new System.Drawing.Point(3, 32);
            this.objectBrowser.Name = "objectBrowser";
            this.objectBrowser.Size = new System.Drawing.Size(198, 326);
            this.objectBrowser.TabIndex = 0;
            this.objectBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.objectBrowser_AfterSelect);
            // 
            // objectModifier
            // 
            this.objectModifier.Controls.Add(this.saveObject);
            this.objectModifier.Controls.Add(this.txtVoltage);
            this.objectModifier.Controls.Add(this.lblVoltage);
            this.objectModifier.Controls.Add(this.sldVoltage);
            this.objectModifier.Controls.Add(this.chkMagnetic);
            this.objectModifier.Controls.Add(this.chkFerrous);
            this.objectModifier.Controls.Add(this.chkConductive);
            this.objectModifier.Controls.Add(this.lblName);
            this.objectModifier.Controls.Add(this.txtName);
            this.objectModifier.Controls.Add(this.imageChooser);
            this.objectModifier.Location = new System.Drawing.Point(3, 6);
            this.objectModifier.Name = "objectModifier";
            this.objectModifier.Size = new System.Drawing.Size(215, 389);
            this.objectModifier.TabIndex = 1;
            this.objectModifier.Visible = false;
            // 
            // txtVoltage
            // 
            this.txtVoltage.Location = new System.Drawing.Point(17, 293);
            this.txtVoltage.Name = "txtVoltage";
            this.txtVoltage.Size = new System.Drawing.Size(43, 20);
            this.txtVoltage.TabIndex = 8;
            this.txtVoltage.TextChanged += new System.EventHandler(this.txtVoltage_TextChanged);
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(14, 277);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(46, 13);
            this.lblVoltage.TabIndex = 7;
            this.lblVoltage.Text = "Voltage:";
            // 
            // sldVoltage
            // 
            this.sldVoltage.Location = new System.Drawing.Point(66, 277);
            this.sldVoltage.Maximum = 200;
            this.sldVoltage.Name = "sldVoltage";
            this.sldVoltage.Size = new System.Drawing.Size(137, 45);
            this.sldVoltage.TabIndex = 6;
            this.sldVoltage.TickFrequency = 20;
            this.sldVoltage.Scroll += new System.EventHandler(this.sldVoltage_Scroll);
            // 
            // chkMagnetic
            // 
            this.chkMagnetic.AutoSize = true;
            this.chkMagnetic.Location = new System.Drawing.Point(25, 236);
            this.chkMagnetic.Name = "chkMagnetic";
            this.chkMagnetic.Size = new System.Drawing.Size(70, 17);
            this.chkMagnetic.TabIndex = 5;
            this.chkMagnetic.Text = "Magnetic";
            this.chkMagnetic.UseVisualStyleBackColor = true;
            // 
            // chkFerrous
            // 
            this.chkFerrous.AutoSize = true;
            this.chkFerrous.Location = new System.Drawing.Point(25, 213);
            this.chkFerrous.Name = "chkFerrous";
            this.chkFerrous.Size = new System.Drawing.Size(61, 17);
            this.chkFerrous.TabIndex = 4;
            this.chkFerrous.Text = "Ferrous";
            this.chkFerrous.UseVisualStyleBackColor = true;
            // 
            // chkConductive
            // 
            this.chkConductive.AutoSize = true;
            this.chkConductive.Location = new System.Drawing.Point(25, 190);
            this.chkConductive.Name = "chkConductive";
            this.chkConductive.Size = new System.Drawing.Size(80, 17);
            this.chkConductive.TabIndex = 3;
            this.chkConductive.Text = "Conductive";
            this.chkConductive.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(22, 167);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 164);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 20);
            this.txtName.TabIndex = 1;
            // 
            // imageChooser
            // 
            this.imageChooser.Location = new System.Drawing.Point(15, 6);
            this.imageChooser.Name = "imageChooser";
            this.imageChooser.Size = new System.Drawing.Size(188, 139);
            this.imageChooser.TabIndex = 0;
            this.imageChooser.Text = "Choose Image";
            this.imageChooser.UseVisualStyleBackColor = true;
            this.imageChooser.Click += new System.EventHandler(this.imageChooser_Click);
            // 
            // pictureSelector
            // 
            this.pictureSelector.Filter = "Bitmap images|*.bmp";
            this.pictureSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.pictureSelector_FileOk);
            // 
            // createNewCategory
            // 
            this.createNewCategory.Location = new System.Drawing.Point(0, 360);
            this.createNewCategory.Name = "createNewCategory";
            this.createNewCategory.Size = new System.Drawing.Size(103, 35);
            this.createNewCategory.TabIndex = 2;
            this.createNewCategory.Text = "New Category";
            this.createNewCategory.UseVisualStyleBackColor = true;
            this.createNewCategory.Visible = false;
            this.createNewCategory.Click += new System.EventHandler(this.createNewCategory_Click);
            // 
            // createNewObject
            // 
            this.createNewObject.Location = new System.Drawing.Point(103, 360);
            this.createNewObject.Name = "createNewObject";
            this.createNewObject.Size = new System.Drawing.Size(98, 35);
            this.createNewObject.TabIndex = 3;
            this.createNewObject.Text = "New Object";
            this.createNewObject.UseVisualStyleBackColor = true;
            this.createNewObject.Visible = false;
            this.createNewObject.Click += new System.EventHandler(this.createNewObject_Click);
            // 
            // saveObject
            // 
            this.saveObject.Location = new System.Drawing.Point(15, 328);
            this.saveObject.Name = "saveObject";
            this.saveObject.Size = new System.Drawing.Size(187, 49);
            this.saveObject.TabIndex = 9;
            this.saveObject.Text = "Save Object";
            this.saveObject.UseVisualStyleBackColor = true;
            this.saveObject.Click += new System.EventHandler(this.saveObject_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 395);
            this.Controls.Add(this.splitContainer1);
            this.Name = "mainWindow";
            this.Text = "Object Creator/Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.objectModifier.ResumeLayout(false);
            this.objectModifier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sldVoltage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView objectBrowser;
        private System.Windows.Forms.Button FileChoser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button imageChooser;
        private System.Windows.Forms.Panel objectModifier;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkMagnetic;
        private System.Windows.Forms.CheckBox chkFerrous;
        private System.Windows.Forms.CheckBox chkConductive;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TrackBar sldVoltage;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.OpenFileDialog pictureSelector;
        private System.Windows.Forms.Button createNewObject;
        private System.Windows.Forms.Button createNewCategory;
        private System.Windows.Forms.Button saveObject;
    }
}

