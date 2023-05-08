namespace View
{
    partial class MemberDeleteAlram
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
            this.Btn_Confirm_1 = new System.Windows.Forms.Button();
            this.lbl_Content_1 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Confirm_1
            // 
            this.Btn_Confirm_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.Btn_Confirm_1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Confirm_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.Btn_Confirm_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Confirm_1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Btn_Confirm_1.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Confirm_1.Location = new System.Drawing.Point(70, 173);
            this.Btn_Confirm_1.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Confirm_1.Name = "Btn_Confirm_1";
            this.Btn_Confirm_1.Size = new System.Drawing.Size(97, 37);
            this.Btn_Confirm_1.TabIndex = 3;
            this.Btn_Confirm_1.Text = "확인";
            this.Btn_Confirm_1.UseVisualStyleBackColor = false;
            this.Btn_Confirm_1.Click += new System.EventHandler(this.Btn_Confirm_1_Click);
            // 
            // lbl_Content_1
            // 
            this.lbl_Content_1.Font = new System.Drawing.Font("Calibri", 12F);
            this.lbl_Content_1.Location = new System.Drawing.Point(7, 9);
            this.lbl_Content_1.Name = "lbl_Content_1";
            this.lbl_Content_1.Size = new System.Drawing.Size(352, 148);
            this.lbl_Content_1.TabIndex = 2;
            this.lbl_Content_1.Text = "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
            this.lbl_Content_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_Close.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Close.Location = new System.Drawing.Point(195, 173);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(97, 37);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "취소";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // MemberDeleteAlram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(366, 219);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.Btn_Confirm_1);
            this.Controls.Add(this.lbl_Content_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MemberDeleteAlram";
            this.Text = "Alarm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MemberDeleteAlram_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MemberDeleteAlram_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Confirm_1;
        private System.Windows.Forms.Label lbl_Content_1;
        private System.Windows.Forms.Button btn_Close;
    }
}