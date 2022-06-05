
namespace WinForms_BankRobberGame2
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Button_save = new System.Windows.Forms.Button();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WallColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nevToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_name = new System.Windows.Forms.ToolStripTextBox();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_speedRobber = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_speedGuard = new System.Windows.Forms.ToolStripTextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label_speed = new System.Windows.Forms.Label();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.label_settings = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_colors = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "Document";
            this.openFileDialog1.Filter = "Text documents (.txt)|*.txt|All files|*.*";
            // 
            // Button_save
            // 
            this.Button_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button_save.BackColor = System.Drawing.Color.Chartreuse;
            this.Button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Button_save.Location = new System.Drawing.Point(304, 2);
            this.Button_save.Margin = new System.Windows.Forms.Padding(2);
            this.Button_save.Name = "Button_save";
            this.Button_save.Size = new System.Drawing.Size(76, 27);
            this.Button_save.TabIndex = 3;
            this.Button_save.Text = "Save";
            this.Button_save.UseVisualStyleBackColor = false;
            this.Button_save.Click += new System.EventHandler(this.Button_save_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.AutoSize = false;
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackgroundColorToolStripMenuItem,
            this.WallColorToolStripMenuItem});
            this.colorsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(80, 27);
            this.colorsToolStripMenuItem.Text = "Colors";
            // 
            // BackgroundColorToolStripMenuItem
            // 
            this.BackgroundColorToolStripMenuItem.Name = "BackgroundColorToolStripMenuItem";
            this.BackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.BackgroundColorToolStripMenuItem.Text = "background color";
            this.BackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.BackgroundColorToolStripMenuItem_Click);
            // 
            // WallColorToolStripMenuItem
            // 
            this.WallColorToolStripMenuItem.Name = "WallColorToolStripMenuItem";
            this.WallColorToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.WallColorToolStripMenuItem.Text = "wall color";
            this.WallColorToolStripMenuItem.Click += new System.EventHandler(this.WallColorToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nevToolStripMenuItem1,
            this.speedToolStripMenuItem,
            this.colorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(684, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nevToolStripMenuItem1
            // 
            this.nevToolStripMenuItem1.AutoSize = false;
            this.nevToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_name});
            this.nevToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.nevToolStripMenuItem1.Name = "nevToolStripMenuItem1";
            this.nevToolStripMenuItem1.Size = new System.Drawing.Size(122, 27);
            this.nevToolStripMenuItem1.Text = "Name";
            this.nevToolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripTextBox_name
            // 
            this.toolStripTextBox_name.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStripTextBox_name.Name = "toolStripTextBox_name";
            this.toolStripTextBox_name.Size = new System.Drawing.Size(100, 27);
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.AutoSize = false;
            this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.speedToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(80, 27);
            this.speedToolStripMenuItem.Text = "Speed";
            this.speedToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_speedRobber});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 24);
            this.toolStripMenuItem1.Text = "robber";
            // 
            // toolStripTextBox_speedRobber
            // 
            this.toolStripTextBox_speedRobber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStripTextBox_speedRobber.Name = "toolStripTextBox_speedRobber";
            this.toolStripTextBox_speedRobber.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_speedGuard});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(114, 24);
            this.toolStripMenuItem2.Text = "guard";
            // 
            // toolStripTextBox_speedGuard
            // 
            this.toolStripTextBox_speedGuard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStripTextBox_speedGuard.Name = "toolStripTextBox_speedGuard";
            this.toolStripTextBox_speedGuard.Size = new System.Drawing.Size(100, 27);
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.BackColor = System.Drawing.SystemColors.Control;
            this.label_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_speed.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_speed.Location = new System.Drawing.Point(129, 28);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(94, 15);
            this.label_speed.TabIndex = 4;
            this.label_speed.Text = "label_speed";
            // 
            // label_settings
            // 
            this.label_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_settings.Location = new System.Drawing.Point(17, 80);
            this.label_settings.Name = "label_settings";
            this.label_settings.Size = new System.Drawing.Size(655, 275);
            this.label_settings.TabIndex = 5;
            this.label_settings.Text = resources.GetString("label_settings.Text");
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.SystemColors.Control;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_name.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_name.Location = new System.Drawing.Point(7, 28);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(60, 15);
            this.label_name.TabIndex = 6;
            this.label_name.Text = "label_nev";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::WinForms_BankRobberGame2.Properties.Resources.bank_image;
            this.pictureBox1.Location = new System.Drawing.Point(20, 309);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(652, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label_colors
            // 
            this.label_colors.AutoSize = true;
            this.label_colors.BackColor = System.Drawing.SystemColors.Control;
            this.label_colors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_colors.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_colors.Location = new System.Drawing.Point(222, 28);
            this.label_colors.Name = "label_colors";
            this.label_colors.Size = new System.Drawing.Size(76, 15);
            this.label_colors.TabIndex = 7;
            this.label_colors.Text = "label_colors";
            // 
            // settingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 591);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_colors);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_settings);
            this.Controls.Add(this.label_speed);
            this.Controls.Add(this.Button_save);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "settingsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settingsPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Button_save;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem WallColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.ToolStripMenuItem BackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nevToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_name;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_speedRobber;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_speedGuard;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Label label_settings;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_colors;
    }
}

