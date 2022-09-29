
namespace Intro02.WinApp
{
    partial class Form4
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
            this.txtAraToplam = new System.Windows.Forms.TextBox();
            this.cmbPizzalar = new System.Windows.Forms.ComboBox();
            this.rdpKucuk = new System.Windows.Forms.RadioButton();
            this.rdpOrta = new System.Windows.Forms.RadioButton();
            this.rdpBuyuk = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAt = new System.Windows.Forms.Button();
            this.btnCikar = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstSepetim = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAnaToplam = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.lstSecilenMalzemeler = new System.Windows.Forms.ListBox();
            this.lstMalzemeler = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pizza";
            // 
            // txtAraToplam
            // 
            this.txtAraToplam.Location = new System.Drawing.Point(394, 459);
            this.txtAraToplam.Name = "txtAraToplam";
            this.txtAraToplam.Size = new System.Drawing.Size(145, 26);
            this.txtAraToplam.TabIndex = 1;
            this.txtAraToplam.TextChanged += new System.EventHandler(this.txtAraToplam_TextChanged);
            // 
            // cmbPizzalar
            // 
            this.cmbPizzalar.FormattingEnabled = true;
            this.cmbPizzalar.Location = new System.Drawing.Point(165, 54);
            this.cmbPizzalar.Name = "cmbPizzalar";
            this.cmbPizzalar.Size = new System.Drawing.Size(374, 28);
            this.cmbPizzalar.TabIndex = 2;
            this.cmbPizzalar.SelectedIndexChanged += new System.EventHandler(this.cmbPizzalar_SelectedIndexChanged);
            // 
            // rdpKucuk
            // 
            this.rdpKucuk.AutoSize = true;
            this.rdpKucuk.Location = new System.Drawing.Point(165, 116);
            this.rdpKucuk.Name = "rdpKucuk";
            this.rdpKucuk.Size = new System.Drawing.Size(76, 24);
            this.rdpKucuk.TabIndex = 4;
            this.rdpKucuk.TabStop = true;
            this.rdpKucuk.Text = "Küçük";
            this.rdpKucuk.UseVisualStyleBackColor = true;
            this.rdpKucuk.CheckedChanged += new System.EventHandler(this.rdpKucuk_CheckedChanged_1);
            // 
            // rdpOrta
            // 
            this.rdpOrta.AutoSize = true;
            this.rdpOrta.Location = new System.Drawing.Point(316, 116);
            this.rdpOrta.Name = "rdpOrta";
            this.rdpOrta.Size = new System.Drawing.Size(62, 24);
            this.rdpOrta.TabIndex = 4;
            this.rdpOrta.TabStop = true;
            this.rdpOrta.Text = "Orta";
            this.rdpOrta.UseVisualStyleBackColor = true;
            this.rdpOrta.CheckedChanged += new System.EventHandler(this.rdpKucuk_CheckedChanged_1);
            // 
            // rdpBuyuk
            // 
            this.rdpBuyuk.AutoSize = true;
            this.rdpBuyuk.Location = new System.Drawing.Point(446, 116);
            this.rdpBuyuk.Name = "rdpBuyuk";
            this.rdpBuyuk.Size = new System.Drawing.Size(76, 24);
            this.rdpBuyuk.TabIndex = 4;
            this.rdpBuyuk.TabStop = true;
            this.rdpBuyuk.Text = "Büyük";
            this.rdpBuyuk.UseVisualStyleBackColor = true;
            this.rdpBuyuk.CheckedChanged += new System.EventHandler(this.rdpKucuk_CheckedChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Malzemeler";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAt
            // 
            this.btnAt.Location = new System.Drawing.Point(321, 209);
            this.btnAt.Name = "btnAt";
            this.btnAt.Size = new System.Drawing.Size(61, 48);
            this.btnAt.TabIndex = 6;
            this.btnAt.Text = ">";
            this.btnAt.UseVisualStyleBackColor = true;
            this.btnAt.Click += new System.EventHandler(this.btnAt_Click);
            // 
            // btnCikar
            // 
            this.btnCikar.Location = new System.Drawing.Point(321, 263);
            this.btnCikar.Name = "btnCikar";
            this.btnCikar.Size = new System.Drawing.Size(61, 48);
            this.btnCikar.TabIndex = 6;
            this.btnCikar.Text = "<";
            this.btnCikar.UseVisualStyleBackColor = true;
            this.btnCikar.Click += new System.EventHandler(this.btnCikar_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(394, 423);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(145, 26);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ara Toplam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Adet";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(394, 521);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 59);
            this.button3.TabIndex = 8;
            this.button3.Text = "Sepete At";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstSepetim);
            this.groupBox2.Location = new System.Drawing.Point(599, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 413);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sepet Bilgileri";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lstSepetim
            // 
            this.lstSepetim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSepetim.FormattingEnabled = true;
            this.lstSepetim.ItemHeight = 20;
            this.lstSepetim.Location = new System.Drawing.Point(3, 22);
            this.lstSepetim.Name = "lstSepetim";
            this.lstSepetim.Size = new System.Drawing.Size(413, 388);
            this.lstSepetim.TabIndex = 0;
            this.lstSepetim.SelectedIndexChanged += new System.EventHandler(this.lstSepetim_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(830, 521);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 59);
            this.button4.TabIndex = 8;
            this.button4.Text = "Siparişi Ver";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(825, 480);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sepet Toplam";
            // 
            // lblAnaToplam
            // 
            this.lblAnaToplam.AutoSize = true;
            this.lblAnaToplam.Location = new System.Drawing.Point(978, 480);
            this.lblAnaToplam.Name = "lblAnaToplam";
            this.lblAnaToplam.Size = new System.Drawing.Size(19, 20);
            this.lblAnaToplam.TabIndex = 0;
            this.lblAnaToplam.Text = "0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(644, 521);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 59);
            this.button5.TabIndex = 9;
            this.button5.Text = "Müşteri Gir";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lstSecilenMalzemeler
            // 
            this.lstSecilenMalzemeler.FormattingEnabled = true;
            this.lstSecilenMalzemeler.ItemHeight = 20;
            this.lstSecilenMalzemeler.Location = new System.Drawing.Point(394, 166);
            this.lstSecilenMalzemeler.Name = "lstSecilenMalzemeler";
            this.lstSecilenMalzemeler.Size = new System.Drawing.Size(145, 224);
            this.lstSecilenMalzemeler.TabIndex = 10;
            this.lstSecilenMalzemeler.SelectedIndexChanged += new System.EventHandler(this.lstSecilenMalzemeler_SelectedIndexChanged);
            // 
            // lstMalzemeler
            // 
            this.lstMalzemeler.FormattingEnabled = true;
            this.lstMalzemeler.ItemHeight = 20;
            this.lstMalzemeler.Location = new System.Drawing.Point(165, 166);
            this.lstMalzemeler.Name = "lstMalzemeler";
            this.lstMalzemeler.Size = new System.Drawing.Size(150, 224);
            this.lstMalzemeler.TabIndex = 10;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 681);
            this.Controls.Add(this.lstMalzemeler);
            this.Controls.Add(this.lstSecilenMalzemeler);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnCikar);
            this.Controls.Add(this.btnAt);
            this.Controls.Add(this.rdpBuyuk);
            this.Controls.Add(this.rdpOrta);
            this.Controls.Add(this.rdpKucuk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmbPizzalar);
            this.Controls.Add(this.txtAraToplam);
            this.Controls.Add(this.lblAnaToplam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAraToplam;
        private System.Windows.Forms.ComboBox cmbPizzalar;
        private System.Windows.Forms.RadioButton rdpKucuk;
        private System.Windows.Forms.RadioButton rdpOrta;
        private System.Windows.Forms.RadioButton rdpBuyuk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAt;
        private System.Windows.Forms.Button btnCikar;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAnaToplam;
        private System.Windows.Forms.ListBox lstSepetim;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox lstSecilenMalzemeler;
        private System.Windows.Forms.ListBox lstMalzemeler;
    }
}