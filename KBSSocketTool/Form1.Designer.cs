﻿namespace KBSSocketTool
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbRxd = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbTxd = new System.Windows.Forms.RichTextBox();
            this.TbTelegram = new System.Windows.Forms.TextBox();
            this.CmdSende = new System.Windows.Forms.Button();
            this.CmdInsertEsc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbRxd
            // 
            this.TbRxd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TbRxd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TbRxd.Location = new System.Drawing.Point(12, 45);
            this.TbRxd.Name = "TbRxd";
            this.TbRxd.ReadOnly = true;
            this.TbRxd.Size = new System.Drawing.Size(435, 472);
            this.TbRxd.TabIndex = 0;
            this.TbRxd.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "RXD";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(663, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "TXD";
            // 
            // TbTxd
            // 
            this.TbTxd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbTxd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TbTxd.Location = new System.Drawing.Point(468, 45);
            this.TbTxd.Name = "TbTxd";
            this.TbTxd.ReadOnly = true;
            this.TbTxd.Size = new System.Drawing.Size(435, 472);
            this.TbTxd.TabIndex = 3;
            this.TbTxd.Text = "";
            // 
            // TbTelegram
            // 
            this.TbTelegram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TbTelegram.Location = new System.Drawing.Point(12, 535);
            this.TbTelegram.Name = "TbTelegram";
            this.TbTelegram.Size = new System.Drawing.Size(435, 20);
            this.TbTelegram.TabIndex = 4;
            // 
            // CmdSende
            // 
            this.CmdSende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdSende.Location = new System.Drawing.Point(453, 533);
            this.CmdSende.Name = "CmdSende";
            this.CmdSende.Size = new System.Drawing.Size(75, 23);
            this.CmdSende.TabIndex = 5;
            this.CmdSende.Text = "Sende";
            this.CmdSende.UseVisualStyleBackColor = true;
            this.CmdSende.Click += new System.EventHandler(this.CmdSende_Click);
            // 
            // CmdInsertEsc
            // 
            this.CmdInsertEsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdInsertEsc.Location = new System.Drawing.Point(534, 533);
            this.CmdInsertEsc.Name = "CmdInsertEsc";
            this.CmdInsertEsc.Size = new System.Drawing.Size(75, 23);
            this.CmdInsertEsc.TabIndex = 6;
            this.CmdInsertEsc.Text = "Insert<ESC>";
            this.CmdInsertEsc.UseVisualStyleBackColor = true;
            this.CmdInsertEsc.Click += new System.EventHandler(this.CmdInsertEsc_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.CmdSende;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 567);
            this.Controls.Add(this.CmdInsertEsc);
            this.Controls.Add(this.CmdSende);
            this.Controls.Add(this.TbTelegram);
            this.Controls.Add(this.TbTxd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbRxd);
            this.Name = "Form1";
            this.Text = "KBSSocketTool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TbRxd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TbTxd;
        private System.Windows.Forms.TextBox TbTelegram;
        private System.Windows.Forms.Button CmdSende;
        private System.Windows.Forms.Button CmdInsertEsc;
    }
}

