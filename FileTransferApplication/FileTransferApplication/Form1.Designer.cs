namespace FileTransferApplication
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            onlinePCList = new ListView();
            Ip = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            BrowseBtn = new Button();
            button6 = new Button();
            button7 = new Button();
            savePathLabel = new Label();
            MessagesFromHost = new RichTextBox();
            label2 = new Label();
            infoLabel = new Label();
            notificationLabel = new Label();
            fileNameLabel = new Label();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button5 = new Button();
            textProgressBar = new TextProgressBar();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(62, 124, 83);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(2, 2);
            button1.Name = "button1";
            button1.Size = new Size(116, 45);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 181, 8);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(124, 2);
            button2.Name = "button2";
            button2.Size = new Size(116, 45);
            button2.TabIndex = 1;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(2, 103, 180);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(246, 2);
            button3.Name = "button3";
            button3.Size = new Size(174, 45);
            button3.TabIndex = 2;
            button3.Text = "Change Save Location";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 101, 97);
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(426, 2);
            button4.Name = "button4";
            button4.Size = new Size(116, 45);
            button4.TabIndex = 3;
            button4.Text = "Exit";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // onlinePCList
            // 
            onlinePCList.Activation = ItemActivation.OneClick;
            onlinePCList.Columns.AddRange(new ColumnHeader[] { Ip, columnHeader1 });
            onlinePCList.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            onlinePCList.FullRowSelect = true;
            onlinePCList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            onlinePCList.HoverSelection = true;
            onlinePCList.Location = new Point(12, 78);
            onlinePCList.MultiSelect = false;
            onlinePCList.Name = "onlinePCList";
            onlinePCList.Size = new Size(530, 312);
            onlinePCList.TabIndex = 4;
            onlinePCList.UseCompatibleStateImageBehavior = false;
            onlinePCList.View = View.Details;
            // 
            // Ip
            // 
            Ip.Text = "IP Address";
            Ip.Width = 200;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Device Name";
            columnHeader1.Width = 325;
            // 
            // BrowseBtn
            // 
            BrowseBtn.BackColor = Color.FromArgb(2, 103, 180);
            BrowseBtn.Cursor = Cursors.Hand;
            BrowseBtn.FlatStyle = FlatStyle.Flat;
            BrowseBtn.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BrowseBtn.ForeColor = Color.White;
            BrowseBtn.Location = new Point(12, 396);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new Size(116, 45);
            BrowseBtn.TabIndex = 5;
            BrowseBtn.Text = "Browse";
            BrowseBtn.UseVisualStyleBackColor = false;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(25, 139, 221);
            button6.Cursor = Cursors.Hand;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.White;
            button6.Location = new Point(134, 396);
            button6.Name = "button6";
            button6.Size = new Size(198, 45);
            button6.TabIndex = 6;
            button6.Text = "Send Files";
            button6.UseVisualStyleBackColor = false;
            button6.Click += SendFiles;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(232, 249, 243);
            button7.Cursor = Cursors.Hand;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button7.ForeColor = Color.Gray;
            button7.Location = new Point(338, 396);
            button7.Name = "button7";
            button7.Size = new Size(137, 45);
            button7.TabIndex = 7;
            button7.Text = "Clear";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // savePathLabel
            // 
            savePathLabel.AutoSize = true;
            savePathLabel.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            savePathLabel.Location = new Point(628, 18);
            savePathLabel.Name = "savePathLabel";
            savePathLabel.Size = new Size(213, 22);
            savePathLabel.TabIndex = 8;
            savePathLabel.Text = "C:\\User\\Public\\Public Downloads";
            // 
            // MessagesFromHost
            // 
            MessagesFromHost.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MessagesFromHost.Location = new Point(555, 81);
            MessagesFromHost.Name = "MessagesFromHost";
            MessagesFromHost.ReadOnly = true;
            MessagesFromHost.ScrollBars = RichTextBoxScrollBars.Vertical;
            MessagesFromHost.Size = new Size(381, 309);
            MessagesFromHost.TabIndex = 9;
            MessagesFromHost.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(555, 56);
            label2.Name = "label2";
            label2.Size = new Size(68, 22);
            label2.TabIndex = 10;
            label2.Text = "Messages";
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            infoLabel.Location = new Point(147, 50);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(13, 22);
            infoLabel.TabIndex = 11;
            infoLabel.Text = ".";
            infoLabel.Visible = false;
            // 
            // notificationLabel
            // 
            notificationLabel.AutoSize = true;
            notificationLabel.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            notificationLabel.Location = new Point(12, 50);
            notificationLabel.Name = "notificationLabel";
            notificationLabel.Size = new Size(13, 22);
            notificationLabel.TabIndex = 12;
            notificationLabel.Text = ".";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            fileNameLabel.Location = new Point(280, 50);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(13, 22);
            fileNameLabel.TabIndex = 13;
            fileNameLabel.Text = ".";
            fileNameLabel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(557, 18);
            label3.Name = "label3";
            label3.Size = new Size(75, 22);
            label3.TabIndex = 14;
            label3.Text = "Save Path :";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(232, 249, 243);
            button5.Cursor = Cursors.Hand;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.Gray;
            button5.Location = new Point(816, 50);
            button5.Name = "button5";
            button5.Size = new Size(120, 28);
            button5.TabIndex = 15;
            button5.Text = "Clear Messages";
            button5.UseVisualStyleBackColor = false;
            button5.Click += ClearMessages;
            // 
            // textProgressBar
            // 
            textProgressBar.CustomText = "";
            textProgressBar.Location = new Point(557, 404);
            textProgressBar.Name = "textProgressBar";
            textProgressBar.ProgressColor = Color.LightGreen;
            textProgressBar.Size = new Size(379, 34);
            textProgressBar.TabIndex = 18;
            textProgressBar.TextColor = Color.Black;
            textProgressBar.TextFont = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textProgressBar.Visible = false;
            textProgressBar.VisualMode = ProgressBarDisplayMode.CustomText;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(948, 450);
            Controls.Add(textProgressBar);
            Controls.Add(button5);
            Controls.Add(label3);
            Controls.Add(fileNameLabel);
            Controls.Add(notificationLabel);
            Controls.Add(infoLabel);
            Controls.Add(label2);
            Controls.Add(MessagesFromHost);
            Controls.Add(savePathLabel);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(BrowseBtn);
            Controls.Add(onlinePCList);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            MaximizeBox = false;
            MaximumSize = new Size(964, 489);
            MinimumSize = new Size(964, 489);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transfer File ";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ForeColorChanged += Form1_ForeColorChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListView onlinePCList;
        private ColumnHeader Ip;
        private ColumnHeader columnHeader1;
        private Button BrowseBtn;
        private Button button6;
        private Button button7;
        private Label savePathLabel;
        private RichTextBox MessagesFromHost;
        private Label label2;
        private Label infoLabel;
        private Label notificationLabel;
        private Label fileNameLabel;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
        private Button button5;
        private TextProgressBar textProgressBar;
    }
}