namespace TSPWinForms
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
            formsPlot1 = new ScottPlot.FormsPlot();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            groupBox1 = new GroupBox();
            button1 = new Button();
            groupBox2 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(251, 12);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(536, 413);
            formsPlot1.TabIndex = 0;
            formsPlot1.Load += formsPlot1_Load;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(6, 36);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(70, 19);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Random";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 61);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(95, 19);
            radioButton2.TabIndex = 2;
            radioButton2.Text = "Deterministic";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Location = new Point(14, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(122, 84);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crossover";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button1
            // 
            button1.Location = new Point(81, 359);
            button1.Name = "button1";
            button1.Size = new Size(94, 54);
            button1.TabIndex = 8;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(radioButton4);
            groupBox2.Location = new Point(142, 57);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(122, 84);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mutation";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Location = new Point(6, 36);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(70, 19);
            radioButton3.TabIndex = 1;
            radioButton3.TabStop = true;
            radioButton3.Text = "Random";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(6, 61);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(95, 19);
            radioButton4.TabIndex = 2;
            radioButton4.Text = "Deterministic";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(18, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 23);
            comboBox1.TabIndex = 10;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(20, 180);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(96, 23);
            numericUpDown1.TabIndex = 11;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(148, 180);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(96, 23);
            numericUpDown2.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 153);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 13;
            label1.Text = "Max iterations";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 153);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 14;
            label2.Text = "Population size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 254);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 15;
            label3.Text = "Lowest cost";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 286);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 16;
            label4.Text = "Iteration";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 316);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 17;
            label5.Text = "Time [ms]";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(90, 316);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 20;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(90, 286);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 19;
            label7.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(90, 254);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 18;
            label8.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(90, 226);
            label9.Name = "label9";
            label9.Size = new Size(21, 15);
            label9.TabIndex = 21;
            label9.Text = "EA";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(148, 226);
            label10.Name = "label10";
            label10.Size = new Size(30, 15);
            label10.TabIndex = 25;
            label10.Text = "ABC";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(148, 316);
            label11.Name = "label11";
            label11.Size = new Size(13, 15);
            label11.TabIndex = 24;
            label11.Text = "0";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(148, 286);
            label12.Name = "label12";
            label12.Size = new Size(13, 15);
            label12.TabIndex = 23;
            label12.Text = "0";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(148, 254);
            label13.Name = "label13";
            label13.Size = new Size(13, 15);
            label13.TabIndex = 22;
            label13.Text = "0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(209, 226);
            label14.Name = "label14";
            label14.Size = new Size(35, 15);
            label14.TabIndex = 29;
            label14.Text = "GWO";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(209, 316);
            label15.Name = "label15";
            label15.Size = new Size(13, 15);
            label15.TabIndex = 28;
            label15.Text = "0";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(209, 286);
            label16.Name = "label16";
            label16.Size = new Size(13, 15);
            label16.TabIndex = 27;
            label16.Text = "0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(209, 254);
            label17.Name = "label17";
            label17.Size = new Size(13, 15);
            label17.TabIndex = 26;
            label17.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(formsPlot1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox groupBox1;
        private Button button1;
        private GroupBox groupBox2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
    }
}