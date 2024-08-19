namespace SpaceShooter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MoveBgTimer = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            LeftMoveTimer = new System.Windows.Forms.Timer(components);
            RightMoveTimer = new System.Windows.Forms.Timer(components);
            DownMoveTimer = new System.Windows.Forms.Timer(components);
            UpMoveTimer = new System.Windows.Forms.Timer(components);
            MoveMunitiontimer = new System.Windows.Forms.Timer(components);
            MoveEnemiesTimer = new System.Windows.Forms.Timer(components);
            EnemiesMunitionTimer = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            btnScore = new Label();
            btnlevel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // MoveBgTimer
            // 
            MoveBgTimer.Interval = 10;
            MoveBgTimer.Tick += MoveBgTimer_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(328, 388);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // LeftMoveTimer
            // 
            LeftMoveTimer.Tick += LeftMoveTimer_Tick;
            // 
            // RightMoveTimer
            // 
            RightMoveTimer.Tick += RightMoveTimer_Tick;
            // 
            // DownMoveTimer
            // 
            DownMoveTimer.Tick += DownMoveTimer_Tick;
            // 
            // UpMoveTimer
            // 
            UpMoveTimer.Tick += UpMoveTimer_Tick;
            // 
            // MoveMunitiontimer
            // 
            MoveMunitiontimer.Enabled = true;
            MoveMunitiontimer.Interval = 20;
            MoveMunitiontimer.Tick += MoveMunitiontimer_Tick;
            // 
            // MoveEnemiesTimer
            // 
            MoveEnemiesTimer.Enabled = true;
            MoveEnemiesTimer.Interval = 20;
            MoveEnemiesTimer.Tick += MoveEnemiesTimer_Tick;
            // 
            // EnemiesMunitionTimer
            // 
            EnemiesMunitionTimer.Enabled = true;
            EnemiesMunitionTimer.Interval = 20;
            EnemiesMunitionTimer.Tick += EnemiesMunitionTimer_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(306, 81);
            button1.Name = "button1";
            button1.Size = new Size(216, 53);
            button1.TabIndex = 1;
            button1.Text = "Replay";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(306, 198);
            button2.Name = "button2";
            button2.Size = new Size(216, 52);
            button2.TabIndex = 2;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Wheat;
            label1.ForeColor = Color.DarkOrange;
            label1.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            label1.Location = new Point(368, 137);
            label1.Name = "label1";
            label1.Size = new Size(66, 40);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.Visible = false;
            label1.Click += label1_Click;
            // 
            // btnScore
            // 
            btnScore.AutoSize = true;
            btnScore.ForeColor = SystemColors.ControlLightLight;
            btnScore.Location = new Point(56, 44);
            btnScore.Name = "btnScore";
            btnScore.Size = new Size(61, 25);
            btnScore.TabIndex = 4;
            btnScore.Text = "Score ";
            btnScore.Click += btnScore_Click;
            // 
            // btnlevel
            // 
            btnlevel.AutoSize = true;
            btnlevel.ForeColor = SystemColors.ControlLightLight;
            btnlevel.Location = new Point(669, 44);
            btnlevel.Name = "btnlevel";
            btnlevel.Size = new Size(75, 25);
            btnlevel.TabIndex = 5;
            btnlevel.Text = "Level : 0";
            btnlevel.Click += btnlevel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btnlevel);
            Controls.Add(btnScore);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Space Shooter";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer MoveBgTimer;
        protected PictureBox pictureBox1;
        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;
        private System.Windows.Forms.Timer MoveMunitiontimer;
        private System.Windows.Forms.Timer MoveEnemiesTimer;
        private System.Windows.Forms.Timer EnemiesMunitionTimer;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label btnScore;
        private Label btnlevel;
    }
}
