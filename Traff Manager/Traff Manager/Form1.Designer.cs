namespace Traff_Manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            label1 = new Label();
            tbToken = new TextBox();
            dtgv = new DataGridView();
            gvStt = new DataGridViewTextBoxColumn();
            gvName = new DataGridViewTextBoxColumn();
            gvProxy = new DataGridViewTextBoxColumn();
            gvType = new DataGridViewTextBoxColumn();
            gvEarnEachMin = new DataGridViewTextBoxColumn();
            gvEarnEach24H = new DataGridViewTextBoxColumn();
            gvStatus = new DataGridViewTextBoxColumn();
            numWait = new NumericUpDown();
            btnProxy = new Button();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            tbSum = new TextBox();
            label5 = new Label();
            label6 = new Label();
            tbEarnDay = new TextBox();
            label7 = new Label();
            label8 = new Label();
            tbEarnMin = new TextBox();
            label9 = new Label();
            panel1 = new Panel();
            tbActive = new TextBox();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWait).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(102, 51);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 12);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "Token";
            // 
            // tbToken
            // 
            tbToken.Location = new Point(120, 33);
            tbToken.Name = "tbToken";
            tbToken.Size = new Size(340, 23);
            tbToken.TabIndex = 2;
            tbToken.TextChanged += tbToken_TextChanged;
            // 
            // dtgv
            // 
            dtgv.AllowUserToDeleteRows = false;
            dtgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv.Columns.AddRange(new DataGridViewColumn[] { gvStt, gvName, gvProxy, gvType, gvEarnEachMin, gvEarnEach24H, gvStatus });
            dtgv.Location = new Point(226, 81);
            dtgv.Name = "dtgv";
            dtgv.ReadOnly = true;
            dtgv.RowTemplate.Height = 25;
            dtgv.Size = new Size(709, 438);
            dtgv.TabIndex = 3;
            // 
            // gvStt
            // 
            gvStt.HeaderText = "STT";
            gvStt.Name = "gvStt";
            gvStt.ReadOnly = true;
            gvStt.Width = 50;
            // 
            // gvName
            // 
            gvName.HeaderText = "Name";
            gvName.MinimumWidth = 15;
            gvName.Name = "gvName";
            gvName.ReadOnly = true;
            gvName.Width = 115;
            // 
            // gvProxy
            // 
            gvProxy.HeaderText = "Proxy";
            gvProxy.MinimumWidth = 20;
            gvProxy.Name = "gvProxy";
            gvProxy.ReadOnly = true;
            gvProxy.Width = 160;
            // 
            // gvType
            // 
            gvType.HeaderText = "Type";
            gvType.Name = "gvType";
            gvType.ReadOnly = true;
            gvType.Width = 80;
            // 
            // gvEarnEachMin
            // 
            gvEarnEachMin.HeaderText = "MB/min";
            gvEarnEachMin.Name = "gvEarnEachMin";
            gvEarnEachMin.ReadOnly = true;
            gvEarnEachMin.Width = 90;
            // 
            // gvEarnEach24H
            // 
            gvEarnEach24H.HeaderText = "MB/24H";
            gvEarnEach24H.Name = "gvEarnEach24H";
            gvEarnEach24H.ReadOnly = true;
            gvEarnEach24H.Width = 90;
            // 
            // gvStatus
            // 
            gvStatus.HeaderText = "Status";
            gvStatus.Name = "gvStatus";
            gvStatus.ReadOnly = true;
            gvStatus.Width = 80;
            // 
            // numWait
            // 
            numWait.Location = new Point(83, 76);
            numWait.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numWait.Name = "numWait";
            numWait.Size = new Size(41, 23);
            numWait.TabIndex = 5;
            numWait.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnProxy
            // 
            btnProxy.Location = new Point(484, 12);
            btnProxy.Name = "btnProxy";
            btnProxy.Size = new Size(102, 51);
            btnProxy.TabIndex = 6;
            btnProxy.Text = "Proxy";
            btnProxy.UseVisualStyleBackColor = true;
            btnProxy.Click += btnProxy_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(603, 15);
            label3.Name = "label3";
            label3.Size = new Size(277, 45);
            label3.TabIndex = 7;
            label3.Text = "Format:     IP:PORT:USERNAME:PASSWORD\r\nHTTPS:      (none)(Format) - Ex: 127.0.0.1:80\r\nSOCKS5:    Socks5|(Format) - Ex: Socks5|127.0.0.1:80";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 4;
            label2.Text = "Time Wait :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 39);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 8;
            label4.Text = "Sum :";
            // 
            // tbSum
            // 
            tbSum.Location = new Point(81, 36);
            tbSum.Name = "tbSum";
            tbSum.Size = new Size(64, 23);
            tbSum.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(148, 40);
            label5.Name = "label5";
            label5.Size = new Size(25, 15);
            label5.TabIndex = 10;
            label5.Text = "MB";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(148, 107);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 13;
            label6.Text = "MB / 24H";
            // 
            // tbEarnDay
            // 
            tbEarnDay.Location = new Point(81, 103);
            tbEarnDay.Name = "tbEarnDay";
            tbEarnDay.Size = new Size(64, 23);
            tbEarnDay.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 106);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 11;
            label7.Text = "All Day :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(148, 73);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 16;
            label8.Text = "MB / min";
            // 
            // tbEarnMin
            // 
            tbEarnMin.Location = new Point(81, 69);
            tbEarnMin.Name = "tbEarnMin";
            tbEarnMin.Size = new Size(64, 23);
            tbEarnMin.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 72);
            label9.Name = "label9";
            label9.Size = new Size(71, 15);
            label9.TabIndex = 14;
            label9.Text = "Earn Speed :";
            // 
            // panel1
            // 
            panel1.Controls.Add(tbActive);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(tbSum);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(tbEarnMin);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(tbEarnDay);
            panel1.Location = new Point(2, 379);
            panel1.Name = "panel1";
            panel1.Size = new Size(218, 135);
            panel1.TabIndex = 17;
            // 
            // tbActive
            // 
            tbActive.Location = new Point(81, 3);
            tbActive.Name = "tbActive";
            tbActive.Size = new Size(64, 23);
            tbActive.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 6);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 17;
            label10.Text = "Active :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 526);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(btnProxy);
            Controls.Add(numWait);
            Controls.Add(label2);
            Controls.Add(dtgv);
            Controls.Add(tbToken);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dtgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWait).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label label1;
        private TextBox tbToken;
        private DataGridView dtgv;
        private NumericUpDown numWait;
        private Button btnProxy;
        private DataGridViewTextBoxColumn gvStt;
        private DataGridViewTextBoxColumn gvName;
        private DataGridViewTextBoxColumn gvProxy;
        private DataGridViewTextBoxColumn gvType;
        private DataGridViewTextBoxColumn gvEarnEachMin;
        private DataGridViewTextBoxColumn gvEarnEach24H;
        private DataGridViewTextBoxColumn gvStatus;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox tbSum;
        private Label label5;
        private Label label6;
        private TextBox tbEarnDay;
        private Label label7;
        private Label label8;
        private TextBox tbEarnMin;
        private Label label9;
        private Panel panel1;
        private TextBox tbActive;
        private Label label10;
    }
}