﻿namespace Task4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.tbSpread = new System.Windows.Forms.TrackBar();
            this.btnFromColor = new System.Windows.Forms.Button();
            this.btnToColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpread)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(253, 203);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(285, 12);
            this.tbDirection.Maximum = 200;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(104, 45);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.TickFrequency = 10;
            this.tbDirection.Scroll += new System.EventHandler(this.TbDirection_Scroll);
            // 
            // tbSpread
            // 
            this.tbSpread.Location = new System.Drawing.Point(285, 63);
            this.tbSpread.Maximum = 180;
            this.tbSpread.Name = "tbSpread";
            this.tbSpread.Size = new System.Drawing.Size(104, 45);
            this.tbSpread.TabIndex = 2;
            this.tbSpread.TickFrequency = 10;
            this.tbSpread.Scroll += new System.EventHandler(this.TbSpead_Scroll);
            // 
            // btnFromColor
            // 
            this.btnFromColor.Location = new System.Drawing.Point(285, 126);
            this.btnFromColor.Name = "btnFromColor";
            this.btnFromColor.Size = new System.Drawing.Size(104, 23);
            this.btnFromColor.TabIndex = 3;
            this.btnFromColor.Text = "From color";
            this.btnFromColor.UseVisualStyleBackColor = true;
            this.btnFromColor.Click += new System.EventHandler(this.BtnFromColor_Click);
            // 
            // btnToColor
            // 
            this.btnToColor.Location = new System.Drawing.Point(285, 155);
            this.btnToColor.Name = "btnToColor";
            this.btnToColor.Size = new System.Drawing.Size(104, 23);
            this.btnToColor.TabIndex = 4;
            this.btnToColor.Text = "To color";
            this.btnToColor.UseVisualStyleBackColor = true;
            this.btnToColor.Click += new System.EventHandler(this.BtnToColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(305, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "напор воды";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label2.Location = new System.Drawing.Point(305, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "направление";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(402, 227);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnToColor);
            this.Controls.Add(this.btnFromColor);
            this.Controls.Add(this.tbSpread);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpread)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.TrackBar tbSpread;
        private System.Windows.Forms.Button btnFromColor;
        private System.Windows.Forms.Button btnToColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

