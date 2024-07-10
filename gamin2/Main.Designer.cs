namespace gamin2
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSDDM_Main = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDDMI_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Screen = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDDM_Main});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSDDM_Main
            // 
            this.TSDDM_Main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDDMI_Exit});
            this.TSDDM_Main.Name = "TSDDM_Main";
            this.TSDDM_Main.Size = new System.Drawing.Size(37, 20);
            this.TSDDM_Main.Text = "File";
            // 
            // TSDDMI_Exit
            // 
            this.TSDDMI_Exit.Name = "TSDDMI_Exit";
            this.TSDDMI_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.TSDDMI_Exit.Size = new System.Drawing.Size(180, 22);
            this.TSDDMI_Exit.Text = "Exit";
            this.TSDDMI_Exit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Screen
            // 
            this.Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Screen.Location = new System.Drawing.Point(0, 24);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(800, 426);
            this.Screen.TabIndex = 2;
            this.Screen.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Screen);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSDDM_Main;
        private System.Windows.Forms.ToolStripMenuItem TSDDMI_Exit;
        private System.Windows.Forms.PictureBox Screen;
    }
}

