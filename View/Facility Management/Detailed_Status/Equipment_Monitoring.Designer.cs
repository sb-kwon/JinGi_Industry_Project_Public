using System.Drawing;

namespace View
{
    partial class Equipment_Monitoring
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Monitoring = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.circularProgressBar2 = new CircularProgressBar.CircularProgressBar();
            this.circularProgressBar3 = new CircularProgressBar.CircularProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.circularProgressBar4 = new CircularProgressBar.CircularProgressBar();
            this.circularProgressBar5 = new CircularProgressBar.CircularProgressBar();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Monitoring)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Monitoring
            // 
            this.dgv_Monitoring.AllowUserToAddRows = false;
            this.dgv_Monitoring.AllowUserToDeleteRows = false;
            this.dgv_Monitoring.AllowUserToResizeColumns = false;
            this.dgv_Monitoring.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Monitoring.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Monitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Monitoring.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Monitoring.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Monitoring.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Monitoring.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Monitoring.ColumnHeadersHeight = 60;
            this.dgv_Monitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Monitoring.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column6,
            this.Column12});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 100F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Monitoring.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Monitoring.EnableHeadersVisualStyles = false;
            this.dgv_Monitoring.Location = new System.Drawing.Point(3, 0);
            this.dgv_Monitoring.Name = "dgv_Monitoring";
            this.dgv_Monitoring.ReadOnly = true;
            this.dgv_Monitoring.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Monitoring.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Monitoring.RowHeadersVisible = false;
            this.dgv_Monitoring.RowHeadersWidth = 4;
            this.dgv_Monitoring.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.dgv_Monitoring.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_Monitoring.RowTemplate.Height = 157;
            this.dgv_Monitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Monitoring.Size = new System.Drawing.Size(590, 154);
            this.dgv_Monitoring.TabIndex = 1;
            this.dgv_Monitoring.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "장비명";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.FillWeight = 150F;
            this.Column5.HeaderText = "시간";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.FillWeight = 80F;
            this.Column6.HeaderText = "전원/가동상태";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column12
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.Column12.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column12.FillWeight = 80F;
            this.Column12.HeaderText = "센서 값";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Black;
            this.circularProgressBar1.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar1.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar1.InnerColor = System.Drawing.Color.Black;
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(24, 545);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(101)))));
            this.circularProgressBar1.OuterMargin = -20;
            this.circularProgressBar1.OuterWidth = 15;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.Lime;
            this.circularProgressBar1.ProgressWidth = 15;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("맑은 고딕", 15F);
            this.circularProgressBar1.Size = new System.Drawing.Size(370, 370);
            this.circularProgressBar1.StartAngle = 90;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.Silver;
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.circularProgressBar1.SubscriptText = "가동중";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 14;
            this.circularProgressBar1.Tag = "TruLaser3030";
            this.circularProgressBar1.Text = "Machine";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 68;
            // 
            // circularProgressBar2
            // 
            this.circularProgressBar2.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar2.AnimationSpeed = 500;
            this.circularProgressBar2.BackColor = System.Drawing.Color.Black;
            this.circularProgressBar2.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar2.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar2.InnerColor = System.Drawing.Color.Black;
            this.circularProgressBar2.InnerMargin = 2;
            this.circularProgressBar2.InnerWidth = -1;
            this.circularProgressBar2.Location = new System.Drawing.Point(400, 545);
            this.circularProgressBar2.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar2.Name = "circularProgressBar2";
            this.circularProgressBar2.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(101)))));
            this.circularProgressBar2.OuterMargin = -20;
            this.circularProgressBar2.OuterWidth = 15;
            this.circularProgressBar2.ProgressColor = System.Drawing.Color.Lime;
            this.circularProgressBar2.ProgressWidth = 15;
            this.circularProgressBar2.SecondaryFont = new System.Drawing.Font("맑은 고딕", 15F);
            this.circularProgressBar2.Size = new System.Drawing.Size(370, 370);
            this.circularProgressBar2.StartAngle = 90;
            this.circularProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar2.SubscriptColor = System.Drawing.Color.Silver;
            this.circularProgressBar2.SubscriptMargin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.circularProgressBar2.SubscriptText = "";
            this.circularProgressBar2.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar2.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar2.SuperscriptText = "";
            this.circularProgressBar2.TabIndex = 15;
            this.circularProgressBar2.Tag = "TruLaser3030-2";
            this.circularProgressBar2.Text = "Machine";
            this.circularProgressBar2.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar2.Value = 68;
            // 
            // circularProgressBar3
            // 
            this.circularProgressBar3.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar3.AnimationSpeed = 500;
            this.circularProgressBar3.BackColor = System.Drawing.Color.Black;
            this.circularProgressBar3.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar3.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar3.InnerColor = System.Drawing.Color.Black;
            this.circularProgressBar3.InnerMargin = 2;
            this.circularProgressBar3.InnerWidth = -1;
            this.circularProgressBar3.Location = new System.Drawing.Point(1528, 545);
            this.circularProgressBar3.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar3.Name = "circularProgressBar3";
            this.circularProgressBar3.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(101)))));
            this.circularProgressBar3.OuterMargin = -20;
            this.circularProgressBar3.OuterWidth = 15;
            this.circularProgressBar3.ProgressColor = System.Drawing.Color.Lime;
            this.circularProgressBar3.ProgressWidth = 15;
            this.circularProgressBar3.SecondaryFont = new System.Drawing.Font("맑은 고딕", 15F);
            this.circularProgressBar3.Size = new System.Drawing.Size(370, 370);
            this.circularProgressBar3.StartAngle = 90;
            this.circularProgressBar3.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar3.SubscriptColor = System.Drawing.Color.Silver;
            this.circularProgressBar3.SubscriptMargin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.circularProgressBar3.SubscriptText = "";
            this.circularProgressBar3.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar3.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar3.SuperscriptText = "";
            this.circularProgressBar3.TabIndex = 17;
            this.circularProgressBar3.Tag = "CNC-1500";
            this.circularProgressBar3.Text = "Machine";
            this.circularProgressBar3.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar3.Value = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(22, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 30);
            this.label8.TabIndex = 198;
            this.label8.Text = "※ 실시간 모니터링";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Black;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label31);
            this.panel9.Controls.Add(this.label33);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(1809, 9);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(89, 81);
            this.panel9.TabIndex = 199;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Black;
            this.label31.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(20, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(42, 19);
            this.label31.TabIndex = 5;
            this.label31.Tag = "Producing";
            this.label31.Text = "가 동";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Black;
            this.label33.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(16, 39);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(51, 19);
            this.label33.TabIndex = 6;
            this.label33.Tag = "Manual";
            this.label33.Text = "비가동";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.DarkOrange;
            this.panel11.Location = new System.Drawing.Point(10, 63);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(66, 10);
            this.panel11.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Lime;
            this.panel10.Location = new System.Drawing.Point(10, 24);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(66, 10);
            this.panel10.TabIndex = 0;
            // 
            // circularProgressBar4
            // 
            this.circularProgressBar4.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar4.AnimationSpeed = 500;
            this.circularProgressBar4.BackColor = System.Drawing.Color.Black;
            this.circularProgressBar4.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar4.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar4.InnerColor = System.Drawing.Color.Black;
            this.circularProgressBar4.InnerMargin = 2;
            this.circularProgressBar4.InnerWidth = -1;
            this.circularProgressBar4.Location = new System.Drawing.Point(1152, 545);
            this.circularProgressBar4.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar4.Name = "circularProgressBar4";
            this.circularProgressBar4.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(101)))));
            this.circularProgressBar4.OuterMargin = -20;
            this.circularProgressBar4.OuterWidth = 15;
            this.circularProgressBar4.ProgressColor = System.Drawing.Color.Lime;
            this.circularProgressBar4.ProgressWidth = 15;
            this.circularProgressBar4.SecondaryFont = new System.Drawing.Font("맑은 고딕", 15F);
            this.circularProgressBar4.Size = new System.Drawing.Size(370, 370);
            this.circularProgressBar4.StartAngle = 90;
            this.circularProgressBar4.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar4.SubscriptColor = System.Drawing.Color.Silver;
            this.circularProgressBar4.SubscriptMargin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.circularProgressBar4.SubscriptText = "";
            this.circularProgressBar4.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar4.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar4.SuperscriptText = "";
            this.circularProgressBar4.TabIndex = 209;
            this.circularProgressBar4.Tag = "CNC-3000";
            this.circularProgressBar4.Text = "Machine";
            this.circularProgressBar4.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar4.Value = 68;
            // 
            // circularProgressBar5
            // 
            this.circularProgressBar5.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar5.AnimationSpeed = 500;
            this.circularProgressBar5.BackColor = System.Drawing.Color.Black;
            this.circularProgressBar5.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar5.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar5.InnerColor = System.Drawing.Color.Black;
            this.circularProgressBar5.InnerMargin = 2;
            this.circularProgressBar5.InnerWidth = -1;
            this.circularProgressBar5.Location = new System.Drawing.Point(776, 545);
            this.circularProgressBar5.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar5.Name = "circularProgressBar5";
            this.circularProgressBar5.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(101)))));
            this.circularProgressBar5.OuterMargin = -20;
            this.circularProgressBar5.OuterWidth = 15;
            this.circularProgressBar5.ProgressColor = System.Drawing.Color.Lime;
            this.circularProgressBar5.ProgressWidth = 15;
            this.circularProgressBar5.SecondaryFont = new System.Drawing.Font("맑은 고딕", 15F);
            this.circularProgressBar5.Size = new System.Drawing.Size(370, 370);
            this.circularProgressBar5.StartAngle = 90;
            this.circularProgressBar5.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar5.SubscriptColor = System.Drawing.Color.Silver;
            this.circularProgressBar5.SubscriptMargin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.circularProgressBar5.SubscriptText = "";
            this.circularProgressBar5.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar5.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar5.SuperscriptText = "";
            this.circularProgressBar5.TabIndex = 211;
            this.circularProgressBar5.Tag = "CNC-5170";
            this.circularProgressBar5.Text = "Machine";
            this.circularProgressBar5.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar5.Value = 68;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::View.Properties.Resources.KakaoTalk_20221012_135455735;
            this.pictureBox6.Location = new System.Drawing.Point(1528, 169);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(370, 370);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 210;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::View.Properties.Resources.CNC_5170;
            this.pictureBox5.Location = new System.Drawing.Point(776, 169);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(370, 370);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 208;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::View.Properties.Resources.KakaoTalk_20221012_135451296;
            this.pictureBox4.Location = new System.Drawing.Point(1152, 169);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(370, 370);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 207;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::View.Properties.Resources.TruLaser_3030;
            this.pictureBox1.Location = new System.Drawing.Point(24, 169);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 370);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 204;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::View.Properties.Resources.TruLaser_3030;
            this.pictureBox2.Location = new System.Drawing.Point(400, 169);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(370, 370);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 212;
            this.pictureBox2.TabStop = false;
            // 
            // Equipment_Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.circularProgressBar5);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.circularProgressBar4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.circularProgressBar3);
            this.Controls.Add(this.circularProgressBar2);
            this.Controls.Add(this.circularProgressBar1);
            this.Controls.Add(this.dgv_Monitoring);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Equipment_Monitoring";
            this.Load += new System.EventHandler(this.Equipment_Monitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Monitoring)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Monitoring;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private CircularProgressBar.CircularProgressBar circularProgressBar2;
        private CircularProgressBar.CircularProgressBar circularProgressBar3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private CircularProgressBar.CircularProgressBar circularProgressBar4;
        private CircularProgressBar.CircularProgressBar circularProgressBar5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}