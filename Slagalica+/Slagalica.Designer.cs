namespace Slagalica_
{
    partial class Slagalica
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Slagalica));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bSubmit = new Slagalica_.RoundedButton();
            this.bStop = new Slagalica_.RoundedButton();
            this.roundedButton12 = new Slagalica_.RoundedButton();
            this.roundedButton11 = new Slagalica_.RoundedButton();
            this.roundedButton10 = new Slagalica_.RoundedButton();
            this.roundedButton9 = new Slagalica_.RoundedButton();
            this.roundedButton8 = new Slagalica_.RoundedButton();
            this.roundedButton7 = new Slagalica_.RoundedButton();
            this.roundedButton6 = new Slagalica_.RoundedButton();
            this.roundedButton5 = new Slagalica_.RoundedButton();
            this.roundedButton4 = new Slagalica_.RoundedButton();
            this.roundedButton3 = new Slagalica_.RoundedButton();
            this.roundedButton2 = new Slagalica_.RoundedButton();
            this.roundedButton1 = new Slagalica_.RoundedButton();
            this.roundedButton13 = new Slagalica_.RoundedButton();
            this.bBackSpace = new Slagalica_.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "90";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(65, 215);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(276, 30);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Word is valid/not valid";
            // 
            // bSubmit
            // 
            this.bSubmit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.bSubmit.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.bSubmit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.bSubmit.BorderRadius = 20;
            this.bSubmit.BorderSize = 0;
            this.bSubmit.Enabled = false;
            this.bSubmit.FlatAppearance.BorderSize = 0;
            this.bSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSubmit.ForeColor = System.Drawing.Color.White;
            this.bSubmit.Location = new System.Drawing.Point(159, 282);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(88, 44);
            this.bSubmit.TabIndex = 17;
            this.bSubmit.Text = "Submit";
            this.bSubmit.TextColor = System.Drawing.Color.White;
            this.bSubmit.UseVisualStyleBackColor = false;
            this.bSubmit.Visible = false;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // bStop
            // 
            this.bStop.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.bStop.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.bStop.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.bStop.BorderRadius = 8;
            this.bStop.BorderSize = 0;
            this.bStop.FlatAppearance.BorderSize = 0;
            this.bStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStop.ForeColor = System.Drawing.Color.White;
            this.bStop.Location = new System.Drawing.Point(159, 163);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(88, 36);
            this.bStop.TabIndex = 12;
            this.bStop.Text = "STOP";
            this.bStop.TextColor = System.Drawing.Color.White;
            this.bStop.UseVisualStyleBackColor = false;
            this.bStop.Click += new System.EventHandler(this.roundedButton13_Click);
            // 
            // roundedButton12
            // 
            this.roundedButton12.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton12.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton12.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton12.BorderRadius = 8;
            this.roundedButton12.BorderSize = 0;
            this.roundedButton12.FlatAppearance.BorderSize = 0;
            this.roundedButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton12.ForeColor = System.Drawing.Color.White;
            this.roundedButton12.Location = new System.Drawing.Point(300, 103);
            this.roundedButton12.Name = "roundedButton12";
            this.roundedButton12.Size = new System.Drawing.Size(41, 37);
            this.roundedButton12.TabIndex = 11;
            this.roundedButton12.Text = "A";
            this.roundedButton12.TextColor = System.Drawing.Color.White;
            this.roundedButton12.UseVisualStyleBackColor = false;
            // 
            // roundedButton11
            // 
            this.roundedButton11.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton11.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton11.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton11.BorderRadius = 8;
            this.roundedButton11.BorderSize = 0;
            this.roundedButton11.FlatAppearance.BorderSize = 0;
            this.roundedButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton11.ForeColor = System.Drawing.Color.White;
            this.roundedButton11.Location = new System.Drawing.Point(253, 103);
            this.roundedButton11.Name = "roundedButton11";
            this.roundedButton11.Size = new System.Drawing.Size(41, 37);
            this.roundedButton11.TabIndex = 10;
            this.roundedButton11.Text = "A";
            this.roundedButton11.TextColor = System.Drawing.Color.White;
            this.roundedButton11.UseVisualStyleBackColor = false;
            // 
            // roundedButton10
            // 
            this.roundedButton10.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton10.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton10.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton10.BorderRadius = 8;
            this.roundedButton10.BorderSize = 0;
            this.roundedButton10.FlatAppearance.BorderSize = 0;
            this.roundedButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton10.ForeColor = System.Drawing.Color.White;
            this.roundedButton10.Location = new System.Drawing.Point(206, 103);
            this.roundedButton10.Name = "roundedButton10";
            this.roundedButton10.Size = new System.Drawing.Size(41, 37);
            this.roundedButton10.TabIndex = 9;
            this.roundedButton10.Text = "A";
            this.roundedButton10.TextColor = System.Drawing.Color.White;
            this.roundedButton10.UseVisualStyleBackColor = false;
            // 
            // roundedButton9
            // 
            this.roundedButton9.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton9.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton9.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton9.BorderRadius = 8;
            this.roundedButton9.BorderSize = 0;
            this.roundedButton9.FlatAppearance.BorderSize = 0;
            this.roundedButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton9.ForeColor = System.Drawing.Color.White;
            this.roundedButton9.Location = new System.Drawing.Point(159, 103);
            this.roundedButton9.Name = "roundedButton9";
            this.roundedButton9.Size = new System.Drawing.Size(41, 37);
            this.roundedButton9.TabIndex = 8;
            this.roundedButton9.Text = "A";
            this.roundedButton9.TextColor = System.Drawing.Color.White;
            this.roundedButton9.UseVisualStyleBackColor = false;
            // 
            // roundedButton8
            // 
            this.roundedButton8.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton8.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton8.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton8.BorderRadius = 8;
            this.roundedButton8.BorderSize = 0;
            this.roundedButton8.FlatAppearance.BorderSize = 0;
            this.roundedButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton8.ForeColor = System.Drawing.Color.White;
            this.roundedButton8.Location = new System.Drawing.Point(112, 103);
            this.roundedButton8.Name = "roundedButton8";
            this.roundedButton8.Size = new System.Drawing.Size(41, 37);
            this.roundedButton8.TabIndex = 7;
            this.roundedButton8.Text = "A";
            this.roundedButton8.TextColor = System.Drawing.Color.White;
            this.roundedButton8.UseVisualStyleBackColor = false;
            // 
            // roundedButton7
            // 
            this.roundedButton7.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton7.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton7.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton7.BorderRadius = 8;
            this.roundedButton7.BorderSize = 0;
            this.roundedButton7.FlatAppearance.BorderSize = 0;
            this.roundedButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton7.ForeColor = System.Drawing.Color.White;
            this.roundedButton7.Location = new System.Drawing.Point(65, 103);
            this.roundedButton7.Name = "roundedButton7";
            this.roundedButton7.Size = new System.Drawing.Size(41, 37);
            this.roundedButton7.TabIndex = 6;
            this.roundedButton7.Text = "A";
            this.roundedButton7.TextColor = System.Drawing.Color.White;
            this.roundedButton7.UseVisualStyleBackColor = false;
            // 
            // roundedButton6
            // 
            this.roundedButton6.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton6.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton6.BorderRadius = 8;
            this.roundedButton6.BorderSize = 0;
            this.roundedButton6.FlatAppearance.BorderSize = 0;
            this.roundedButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton6.ForeColor = System.Drawing.Color.White;
            this.roundedButton6.Location = new System.Drawing.Point(300, 60);
            this.roundedButton6.Name = "roundedButton6";
            this.roundedButton6.Size = new System.Drawing.Size(41, 37);
            this.roundedButton6.TabIndex = 5;
            this.roundedButton6.Text = "A";
            this.roundedButton6.TextColor = System.Drawing.Color.White;
            this.roundedButton6.UseVisualStyleBackColor = false;
            // 
            // roundedButton5
            // 
            this.roundedButton5.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton5.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton5.BorderRadius = 8;
            this.roundedButton5.BorderSize = 0;
            this.roundedButton5.FlatAppearance.BorderSize = 0;
            this.roundedButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton5.ForeColor = System.Drawing.Color.White;
            this.roundedButton5.Location = new System.Drawing.Point(253, 60);
            this.roundedButton5.Name = "roundedButton5";
            this.roundedButton5.Size = new System.Drawing.Size(41, 37);
            this.roundedButton5.TabIndex = 4;
            this.roundedButton5.Text = "A";
            this.roundedButton5.TextColor = System.Drawing.Color.White;
            this.roundedButton5.UseVisualStyleBackColor = false;
            // 
            // roundedButton4
            // 
            this.roundedButton4.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton4.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton4.BorderRadius = 8;
            this.roundedButton4.BorderSize = 0;
            this.roundedButton4.FlatAppearance.BorderSize = 0;
            this.roundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton4.ForeColor = System.Drawing.Color.White;
            this.roundedButton4.Location = new System.Drawing.Point(206, 60);
            this.roundedButton4.Name = "roundedButton4";
            this.roundedButton4.Size = new System.Drawing.Size(41, 37);
            this.roundedButton4.TabIndex = 3;
            this.roundedButton4.Text = "A";
            this.roundedButton4.TextColor = System.Drawing.Color.White;
            this.roundedButton4.UseVisualStyleBackColor = false;
            // 
            // roundedButton3
            // 
            this.roundedButton3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton3.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton3.BorderRadius = 8;
            this.roundedButton3.BorderSize = 0;
            this.roundedButton3.FlatAppearance.BorderSize = 0;
            this.roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton3.ForeColor = System.Drawing.Color.White;
            this.roundedButton3.Location = new System.Drawing.Point(159, 60);
            this.roundedButton3.Name = "roundedButton3";
            this.roundedButton3.Size = new System.Drawing.Size(41, 37);
            this.roundedButton3.TabIndex = 2;
            this.roundedButton3.Text = "A";
            this.roundedButton3.TextColor = System.Drawing.Color.White;
            this.roundedButton3.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton2.BorderRadius = 8;
            this.roundedButton2.BorderSize = 0;
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton2.ForeColor = System.Drawing.Color.White;
            this.roundedButton2.Location = new System.Drawing.Point(112, 60);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(41, 37);
            this.roundedButton2.TabIndex = 1;
            this.roundedButton2.Text = "A";
            this.roundedButton2.TextColor = System.Drawing.Color.White;
            this.roundedButton2.UseVisualStyleBackColor = false;
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton1.BorderRadius = 8;
            this.roundedButton1.BorderSize = 0;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.Location = new System.Drawing.Point(65, 60);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(41, 37);
            this.roundedButton1.TabIndex = 0;
            this.roundedButton1.Text = "A";
            this.roundedButton1.TextColor = System.Drawing.Color.White;
            this.roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedButton13
            // 
            this.roundedButton13.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton13.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundedButton13.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton13.BorderRadius = 20;
            this.roundedButton13.BorderSize = 0;
            this.roundedButton13.FlatAppearance.BorderSize = 0;
            this.roundedButton13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton13.ForeColor = System.Drawing.Color.White;
            this.roundedButton13.Location = new System.Drawing.Point(12, 398);
            this.roundedButton13.Name = "roundedButton13";
            this.roundedButton13.Size = new System.Drawing.Size(109, 40);
            this.roundedButton13.TabIndex = 20;
            this.roundedButton13.Text = "Back";
            this.roundedButton13.TextColor = System.Drawing.Color.White;
            this.roundedButton13.UseVisualStyleBackColor = false;
            this.roundedButton13.Click += new System.EventHandler(this.roundedButton13_Click_1);
            // 
            // bBackSpace
            // 
            this.bBackSpace.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.bBackSpace.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.bBackSpace.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.bBackSpace.BorderRadius = 20;
            this.bBackSpace.BorderSize = 0;
            this.bBackSpace.FlatAppearance.BorderSize = 0;
            this.bBackSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBackSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBackSpace.ForeColor = System.Drawing.Color.White;
            this.bBackSpace.Location = new System.Drawing.Point(347, 215);
            this.bBackSpace.Name = "bBackSpace";
            this.bBackSpace.Size = new System.Drawing.Size(52, 40);
            this.bBackSpace.TabIndex = 21;
            this.bBackSpace.Text = "⌫";
            this.bBackSpace.TextColor = System.Drawing.Color.White;
            this.bBackSpace.UseVisualStyleBackColor = false;
            this.bBackSpace.Click += new System.EventHandler(this.bBackSpace_Click_1);
            // 
            // Slagalica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Slagalica_.Properties.Resources.ground;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.bBackSpace);
            this.Controls.Add(this.roundedButton13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.roundedButton12);
            this.Controls.Add(this.roundedButton11);
            this.Controls.Add(this.roundedButton10);
            this.Controls.Add(this.roundedButton9);
            this.Controls.Add(this.roundedButton8);
            this.Controls.Add(this.roundedButton7);
            this.Controls.Add(this.roundedButton6);
            this.Controls.Add(this.roundedButton5);
            this.Controls.Add(this.roundedButton4);
            this.Controls.Add(this.roundedButton3);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Slagalica";
            this.Text = "Slagalica";
            this.Load += new System.EventHandler(this.Slagalica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton roundedButton1;
        private RoundedButton roundedButton2;
        private RoundedButton roundedButton3;
        private RoundedButton roundedButton4;
        private RoundedButton roundedButton5;
        private RoundedButton roundedButton6;
        private RoundedButton roundedButton7;
        private RoundedButton roundedButton8;
        private RoundedButton roundedButton9;
        private RoundedButton roundedButton10;
        private RoundedButton roundedButton11;
        private RoundedButton roundedButton12;
        private RoundedButton bStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBox1;
        private RoundedButton bSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RoundedButton roundedButton13;
        private RoundedButton bBackSpace;
    }
}