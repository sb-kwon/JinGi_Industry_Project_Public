﻿namespace View
{
    partial class Print_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label19 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Memo = new System.Windows.Forms.Label();
            this.lbl_State = new System.Windows.Forms.Label();
            this.lbl_No = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_Order = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.pic_Print = new System.Windows.Forms.PictureBox();
            this.pic_BCR = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BCR)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.SystemColors.Window;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(899, 43);
            this.label19.TabIndex = 170;
            this.label19.Text = " 미리보기";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(202, 100);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(602, 416);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.pnl_Order);
            this.panel3.Controls.Add(this.label32);
            this.panel3.Location = new System.Drawing.Point(-1, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(898, 788);
            this.panel3.TabIndex = 174;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Memo);
            this.panel1.Controls.Add(this.lbl_State);
            this.panel1.Controls.Add(this.lbl_No);
            this.panel1.Controls.Add(this.pic_BCR);
            this.panel1.Location = new System.Drawing.Point(6, 716);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 69);
            this.panel1.TabIndex = 310;
            // 
            // lbl_Memo
            // 
            this.lbl_Memo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lbl_Memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Memo.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_Memo.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Memo.Location = new System.Drawing.Point(365, 3);
            this.lbl_Memo.Name = "lbl_Memo";
            this.lbl_Memo.Size = new System.Drawing.Size(522, 62);
            this.lbl_Memo.TabIndex = 314;
            this.lbl_Memo.Text = "Memo";
            // 
            // lbl_State
            // 
            this.lbl_State.BackColor = System.Drawing.Color.Teal;
            this.lbl_State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_State.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_State.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_State.Location = new System.Drawing.Point(169, 34);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(194, 31);
            this.lbl_State.TabIndex = 313;
            this.lbl_State.Text = "상태";
            this.lbl_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_No
            // 
            this.lbl_No.BackColor = System.Drawing.Color.Teal;
            this.lbl_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_No.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_No.Location = new System.Drawing.Point(169, 3);
            this.lbl_No.Name = "lbl_No";
            this.lbl_No.Size = new System.Drawing.Size(194, 31);
            this.lbl_No.TabIndex = 312;
            this.lbl_No.Text = "바코드 번호";
            this.lbl_No.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.Column5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.Column1,
            this.dataGridViewTextBoxColumn13});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(5, 250);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(890, 460);
            this.dataGridView1.TabIndex = 308;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "공정순서";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "공정 분류";
            this.Column5.Name = "Column5";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "공정명";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "공정진행상태";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "작업자";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "장비명";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "검사상태";
            this.Column1.Name = "Column1";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "메모";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // pnl_Order
            // 
            this.pnl_Order.Location = new System.Drawing.Point(3, 4);
            this.pnl_Order.Name = "pnl_Order";
            this.pnl_Order.Size = new System.Drawing.Size(892, 240);
            this.pnl_Order.TabIndex = 307;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label32.Location = new System.Drawing.Point(1053, 500);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(22, 21);
            this.label32.TabIndex = 283;
            this.label32.Text = "\\";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.btn_Exit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Exit.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Exit.Location = new System.Drawing.Point(861, 7);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(28, 29);
            this.btn_Exit.TabIndex = 175;
            this.btn_Exit.Text = "X";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.button2_Click);
            // 
            // pic_Print
            // 
            this.pic_Print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.pic_Print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Print.Image = global::View.Properties.Resources.Pint;
            this.pic_Print.Location = new System.Drawing.Point(809, 7);
            this.pic_Print.Name = "pic_Print";
            this.pic_Print.Size = new System.Drawing.Size(68, 29);
            this.pic_Print.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Print.TabIndex = 176;
            this.pic_Print.TabStop = false;
            this.pic_Print.Click += new System.EventHandler(this.pic_Print_Click);
            // 
            // pic_BCR
            // 
            this.pic_BCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_BCR.Location = new System.Drawing.Point(0, 4);
            this.pic_BCR.Name = "pic_BCR";
            this.pic_BCR.Size = new System.Drawing.Size(167, 62);
            this.pic_BCR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_BCR.TabIndex = 311;
            this.pic_BCR.TabStop = false;
            // 
            // Print_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(901, 835);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.pic_Print);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Print_Form";
            this.Text = "StatementForm";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BCR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label32;
        private UserController.WorkProcess workProcess1;
        private System.Windows.Forms.Panel pnl_Order;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.Label lbl_No;
        private System.Windows.Forms.PictureBox pic_BCR;
        private System.Windows.Forms.Label lbl_Memo;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox pic_Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    }
}