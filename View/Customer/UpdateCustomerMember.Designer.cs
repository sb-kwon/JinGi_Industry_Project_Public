namespace View
{
    partial class UpdateCustomerMember
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CustomerNo = new System.Windows.Forms.TextBox();
            this.Cb_CM_Rank = new System.Windows.Forms.ComboBox();
            this.txt_CM_Number = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_CM_Rank = new System.Windows.Forms.Label();
            this.txt_CM_Name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_CM_Name = new System.Windows.Forms.Label();
            this.lbl_C_Name = new System.Windows.Forms.Label();
            this.lbl_CM_Number = new System.Windows.Forms.Label();
            this.txt_CM_Memo = new System.Windows.Forms.TextBox();
            this.txt_CM_Mail = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_CM_Mail = new System.Windows.Forms.Label();
            this.lbl_CM_Memo = new System.Windows.Forms.Label();
            this.lbl_CM_No = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(699, 184);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(83, 33);
            this.btn_Close.TabIndex = 223;
            this.btn_Close.Text = "√ 닫 기";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Update.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Location = new System.Drawing.Point(608, 184);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(83, 33);
            this.btn_Update.TabIndex = 222;
            this.btn_Update.Text = "↺ 수 정";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 30);
            this.label1.TabIndex = 221;
            this.label1.Text = "※ Update Customer Member List";
            // 
            // txt_CustomerNo
            // 
            this.txt_CustomerNo.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CustomerNo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CustomerNo.Location = new System.Drawing.Point(136, 56);
            this.txt_CustomerNo.Name = "txt_CustomerNo";
            this.txt_CustomerNo.ReadOnly = true;
            this.txt_CustomerNo.Size = new System.Drawing.Size(255, 27);
            this.txt_CustomerNo.TabIndex = 244;
            // 
            // Cb_CM_Rank
            // 
            this.Cb_CM_Rank.BackColor = System.Drawing.SystemColors.Window;
            this.Cb_CM_Rank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_CM_Rank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cb_CM_Rank.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.Cb_CM_Rank.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Cb_CM_Rank.FormattingEnabled = true;
            this.Cb_CM_Rank.ItemHeight = 20;
            this.Cb_CM_Rank.Location = new System.Drawing.Point(136, 99);
            this.Cb_CM_Rank.Name = "Cb_CM_Rank";
            this.Cb_CM_Rank.Size = new System.Drawing.Size(255, 28);
            this.Cb_CM_Rank.TabIndex = 243;
            // 
            // txt_CM_Number
            // 
            this.txt_CM_Number.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CM_Number.Location = new System.Drawing.Point(527, 100);
            this.txt_CM_Number.Name = "txt_CM_Number";
            this.txt_CM_Number.Size = new System.Drawing.Size(255, 27);
            this.txt_CM_Number.TabIndex = 237;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(5, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 1);
            this.panel2.TabIndex = 232;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(6, 134);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 1);
            this.panel3.TabIndex = 233;
            // 
            // lbl_CM_Rank
            // 
            this.lbl_CM_Rank.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Rank.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Rank.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Rank.Location = new System.Drawing.Point(6, 91);
            this.lbl_CM_Rank.Name = "lbl_CM_Rank";
            this.lbl_CM_Rank.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Rank.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Rank.TabIndex = 235;
            this.lbl_CM_Rank.Text = "   직 급   ";
            this.lbl_CM_Rank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CM_Name
            // 
            this.txt_CM_Name.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CM_Name.Location = new System.Drawing.Point(527, 56);
            this.txt_CM_Name.Name = "txt_CM_Name";
            this.txt_CM_Name.Size = new System.Drawing.Size(255, 27);
            this.txt_CM_Name.TabIndex = 234;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(6, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 1);
            this.panel1.TabIndex = 231;
            // 
            // lbl_CM_Name
            // 
            this.lbl_CM_Name.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Name.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Name.Location = new System.Drawing.Point(397, 48);
            this.lbl_CM_Name.Name = "lbl_CM_Name";
            this.lbl_CM_Name.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Name.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Name.TabIndex = 230;
            this.lbl_CM_Name.Text = "담당자명";
            this.lbl_CM_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_C_Name
            // 
            this.lbl_C_Name.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_C_Name.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_C_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_C_Name.Location = new System.Drawing.Point(6, 48);
            this.lbl_C_Name.Name = "lbl_C_Name";
            this.lbl_C_Name.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_C_Name.Size = new System.Drawing.Size(124, 44);
            this.lbl_C_Name.TabIndex = 229;
            this.lbl_C_Name.Text = "고유번호";
            this.lbl_C_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CM_Number
            // 
            this.lbl_CM_Number.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Number.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Number.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Number.Location = new System.Drawing.Point(397, 91);
            this.lbl_CM_Number.Name = "lbl_CM_Number";
            this.lbl_CM_Number.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Number.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Number.TabIndex = 236;
            this.lbl_CM_Number.Text = "전화 번호";
            this.lbl_CM_Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CM_Memo
            // 
            this.txt_CM_Memo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CM_Memo.Location = new System.Drawing.Point(527, 143);
            this.txt_CM_Memo.Name = "txt_CM_Memo";
            this.txt_CM_Memo.Size = new System.Drawing.Size(255, 27);
            this.txt_CM_Memo.TabIndex = 242;
            // 
            // txt_CM_Mail
            // 
            this.txt_CM_Mail.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CM_Mail.Location = new System.Drawing.Point(136, 143);
            this.txt_CM_Mail.Name = "txt_CM_Mail";
            this.txt_CM_Mail.Size = new System.Drawing.Size(255, 27);
            this.txt_CM_Mail.TabIndex = 241;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel4.Location = new System.Drawing.Point(6, 177);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(780, 1);
            this.panel4.TabIndex = 238;
            // 
            // lbl_CM_Mail
            // 
            this.lbl_CM_Mail.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Mail.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Mail.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Mail.Location = new System.Drawing.Point(6, 134);
            this.lbl_CM_Mail.Name = "lbl_CM_Mail";
            this.lbl_CM_Mail.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Mail.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Mail.TabIndex = 239;
            this.lbl_CM_Mail.Text = "  E-Mail  ";
            this.lbl_CM_Mail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CM_Memo
            // 
            this.lbl_CM_Memo.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Memo.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Memo.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Memo.Location = new System.Drawing.Point(397, 134);
            this.lbl_CM_Memo.Name = "lbl_CM_Memo";
            this.lbl_CM_Memo.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Memo.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Memo.TabIndex = 240;
            this.lbl_CM_Memo.Text = "   메 모   ";
            this.lbl_CM_Memo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CM_No
            // 
            this.lbl_CM_No.AutoSize = true;
            this.lbl_CM_No.Location = new System.Drawing.Point(748, 4);
            this.lbl_CM_No.Name = "lbl_CM_No";
            this.lbl_CM_No.Size = new System.Drawing.Size(38, 12);
            this.lbl_CM_No.TabIndex = 245;
            this.lbl_CM_No.Text = "label2";
            this.lbl_CM_No.Visible = false;
            // 
            // UpdateCustomerMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(790, 225);
            this.Controls.Add(this.lbl_CM_No);
            this.Controls.Add(this.txt_CustomerNo);
            this.Controls.Add(this.Cb_CM_Rank);
            this.Controls.Add(this.txt_CM_Number);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbl_CM_Rank);
            this.Controls.Add(this.txt_CM_Name);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_CM_Name);
            this.Controls.Add(this.lbl_C_Name);
            this.Controls.Add(this.lbl_CM_Number);
            this.Controls.Add(this.txt_CM_Memo);
            this.Controls.Add(this.txt_CM_Mail);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbl_CM_Mail);
            this.Controls.Add(this.lbl_CM_Memo);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateCustomerMember";
            this.Text = "UpdateCustomerMember";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CustomerNo;
        private System.Windows.Forms.ComboBox Cb_CM_Rank;
        private System.Windows.Forms.TextBox txt_CM_Number;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_CM_Rank;
        private System.Windows.Forms.TextBox txt_CM_Name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_CM_Name;
        private System.Windows.Forms.Label lbl_C_Name;
        private System.Windows.Forms.Label lbl_CM_Number;
        private System.Windows.Forms.TextBox txt_CM_Memo;
        private System.Windows.Forms.TextBox txt_CM_Mail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_CM_Mail;
        private System.Windows.Forms.Label lbl_CM_Memo;
        private System.Windows.Forms.Label lbl_CM_No;
    }
}