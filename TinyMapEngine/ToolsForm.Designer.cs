namespace TinyMapEngine
{
    partial class ToolsForm
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
            this.container = new System.Windows.Forms.FlowLayoutPanel();
            this.chkTilePaintTool = new System.Windows.Forms.RadioButton();
            this.chkEraserTool = new System.Windows.Forms.RadioButton();
            this.chkFillTool = new System.Windows.Forms.RadioButton();
            this.chkCreateEntityTool = new System.Windows.Forms.RadioButton();
            this.chkCollisionPainter = new System.Windows.Forms.RadioButton();
            this.chkLightPainter = new System.Windows.Forms.RadioButton();
            this.chkOpacityPainter = new System.Windows.Forms.RadioButton();
            this.chkMobSpawnPainter = new System.Windows.Forms.RadioButton();
            this.chkSelectObjectTool = new System.Windows.Forms.RadioButton();
            this.chkParticleTool = new System.Windows.Forms.RadioButton();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.chkTilePaintTool);
            this.container.Controls.Add(this.chkEraserTool);
            this.container.Controls.Add(this.chkFillTool);
            this.container.Controls.Add(this.chkCreateEntityTool);
            this.container.Controls.Add(this.chkCollisionPainter);
            this.container.Controls.Add(this.chkLightPainter);
            this.container.Controls.Add(this.chkOpacityPainter);
            this.container.Controls.Add(this.chkMobSpawnPainter);
            this.container.Controls.Add(this.chkParticleTool);
            this.container.Controls.Add(this.chkSelectObjectTool);
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(340, 35);
            this.container.TabIndex = 0;
            // 
            // chkTilePaintTool
            // 
            this.chkTilePaintTool.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTilePaintTool.AutoSize = true;
            this.chkTilePaintTool.FlatAppearance.BorderSize = 0;
            this.chkTilePaintTool.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkTilePaintTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTilePaintTool.Image = global::TinyMapEngine.Properties.Resources.stock_tool_clone;
            this.chkTilePaintTool.Location = new System.Drawing.Point(3, 3);
            this.chkTilePaintTool.Name = "chkTilePaintTool";
            this.chkTilePaintTool.Size = new System.Drawing.Size(28, 28);
            this.chkTilePaintTool.TabIndex = 0;
            this.chkTilePaintTool.UseVisualStyleBackColor = true;
            // 
            // chkEraserTool
            // 
            this.chkEraserTool.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkEraserTool.AutoSize = true;
            this.chkEraserTool.FlatAppearance.BorderSize = 0;
            this.chkEraserTool.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkEraserTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEraserTool.Image = global::TinyMapEngine.Properties.Resources.stock_tool_eraser;
            this.chkEraserTool.Location = new System.Drawing.Point(37, 3);
            this.chkEraserTool.Name = "chkEraserTool";
            this.chkEraserTool.Size = new System.Drawing.Size(28, 28);
            this.chkEraserTool.TabIndex = 1;
            this.chkEraserTool.UseVisualStyleBackColor = true;
            // 
            // chkFillTool
            // 
            this.chkFillTool.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFillTool.AutoSize = true;
            this.chkFillTool.FlatAppearance.BorderSize = 0;
            this.chkFillTool.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkFillTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFillTool.Image = global::TinyMapEngine.Properties.Resources.stock_tool_bucket_fill;
            this.chkFillTool.Location = new System.Drawing.Point(71, 3);
            this.chkFillTool.Name = "chkFillTool";
            this.chkFillTool.Size = new System.Drawing.Size(28, 28);
            this.chkFillTool.TabIndex = 2;
            this.chkFillTool.UseVisualStyleBackColor = true;
            // 
            // chkCreateEntityTool
            // 
            this.chkCreateEntityTool.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCreateEntityTool.AutoSize = true;
            this.chkCreateEntityTool.FlatAppearance.BorderSize = 0;
            this.chkCreateEntityTool.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkCreateEntityTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCreateEntityTool.Image = global::TinyMapEngine.Properties.Resources.tool_select_objects;
            this.chkCreateEntityTool.Location = new System.Drawing.Point(105, 3);
            this.chkCreateEntityTool.Name = "chkCreateEntityTool";
            this.chkCreateEntityTool.Size = new System.Drawing.Size(28, 28);
            this.chkCreateEntityTool.TabIndex = 3;
            this.chkCreateEntityTool.UseVisualStyleBackColor = true;
            // 
            // chkCollisionPainter
            // 
            this.chkCollisionPainter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCollisionPainter.AutoSize = true;
            this.chkCollisionPainter.FlatAppearance.BorderSize = 0;
            this.chkCollisionPainter.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkCollisionPainter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCollisionPainter.Image = global::TinyMapEngine.Properties.Resources.collision_painter;
            this.chkCollisionPainter.Location = new System.Drawing.Point(139, 3);
            this.chkCollisionPainter.Name = "chkCollisionPainter";
            this.chkCollisionPainter.Size = new System.Drawing.Size(28, 28);
            this.chkCollisionPainter.TabIndex = 5;
            this.chkCollisionPainter.UseVisualStyleBackColor = true;
            // 
            // chkLightPainter
            // 
            this.chkLightPainter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLightPainter.AutoSize = true;
            this.chkLightPainter.FlatAppearance.BorderSize = 0;
            this.chkLightPainter.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkLightPainter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLightPainter.Image = global::TinyMapEngine.Properties.Resources.light_painter;
            this.chkLightPainter.Location = new System.Drawing.Point(173, 3);
            this.chkLightPainter.Name = "chkLightPainter";
            this.chkLightPainter.Size = new System.Drawing.Size(28, 28);
            this.chkLightPainter.TabIndex = 6;
            this.chkLightPainter.UseVisualStyleBackColor = true;
            // 
            // chkOpacityPainter
            // 
            this.chkOpacityPainter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOpacityPainter.FlatAppearance.BorderSize = 0;
            this.chkOpacityPainter.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkOpacityPainter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOpacityPainter.Image = global::TinyMapEngine.Properties.Resources.visible;
            this.chkOpacityPainter.Location = new System.Drawing.Point(207, 3);
            this.chkOpacityPainter.Name = "chkOpacityPainter";
            this.chkOpacityPainter.Size = new System.Drawing.Size(28, 28);
            this.chkOpacityPainter.TabIndex = 7;
            this.chkOpacityPainter.UseVisualStyleBackColor = true;
            // 
            // chkMobSpawnPainter
            // 
            this.chkMobSpawnPainter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMobSpawnPainter.BackgroundImage = global::TinyMapEngine.Properties.Resources.rat;
            this.chkMobSpawnPainter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkMobSpawnPainter.FlatAppearance.BorderSize = 0;
            this.chkMobSpawnPainter.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkMobSpawnPainter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMobSpawnPainter.Location = new System.Drawing.Point(241, 3);
            this.chkMobSpawnPainter.Name = "chkMobSpawnPainter";
            this.chkMobSpawnPainter.Size = new System.Drawing.Size(28, 28);
            this.chkMobSpawnPainter.TabIndex = 8;
            this.chkMobSpawnPainter.UseVisualStyleBackColor = true;
            // 
            // chkSelectObjectTool
            // 
            this.chkSelectObjectTool.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSelectObjectTool.AutoSize = true;
            this.chkSelectObjectTool.FlatAppearance.BorderSize = 0;
            this.chkSelectObjectTool.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkSelectObjectTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSelectObjectTool.Image = global::TinyMapEngine.Properties.Resources.stock_tool_rect_select;
            this.chkSelectObjectTool.Location = new System.Drawing.Point(309, 3);
            this.chkSelectObjectTool.Name = "chkSelectObjectTool";
            this.chkSelectObjectTool.Size = new System.Drawing.Size(28, 28);
            this.chkSelectObjectTool.TabIndex = 4;
            this.chkSelectObjectTool.UseVisualStyleBackColor = true;
            // 
            // chkParticleTool
            // 
            this.chkParticleTool.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkParticleTool.BackgroundImage = global::TinyMapEngine.Properties.Resources.particle_icon;
            this.chkParticleTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkParticleTool.FlatAppearance.BorderSize = 0;
            this.chkParticleTool.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chkParticleTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkParticleTool.Location = new System.Drawing.Point(275, 3);
            this.chkParticleTool.Name = "chkParticleTool";
            this.chkParticleTool.Size = new System.Drawing.Size(28, 28);
            this.chkParticleTool.TabIndex = 9;
            this.chkParticleTool.UseVisualStyleBackColor = true;
            // 
            // ToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 35);
            this.ControlBox = false;
            this.Controls.Add(this.container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ToolsForm";
            this.Text = "Tools";
            this.Load += new System.EventHandler(this.ToolsForm_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel container;
        private System.Windows.Forms.RadioButton chkTilePaintTool;
        private System.Windows.Forms.RadioButton chkEraserTool;
        private System.Windows.Forms.RadioButton chkFillTool;
        private System.Windows.Forms.RadioButton chkCreateEntityTool;
        private System.Windows.Forms.RadioButton chkSelectObjectTool;
        private System.Windows.Forms.RadioButton chkCollisionPainter;
        private System.Windows.Forms.RadioButton chkLightPainter;
        private System.Windows.Forms.RadioButton chkOpacityPainter;
        private System.Windows.Forms.RadioButton chkMobSpawnPainter;
        private System.Windows.Forms.RadioButton chkParticleTool;
    }
}