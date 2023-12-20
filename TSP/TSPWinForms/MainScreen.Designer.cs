namespace TSPWinForms
{
    partial class MainScreen
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
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            button2 = new Button();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            label37 = new Label();
            label38 = new Label();
            label39 = new Label();
            button3 = new Button();
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
            formsPlot1.Size = new Size(626, 506);
            formsPlot1.TabIndex = 0;
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
            groupBox1.Location = new Point(15, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(122, 84);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crossover";
            // 
            // button1
            // 
            button1.Location = new Point(143, 205);
            button1.Name = "button1";
            button1.Size = new Size(122, 39);
            button1.TabIndex = 8;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(radioButton4);
            groupBox2.Location = new Point(143, 109);
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
            radioButton3.Location = new Point(7, 36);
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
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(21, 215);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(96, 23);
            numericUpDown1.TabIndex = 11;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(21, 267);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(96, 23);
            numericUpDown2.TabIndex = 12;
            numericUpDown2.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 197);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 13;
            label1.Text = "Max iterations";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 249);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 14;
            label2.Text = "Population size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 339);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 15;
            label3.Text = "Lowest cost";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 363);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 16;
            label4.Text = "Iteration";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 387);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 17;
            label5.Text = "Time [ms]";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(90, 387);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 20;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(90, 363);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 19;
            label7.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(90, 339);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 18;
            label8.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(90, 311);
            label9.Name = "label9";
            label9.Size = new Size(21, 15);
            label9.TabIndex = 21;
            label9.Text = "EA";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(148, 311);
            label10.Name = "label10";
            label10.Size = new Size(30, 15);
            label10.TabIndex = 25;
            label10.Text = "ABC";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(148, 387);
            label11.Name = "label11";
            label11.Size = new Size(13, 15);
            label11.TabIndex = 24;
            label11.Text = "0";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(148, 363);
            label12.Name = "label12";
            label12.Size = new Size(13, 15);
            label12.TabIndex = 23;
            label12.Text = "0";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(148, 339);
            label13.Name = "label13";
            label13.Size = new Size(13, 15);
            label13.TabIndex = 22;
            label13.Text = "0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(209, 311);
            label14.Name = "label14";
            label14.Size = new Size(35, 15);
            label14.TabIndex = 29;
            label14.Text = "GWO";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(209, 387);
            label15.Name = "label15";
            label15.Size = new Size(13, 15);
            label15.TabIndex = 28;
            label15.Text = "0";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(209, 363);
            label16.Name = "label16";
            label16.Size = new Size(13, 15);
            label16.TabIndex = 27;
            label16.Text = "0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(209, 339);
            label17.Name = "label17";
            label17.Size = new Size(13, 15);
            label17.TabIndex = 26;
            label17.Text = "0";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(21, 47);
            label18.Name = "label18";
            label18.Size = new Size(89, 15);
            label18.TabIndex = 30;
            label18.Text = "Nodes number:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(125, 47);
            label19.Name = "label19";
            label19.Size = new Size(13, 15);
            label19.TabIndex = 31;
            label19.Text = "0";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(21, 71);
            label20.Name = "label20";
            label20.Size = new Size(103, 15);
            label20.TabIndex = 32;
            label20.Text = "Best solution cost:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(125, 71);
            label21.Name = "label21";
            label21.Size = new Size(13, 15);
            label21.TabIndex = 33;
            label21.Text = "0";
            // 
            // button2
            // 
            button2.Location = new Point(209, 23);
            button2.Name = "button2";
            button2.Size = new Size(56, 63);
            button2.TabIndex = 34;
            button2.Text = "Choose Graph";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(125, 23);
            label22.Name = "label22";
            label22.Size = new Size(36, 15);
            label22.TabIndex = 36;
            label22.Text = "None";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(21, 23);
            label23.Name = "label23";
            label23.Size = new Size(61, 15);
            label23.TabIndex = 35;
            label23.Text = "File name:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(209, 411);
            label24.Name = "label24";
            label24.Size = new Size(13, 15);
            label24.TabIndex = 40;
            label24.Text = "0";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(148, 411);
            label25.Name = "label25";
            label25.Size = new Size(13, 15);
            label25.TabIndex = 39;
            label25.Text = "0";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(90, 411);
            label26.Name = "label26";
            label26.Size = new Size(13, 15);
            label26.TabIndex = 38;
            label26.Text = "0";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(18, 411);
            label27.Name = "label27";
            label27.Size = new Size(64, 15);
            label27.TabIndex = 37;
            label27.Text = "Crossovers";
            label27.Click += label27_Click;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(209, 459);
            label28.Name = "label28";
            label28.Size = new Size(13, 15);
            label28.TabIndex = 48;
            label28.Text = "0";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(148, 459);
            label29.Name = "label29";
            label29.Size = new Size(13, 15);
            label29.TabIndex = 47;
            label29.Text = "0";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(90, 459);
            label30.Name = "label30";
            label30.Size = new Size(13, 15);
            label30.TabIndex = 46;
            label30.Text = "0";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(18, 459);
            label31.Name = "label31";
            label31.Size = new Size(61, 15);
            label31.TabIndex = 45;
            label31.Text = "Mutations";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(209, 435);
            label32.Name = "label32";
            label32.Size = new Size(13, 15);
            label32.TabIndex = 44;
            label32.Text = "0";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(148, 435);
            label33.Name = "label33";
            label33.Size = new Size(13, 15);
            label33.TabIndex = 43;
            label33.Text = "0";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(90, 435);
            label34.Name = "label34";
            label34.Size = new Size(13, 15);
            label34.TabIndex = 42;
            label34.Text = "0";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(18, 435);
            label35.Name = "label35";
            label35.Size = new Size(69, 15);
            label35.TabIndex = 41;
            label35.Text = "C. efficency";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(209, 483);
            label36.Name = "label36";
            label36.Size = new Size(13, 15);
            label36.TabIndex = 52;
            label36.Text = "0";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(148, 483);
            label37.Name = "label37";
            label37.Size = new Size(13, 15);
            label37.TabIndex = 51;
            label37.Text = "0";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(90, 483);
            label38.Name = "label38";
            label38.Size = new Size(13, 15);
            label38.TabIndex = 50;
            label38.Text = "0";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(18, 483);
            label39.Name = "label39";
            label39.Size = new Size(72, 15);
            label39.TabIndex = 49;
            label39.Text = "M. efficency";
            // 
            // button3
            // 
            button3.Location = new Point(143, 257);
            button3.Name = "button3";
            button3.Size = new Size(122, 39);
            button3.TabIndex = 53;
            button3.Text = "Generate data";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 530);
            Controls.Add(button3);
            Controls.Add(label36);
            Controls.Add(label37);
            Controls.Add(label38);
            Controls.Add(label39);
            Controls.Add(label28);
            Controls.Add(label29);
            Controls.Add(label30);
            Controls.Add(label31);
            Controls.Add(label32);
            Controls.Add(label33);
            Controls.Add(label34);
            Controls.Add(label35);
            Controls.Add(label24);
            Controls.Add(label25);
            Controls.Add(label26);
            Controls.Add(label27);
            Controls.Add(label22);
            Controls.Add(label23);
            Controls.Add(button2);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label18);
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
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(formsPlot1);
            Name = "MainScreen";
            Text = "TSP App";
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
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Button button2;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Button button3;
    }
}