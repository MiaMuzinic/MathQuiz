namespace OTTER
{
    partial class BGL
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
            this.syncRate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_tekstpitanja = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // syncRate
            // 
            this.syncRate.AutoSize = true;
            this.syncRate.BackColor = System.Drawing.Color.Transparent;
            this.syncRate.Location = new System.Drawing.Point(12, 479);
            this.syncRate.Name = "syncRate";
            this.syncRate.Size = new System.Drawing.Size(71, 52);
            this.syncRate.TabIndex = 0;
            this.syncRate.Text = "60";
            this.syncRate.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 17;
            this.timer1.Tick += new System.EventHandler(this.Update);
            // 
            // timer2
            // 
            this.timer2.Interval = 250;
            this.timer2.Tick += new System.EventHandler(this.updateFrameRate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 200);
            this.label1.MaximumSize = new System.Drawing.Size(0, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 4;
            // 
            // lbl_tekstpitanja
            // 
            this.lbl_tekstpitanja.BackColor = System.Drawing.Color.Transparent;
            this.lbl_tekstpitanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tekstpitanja.ForeColor = System.Drawing.Color.Black;
            this.lbl_tekstpitanja.Location = new System.Drawing.Point(104, 46);
            this.lbl_tekstpitanja.Name = "lbl_tekstpitanja";
            this.lbl_tekstpitanja.Size = new System.Drawing.Size(478, 295);
            this.lbl_tekstpitanja.TabIndex = 5;
            this.lbl_tekstpitanja.Text = "label2";
            this.lbl_tekstpitanja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(135, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 119);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(360, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 119);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(588, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 119);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // BGL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(26F, 52F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(778, 549);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_tekstpitanja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.syncRate);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MaximizeBox = false;
            this.Name = "BGL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2DGL";
            this.Load += new System.EventHandler(this.startTimer);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label syncRate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_tekstpitanja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer3;
    }
}

