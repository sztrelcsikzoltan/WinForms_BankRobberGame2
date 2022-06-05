
namespace WinForms_BankRobberGame2
{
    partial class DatabaseForm
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
            this.dataGridView_values = new System.Windows.Forms.DataGridView();
            this.label_message = new System.Windows.Forms.Label();
            this.button_deleteRow = new System.Windows.Forms.Button();
            this.button_allResults = new System.Windows.Forms.Button();
            this.button_ownResults = new System.Windows.Forms.Button();
            this.button_winningResults = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_values)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_values
            // 
            this.dataGridView_values.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_values.Location = new System.Drawing.Point(37, 137);
            this.dataGridView_values.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_values.Name = "dataGridView_values";
            this.dataGridView_values.RowHeadersWidth = 51;
            this.dataGridView_values.Size = new System.Drawing.Size(832, 283);
            this.dataGridView_values.TabIndex = 11;
            this.dataGridView_values.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_values_CellClick);
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(35, 442);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(65, 17);
            this.label_message.TabIndex = 13;
            this.label_message.Text = "Message";
            // 
            // button_deleteRow
            // 
            this.button_deleteRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_deleteRow.Location = new System.Drawing.Point(671, 69);
            this.button_deleteRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_deleteRow.Name = "button_deleteRow";
            this.button_deleteRow.Size = new System.Drawing.Size(184, 38);
            this.button_deleteRow.TabIndex = 14;
            this.button_deleteRow.Text = "Delete row(s)";
            this.button_deleteRow.UseVisualStyleBackColor = true;
            this.button_deleteRow.Click += new System.EventHandler(this.button_deleteRow_Click);
            // 
            // button_allResults
            // 
            this.button_allResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_allResults.Location = new System.Drawing.Point(37, 69);
            this.button_allResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_allResults.Name = "button_allResults";
            this.button_allResults.Size = new System.Drawing.Size(193, 38);
            this.button_allResults.TabIndex = 15;
            this.button_allResults.Text = "Total result";
            this.button_allResults.UseVisualStyleBackColor = true;
            this.button_allResults.Click += new System.EventHandler(this.button_allResults_Click);
            // 
            // button_ownResults
            // 
            this.button_ownResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_ownResults.Location = new System.Drawing.Point(236, 69);
            this.button_ownResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ownResults.Name = "button_ownResults";
            this.button_ownResults.Size = new System.Drawing.Size(197, 38);
            this.button_ownResults.TabIndex = 16;
            this.button_ownResults.Text = "Own results";
            this.button_ownResults.UseVisualStyleBackColor = true;
            this.button_ownResults.Click += new System.EventHandler(this.button_ownResults_Click);
            // 
            // button_winningResults
            // 
            this.button_winningResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_winningResults.Location = new System.Drawing.Point(439, 69);
            this.button_winningResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_winningResults.Name = "button_winningResults";
            this.button_winningResults.Size = new System.Drawing.Size(228, 38);
            this.button_winningResults.TabIndex = 17;
            this.button_winningResults.Text = "Winning results";
            this.button_winningResults.UseVisualStyleBackColor = true;
            this.button_winningResults.Click += new System.EventHandler(this.button_winningResults_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::WinForms_BankRobberGame2.Properties.Resources._100_dollar;
            this.pictureBox1.Location = new System.Drawing.Point(181, 497);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 727);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_winningResults);
            this.Controls.Add(this.button_ownResults);
            this.Controls.Add(this.button_allResults);
            this.Controls.Add(this.button_deleteRow);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.dataGridView_values);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_values)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_values;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Button button_deleteRow;
        private System.Windows.Forms.Button button_allResults;
        private System.Windows.Forms.Button button_ownResults;
        private System.Windows.Forms.Button button_winningResults;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

