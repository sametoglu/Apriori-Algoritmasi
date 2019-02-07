namespace Veri_odevi_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nud_destek = new System.Windows.Forms.NumericUpDown();
            this.nud_guven = new System.Windows.Forms.NumericUpDown();
            this.lb_yorum = new System.Windows.Forms.ListBox();
            this.lb1 = new System.Windows.Forms.ListBox();
            this.lb2 = new System.Windows.Forms.ListBox();
            this.lb3 = new System.Windows.Forms.ListBox();
            this.lb4 = new System.Windows.Forms.ListBox();
            this.lb5 = new System.Windows.Forms.ListBox();
            this.dgv_tablo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nud_destek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_guven)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Min Destek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min Guven";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "hesap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nud_destek
            // 
            this.nud_destek.Location = new System.Drawing.Point(462, 13);
            this.nud_destek.Name = "nud_destek";
            this.nud_destek.Size = new System.Drawing.Size(63, 20);
            this.nud_destek.TabIndex = 6;
            // 
            // nud_guven
            // 
            this.nud_guven.Location = new System.Drawing.Point(462, 39);
            this.nud_guven.Name = "nud_guven";
            this.nud_guven.Size = new System.Drawing.Size(63, 20);
            this.nud_guven.TabIndex = 7;
            // 
            // lb_yorum
            // 
            this.lb_yorum.FormattingEnabled = true;
            this.lb_yorum.Location = new System.Drawing.Point(645, 14);
            this.lb_yorum.Name = "lb_yorum";
            this.lb_yorum.Size = new System.Drawing.Size(413, 485);
            this.lb_yorum.TabIndex = 8;
            // 
            // lb1
            // 
            this.lb1.FormattingEnabled = true;
            this.lb1.Location = new System.Drawing.Point(402, 65);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(237, 82);
            this.lb1.TabIndex = 10;
            // 
            // lb2
            // 
            this.lb2.FormattingEnabled = true;
            this.lb2.Location = new System.Drawing.Point(402, 153);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(237, 82);
            this.lb2.TabIndex = 11;
            // 
            // lb3
            // 
            this.lb3.FormattingEnabled = true;
            this.lb3.Location = new System.Drawing.Point(402, 240);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(237, 82);
            this.lb3.TabIndex = 12;
            // 
            // lb4
            // 
            this.lb4.FormattingEnabled = true;
            this.lb4.Location = new System.Drawing.Point(402, 328);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(237, 82);
            this.lb4.TabIndex = 13;
            // 
            // lb5
            // 
            this.lb5.FormattingEnabled = true;
            this.lb5.Location = new System.Drawing.Point(402, 417);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(237, 82);
            this.lb5.TabIndex = 14;
            // 
            // dgv_tablo
            // 
            this.dgv_tablo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tablo.Location = new System.Drawing.Point(5, 12);
            this.dgv_tablo.Name = "dgv_tablo";
            this.dgv_tablo.Size = new System.Drawing.Size(391, 486);
            this.dgv_tablo.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 504);
            this.Controls.Add(this.dgv_tablo);
            this.Controls.Add(this.lb5);
            this.Controls.Add(this.lb4);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.lb_yorum);
            this.Controls.Add(this.nud_guven);
            this.Controls.Add(this.nud_destek);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_destek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_guven)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nud_destek;
        private System.Windows.Forms.NumericUpDown nud_guven;
        private System.Windows.Forms.ListBox lb_yorum;
        private System.Windows.Forms.ListBox lb1;
        private System.Windows.Forms.ListBox lb2;
        private System.Windows.Forms.ListBox lb3;
        private System.Windows.Forms.ListBox lb4;
        private System.Windows.Forms.ListBox lb5;
        private System.Windows.Forms.DataGridView dgv_tablo;
    }
}

