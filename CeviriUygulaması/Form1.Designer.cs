namespace CeviriUygulamasi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtKaynakMetin = new System.Windows.Forms.TextBox();
            this.cmbKaynakDil = new System.Windows.Forms.ComboBox();
            this.txtCeviriSonucu = new System.Windows.Forms.TextBox();
            this.cmbHedefDil = new System.Windows.Forms.ComboBox();
            this.btnCevir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKaynakMetin
            // 
            this.txtKaynakMetin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKaynakMetin.BackColor = System.Drawing.Color.FloralWhite;
            this.txtKaynakMetin.Location = new System.Drawing.Point(-1, 88);
            this.txtKaynakMetin.Multiline = true;
            this.txtKaynakMetin.Name = "txtKaynakMetin";
            this.txtKaynakMetin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKaynakMetin.Size = new System.Drawing.Size(400, 168);
            this.txtKaynakMetin.TabIndex = 0;
            // 
            // cmbKaynakDil
            // 
            this.cmbKaynakDil.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmbKaynakDil.FormattingEnabled = true;
            this.cmbKaynakDil.Location = new System.Drawing.Point(-1, 0);
            this.cmbKaynakDil.Name = "cmbKaynakDil";
            this.cmbKaynakDil.Size = new System.Drawing.Size(121, 24);
            this.cmbKaynakDil.TabIndex = 1;
            // 
            // txtCeviriSonucu
            // 
            this.txtCeviriSonucu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCeviriSonucu.BackColor = System.Drawing.Color.FloralWhite;
            this.txtCeviriSonucu.Location = new System.Drawing.Point(427, 88);
            this.txtCeviriSonucu.Multiline = true;
            this.txtCeviriSonucu.Name = "txtCeviriSonucu";
            this.txtCeviriSonucu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCeviriSonucu.Size = new System.Drawing.Size(373, 168);
            this.txtCeviriSonucu.TabIndex = 2;
            // 
            // cmbHedefDil
            // 
            this.cmbHedefDil.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmbHedefDil.FormattingEnabled = true;
            this.cmbHedefDil.Location = new System.Drawing.Point(678, 0);
            this.cmbHedefDil.Name = "cmbHedefDil";
            this.cmbHedefDil.Size = new System.Drawing.Size(121, 24);
            this.cmbHedefDil.TabIndex = 3;
            // 
            // btnCevir
            // 
            this.btnCevir.BackColor = System.Drawing.Color.FloralWhite;
            this.btnCevir.Location = new System.Drawing.Point(330, 308);
            this.btnCevir.Name = "btnCevir";
            this.btnCevir.Size = new System.Drawing.Size(154, 45);
            this.btnCevir.TabIndex = 4;
            this.btnCevir.Text = "Çevir";
            this.btnCevir.UseVisualStyleBackColor = false;
            this.btnCevir.Click += new System.EventHandler(this.btnCevir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCevir);
            this.Controls.Add(this.cmbHedefDil);
            this.Controls.Add(this.txtCeviriSonucu);
            this.Controls.Add(this.cmbKaynakDil);
            this.Controls.Add(this.txtKaynakMetin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKaynakMetin;
        private System.Windows.Forms.ComboBox cmbKaynakDil;
        private System.Windows.Forms.TextBox txtCeviriSonucu;
        private System.Windows.Forms.ComboBox cmbHedefDil;
        private System.Windows.Forms.Button btnCevir;
    }
}

