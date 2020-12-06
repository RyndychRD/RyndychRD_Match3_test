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
            Figure f = new Figure();
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

        private class Figure
        {
            Label[,] figure_arr;
            Random rnd = new Random();

            public Figure()
            {

            }

            public void Fill_table(Form_game form_Game)
            {
                figure_arr = new Label[form_Game.t_game_desk.ColumnCount, form_Game.t_game_desk.RowCount];
                for (int col = 0; col < form_Game.t_game_desk.ColumnCount; col++)
                {
                    for (int rows = 0; rows < form_Game.t_game_desk.RowCount; rows++)
                    {

                        Label l = new Label()
                        {
                            Margin = new Padding(4, 4, 4, 4),
                            Dock = DockStyle.Fill,

                        };

                        //TODO заменить на картинки
                        //TODO добавить дочерний класс с обозначением типа ячейки, пока сделаю на цветах
                        switch (rnd.Next() % 5)
                        {
                            case 0:
                                l.BackColor = Color.Red;
                                break;
                            case 1:
                                l.BackColor = Color.Blue;
                                break;
                            case 2:
                                l.BackColor = Color.Orange;
                                break;
                            case 3:
                                l.BackColor = Color.Green;
                                break;
                            case 4:
                                l.BackColor = Color.Black;
                                break;
                        }

                        figure_arr[rows, col] = l;
                        form_Game.t_game_desk.Controls.Add(l, col, rows);
                    }
                }

            }


        }


    }


}
