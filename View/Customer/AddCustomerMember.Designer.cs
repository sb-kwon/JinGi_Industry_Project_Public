namespace View
{
    partial class AddCustomerMember
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
            this.txt_CM_Name = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_CM_Name = new System.Windows.Forms.Label();
            this.lbl_C_Name = new System.Windows.Forms.Label();
            this.Btn_CM_Add = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_CM_Rank = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_CM_Number = new System.Windows.Forms.Label();
            this.txt_CM_Number = new System.Windows.Forms.TextBox();
            this.txt_CM_Memo = new System.Windows.Forms.TextBox();
            this.txt_CM_Mail = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_CM_Mail = new System.Windows.Forms.Label();
            this.lbl_CM_Memo = new System.Windows.Forms.Label();
            this.Cb_CM_Rank = new System.Windows.Forms.ComboBox();
            this.txt_CustomerNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 30);
            this.label1.TabIndex = 208;
            this.label1.Text = "※ Add Customer Manager";
            // 
            // txt_CM_Name
            // 
            this.txt_CM_Name.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CM_Name.Location = new System.Drawing.Point(493, 48);
            this.txt_CM_Name.Name = "txt_CM_Name";
            this.txt_CM_Name.Size = new System.Drawing.Size(220, 27);
            this.txt_CM_Name.TabIndex = 215;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(6, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 1);
            this.panel2.TabIndex = 214;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(7, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 1);
            this.panel1.TabIndex = 213;
            // 
            // lbl_CM_Name
            // 
            this.lbl_CM_Name.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Name.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Name.Location = new System.Drawing.Point(363, 41);
            this.lbl_CM_Name.Name = "lbl_CM_Name";
            this.lbl_CM_Name.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Name.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Name.TabIndex = 212;
            this.lbl_CM_Name.Text = "담당자명";
            this.lbl_CM_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_C_Name
            // 
            this.lbl_C_Name.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_C_Name.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_C_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_C_Name.Location = new System.Drawing.Point(7, 41);
            this.lbl_C_Name.Name = "lbl_C_Name";
            this.lbl_C_Name.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_C_Name.Size = new System.Drawing.Size(124, 44);
            this.lbl_C_Name.TabIndex = 211;
            this.lbl_C_Name.Text = "고유 번호";
            this.lbl_C_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_CM_Add
            // 
            this.Btn_CM_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_CM_Add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_CM_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_CM_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_CM_Add.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.Btn_CM_Add.ForeColor = System.Drawing.Color.White;
            this.Btn_CM_Add.Location = new System.Drawing.Point(541, 181);
            this.Btn_CM_Add.Name = "Btn_CM_Add";
            this.Btn_CM_Add.Size = new System.Drawing.Size(83, 33);
            this.Btn_CM_Add.TabIndex = 216;
            this.Btn_CM_Add.Text = "↺ 추 가";
            this.Btn_CM_Add.UseVisualStyleBackColor = false;
            this.Btn_CM_Add.Click += new System.EventHandler(this.Btn_C_Add_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(630, 181);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(83, 33);
            this.btn_Close.TabIndex = 217;
            this.btn_Close.Text = "√ 닫 기";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_CM_Rank
            // 
            this.lbl_CM_Rank.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Rank.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Rank.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Rank.Location = new System.Drawing.Point(7, 84);
            this.lbl_CM_Rank.Name = "lbl_CM_Rank";
            this.lbl_CM_Rank.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Rank.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Rank.TabIndex = 218;
            this.lbl_CM_Rank.Text = "   직 급   ";
            this.lbl_CM_Rank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(7, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(707, 1);
            this.panel3.TabIndex = 215;
            // 
            // lbl_CM_Number
            // 
            this.lbl_CM_Number.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Number.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Number.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Number.Location = new System.Drawing.Point(363, 84);
            this.lbl_CM_Number.Name = "lbl_CM_Number";
            this.lbl_CM_Number.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Number.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Number.TabIndex = 219;
            this.lbl_CM_Number.Text = "전화번호";
            this.lbl_CM_Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CM_Number
            // 
            this.txt_CM_Number.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CM_Number.Location = new System.Drawing.Point(493, 94);
            this.txt_CM_Number.Name = "txt_CM_Number";
            this.txt_CM_Number.Size = new System.Drawing.Size(220, 27);
            this.txt_CM_Number.TabIndex = 221;
            // 
            // txt_CM_Memo
            // 
            this.txt_CM_Memo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CM_Memo.Location = new System.Drawing.Point(493, 137);
            this.txt_CM_Memo.Name = "txt_CM_Memo";
            this.txt_CM_Memo.Size = new System.Drawing.Size(220, 27);
            this.txt_CM_Memo.TabIndex = 226;
            // 
            // txt_CM_Mail
            // 
            this.txt_CM_Mail.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CM_Mail.Location = new System.Drawing.Point(137, 137);
            this.txt_CM_Mail.Name = "txt_CM_Mail";
            this.txt_CM_Mail.Size = new System.Drawing.Size(220, 27);
            this.txt_CM_Mail.TabIndex = 225;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel4.Location = new System.Drawing.Point(7, 170);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(707, 1);
            this.panel4.TabIndex = 222;
            // 
            // lbl_CM_Mail
            // 
            this.lbl_CM_Mail.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Mail.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Mail.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Mail.Location = new System.Drawing.Point(7, 127);
            this.lbl_CM_Mail.Name = "lbl_CM_Mail";
            this.lbl_CM_Mail.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Mail.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Mail.TabIndex = 223;
            this.lbl_CM_Mail.Text = "  E-Mail  ";
            this.lbl_CM_Mail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CM_Memo
            // 
            this.lbl_CM_Memo.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CM_Memo.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_CM_Memo.ForeColor = System.Drawing.Color.Black;
            this.lbl_CM_Memo.Location = new System.Drawing.Point(363, 127);
            this.lbl_CM_Memo.Name = "lbl_CM_Memo";
            this.lbl_CM_Memo.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_CM_Memo.Size = new System.Drawing.Size(124, 44);
            this.lbl_CM_Memo.TabIndex = 224;
            this.lbl_CM_Memo.Text = "   메 모   ";
            this.lbl_CM_Memo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Cb_CM_Rank.Location = new System.Drawing.Point(137, 94);
            this.Cb_CM_Rank.Name = "Cb_CM_Rank";
            this.Cb_CM_Rank.Size = new System.Drawing.Size(220, 28);
            this.Cb_CM_Rank.TabIndex = 227;
            // 
            // txt_CustomerNo
            // 
            this.txt_CustomerNo.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CustomerNo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txt_CustomerNo.Location = new System.Drawing.Point(137, 48);
            this.txt_CustomerNo.Name = "txt_CustomerNo";
            this.txt_CustomerNo.ReadOnly = true;
            this.txt_CustomerNo.Size = new System.Drawing.Size(220, 27);
            this.txt_CustomerNo.TabIndex = 228;
            // 
            // AddCustomerMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(722, 221);
            this.Controls.Add(this.txt_CustomerNo);
            this.Controls.Add(this.Cb_CM_Rank);
            this.Controls.Add(this.txt_CM_Number);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbl_CM_Rank);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.Btn_CM_Add);
            this.Controls.Add(this.txt_CM_Name);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_CM_Name);
            this.Controls.Add(this.lbl_C_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_CM_Number);
            this.Controls.Add(this.txt_CM_Memo);
            this.Controls.Add(this.txt_CM_Mail);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbl_CM_Mail);
            this.Controls.Add(this.lbl_CM_Memo);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCustomerMember";
            this.Text = "AddCustomer";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddCustomerMember_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AddCustomerMember_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CM_Name;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_CM_Name;
        private System.Windows.Forms.Label lbl_C_Name;
        private System.Windows.Forms.Button Btn_CM_Add;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_CM_Rank;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_CM_Number;
        private System.Windows.Forms.TextBox txt_CM_Number;
        private System.Windows.Forms.TextBox txt_CM_Memo;
        private System.Windows.Forms.TextBox txt_CM_Mail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_CM_Mail;
        private System.Windows.Forms.Label lbl_CM_Memo;
        private System.Windows.Forms.ComboBox Cb_CM_Rank;
        private System.Windows.Forms.TextBox txt_CustomerNo;
    }
}