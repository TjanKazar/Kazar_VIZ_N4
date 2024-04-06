namespace Kazar_VIZ_N4
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            browse_button = new Button();
            save_button = new Button();
            label1 = new Label();
            save_label = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(37, 50);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // browse_button
            // 
            browse_button.Location = new Point(71, 135);
            browse_button.Name = "browse_button";
            browse_button.Size = new Size(75, 23);
            browse_button.TabIndex = 1;
            browse_button.Text = "browse";
            browse_button.UseVisualStyleBackColor = true;
            browse_button.Click += browse_button_Click;
            // 
            // save_button
            // 
            save_button.Location = new Point(71, 230);
            save_button.Name = "save_button";
            save_button.Size = new Size(75, 23);
            save_button.TabIndex = 2;
            save_button.Text = "save";
            save_button.UseVisualStyleBackColor = true;
            save_button.Click += save_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 117);
            label1.Name = "label1";
            label1.Size = new Size(214, 15);
            label1.TabIndex = 3;
            label1.Text = "Pick a file you want to get the hash of : ";
            // 
            // save_label
            // 
            save_label.AutoSize = true;
            save_label.Location = new Point(37, 209);
            save_label.Name = "save_label";
            save_label.Size = new Size(158, 15);
            save_label.TabIndex = 4;
            save_label.Text = "Save the hash of selected file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 32);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 5;
            label2.Text = "Pick a hashing function :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 571);
            Controls.Add(label2);
            Controls.Add(save_label);
            Controls.Add(label1);
            Controls.Add(save_button);
            Controls.Add(browse_button);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button browse_button;
        private Button save_button;
        private Label label1;
        private Label save_label;
        private Label label2;
    }
}
