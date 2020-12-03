using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace RyndychRD_Match3_test
{

    public partial class Form_game : Form
    {
        private readonly Form_main main;

        bool is_debag_on = false;
        int s = 60;

        int x_step = 50;
        int y_step = 50;

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
                figure_arr = new Figure[10, 10];
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        if (row == 0 || col == 0 || row == 9 || col == 9)
                        {
                            figure_arr[row, col] = new Figure(-1, row, col, this);
                            continue;
                        }
                        figure_arr[row, col] = new Figure(rnd.Next() % 5, row, col, this);
                        figure_arr[row, col].label.Location = new Point(23 + (col - 1) * 50, 48 + (row - 1) * 50);
                        form_Game.Controls.Add(figure_arr[row, col].label);
                        figure_arr[row, col].label.BringToFront();
                    }
                }

                for (int row = 1; row < 9; row++)
                {
                    for (int col = 1; col < 9; col++)
                    {
                        is_resulted(figure_arr[row, col],false);
                    }
                }
                form_Game.score_label.Text = "0";


            }

            private void swap_figure(Figure figure_1, Figure figure_2)
            {
                int col1 = figure_1.col;
                int row1 = figure_1.row;

                int col2 = figure_2.col;
                int row2 = figure_2.row;

                int temp_col = figure_1.col;
                figure_1.col = figure_2.col;
                figure_2.col = temp_col;

                int temp_row = figure_1.row;
                figure_1.row = figure_2.row;
                figure_2.row = temp_row;

                figure_arr[row1, col1] = figure_2;
                figure_arr[row2, col2] = figure_1;


                int posx_figure_1 = figure_1.label.Left;
                int posx_figure_2 = figure_2.label.Left;

                int posy_figure_1 = figure_1.label.Top;
                int posy_figure_2 = figure_2.label.Top;

                figure_2.label.Location = new Point(posx_figure_1, posy_figure_1);
                figure_1.label.Location = new Point(posx_figure_2, posy_figure_2);




            }

            private void move_figure(Figure figure_1, Figure figure_2)
            {
                int col1 = figure_1.col;
                int row1 = figure_1.row;

                int col2 = figure_2.col;
                int row2 = figure_2.row;

                int temp_col = figure_1.col;
                figure_1.col = figure_2.col;
                figure_2.col = temp_col;

                int temp_row = figure_1.row;
                figure_1.row = figure_2.row;
                figure_2.row = temp_row;

                figure_arr[row1, col1] = figure_2;
                figure_arr[row2, col2] = figure_1;


                int posx_figure_1 = figure_1.label.Left;
                int posx_figure_2 = figure_2.label.Left;

                int posy_figure_1 = figure_1.label.Top;
                int posy_figure_2 = figure_2.label.Top;

                for (int i = 0; i < 25; i++)
                {
                    figure_1.label.Left += (posx_figure_2 - posx_figure_1) / 25;
                    figure_2.label.Left += (posx_figure_1 - posx_figure_2) / 25;
                    figure_1.label.Top += (posy_figure_2 - posy_figure_1) / 25;
                    figure_2.label.Top += (posy_figure_1 - posy_figure_2) / 25;
                    form_Game.Refresh();
                    Thread.Sleep(1);
                }
                figure_2.label.Location = new Point(posx_figure_1, posy_figure_1);
                figure_1.label.Location = new Point(posx_figure_2, posy_figure_2);
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

            private bool is_resulted(Figure figure,  bool is_animated)
            {
                int x = figure.col;
                int y = figure.row;

                List<int> sameX = new List<int>();
                List<int> sameY = new List<int>();

                int same_type = figure_arr[y, x].type;
                for (int i = 1; i < 9; i++)
                {
                    if (figure_arr[y, i].type == same_type)
                    {
                        if (sameX.Count == 0)
                        {
                            sameX.Add(i);
                        }
                        if (i == sameX.Last() + 1)
                        {
                            sameX.Add(i);
                        }
                    }
                    else
                    {
                        if (sameX.Count() < 3)
                        {
                            sameX.Clear();
                        }

                    }
                    if (figure_arr[i, x].type == same_type)
                    {
                        if (sameY.Count == 0)
                        {
                            sameY.Add(i);
                        }
                        if (i == sameY.Last() + 1)
                        {
                            sameY.Add(i);
                        }
                    }
                    else
                    {
                        if (sameY.Count() < 3)
                        {
                            sameY.Clear();
                        }

                    }
                }
                if (sameX.Count > 2 || sameY.Count() > 2)
                {
                    delete_resulted_and_spawn_new(x, y, sameX, sameY,  is_animated);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void delete_resulted_and_spawn_new(int x_figure, int y_figure, List<int> sameX, List<int> sameY,bool is_animated)
            {
                if (sameX.Count > 2)
                {
                    foreach (int x in sameX)
                    {
                        figure_arr[y_figure, x].label.Hide();
                    }
                            foreach (int x in sameX)
                    {
                        for (int i = y_figure; i > 1; i--)
                        {
                            if (is_animated)
                            {
                                move_figure(figure_arr[i, x], figure_arr[i - 1, x]);
                            }
                            else
                            {
                                swap_figure(figure_arr[i, x], figure_arr[i - 1, x]);
                            }

                        }
                        figure_arr[1, x].type = rnd.Next() % 5;
                        figure_arr[1, x].set_type_color(figure_arr[1, x].type);
                     
                    }
                    

                    form_Game.score_label.Text = (Convert.ToInt32(form_Game.score_label.Text) + 100 * sameX.Count).ToString();

                }
                if (sameY.Count > 2)
                {
                    
                    foreach(int y in sameY)
                    {
                        figure_arr[y, x_figure].label.Hide();
                    }

                    for (int i = 0; i < sameY.Count(); i++)
                    {
                        figure_arr[sameY.Last() - i, x_figure].type = rnd.Next() % 5;
                        figure_arr[sameY.Last() - i, x_figure].set_type_color(figure_arr[sameY.Last() - i, x_figure].type);

                    }

                    for (int i = sameY.Last(); i > sameY.Count(); i--)
                    {
                        if (is_animated)
                        {
                            // figure_arr[i, x_figure].label.Show();

                             move_figure(figure_arr[i, x_figure], figure_arr[i - sameY.Count(), x_figure]);

                        }
                        else
                        {
                            swap_figure(figure_arr[i, x_figure], figure_arr[i - sameY.Count(), x_figure]);
                        }
                    }
                
                   

                        form_Game.score_label.Text = (Convert.ToInt32(form_Game.score_label.Text) + 100 * sameY.Count).ToString();
                }
                foreach (Figure f in figure_arr)
                {
                    f.label.Show();
                }
                for (int i = 1; i < 9; i++)
                {
                    
                        is_resulted(figure_arr[i, x_figure], true);
                        is_resulted(figure_arr[y_figure, i], true);
                }
            }

            private void Label_Click(object sender, EventArgs e, Figure figure_in, Figure_table figure_table)
            {
                if (isClickedFirstFigure)
                {
                    figure_first.label.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    figure_in.label.Text = "2 click";

                    if (!(form_Game.is_debag_on))
                    {
                        if (is_near(figure_first, figure_in))
                        {
                            move_figure(figure_first, figure_in);
                            if (!(is_resulted(figure_first, true) || is_resulted(figure_in, true)))
                            {
                                move_figure(figure_first, figure_in);
                            }
                            isClickedFirstFigure = false;
                            figure_first = null;
                        }
                        else
                        {
                            figure_first = figure_in;
                            figure_first.label.Text = "1 click";
                            isClickedFirstFigure = true;
                        }
                    }
                    else
                    {
                        swap_figure(figure_first, figure_in);
                        isClickedFirstFigure = false;
                        figure_first = null;
                    }

                }
                else
                {
                    figure_in.label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    figure_first = figure_in;
                    figure_first.label.Text = "1 click";
                    isClickedFirstFigure = true;
                    //TODO light it up

                }

            }

            public class Figure
            {
                public Label label = new Label()
                {
                    Size = new Size(45, 45),

                };
                public int col;
                public int row;

                public int type;

                public Figure_table figure_table;

               

                public Figure( Figure figure_in)
                {

                    this.label = figure_in.label;
                    this.col = figure_in.col;
                    this.row = figure_in.row;
                    this.type = figure_in.type;
                    this.figure_table = figure_in.figure_table;

                }


                public Figure(int typeIn, int row_in, int col_in, Figure_table figure_table_in)
                {

                    this.set_type_color(typeIn);
                    row = row_in;
                    col = col_in;
                    figure_table = figure_table_in;
                    label.Click += (sender, e) => figure_table.Label_Click(sender, e, this, figure_table);


                }
                public void set_type_color(int typeIn)
                {
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
                        
                        case -1:
                            label.Dispose();
                            type = -1;
                            break;
                    }

                }
                public class LineBonus : Figure 
                {
                    bool dir;// false-col, true-row
                    Random r = new Random();

                    public LineBonus(Figure figure_in) : base (figure_in)
                    {
                        dir = r.Next() % 2==0;  
                        if (dir)
                        {

                            label.Text = "Line row";
                        }
                        else
                        {
                            label.Text = "Line col";
                        }
                    }

                }

                public class BombBonus : Figure
                {
                    public BombBonus(Figure figure_in) : base(figure_in)
                    {
                        label.Text = "BOMB";
                    }

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

        private void countdown_timer_Tick(object sender, EventArgs e)
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
