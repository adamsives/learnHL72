namespace learnHL72
{
    partial class Start
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
            this.btnCDMCodes = new System.Windows.Forms.Button();
            this.btnHl7 = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.txtCDMCodeFile = new System.Windows.Forms.TextBox();
            this.txtHL7MessageFile = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCDMCodes
            // 
            this.btnCDMCodes.Location = new System.Drawing.Point(12, 111);
            this.btnCDMCodes.Name = "btnCDMCodes";
            this.btnCDMCodes.Size = new System.Drawing.Size(110, 23);
            this.btnCDMCodes.TabIndex = 0;
            this.btnCDMCodes.Text = "Select CDM Codes";
            this.btnCDMCodes.UseVisualStyleBackColor = true;
            this.btnCDMCodes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHl7
            // 
            this.btnHl7.Location = new System.Drawing.Point(12, 172);
            this.btnHl7.Name = "btnHl7";
            this.btnHl7.Size = new System.Drawing.Size(110, 23);
            this.btnHl7.TabIndex = 1;
            this.btnHl7.Text = "Hl7 message file";
            this.btnHl7.UseVisualStyleBackColor = true;
            this.btnHl7.Click += new System.EventHandler(this.Button4_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(43, 226);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.BtnValidate_Click);
            // 
            // txtCDMCodeFile
            // 
            this.txtCDMCodeFile.Location = new System.Drawing.Point(13, 85);
            this.txtCDMCodeFile.Name = "txtCDMCodeFile";
            this.txtCDMCodeFile.ReadOnly = true;
            this.txtCDMCodeFile.Size = new System.Drawing.Size(259, 20);
            this.txtCDMCodeFile.TabIndex = 4;
            // 
            // txtHL7MessageFile
            // 
            this.txtHL7MessageFile.Location = new System.Drawing.Point(12, 146);
            this.txtHL7MessageFile.Name = "txtHL7MessageFile";
            this.txtHL7MessageFile.ReadOnly = true;
            this.txtHL7MessageFile.Size = new System.Drawing.Size(259, 20);
            this.txtHL7MessageFile.TabIndex = 5;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(180, 226);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Tag = "Cancel";
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.txtHL7MessageFile);
            this.Controls.Add(this.txtCDMCodeFile);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnHl7);
            this.Controls.Add(this.btnCDMCodes);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCDMCodes;
        private System.Windows.Forms.Button btnHl7;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.TextBox txtCDMCodeFile;
        private System.Windows.Forms.TextBox txtHL7MessageFile;
        private System.Windows.Forms.Button Cancel;
    }
}