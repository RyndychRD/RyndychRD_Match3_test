
namespace RyndychRD_Match3_test
{
    partial class Form_main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Form_main_playbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Form_main_playbutton
            // 
            this.Form_main_playbutton.Location = new System.Drawing.Point(150, 200);
            this.Form_main_playbutton.Name = "Form_main_playbutton";
            this.Form_main_playbutton.Size = new System.Drawing.Size(150, 100);
            this.Form_main_playbutton.TabIndex = 0;
            this.Form_main_playbutton.Text = "PLAY";
            this.Form_main_playbutton.UseVisualStyleBackColor = true;
            this.Form_main_playbutton.Click += new System.EventHandler(this.Form_main_playbutton_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.Form_main_playbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_main";
            this.Text = "Match3_RyndychRD";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Form_main_playbutton;
    }
}

