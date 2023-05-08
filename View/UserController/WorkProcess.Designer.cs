namespace View.UserController
{
    partial class WorkProcess
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_State = new System.Windows.Forms.Label();
            this.lbl_Bcr = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_Memo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_State, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Bcr, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(167, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 62);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // lbl_State
            // 
            this.lbl_State.BackColor = System.Drawing.Color.Teal;
            this.lbl_State.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_State.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_State.Location = new System.Drawing.Point(3, 31);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(194, 31);
            this.lbl_State.TabIndex = 5;
            this.lbl_State.Text = "상태값";
            this.lbl_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Bcr
            // 
            this.lbl_Bcr.BackColor = System.Drawing.Color.Teal;
            this.lbl_Bcr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Bcr.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Bcr.Location = new System.Drawing.Point(3, 0);
            this.lbl_Bcr.Name = "lbl_Bcr";
            this.lbl_Bcr.Size = new System.Drawing.Size(194, 31);
            this.lbl_Bcr.TabIndex = 4;
            this.lbl_Bcr.Text = "바코드 번호";
            this.lbl_Bcr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(793, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 62);
            this.button1.TabIndex = 5;
            this.button1.Text = "폐 기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // tb_Memo
            // 
            this.tb_Memo.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Memo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Memo.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Memo.Font = new System.Drawing.Font("맑은 고딕", 12.25F);
            this.tb_Memo.Location = new System.Drawing.Point(367, 0);
            this.tb_Memo.Multiline = true;
            this.tb_Memo.Name = "tb_Memo";
            this.tb_Memo.ReadOnly = true;
            this.tb_Memo.Size = new System.Drawing.Size(426, 62);
            this.tb_Memo.TabIndex = 7;
            // 
            // WorkProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_Memo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "WorkProcess";
            this.Size = new System.Drawing.Size(850, 62);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.Label lbl_Bcr;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_Memo;
    }
}
