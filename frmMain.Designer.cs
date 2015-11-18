namespace WindowsFormsApplication1
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cbtAtivar = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAfter = new System.Windows.Forms.RadioButton();
            this.rbBefore = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbtAtivar
            // 
            this.cbtAtivar.AutoSize = true;
            this.cbtAtivar.Location = new System.Drawing.Point(6, 0);
            this.cbtAtivar.Name = "cbtAtivar";
            this.cbtAtivar.Size = new System.Drawing.Size(65, 17);
            this.cbtAtivar.TabIndex = 1;
            this.cbtAtivar.Text = "Activate";
            this.cbtAtivar.UseVisualStyleBackColor = true;
            this.cbtAtivar.CheckedChanged += new System.EventHandler(this.cbtAtivar_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAfter);
            this.groupBox1.Controls.Add(this.rbBefore);
            this.groupBox1.Controls.Add(this.cbtAtivar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 82);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rbAfter
            // 
            this.rbAfter.AutoSize = true;
            this.rbAfter.Location = new System.Drawing.Point(6, 46);
            this.rbAfter.Name = "rbAfter";
            this.rbAfter.Size = new System.Drawing.Size(187, 17);
            this.rbAfter.TabIndex = 3;
            this.rbAfter.TabStop = true;
            this.rbAfter.Text = "Insert special letter pressing x after";
            this.rbAfter.UseVisualStyleBackColor = true;
            this.rbAfter.CheckedChanged += new System.EventHandler(this.rbAfter_CheckedChanged);
            // 
            // rbBefore
            // 
            this.rbBefore.AutoSize = true;
            this.rbBefore.Checked = true;
            this.rbBefore.Location = new System.Drawing.Point(6, 23);
            this.rbBefore.Name = "rbBefore";
            this.rbBefore.Size = new System.Drawing.Size(196, 17);
            this.rbBefore.TabIndex = 2;
            this.rbBefore.TabStop = true;
            this.rbBefore.Text = "Insert special letter pressing x before";
            this.rbBefore.UseVisualStyleBackColor = true;
            this.rbBefore.CheckedChanged += new System.EventHandler(this.rbBefore_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 109);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Esperantilo - github.com/G4BB3R/Esperantilo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbtAtivar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAfter;
        private System.Windows.Forms.RadioButton rbBefore;
    }
}

