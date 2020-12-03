
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
            this.Form_game_debug = new System.Windows.Forms.Button();
            this.t_game_desk = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.countdown_timer = new System.Windows.Forms.Timer(this.components);
            this.countdown_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.t_game_desk)).BeginInit();
            this.SuspendLayout();
            // 
            // Form_game_debug
            // 
            this.Form_game_debug.Location = new System.Drawing.Point(266, 12);
            this.Form_game_debug.Name = "Form_game_debug";
            this.Form_game_debug.Size = new System.Drawing.Size(75, 23);
            this.Form_game_debug.TabIndex = 1;
            this.Form_game_debug.Text = "Debug off";
            this.Form_game_debug.UseVisualStyleBackColor = true;
            this.Form_game_debug.Click += new System.EventHandler(this.Form_game_debug_Click);
            // 
            // t_game_desk
            // 
            this.t_game_desk.Location = new System.Drawing.Point(20, 45);
            this.t_game_desk.Name = "t_game_desk";
            this.t_game_desk.Size = new System.Drawing.Size(400, 456);
            this.t_game_desk.TabIndex = 2;
            this.t_game_desk.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Countdown";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Score";
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Location = new System.Drawing.Point(144, 22);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(13, 13);
            this.score_label.TabIndex = 8;
            this.score_label.Text = "0";
            // 
            // countdown_timer
            // 
            this.countdown_timer.Interval = 1000;
            this.countdown_timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // countdown_label
            // 
            this.countdown_label.AutoSize = true;
            this.countdown_label.Location = new System.Drawing.Point(37, 22);
            this.countdown_label.Name = "countdown_label";
            this.countdown_label.Size = new System.Drawing.Size(19, 13);
            this.countdown_label.TabIndex = 9;
            this.countdown_label.Text = "60";
            // 
            // Form_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.countdown_label);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_game_desk);
            this.Controls.Add(this.Form_game_debug);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_game";
            this.Text = "Match3_RyndychRD";
            ((System.ComponentModel.ISupportInitialize)(this.t_game_desk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button Form_game_debug;
        private System.Windows.Forms.PictureBox t_game_desk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Timer countdown_timer;
        private System.Windows.Forms.Label countdown_label;
    }
}