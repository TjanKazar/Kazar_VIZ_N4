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
            cost_box = new ComboBox();
            label3 = new Label();
            compare_button = new Button();
            label4 = new Label();
            compare = new Button();
            override_main = new Button();
            label5 = new Label();
            override_comp = new Button();
            label6 = new Label();
            salt_hash = new Button();
            label7 = new Label();
            textBox1 = new TextBox();
            username = new Label();
            save_all = new Button();
            label8 = new Label();
            label9 = new Label();
            button3 = new Button();
            label12 = new Label();
            textBox2 = new TextBox();
            pass = new Label();
            label13 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(50, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // browse_button
            // 
            browse_button.Location = new Point(79, 161);
            browse_button.Name = "browse_button";
            browse_button.Size = new Size(75, 23);
            browse_button.TabIndex = 1;
            browse_button.Text = "browse";
            browse_button.UseVisualStyleBackColor = true;
            browse_button.Click += browse_button_Click;
            // 
            // save_button
            // 
            save_button.Location = new Point(372, 135);
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
            label1.Location = new Point(22, 143);
            label1.Name = "label1";
            label1.Size = new Size(211, 15);
            label1.TabIndex = 3;
            label1.Text = "Pick a file you want to get the hash of: ";
            // 
            // save_label
            // 
            save_label.AutoSize = true;
            save_label.Location = new Point(335, 117);
            save_label.Name = "save_label";
            save_label.Size = new Size(158, 15);
            save_label.TabIndex = 4;
            save_label.Text = "Save the hash of selected file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 16);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 5;
            label2.Text = "Pick a hashing function :";
            // 
            // cost_box
            // 
            cost_box.FormattingEnabled = true;
            cost_box.Location = new Point(51, 99);
            cost_box.Name = "cost_box";
            cost_box.Size = new Size(121, 23);
            cost_box.TabIndex = 6;
            cost_box.SelectedIndexChanged += cost_box_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 81);
            label3.Name = "label3";
            label3.Size = new Size(143, 15);
            label3.TabIndex = 7;
            label3.Text = "pick the \"cost\" of  bCrypt ";
            // 
            // compare_button
            // 
            compare_button.Location = new Point(79, 229);
            compare_button.Name = "compare_button";
            compare_button.Size = new Size(75, 23);
            compare_button.TabIndex = 8;
            compare_button.Text = "browse";
            compare_button.UseVisualStyleBackColor = true;
            compare_button.Click += compare_button_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 211);
            label4.Name = "label4";
            label4.Size = new Size(144, 15);
            label4.TabIndex = 9;
            label4.Text = "pick a file for comparison:";
            // 
            // compare
            // 
            compare.Location = new Point(79, 296);
            compare.Name = "compare";
            compare.Size = new Size(75, 23);
            compare.TabIndex = 10;
            compare.Text = "compare";
            compare.UseVisualStyleBackColor = true;
            compare.Click += compare_Click;
            // 
            // override_main
            // 
            override_main.Location = new Point(79, 357);
            override_main.Name = "override_main";
            override_main.Size = new Size(75, 23);
            override_main.TabIndex = 11;
            override_main.Text = "override";
            override_main.UseVisualStyleBackColor = true;
            override_main.Click += override_main_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 339);
            label5.Name = "label5";
            label5.Size = new Size(104, 15);
            label5.TabIndex = 12;
            label5.Text = "override first hash:";
            // 
            // override_comp
            // 
            override_comp.Location = new Point(79, 412);
            override_comp.Name = "override_comp";
            override_comp.Size = new Size(75, 23);
            override_comp.TabIndex = 13;
            override_comp.Text = "override";
            override_comp.UseVisualStyleBackColor = true;
            override_comp.Click += override_comp_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(44, 394);
            label6.Name = "label6";
            label6.Size = new Size(147, 15);
            label6.TabIndex = 14;
            label6.Text = "override comparison hash:";
            // 
            // salt_hash
            // 
            salt_hash.Location = new Point(372, 229);
            salt_hash.Name = "salt_hash";
            salt_hash.Size = new Size(75, 23);
            salt_hash.TabIndex = 15;
            salt_hash.Text = "hash + salt";
            salt_hash.UseVisualStyleBackColor = true;
            salt_hash.Click += salt_hash_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(364, 211);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 16;
            label7.Text = "Save salted hash";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(362, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 17;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // username
            // 
            username.AutoSize = true;
            username.Location = new Point(378, 16);
            username.Name = "username";
            username.Size = new Size(69, 15);
            username.TabIndex = 18;
            username.Text = "User name :";
            // 
            // save_all
            // 
            save_all.Location = new Point(372, 312);
            save_all.Name = "save_all";
            save_all.Size = new Size(75, 23);
            save_all.TabIndex = 19;
            save_all.Text = "save";
            save_all.UseVisualStyleBackColor = true;
            save_all.Click += save_all_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(290, 294);
            label8.Name = "label8";
            label8.Size = new Size(250, 15);
            label8.TabIndex = 20;
            label8.Text = "save username, salt and salted hash to text file";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(51, 278);
            label9.Name = "label9";
            label9.Size = new Size(136, 15);
            label9.TabIndex = 21;
            label9.Text = "compare the two hashes";
            // 
            // button3
            // 
            button3.Location = new Point(685, 161);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 26;
            button3.Text = "compare";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(661, 143);
            label12.Name = "label12";
            label12.Size = new Size(136, 15);
            label12.TabIndex = 27;
            label12.Text = "compare the two values:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(677, 26);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 28;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // pass
            // 
            pass.AutoSize = true;
            pass.Location = new Point(700, 8);
            pass.Name = "pass";
            pass.Size = new Size(60, 15);
            pass.TabIndex = 29;
            pass.Text = "password:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(714, 68);
            label13.Name = "label13";
            label13.Size = new Size(28, 15);
            label13.TabIndex = 30;
            label13.Text = "salt:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(677, 86);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 31;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 467);
            Controls.Add(textBox3);
            Controls.Add(label13);
            Controls.Add(pass);
            Controls.Add(textBox2);
            Controls.Add(label12);
            Controls.Add(button3);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(save_all);
            Controls.Add(username);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(salt_hash);
            Controls.Add(label6);
            Controls.Add(override_comp);
            Controls.Add(label5);
            Controls.Add(override_main);
            Controls.Add(compare);
            Controls.Add(label4);
            Controls.Add(compare_button);
            Controls.Add(label3);
            Controls.Add(cost_box);
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
        private ComboBox cost_box;
        private Label label3;
        private Button compare_button;
        private Label label4;
        private Button compare;
        private Button override_main;
        private Label label5;
        private Button override_comp;
        private Label label6;
        private Button salt_hash;
        private Label label7;
        private TextBox textBox1;
        private Label username;
        private Button save_all;
        private Label label8;
        private Label label9;
        private Button button3;
        private Label label12;
        private TextBox textBox2;
        private Label pass;
        private Label label13;
        private TextBox textBox3;
    }
}
