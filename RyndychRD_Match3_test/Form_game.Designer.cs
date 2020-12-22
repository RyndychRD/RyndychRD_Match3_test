
namespace RyndychRD_Match3_test
{
    partial class Form_game
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
            this.components = new System.ComponentModel.Container();
            this.b_debug = new System.Windows.Forms.Button();
            this.t_game_desk = new System.Windows.Forms.PictureBox();
            this.l_countdown_timer_text = new System.Windows.Forms.Label();
            this.l_score_text = new System.Windows.Forms.Label();
            this.l_score = new System.Windows.Forms.Label();
            this.countdown_timer = new System.Windows.Forms.Timer(this.components);
            this.l_countdown_timer = new System.Windows.Forms.Label();
            this.b_refill = new System.Windows.Forms.Button();
            this.curtain_top = new System.Windows.Forms.PictureBox();
            this.figure_move_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.t_game_desk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curtain_top)).BeginInit();
            this.SuspendLayout();
            // 
            // b_debug
            // 
            this.b_debug.Location = new System.Drawing.Point(214, 12);
            this.b_debug.Name = "b_debug";
            this.b_debug.Size = new System.Drawing.Size(75, 23);
            this.b_debug.TabIndex = 1;
            this.b_debug.Text = "Debug off";
            this.b_debug.UseVisualStyleBackColor = true;
            this.b_debug.Click += new System.EventHandler(this.Form_game_debug_Click);
            // 
            // t_game_desk
            // 
            this.t_game_desk.Location = new System.Drawing.Point(0, 90);
            this.t_game_desk.Name = "t_game_desk";
            this.t_game_desk.Size = new System.Drawing.Size(400, 400);
            this.t_game_desk.TabIndex = 2;
            this.t_game_desk.TabStop = false;
            // 
            // l_countdown_timer_text
            // 
            this.l_countdown_timer_text.AutoSize = true;
            this.l_countdown_timer_text.Location = new System.Drawing.Point(37, 3);
            this.l_countdown_timer_text.Name = "l_countdown_timer_text";
            this.l_countdown_timer_text.Size = new System.Drawing.Size(61, 13);
            this.l_countdown_timer_text.TabIndex = 5;
            this.l_countdown_timer_text.Text = "Countdown";
            // 
            // l_score_text
            // 
            this.l_score_text.AutoSize = true;
            this.l_score_text.Location = new System.Drawing.Point(144, 3);
            this.l_score_text.Name = "l_score_text";
            this.l_score_text.Size = new System.Drawing.Size(35, 13);
            this.l_score_text.TabIndex = 6;
            this.l_score_text.Text = "Score";
            // 
            // l_score
            // 
            this.l_score.AutoSize = true;
            this.l_score.Location = new System.Drawing.Point(144, 22);
            this.l_score.Name = "l_score";
            this.l_score.Size = new System.Drawing.Size(13, 13);
            this.l_score.TabIndex = 8;
            this.l_score.Text = "0";
            // 
            // countdown_timer
            // 
            this.countdown_timer.Interval = 1000;
            this.countdown_timer.Tick += new System.EventHandler(this.countdown_timer_Tick);
            // 
            // l_countdown_timer
            // 
            this.l_countdown_timer.AutoSize = true;
            this.l_countdown_timer.Location = new System.Drawing.Point(37, 22);
            this.l_countdown_timer.Name = "l_countdown_timer";
            this.l_countdown_timer.Size = new System.Drawing.Size(19, 13);
            this.l_countdown_timer.TabIndex = 9;
            this.l_countdown_timer.Text = "60";
            // 
            // b_refill
            // 
            this.b_refill.Location = new System.Drawing.Point(305, 12);
            this.b_refill.Name = "b_refill";
            this.b_refill.Size = new System.Drawing.Size(75, 23);
            this.b_refill.TabIndex = 10;
            this.b_refill.Text = "Refill table";
            this.b_refill.UseVisualStyleBackColor = true;
            this.b_refill.Click += new System.EventHandler(this.b_refill_Click);
            // 
            // curtain_top
            // 
            this.curtain_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.curtain_top.Location = new System.Drawing.Point(0, 0);
            this.curtain_top.Name = "curtain_top";
            this.curtain_top.Size = new System.Drawing.Size(401, 90);
            this.curtain_top.TabIndex = 11;
            this.curtain_top.TabStop = false;
            // 
            // Form_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 491);
            this.Controls.Add(this.b_refill);
            this.Controls.Add(this.l_countdown_timer);
            this.Controls.Add(this.l_score);
            this.Controls.Add(this.l_score_text);
            this.Controls.Add(this.l_countdown_timer_text);
            this.Controls.Add(this.t_game_desk);
            this.Controls.Add(this.b_debug);
            this.Controls.Add(this.curtain_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_game";
            this.Text = "Match3_RyndychRD";
            ((System.ComponentModel.ISupportInitialize)(this.t_game_desk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curtain_top)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button b_debug;
        private System.Windows.Forms.PictureBox t_game_desk;
        private System.Windows.Forms.Label l_countdown_timer_text;
        private System.Windows.Forms.Label l_score_text;
        private System.Windows.Forms.Label l_score;
        private System.Windows.Forms.Timer countdown_timer;
        private System.Windows.Forms.Label l_countdown_timer;
        private System.Windows.Forms.Button b_refill;
        private System.Windows.Forms.PictureBox curtain_top;
        private System.Windows.Forms.Timer figure_move_timer;
    }
}