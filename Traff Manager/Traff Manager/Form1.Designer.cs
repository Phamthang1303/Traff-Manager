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
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbToken = new System.Windows.Forms.TextBox();
            this.dtgv = new System.Windows.Forms.DataGridView();
            this.gvStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvProxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvEarnEachMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvEarnEach24H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numWait = new System.Windows.Forms.NumericUpDown();
            this.btnProxy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUpSum = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbUpEarn24H = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbUpEarnMin = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDownSum = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbDownEarn24H = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbDownEarnMin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbActive = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnKillAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWait)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 51);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Token";
            // 
            // tbToken
            // 
            this.tbToken.Location = new System.Drawing.Point(120, 33);
            this.tbToken.Name = "tbToken";
            this.tbToken.Size = new System.Drawing.Size(340, 23);
            this.tbToken.TabIndex = 2;
            this.tbToken.Text = "zMkWSMD4qctlAatbVfRMBGZNzc6FGX/E+7vx4HiUACE=";
            // 
            // dtgv
            // 
            this.dtgv.AllowUserToDeleteRows = false;
            this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvStt,
            this.gvName,
            this.gvProxy,
            this.gvType,
            this.gvEarnEachMin,
            this.gvEarnEach24H,
            this.gvStatus});
            this.dtgv.Location = new System.Drawing.Point(226, 81);
            this.dtgv.Name = "dtgv";
            this.dtgv.ReadOnly = true;
            this.dtgv.RowTemplate.Height = 25;
            this.dtgv.Size = new System.Drawing.Size(709, 438);
            this.dtgv.TabIndex = 3;
            // 
            // gvStt
            // 
            this.gvStt.HeaderText = "STT";
            this.gvStt.Name = "gvStt";
            this.gvStt.ReadOnly = true;
            this.gvStt.Width = 50;
            // 
            // gvName
            // 
            this.gvName.HeaderText = "Name";
            this.gvName.MinimumWidth = 15;
            this.gvName.Name = "gvName";
            this.gvName.ReadOnly = true;
            this.gvName.Width = 65;
            // 
            // gvProxy
            // 
            this.gvProxy.HeaderText = "Proxy";
            this.gvProxy.MinimumWidth = 20;
            this.gvProxy.Name = "gvProxy";
            this.gvProxy.ReadOnly = true;
            this.gvProxy.Width = 160;
            // 
            // gvType
            // 
            this.gvType.HeaderText = "Type";
            this.gvType.Name = "gvType";
            this.gvType.ReadOnly = true;
            this.gvType.Width = 80;
            // 
            // gvEarnEachMin
            // 
            this.gvEarnEachMin.HeaderText = "MB/min";
            this.gvEarnEachMin.Name = "gvEarnEachMin";
            this.gvEarnEachMin.ReadOnly = true;
            this.gvEarnEachMin.Width = 115;
            // 
            // gvEarnEach24H
            // 
            this.gvEarnEach24H.HeaderText = "MB/24H";
            this.gvEarnEach24H.Name = "gvEarnEach24H";
            this.gvEarnEach24H.ReadOnly = true;
            this.gvEarnEach24H.Width = 115;
            // 
            // gvStatus
            // 
            this.gvStatus.HeaderText = "Status";
            this.gvStatus.Name = "gvStatus";
            this.gvStatus.ReadOnly = true;
            this.gvStatus.Width = 80;
            // 
            // numWait
            // 
            this.numWait.Location = new System.Drawing.Point(83, 76);
            this.numWait.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWait.Name = "numWait";
            this.numWait.Size = new System.Drawing.Size(41, 23);
            this.numWait.TabIndex = 5;
            this.numWait.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnProxy
            // 
            this.btnProxy.Location = new System.Drawing.Point(484, 12);
            this.btnProxy.Name = "btnProxy";
            this.btnProxy.Size = new System.Drawing.Size(102, 51);
            this.btnProxy.TabIndex = 6;
            this.btnProxy.Text = "Proxy";
            this.btnProxy.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 45);
            this.label3.TabIndex = 7;
            this.label3.Text = "Format:     IP:PORT:USERNAME:PASSWORD\r\nHTTPS:      (none)(Format) - Ex: 127.0.0.1" +
    ":80\r\nSOCKS5:    Socks5|(Format) - Ex: Socks5|127.0.0.1:80";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time Wait :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.tbActive);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(2, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 293);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbUpSum);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.tbUpEarn24H);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.tbUpEarnMin);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 127);
            this.panel2.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(76, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "UPLOAD";
            // 
            // tbUpSum
            // 
            this.tbUpSum.Location = new System.Drawing.Point(78, 33);
            this.tbUpSum.Name = "tbUpSum";
            this.tbUpSum.Size = new System.Drawing.Size(64, 23);
            this.tbUpSum.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 15);
            this.label17.TabIndex = 20;
            this.label17.Text = "Sum :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(145, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 15);
            this.label18.TabIndex = 28;
            this.label18.Text = "MB / min";
            // 
            // tbUpEarn24H
            // 
            this.tbUpEarn24H.Location = new System.Drawing.Point(78, 100);
            this.tbUpEarn24H.Name = "tbUpEarn24H";
            this.tbUpEarn24H.Size = new System.Drawing.Size(64, 23);
            this.tbUpEarn24H.TabIndex = 24;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(145, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 15);
            this.label19.TabIndex = 25;
            this.label19.Text = "MB / 24H";
            // 
            // tbUpEarnMin
            // 
            this.tbUpEarnMin.Location = new System.Drawing.Point(78, 66);
            this.tbUpEarnMin.Name = "tbUpEarnMin";
            this.tbUpEarnMin.Size = new System.Drawing.Size(64, 23);
            this.tbUpEarnMin.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 103);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 15);
            this.label20.TabIndex = 23;
            this.label20.Text = "All Day :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(145, 37);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 15);
            this.label21.TabIndex = 22;
            this.label21.Text = "GB";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 69);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 15);
            this.label22.TabIndex = 26;
            this.label22.Text = "Earn Speed :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.tbDownSum);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.tbDownEarn24H);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.tbDownEarnMin);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(3, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 122);
            this.panel3.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(63, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "DOWNLOAD";
            // 
            // tbDownSum
            // 
            this.tbDownSum.Location = new System.Drawing.Point(78, 29);
            this.tbDownSum.Name = "tbDownSum";
            this.tbDownSum.Size = new System.Drawing.Size(64, 23);
            this.tbDownSum.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "Sum :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(145, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "MB / min";
            // 
            // tbDownEarn24H
            // 
            this.tbDownEarn24H.Location = new System.Drawing.Point(78, 96);
            this.tbDownEarn24H.Name = "tbDownEarn24H";
            this.tbDownEarn24H.Size = new System.Drawing.Size(64, 23);
            this.tbDownEarn24H.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(145, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "MB / 24H";
            // 
            // tbDownEarnMin
            // 
            this.tbDownEarnMin.Location = new System.Drawing.Point(78, 62);
            this.tbDownEarnMin.Name = "tbDownEarnMin";
            this.tbDownEarnMin.Size = new System.Drawing.Size(64, 23);
            this.tbDownEarnMin.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 15);
            this.label15.TabIndex = 23;
            this.label15.Text = "All Day :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(145, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "GB";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 15);
            this.label14.TabIndex = 26;
            this.label14.Text = "Earn Speed :";
            // 
            // tbActive
            // 
            this.tbActive.Location = new System.Drawing.Point(81, 3);
            this.tbActive.Name = "tbActive";
            this.tbActive.Size = new System.Drawing.Size(64, 23);
            this.tbActive.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Active :";
            // 
            // btnKillAll
            // 
            this.btnKillAll.Location = new System.Drawing.Point(12, 105);
            this.btnKillAll.Name = "btnKillAll";
            this.btnKillAll.Size = new System.Drawing.Size(71, 35);
            this.btnKillAll.TabIndex = 18;
            this.btnKillAll.Text = "Kill All";
            this.btnKillAll.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 526);
            this.Controls.Add(this.btnKillAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnProxy);
            this.Controls.Add(this.numWait);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgv);
            this.Controls.Add(this.tbToken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWait)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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