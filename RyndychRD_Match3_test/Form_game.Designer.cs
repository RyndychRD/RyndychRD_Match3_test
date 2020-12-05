
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
            this.Form_game_exit = new System.Windows.Forms.Button();
            this.Form_game_debug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Form_game_exit
            // 
            this.Form_game_exit.Location = new System.Drawing.Point(347, 12);
            this.Form_game_exit.Name = "Form_game_exit";
            this.Form_game_exit.Size = new System.Drawing.Size(75, 23);
            this.Form_game_exit.TabIndex = 0;
            this.Form_game_exit.Text = "Exit";
            this.Form_game_exit.UseVisualStyleBackColor = true;
            this.Form_game_exit.Click += new System.EventHandler(this.Form_game_exit_Click);
            // 
            // Form_game_debug
            // 
            this.Form_game_debug.Location = new System.Drawing.Point(266, 12);
            this.Form_game_debug.Name = "Form_game_debug";
            this.Form_game_debug.Size = new System.Drawing.Size(75, 23);
            this.Form_game_debug.TabIndex = 1;
            this.Form_game_debug.Text = "Debug";
            this.Form_game_debug.UseVisualStyleBackColor = true;
            // 
            // Form_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.Form_game_debug);
            this.Controls.Add(this.Form_game_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_game";
            this.Text = "Match3_RyndychRD";
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button Form_game_exit;
        private System.Windows.Forms.Button Form_game_debug;
    }
}