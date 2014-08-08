namespace OmsiScriptExampler {
    partial class Form1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bttnRun = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusStep = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkPause = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(165, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(922, 479);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.WordWrap = false;
            // 
            // bttnRun
            // 
            this.bttnRun.Location = new System.Drawing.Point(12, 34);
            this.bttnRun.Name = "bttnRun";
            this.bttnRun.Size = new System.Drawing.Size(147, 23);
            this.bttnRun.TabIndex = 1;
            this.bttnRun.Text = "&Ausführen";
            this.bttnRun.UseVisualStyleBackColor = true;
            this.bttnRun.Click += new System.EventHandler(this.bttnRun_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusStep});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1112, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusStep
            // 
            this.lblStatusStep.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusStep.Name = "lblStatusStep";
            this.lblStatusStep.Size = new System.Drawing.Size(40, 17);
            this.lblStatusStep.Text = "Bereit.";
            // 
            // chkPause
            // 
            this.chkPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPause.Location = new System.Drawing.Point(12, 63);
            this.chkPause.Name = "chkPause";
            this.chkPause.Size = new System.Drawing.Size(147, 24);
            this.chkPause.TabIndex = 8;
            this.chkPause.Text = "&Pause";
            this.chkPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPause.UseVisualStyleBackColor = true;
            this.chkPause.CheckedChanged += new System.EventHandler(this.chkPause_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(12, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 16);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Schritt f. Schritt";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 520);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkPause);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bttnRun);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Script-Debugger";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bttnRun;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusStep;
        private System.Windows.Forms.CheckBox chkPause;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

