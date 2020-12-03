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

        bool is_debag_on = false;
        int s = 60;

        public Form_game(Form_main Form_main)
        {
            InitializeComponent();
            main = Form_main;

            Draw_game_desk();
            Figure_table f = new Figure_table(this);
            f.Fill_table();
            countdown_timer.Start();


        }

        private void Draw_game_desk()
        {
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

       //TODO Вынести его за пределы этого класса

        private class Figure_table
        {
            Figure[,] figure_arr;
            Random rnd = new Random();

            Figure figure_first;

            bool isClickedFirstFigure = false;
            Form_game form_Game;

            public Figure_table(Form_game form_Game_in)
            {
                form_Game = form_Game_in;
            }

            public void Fill_table()
            {
                //TODO rewrite for random num
                figure_arr = new Figure[8, 8];
                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        //TODO придумать генерацию маски или создать несколько маск и их применять
                        figure_arr[row, col] = new Figure(rnd.Next() % 5, row, col, this);

                        figure_arr[row, col].label.Location = new Point(23 + col * 50, 48 + row * 57);
                        form_Game.Controls.Add(figure_arr[row, col].label);
                        figure_arr[row, col].label.BringToFront();

                    }
                }

            }

            private void swap_figure(Figure figure_1, Figure figure_2)
            {


                Figure temp_fig1 = new Figure(figure_1);

                int col1 = figure_1.col;
                int row1 = figure_1.row;

                int col2 = figure_2.col;
                int row2 = figure_2.row;

                Label l1 = new Label();
                l1.BackColor = figure_1.label.BackColor;
                Label l2 = new Label();
                l2.BackColor = figure_2.label.BackColor;



                int posx_figure_1 = figure_1.label.Left;
                int posx_figure_2 = figure_2.label.Left;

                int posy_figure_1 = figure_1.label.Top;
                int posy_figure_2 = figure_2.label.Top;



                figure_arr[row1, col1].label.BackColor = l2.BackColor;

                figure_arr[row2, col2].label.BackColor = l1.BackColor; 




                temp_fig1.col = col2;
                temp_fig1.row = row2;
                figure_arr[row2, col2] = temp_fig1;

                //for(int i=0;i<10;i++)
                //{
                //    figure_arr[row1, col1].label.Top = figure_arr[row1, col1].label.Top + (posy_figure_1 - posy_figure_2)/10;
                //    figure_arr[row2, col2].label.Top = figure_arr[row2, col2].label.Top + (posy_figure_1 - posy_figure_2) / 10;
                //    figure_arr[row1, col1].label.Left += (posx_figure_1 - posx_figure_2) / 10;
                //    figure_arr[row2, col2].label.Left += (posx_figure_1 - posx_figure_2) / 10;
                //    Task.Delay(1000);
                //}

               // figure_arr[row1, col1].label.Location = new Point(posx_figure_1, posy_figure_1);
               // figure_arr[row2, col2].label.Location = new Point(posx_figure_2, posy_figure_2);

               

                figure_arr[row1, col1].label.Text = "x=" + figure_arr[row1, col1].col + "; y=" + figure_arr[row1, col1].row;
                figure_arr[row2, col2].label.Text = "x=" + figure_arr[row2, col2].col + "; y=" + figure_arr[row2, col2].row;


            }

            private bool is_near(Figure figure_1, Figure figure_2)
            {
                if ((Math.Abs(figure_1.col - figure_2.col) == 1) ^ (Math.Abs(figure_1.row - figure_2.row) == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private void Label_Click(object sender, EventArgs e, int row, int col, Figure_table figure_table)
            {
                if (isClickedFirstFigure)
                {
                    Figure temp= figure_arr[row, col];

                    figure_arr[row, col].label.Text = "2 click";

                    //if (!(form_Game.is_debag_on))
                    //{
                    //    if (is_near(figure_first, figure_arr[row, col]))
                    //    {
                    //        swap_figure(figure_first, figure_arr[row, col]);
                    //    }
                    //}
                    //else
                    //{
                        swap_figure(figure_first, figure_arr[row, col]);
                   // }
                    isClickedFirstFigure = false;
                    figure_first = null;
                }
                else
                {
                    figure_first = figure_arr[row,col];
                    figure_first.label.Text = "1 click";
                    isClickedFirstFigure = true;
                    //TODO light it up

                }

            }


            public class Figure
            {
                public Label label = new Label()
                {
                    Size = new Size(45, 52),

                };

                public int type;


                public int row;

                public int col;



                public Figure(Figure figure_to_copy)
                {
                    type = figure_to_copy.type;
                    row = figure_to_copy.row;
                    col = figure_to_copy.col;
                    label = figure_to_copy.label;
                }

                public Figure(int typeIn, int row_in, int col_in, Figure_table figure_table)
                {
                    label.Click += (sender, e) => figure_table.Label_Click(sender, e, this.row, this.col, figure_table);

                    switch (typeIn)
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
                    row = row_in;
                    col = col_in;

                }



            }



        }

        private void Form_game_debug_Click(object sender, EventArgs e)
        {
            is_debag_on = !(is_debag_on);
            if (is_debag_on)
            {
                Form_game_debug.Text = "Debug on";
                countdown_timer.Stop();
            }
            else
            {
                Form_game_debug.Text = "Debug off";
                countdown_timer.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = s - 1;
            this.countdown_label.Text = s.ToString();
            if (s == 0)
            {
                countdown_timer.Stop();
                MessageBox.Show("Game over");
                main.Show();
                this.Close();

            }

        }
    }


}
