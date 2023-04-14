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
            panel1 = new Panel();
            panel2 = new Panel();
            label4 = new Label();
            tbUpSum = new TextBox();
            label17 = new Label();
            label18 = new Label();
            tbUpEarn24H = new TextBox();
            label19 = new Label();
            tbUpEarnMin = new TextBox();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            panel3 = new Panel();
            label5 = new Label();
            tbDownSum = new TextBox();
            label12 = new Label();
            label11 = new Label();
            tbDownEarn24H = new TextBox();
            label16 = new Label();
            tbDownEarnMin = new TextBox();
            label15 = new Label();
            label13 = new Label();
            label14 = new Label();
            tbActive = new TextBox();
            label10 = new Label();
            btnKillAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWait).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
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
            tbToken.Text = "zMkWSMD4qctlAatbVfRMBGZNzc6FGX/E+7vx4HiUACE=";
            tbToken.TextChanged += tbToken_TextChanged;
            // 
            // dtgv
            // 
            dtgv.AllowUserToAddRows = false;
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
            gvName.Width = 65;
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
            gvEarnEachMin.Width = 115;
            // 
            // gvEarnEach24H
            // 
            gvEarnEach24H.HeaderText = "MB/24H";
            gvEarnEach24H.Name = "gvEarnEach24H";
            gvEarnEach24H.ReadOnly = true;
            gvEarnEach24H.Width = 115;
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
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(tbActive);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(2, 226);
            panel1.Name = "panel1";
            panel1.Size = new Size(218, 293);
            panel1.TabIndex = 17;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(tbUpSum);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(tbUpEarn24H);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(tbUpEarnMin);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(label22);
            panel2.Location = new Point(3, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(212, 127);
            panel2.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(76, 5);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 29;
            label4.Text = "UPLOAD";
            // 
            // tbUpSum
            // 
            tbUpSum.Location = new Point(78, 33);
            tbUpSum.Name = "tbUpSum";
            tbUpSum.Size = new Size(64, 23);
            tbUpSum.TabIndex = 21;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(7, 36);
            label17.Name = "label17";
            label17.Size = new Size(37, 15);
            label17.TabIndex = 20;
            label17.Text = "Sum :";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(145, 70);
            label18.Name = "label18";
            label18.Size = new Size(57, 15);
            label18.TabIndex = 28;
            label18.Text = "MB / min";
            // 
            // tbUpEarn24H
            // 
            tbUpEarn24H.Location = new Point(78, 100);
            tbUpEarn24H.Name = "tbUpEarn24H";
            tbUpEarn24H.Size = new Size(64, 23);
            tbUpEarn24H.TabIndex = 24;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(145, 104);
            label19.Name = "label19";
            label19.Size = new Size(57, 15);
            label19.TabIndex = 25;
            label19.Text = "MB / 24H";
            // 
            // tbUpEarnMin
            // 
            tbUpEarnMin.Location = new Point(78, 66);
            tbUpEarnMin.Name = "tbUpEarnMin";
            tbUpEarnMin.Size = new Size(64, 23);
            tbUpEarnMin.TabIndex = 27;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(7, 103);
            label20.Name = "label20";
            label20.Size = new Size(50, 15);
            label20.TabIndex = 23;
            label20.Text = "All Day :";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(145, 37);
            label21.Name = "label21";
            label21.Size = new Size(22, 15);
            label21.TabIndex = 22;
            label21.Text = "GB";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(7, 69);
            label22.Name = "label22";
            label22.Size = new Size(71, 15);
            label22.TabIndex = 26;
            label22.Text = "Earn Speed :";
            // 
            // panel3
            // 
            panel3.Controls.Add(label5);
            panel3.Controls.Add(tbDownSum);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(tbDownEarn24H);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(tbDownEarnMin);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label14);
            panel3.Location = new Point(3, 166);
            panel3.Name = "panel3";
            panel3.Size = new Size(212, 122);
            panel3.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaption;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(63, 6);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 30;
            label5.Text = "DOWNLOAD";
            // 
            // tbDownSum
            // 
            tbDownSum.Location = new Point(78, 29);
            tbDownSum.Name = "tbDownSum";
            tbDownSum.Size = new Size(64, 23);
            tbDownSum.TabIndex = 21;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 32);
            label12.Name = "label12";
            label12.Size = new Size(37, 15);
            label12.TabIndex = 20;
            label12.Text = "Sum :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(145, 66);
            label11.Name = "label11";
            label11.Size = new Size(57, 15);
            label11.TabIndex = 28;
            label11.Text = "MB / min";
            // 
            // tbDownEarn24H
            // 
            tbDownEarn24H.Location = new Point(78, 96);
            tbDownEarn24H.Name = "tbDownEarn24H";
            tbDownEarn24H.Size = new Size(64, 23);
            tbDownEarn24H.TabIndex = 24;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(145, 100);
            label16.Name = "label16";
            label16.Size = new Size(57, 15);
            label16.TabIndex = 25;
            label16.Text = "MB / 24H";
            // 
            // tbDownEarnMin
            // 
            tbDownEarnMin.Location = new Point(78, 62);
            tbDownEarnMin.Name = "tbDownEarnMin";
            tbDownEarnMin.Size = new Size(64, 23);
            tbDownEarnMin.TabIndex = 27;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 99);
            label15.Name = "label15";
            label15.Size = new Size(50, 15);
            label15.TabIndex = 23;
            label15.Text = "All Day :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(145, 33);
            label13.Name = "label13";
            label13.Size = new Size(22, 15);
            label13.TabIndex = 22;
            label13.Text = "GB";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 65);
            label14.Name = "label14";
            label14.Size = new Size(71, 15);
            label14.TabIndex = 26;
            label14.Text = "Earn Speed :";
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
            // btnKillAll
            // 
            btnKillAll.Location = new Point(12, 105);
            btnKillAll.Name = "btnKillAll";
            btnKillAll.Size = new Size(71, 35);
            btnKillAll.TabIndex = 18;
            btnKillAll.Text = "Kill All";
            btnKillAll.UseVisualStyleBackColor = true;
            btnKillAll.Click += btnKillAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 526);
            Controls.Add(btnKillAll);
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
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private Label label3;
        private Label label2;
        private Panel panel1;
        private TextBox tbActive;
        private Label label10;
        private Panel panel2;
        private Label label4;
        private TextBox tbUpSum;
        private Label label17;
        private Label label18;
        private TextBox tbUpEarn24H;
        private Label label19;
        private TextBox tbUpEarnMin;
        private Label label20;
        private Label label21;
        private Label label22;
        private Panel panel3;
        private Label label5;
        private TextBox tbDownSum;
        private Label label12;
        private Label label11;
        private TextBox tbDownEarn24H;
        private Label label16;
        private TextBox tbDownEarnMin;
        private Label label15;
        private Label label13;
        private Label label14;
        private Button btnKillAll;
        private DataGridViewTextBoxColumn gvStt;
        private DataGridViewTextBoxColumn gvName;
        private DataGridViewTextBoxColumn gvProxy;
        private DataGridViewTextBoxColumn gvType;
        private DataGridViewTextBoxColumn gvEarnEachMin;
        private DataGridViewTextBoxColumn gvEarnEach24H;
        private DataGridViewTextBoxColumn gvStatus;
    }
}