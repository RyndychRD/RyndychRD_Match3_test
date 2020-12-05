using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RyndychRD_Match3_test
{
   
    public partial class Form_game : Form
    {
        private readonly Form_main main;
        public Form_game(Form_main Form_main)
        {
            InitializeComponent();
            main = Form_main;
         //   Draw_game_desk();


        }

       //private void Draw_game_desk()
       // {
       //     //TODO сменить bitmap на что-то без лишних затрат памяти
       //     Bitmap bmp = new Bitmap(game_desk.Width, game_desk.Height);
            
       //     Graphics g_game_desk = Graphics.FromImage(bmp);
       //     SolidBrush b_dark_gray = new SolidBrush(Color.DarkGray);
       //     SolidBrush b_light_gray = new SolidBrush(Color.Gray);

       //     //TODO сделать по размеру окна game_desk
       //     int x_step = 50;
       //     int y_step = 57;
       //     const int count_cell = 8;
       //     for (int x = 0 ; x < x_step * count_cell; x += x_step)
       //     {
       //         for (int y = 0; y < y_step * count_cell; y += y_step)
       //         {
       //             if (((x / x_step) % 2 == 1) ^ ((y / y_step) % 2 == 1))
       //             {
       //                 g_game_desk.FillRectangle(b_light_gray, x, y, x_step, y_step);
       //             }
       //             else
       //             {
       //                 g_game_desk.FillRectangle(b_dark_gray, x, y, x_step, y_step);
       //             }
       //         }
       //     }
       //     game_desk.Image = bmp;
       // }

        private void b_Form_game_exit_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }

       
    }
}
