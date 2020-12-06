
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
            this.t_game_desk = new System.Windows.Forms.TableLayoutPanel();
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
            this.Form_game_exit.Click += new System.EventHandler(this.b_Form_game_exit_Click);
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
            // t_game_desk
            // 
            this.t_game_desk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.t_game_desk.ColumnCount = 8;
            this.t_game_desk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.t_game_desk.Location = new System.Drawing.Point(19, 44);
            this.t_game_desk.Name = "t_game_desk";
            this.t_game_desk.RowCount = 8;
            this.t_game_desk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.t_game_desk.Size = new System.Drawing.Size(400, 456);
            this.t_game_desk.TabIndex = 2;
            // 
            // Form_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.t_game_desk);
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
        private System.Windows.Forms.TableLayoutPanel t_game_desk;
    }
}