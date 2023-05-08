namespace View
{
    partial class OrderShipmentUpdate
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
            this.lbl_OrderNo = new System.Windows.Forms.Label();
            this.tb_OrderName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_CM_Rank = new System.Windows.Forms.Label();
            this.tb_OrderPrice = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_CM_Name = new System.Windows.Forms.Label();
            this.lbl_C_Name = new System.Windows.Forms.Label();
            this.tb_OrderMemo = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_OrderDateEnd = new System.Windows.Forms.Label();
            this.lbl_CustomerMemberName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_OrderNo
            // 
            this.lbl_OrderNo.AutoSize = true;
            this.lbl_OrderNo.Location = new System.Drawing.Point(748, 4);
            this.lbl_OrderNo.Name = "lbl_OrderNo";
            this.lbl_OrderNo.Size = new System.Drawing.Size(38, 12);
            this.lbl_OrderNo.TabIndex = 0;
            this.lbl_OrderNo.Text = "label1";
            this.lbl_OrderNo.Visible = false;
            // 
            // tb_OrderName
            // 
            this.tb_OrderName.BackColor = System.Drawing.SystemColors.Window;
            this.tb_OrderName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_OrderName.Location = new System.Drawing.Point(136, 56);
            this.tb_OrderName.Name = "tb_OrderName";
            this.tb_OrderName.ReadOnly = true;
            this.tb_OrderName.Size = new System.Drawing.Size(255, 27);
            this.tb_OrderName.TabIndex = 263;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(5, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 1);
            this.panel2.TabIndex = 251;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(6, 134);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 1);
            this.panel3.TabIndex = 252;
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
            this.lbl_CM_Rank.TabIndex = 254;
            this.lbl_CM_Rank.Text = "메모";
            this.lbl_CM_Rank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_OrderPrice
            // 
            this.tb_OrderPrice.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_OrderPrice.Location = new System.Drawing.Point(527, 56);
            this.tb_OrderPrice.Name = "tb_OrderPrice";
            this.tb_OrderPrice.Size = new System.Drawing.Size(234, 27);
            this.tb_OrderPrice.TabIndex = 253;
            this.tb_OrderPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_OrderPrice.TextChanged += new System.EventHandler(this.tb_OrderPrice_TextChanged);
            this.tb_OrderPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_OrderPrice_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(6, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 1);
            this.panel1.TabIndex = 250;
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
            this.lbl_CM_Name.TabIndex = 249;
            this.lbl_CM_Name.Text = "수주 금액";
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
            this.lbl_C_Name.TabIndex = 248;
            this.lbl_C_Name.Text = "수주명";
            this.lbl_C_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_OrderMemo
            // 
            this.tb_OrderMemo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_OrderMemo.Location = new System.Drawing.Point(136, 100);
            this.tb_OrderMemo.Name = "tb_OrderMemo";
            this.tb_OrderMemo.Size = new System.Drawing.Size(642, 27);
            this.tb_OrderMemo.TabIndex = 261;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(695, 141);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(83, 33);
            this.btn_Close.TabIndex = 247;
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
            this.btn_Update.Location = new System.Drawing.Point(604, 141);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(83, 33);
            this.btn_Update.TabIndex = 246;
            this.btn_Update.Text = "↺ 수 정";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 30);
            this.label2.TabIndex = 245;
            this.label2.Text = "※ Update Order Price＆Memo";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(761, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 27);
            this.label3.TabIndex = 264;
            this.label3.Text = "원";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_OrderDateEnd
            // 
            this.lbl_OrderDateEnd.AutoSize = true;
            this.lbl_OrderDateEnd.Location = new System.Drawing.Point(704, 4);
            this.lbl_OrderDateEnd.Name = "lbl_OrderDateEnd";
            this.lbl_OrderDateEnd.Size = new System.Drawing.Size(38, 12);
            this.lbl_OrderDateEnd.TabIndex = 265;
            this.lbl_OrderDateEnd.Text = "label1";
            this.lbl_OrderDateEnd.Visible = false;
            // 
            // lbl_CustomerMemberName
            // 
            this.lbl_CustomerMemberName.AutoSize = true;
            this.lbl_CustomerMemberName.Location = new System.Drawing.Point(660, 4);
            this.lbl_CustomerMemberName.Name = "lbl_CustomerMemberName";
            this.lbl_CustomerMemberName.Size = new System.Drawing.Size(38, 12);
            this.lbl_CustomerMemberName.TabIndex = 266;
            this.lbl_CustomerMemberName.Text = "label1";
            this.lbl_CustomerMemberName.Visible = false;
            // 
            // OrderShipmentUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(790, 178);
            this.Controls.Add(this.lbl_CustomerMemberName);
            this.Controls.Add(this.lbl_OrderDateEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_OrderName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbl_CM_Rank);
            this.Controls.Add(this.tb_OrderPrice);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_CM_Name);
            this.Controls.Add(this.lbl_C_Name);
            this.Controls.Add(this.tb_OrderMemo);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_OrderNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderShipmentUpdate";
            this.Text = "OrderShipmentUpdate";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OrderShipmentUpdate_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OrderShipmentUpdate_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_OrderNo;
        private System.Windows.Forms.TextBox tb_OrderName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_CM_Rank;
        private System.Windows.Forms.TextBox tb_OrderPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_CM_Name;
        private System.Windows.Forms.Label lbl_C_Name;
        private System.Windows.Forms.TextBox tb_OrderMemo;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_OrderDateEnd;
        private System.Windows.Forms.Label lbl_CustomerMemberName;
    }
}