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

            Draw_game_desk();
            Figure_stek f = new Figure_stek();
            f.Fill_table(this);


        }

        private void Draw_game_desk()
        {
            //TODO сменить bitmap на что-то без лишних затрат памяти
            Bitmap bmp = new Bitmap(t_game_desk.Width, t_game_desk.Height);

            Graphics g_game_desk = Graphics.FromImage(bmp);
            SolidBrush b_dark_gray = new SolidBrush(Color.DarkGray);
            SolidBrush b_light_gray = new SolidBrush(Color.Gray);

            //TODO сделать по размеру окна game_desk
            int x_step = 50;
            int y_step = 57;
            const int count_cell = 8;
            for (int x = 0; x < x_step * count_cell; x += x_step)
            {
                for (int y = 0; y < y_step * count_cell; y += y_step)
                {
                    if (((x / x_step) % 2 == 1) ^ ((y / y_step) % 2 == 1))
                    {
                        g_game_desk.FillRectangle(b_light_gray, x, y, x_step, y_step);
                    }
                    else
                    {
                        g_game_desk.FillRectangle(b_dark_gray, x, y, x_step, y_step);
                    }
                }
            }
            t_game_desk.BackgroundImage = bmp;
        }

        private void b_Form_game_exit_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }

        //TODO Вынести его за пределы этого класса

        private class Figure_stek
        {
            Figure[,] figure_arr;
            Random rnd = new Random();

            public Figure_stek()
            {

            }

            public void Fill_table(Form_game form_Game)
            {
                figure_arr = new Figure[form_Game.t_game_desk.ColumnCount, form_Game.t_game_desk.RowCount];
                for (int col = 0; col < form_Game.t_game_desk.ColumnCount; col++)
                {
                    for (int rows = 0; rows < form_Game.t_game_desk.RowCount; rows++)
                    {
                        figure_arr[rows, col] = new Figure();
                        form_Game.t_game_desk.Controls.Add(figure_arr[rows, col].getLabel, col, rows);
                    }
                }

            }
           
            
            private class Figure : Figure_stek
            {
                Label label = new Label()
                {
                    Margin = new Padding(4, 4, 4, 4),
                    Dock = DockStyle.Fill,

                };

                int type;
                public Figure()
                //TODO заменить на картинки
                {
                    switch (rnd.Next() % 5)
                    {
                        case 0:
                            label.BackColor = Color.Red;
                            type = 0;
                            break;
                        case 1:
                            label.BackColor = Color.Blue;
                            type = 1;
                            break;
                        case 2:
                            label.BackColor = Color.Orange;
                            type = 2;
                            break;
                        case 3:
                            label.BackColor = Color.Green;
                            type = 3;
                            break;
                        case 4:
                            label.BackColor = Color.Black;
                            type = 4;
                            break;
                    }


                }
                public Label getLabel
                {
                    get => label;
                }
            }
            


        }


    }


}
