namespace TinyMapEngine
{
    partial class GuiEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuiEditor));
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.propsGui = new System.Windows.Forms.PropertyGrid();
            this.guiRender = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.AutoScroll = true;
            this.mainSplit.Panel1.Controls.Add(this.guiRender);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.propsGui);
            this.mainSplit.Size = new System.Drawing.Size(737, 485);
            this.mainSplit.SplitterDistance = 530;
            this.mainSplit.TabIndex = 0;
            // 
            // propsGui
            // 
            this.propsGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propsGui.Location = new System.Drawing.Point(0, 0);
            this.propsGui.Name = "propsGui";
            this.propsGui.Size = new System.Drawing.Size(203, 485);
            this.propsGui.TabIndex = 0;
            this.propsGui.ToolbarVisible = false;
            // 
            // guiRender
            // 
            this.guiRender.Location = new System.Drawing.Point(0, 0);
            this.guiRender.Name = "guiRender";
            this.guiRender.Size = new System.Drawing.Size(1280, 720);
            this.guiRender.TabIndex = 0;
            // 
            // GuiEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 485);
            this.Controls.Add(this.mainSplit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GuiEditor";
            this.Text = "Gui Editor";
            this.Load += new System.EventHandler(this.GuiEditor_Load);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.PropertyGrid propsGui;
        private System.Windows.Forms.Panel guiRender;
    }
}