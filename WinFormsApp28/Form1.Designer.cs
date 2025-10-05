namespace WinFormsApp28
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
            buttonHS = new Button();
            groupBox1 = new GroupBox();
            textBoxHS = new TextBox();
            groupBox2 = new GroupBox();
            textBoxFP = new TextBox();
            buttonFP = new Button();
            buttonReset = new Button();
            textBoxLog = new TextBox();
            label1 = new Label();
            buttonSetOne = new Button();
            buttonSetZero = new Button();
            buttonClearLog = new Button();
            button1 = new Button();
            button2 = new Button();
            listView1 = new ListView();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // buttonHS
            // 
            buttonHS.Location = new Point(211, 26);
            buttonHS.Name = "buttonHS";
            buttonHS.Size = new Size(62, 29);
            buttonHS.TabIndex = 1;
            buttonHS.Text = "确定";
            buttonHS.UseVisualStyleBackColor = true;
            buttonHS.Click += buttonHS_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxHS);
            groupBox1.Controls.Add(buttonHS);
            groupBox1.Location = new Point(1064, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(295, 62);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "磁盘块回收";
            // 
            // textBoxHS
            // 
            textBoxHS.Location = new Point(15, 26);
            textBoxHS.Name = "textBoxHS";
            textBoxHS.PlaceholderText = "物理地址";
            textBoxHS.Size = new Size(190, 27);
            textBoxHS.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxFP);
            groupBox2.Controls.Add(buttonFP);
            groupBox2.Location = new Point(1064, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(295, 63);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "磁盘块分配";
            // 
            // textBoxFP
            // 
            textBoxFP.Location = new Point(15, 26);
            textBoxFP.Name = "textBoxFP";
            textBoxFP.PlaceholderText = "块数";
            textBoxFP.Size = new Size(190, 27);
            textBoxFP.TabIndex = 2;
            // 
            // buttonFP
            // 
            buttonFP.Location = new Point(211, 25);
            buttonFP.Name = "buttonFP";
            buttonFP.Size = new Size(62, 29);
            buttonFP.TabIndex = 1;
            buttonFP.Text = "确定";
            buttonFP.UseVisualStyleBackColor = true;
            buttonFP.Click += buttonFP_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(127, 21);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(107, 29);
            buttonReset.TabIndex = 4;
            buttonReset.Text = "随机分配0/1";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(1064, 149);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.PlaceholderText = "log";
            textBoxLog.ReadOnly = true;
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            textBoxLog.Size = new Size(306, 816);
            textBoxLog.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // buttonSetOne
            // 
            buttonSetOne.Location = new Point(331, 23);
            buttonSetOne.Name = "buttonSetOne";
            buttonSetOne.Size = new Size(89, 29);
            buttonSetOne.TabIndex = 7;
            buttonSetOne.Text = "全设为1";
            buttonSetOne.UseVisualStyleBackColor = true;
            buttonSetOne.Click += buttonSetOne_Click;
            // 
            // buttonSetZero
            // 
            buttonSetZero.Location = new Point(240, 21);
            buttonSetZero.Name = "buttonSetZero";
            buttonSetZero.Size = new Size(85, 29);
            buttonSetZero.TabIndex = 8;
            buttonSetZero.Text = "全设为0";
            buttonSetZero.UseVisualStyleBackColor = true;
            buttonSetZero.Click += buttonSetZero_Click;
            // 
            // buttonClearLog
            // 
            buttonClearLog.Location = new Point(1064, 971);
            buttonClearLog.Name = "buttonClearLog";
            buttonClearLog.Size = new Size(94, 29);
            buttonClearLog.TabIndex = 9;
            buttonClearLog.Text = "清空log";
            buttonClearLog.UseVisualStyleBackColor = true;
            buttonClearLog.Click += buttonbuttonClearLog_Click;
            // 
            // button1
            // 
            button1.Location = new Point(426, 23);
            button1.Name = "button1";
            button1.Size = new Size(89, 29);
            button1.TabIndex = 10;
            button1.Text = "设为地址";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(521, 23);
            button2.Name = "button2";
            button2.Size = new Size(98, 27);
            button2.TabIndex = 3;
            button2.Text = "全部回收";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 1);
            listView1.Name = "listView1";
            listView1.Size = new Size(1046, 999);
            listView1.TabIndex = 11;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(buttonSetOne);
            groupBox3.Controls.Add(buttonReset);
            groupBox3.Controls.Add(buttonSetZero);
            groupBox3.Location = new Point(12, 1006);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(625, 57);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "调试信息";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 1067);
            Controls.Add(groupBox3);
            Controls.Add(listView1);
            Controls.Add(buttonClearLog);
            Controls.Add(textBoxLog);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(1400, 1114);
            MinimumSize = new Size(1400, 1114);
            Name = "Form1";
            Text = "模拟位示图管理磁盘空间的分配与回收";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonHS;
        private GroupBox groupBox1;
        private TextBox textBoxHS;
        private GroupBox groupBox2;
        private TextBox textBoxFP;
        private Button buttonFP;
        private Button buttonReset;
        private TextBox textBoxLog;
        private Label label1;
        private Button buttonSetOne;
        private Button buttonSetZero;
        private Button buttonClearLog;
        private Button button1;
        private Button button2;
        private ListView listView1;
        private GroupBox groupBox3;
    }
}
