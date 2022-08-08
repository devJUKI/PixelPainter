namespace PaintPainter
{
    partial class Form1
    {
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
            this.selectPaletteBtn = new System.Windows.Forms.Button();
            this.selectImageBtn = new System.Windows.Forms.Button();
            this.selectTargetAreaBtn = new System.Windows.Forms.Button();
            this.drawBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectPaletteBtn
            // 
            this.selectPaletteBtn.Location = new System.Drawing.Point(12, 12);
            this.selectPaletteBtn.Name = "selectPaletteBtn";
            this.selectPaletteBtn.Size = new System.Drawing.Size(150, 40);
            this.selectPaletteBtn.TabIndex = 0;
            this.selectPaletteBtn.Text = "Select palette";
            this.selectPaletteBtn.UseVisualStyleBackColor = true;
            this.selectPaletteBtn.Click += new System.EventHandler(this.selectPaletteBtn_Click);
            // 
            // selectImageBtn
            // 
            this.selectImageBtn.Location = new System.Drawing.Point(12, 58);
            this.selectImageBtn.Name = "selectImageBtn";
            this.selectImageBtn.Size = new System.Drawing.Size(150, 40);
            this.selectImageBtn.TabIndex = 1;
            this.selectImageBtn.Text = "Select image";
            this.selectImageBtn.UseVisualStyleBackColor = true;
            this.selectImageBtn.Click += new System.EventHandler(this.selectImageBtn_Click);
            // 
            // selectTargetAreaBtn
            // 
            this.selectTargetAreaBtn.Location = new System.Drawing.Point(12, 104);
            this.selectTargetAreaBtn.Name = "selectTargetAreaBtn";
            this.selectTargetAreaBtn.Size = new System.Drawing.Size(150, 40);
            this.selectTargetAreaBtn.TabIndex = 2;
            this.selectTargetAreaBtn.Text = "Select target area";
            this.selectTargetAreaBtn.UseVisualStyleBackColor = true;
            this.selectTargetAreaBtn.Click += new System.EventHandler(this.selectTargetArea_Click);
            // 
            // drawBtn
            // 
            this.drawBtn.Location = new System.Drawing.Point(12, 150);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(150, 40);
            this.drawBtn.TabIndex = 4;
            this.drawBtn.Text = "Draw";
            this.drawBtn.UseVisualStyleBackColor = true;
            this.drawBtn.Click += new System.EventHandler(this.draw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 200);
            this.Controls.Add(this.drawBtn);
            this.Controls.Add(this.selectTargetAreaBtn);
            this.Controls.Add(this.selectImageBtn);
            this.Controls.Add(this.selectPaletteBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint Painter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectPaletteBtn;
        private System.Windows.Forms.Button selectImageBtn;
        private System.Windows.Forms.Button selectTargetAreaBtn;
        private System.Windows.Forms.Button drawBtn;
    }
}

