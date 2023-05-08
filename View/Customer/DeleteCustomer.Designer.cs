namespace View
{
    partial class DeleteCustomer
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
            this.lbl_Content = new System.Windows.Forms.Label();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Btn_Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Content
            // 
            this.lbl_Content.Font = new System.Drawing.Font("Calibri", 12F);
            this.lbl_Content.Location = new System.Drawing.Point(7, 9);
            this.lbl_Content.Name = "lbl_Content";
            this.lbl_Content.Size = new System.Drawing.Size(352, 148);
            this.lbl_Content.TabIndex = 2;
            this.lbl_Content.Text = "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
            this.lbl_Content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.Btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Btn_Close.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Close.Location = new System.Drawing.Point(195, 173);
            this.Btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(97, 37);
            this.Btn_Close.TabIndex = 6;
            this.Btn_Close.Text = "취소";
            this.Btn_Close.UseVisualStyleBackColor = false;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Btn_Confirm
            // 
            this.Btn_Confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.Btn_Confirm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Confirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.Btn_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Confirm.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Btn_Confirm.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Confirm.Location = new System.Drawing.Point(70, 173);
            this.Btn_Confirm.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Confirm.Name = "Btn_Confirm";
            this.Btn_Confirm.Size = new System.Drawing.Size(97, 37);
            this.Btn_Confirm.TabIndex = 5;
            this.Btn_Confirm.Text = "확인";
            this.Btn_Confirm.UseVisualStyleBackColor = false;
            this.Btn_Confirm.Click += new System.EventHandler(this.Btn_Confirm_Click);
            // 
            // DeleteCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(366, 219);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.Btn_Confirm);
            this.Controls.Add(this.lbl_Content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteCustomer";
            this.Text = "Alarm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeleteCustomer_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DeleteCustomer_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_Content;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Button Btn_Confirm;
    }
}