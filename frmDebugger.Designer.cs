namespace OmsiScriptExampler {
    partial class frmDebugger {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTree = new System.Windows.Forms.TabPage();
            this.listTokens = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listVariables = new System.Windows.Forms.ListBox();
            this.tabStack = new System.Windows.Forms.TabPage();
            this.stringStackInspector1 = new OmsiScriptExampler.StringStackInspector();
            this.floatStackInspector1 = new OmsiScriptExampler.FloatStackInspector();
            this.tabSnapshotHistory = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabTrigger = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.comboTriggers = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabTree.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabStack.SuspendLayout();
            this.tabSnapshotHistory.SuspendLayout();
            this.tabTrigger.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTree);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabStack);
            this.tabControl1.Controls.Add(this.tabSnapshotHistory);
            this.tabControl1.Controls.Add(this.tabTrigger);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 528);
            this.tabControl1.TabIndex = 7;
            // 
            // tabTree
            // 
            this.tabTree.Controls.Add(this.listTokens);
            this.tabTree.Location = new System.Drawing.Point(4, 22);
            this.tabTree.Name = "tabTree";
            this.tabTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabTree.Size = new System.Drawing.Size(832, 502);
            this.tabTree.TabIndex = 0;
            this.tabTree.Text = "Abfolge-Baum";
            this.tabTree.UseVisualStyleBackColor = true;
            // 
            // listTokens
            // 
            this.listTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTokens.FormattingEnabled = true;
            this.listTokens.Location = new System.Drawing.Point(3, 3);
            this.listTokens.Name = "listTokens";
            this.listTokens.Size = new System.Drawing.Size(826, 496);
            this.listTokens.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listVariables);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(832, 502);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Variablen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listVariables
            // 
            this.listVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVariables.FormattingEnabled = true;
            this.listVariables.Location = new System.Drawing.Point(3, 3);
            this.listVariables.Name = "listVariables";
            this.listVariables.Size = new System.Drawing.Size(826, 496);
            this.listVariables.TabIndex = 5;
            // 
            // tabStack
            // 
            this.tabStack.Controls.Add(this.stringStackInspector1);
            this.tabStack.Controls.Add(this.floatStackInspector1);
            this.tabStack.Location = new System.Drawing.Point(4, 22);
            this.tabStack.Name = "tabStack";
            this.tabStack.Padding = new System.Windows.Forms.Padding(3);
            this.tabStack.Size = new System.Drawing.Size(832, 502);
            this.tabStack.TabIndex = 2;
            this.tabStack.Text = "abstractStack";
            this.tabStack.UseVisualStyleBackColor = true;
            // 
            // stringStackInspector1
            // 
            this.stringStackInspector1.Location = new System.Drawing.Point(7, 88);
            this.stringStackInspector1.Name = "stringStackInspector1";
            this.stringStackInspector1.Size = new System.Drawing.Size(442, 83);
            this.stringStackInspector1.AbstractStack = null;
            this.stringStackInspector1.TabIndex = 5;
            this.stringStackInspector1.Text = "stringStackInspector1";
            // 
            // floatStackInspector1
            // 
            this.floatStackInspector1.Location = new System.Drawing.Point(6, 7);
            this.floatStackInspector1.Name = "floatStackInspector1";
            this.floatStackInspector1.Size = new System.Drawing.Size(498, 74);
            this.floatStackInspector1.AbstractStack = null;
            this.floatStackInspector1.TabIndex = 4;
            this.floatStackInspector1.Text = "floatStackInspector1";
            // 
            // tabSnapshotHistory
            // 
            this.tabSnapshotHistory.Controls.Add(this.richTextBox2);
            this.tabSnapshotHistory.Location = new System.Drawing.Point(4, 22);
            this.tabSnapshotHistory.Name = "tabSnapshotHistory";
            this.tabSnapshotHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabSnapshotHistory.Size = new System.Drawing.Size(832, 502);
            this.tabSnapshotHistory.TabIndex = 3;
            this.tabSnapshotHistory.Text = "Snapshot-History";
            this.tabSnapshotHistory.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(826, 496);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            this.richTextBox2.WordWrap = false;
            // 
            // tabTrigger
            // 
            this.tabTrigger.Controls.Add(this.button1);
            this.tabTrigger.Controls.Add(this.comboTriggers);
            this.tabTrigger.Location = new System.Drawing.Point(4, 22);
            this.tabTrigger.Name = "tabTrigger";
            this.tabTrigger.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrigger.Size = new System.Drawing.Size(832, 502);
            this.tabTrigger.TabIndex = 4;
            this.tabTrigger.Text = "Trigger";
            this.tabTrigger.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Trigger!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboTriggers
            // 
            this.comboTriggers.FormattingEnabled = true;
            this.comboTriggers.Location = new System.Drawing.Point(3, 6);
            this.comboTriggers.Name = "comboTriggers";
            this.comboTriggers.Size = new System.Drawing.Size(446, 21);
            this.comboTriggers.TabIndex = 0;
            // 
            // frmDebugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 528);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmDebugger";
            this.Text = "frmDebugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDebugger_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabTree.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabStack.ResumeLayout(false);
            this.tabSnapshotHistory.ResumeLayout(false);
            this.tabTrigger.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabTree;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabStack;
        private System.Windows.Forms.TabPage tabSnapshotHistory;
        private System.Windows.Forms.TabPage tabTrigger;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboTriggers;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.ListBox listTokens;
        public System.Windows.Forms.ListBox listVariables;
        public StringStackInspector stringStackInspector1;
        public FloatStackInspector floatStackInspector1;
        public System.Windows.Forms.RichTextBox richTextBox2;

    }
}