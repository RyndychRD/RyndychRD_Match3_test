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

        const int count_cell = 8;

        Figure_table f;

        int figure_size = 40;

        public Form_game(Form_main Form_main)
        {
            InitializeComponent();
            main = Form_main;

            Draw_game_desk();
            f = new Figure_table(this);
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
            //Figure destroyer_2 = new Figure();
            //Figure destroyer_1 = new Figure();

            Figure[,] figure_arr=new Figure[10, 10];
            Random rnd = new Random();

            Figure figure_first;

            bool isClickedFirstFigure = false;
            Form_game form_Game;

            public Figure_table(Form_game form_Game_in)
            {
                form_Game = form_Game_in;
            }

            public void clear_table()
            {
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 10; col++) 
                    { 

                        figure_arr[row, col].label.Dispose();
                        figure_arr[row, col].type = -1;
                        figure_arr[row, col].row = -1;
                        figure_arr[row, col].col = -1;


                    }
                }
            }

            public void Fill_table()
            {
                //TODO rewrite for random num
                
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        if (row == 0 || col == 0 || row == 9 || col == 9)
                        {
                            figure_arr[row, col] = new Figure(-1, row, col, this);
                        }
                        else
                        {
                            figure_arr[row, col] = new Figure(rnd.Next() % 5, row, col, this);
                            int padding = (form_Game.x_step - form_Game.figure_size) / 2;
                            figure_arr[row, col].label.Location = new Point(form_Game.t_game_desk.Left + padding + (col - 1) * 50, 
                                                                            form_Game.t_game_desk.Top + padding + (row - 1) * 50);
                            form_Game.Controls.Add(figure_arr[row, col].label);
                            figure_arr[row, col].label.BringToFront();
                        }
                    }
                }


                for (int row = 1; row < 9; row++)
                {
                    for (int col = 1; col < 9; col++)
                    {
                        List<ColRow> zad1 = new List<ColRow>();
                        //TODO make it withput zad1
                        if(is_resulted(figure_arr[row, col],ref zad1))
                        {
                            List<int> new_type = new List<int>() { 0, 1, 2, 3, 4 };
                            new_type.Remove(figure_arr[row, col - 1].type);
                            new_type.Remove(figure_arr[row, col + 1].type);
                            new_type.Remove(figure_arr[row - 1, col].type);
                            new_type.Remove(figure_arr[row + 1, col].type);
                            figure_arr[row, col].type = new_type.Last();
                            figure_arr[row, col].set_type_color();
                        }
                    }
                }



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

            //private void move_destroyer_to_position(Figure d1, Figure d2, string dir)
            //{

            //    int posy_d1 = d1.label.Top;
            //    int posx_d1 = d1.label.Left;
            //    int posy_d2 = d2.label.Top;
            //    int posx_d2 = d2.label.Left;

            //    int posy_d1_distanation = form_Game.t_game_desk.Top;
            //    int posx_d1_distanation = form_Game.t_game_desk.Left;
            //    int posy_d2_distanation = form_Game.t_game_desk.Bottom - d2.label.Size.Height;
            //    int posx_d2_distanation = form_Game.t_game_desk.Right - d2.label.Size.Width;

            //    if (dir == "col")
            //    {
            //        posx_d1_distanation = posx_d1;
            //        posx_d2_distanation = posx_d2;
            //    }
            //    if (dir == "row")
            //    {
            //        posy_d1_distanation = posy_d1;
            //        posy_d2_distanation = posy_d2;
            //    }


            //    for (int i = 0; i < 25; i++)
            //    {
            //        d1.label.Left += (posx_d1_distanation - posx_d1) / 25;
            //        d1.label.Top += (posy_d1_distanation - posy_d1) / 25;

            //        d2.label.Left += (posx_d2_distanation - posx_d2) / 25;
            //        d2.label.Top += (posy_d2_distanation - posy_d2) / 25;
            //        form_Game.Refresh();
            //        Thread.Sleep(1);
            //    }
            //    //d1.label.Location = new Point(posx_d1_distanation, posy_d1_distanation);
            //    //d2.label.Location = new Point(posx_d2_distanation, posy_d2_distanation);

            //}
            //TODO добавить скорость падения
          

           
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

            private bool is_resulted(Figure figure, ref List<ColRow> point_to_delete)
            {
                List<int> sameX = new List<int>();
                List<int> sameY = new List<int>();

                int same_type = figure_arr[figure.row, figure.col].type;
                for (int i = 1; i < 9; i++)
                {
                    //TODO rewrite
                    if (figure_arr[figure.row, i].type == same_type)
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
                    if (figure_arr[i, figure.col].type == same_type)
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
                //TODO rewrite
                if (sameX.Count > 2 || sameY.Count() > 2)
                {
                    if (sameX.Count > 2)
                    {
                        foreach (int x in sameX)
                        {
                            point_to_delete.Add(new ColRow(x, figure.row));
                        }
                    }
                    if (sameY.Count > 2)
                    {
                        foreach (int y in sameY)
                        {
                            point_to_delete.Add(new ColRow(figure.col, y));
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool find_match3_and_match_it(Figure figure)
            {
                List<ColRow> point_to_delete = new List<ColRow>();
                if(is_resulted(figure,ref point_to_delete))
                {
                    delete_resulted_and_spawn_new(point_to_delete, figure);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }


            //private void delete_row( int row_figure, List<Point> sameX, Figure last_figure)
            //{

            //    ////create line bonus
            //    if (sameX.Count == 4)
            //    {
            //        figure_arr[last_figure.row, last_figure.col] = new Figure.LineBonus(last_figure);
            //        sameX.Remove(last_figure.col);
            //    }
                
            //   foreach (int x in sameX)
            //    {
            //        figure_arr[row_figure, x].label.Hide();
            //        //if(figure_arr[row_figure, x].label.Text=="Line col" || figure_arr[row_figure, x].label.Text == "Line row")
            //        //{
            //        //    Figure.LineBonus l1 = new Figure.LineBonus(figure_arr[row_figure, x]);
            //        //    destroyer_1.label.Show();
            //        //    destroyer_1.label.Text = "Destroyer_1";
            //        //    destroyer_1.label.BackColor = figure_arr[row_figure, x].label.BackColor;
            //        //    destroyer_1.label.Location = figure_arr[row_figure, x].label.Location;
            //        //    destroyer_1.label.BringToFront();

            //        //    destroyer_2.label.Show();
            //        //    destroyer_2.label.Text = "Destroyer_2";
            //        //    destroyer_2.label.BackColor = figure_arr[row_figure, x].label.BackColor;
            //        //    destroyer_2.label.Location = figure_arr[row_figure, x].label.Location;
            //        //    destroyer_2.label.BringToFront();
                        
            //        //    //move_destroyer_to_position(destroyer_1, destroyer_2, l1.dir);
                       

            //        //    //List<int> sameY = new List<int>();
            //        //    //for(int i = 1; i < 9; i++) { sameY.Add(i); }
            //        //    //delete_col(x, y_figure, sameY, last_figure, is_animated);
            //        //}
            //    }
            //    foreach (int x in sameX)
            //    {
            //        for (int i = row_figure; i > 1; i--)
            //        {
            //            move_figure(figure_arr[i, x], figure_arr[i - 1, x]);
            //        }
            //        figure_arr[1, x].type = rnd.Next() % 5;
            //        figure_arr[1, x].set_type_color(figure_arr[1, x].type);
            //        figure_arr[1, x].label.Text="";
            //        figure_arr[1, x].label.Show();

            //    }
            //    form_Game.score_label.Text = (Convert.ToInt32(form_Game.score_label.Text) + 100 * sameX.Count).ToString();

            //}
            ////private void delete_col(int col_figure, List<int> sameY, Figure last_figure)
            //{
            //    //create bonus line
            //    if (sameY.Count == 4)
            //    {
            //        figure_arr[last_figure.row, last_figure.col] = new Figure.LineBonus(last_figure);
                    
            //        foreach (int y in sameY)
            //        {
            //            figure_arr[y, col_figure].label.Hide();

            //        }
            //        figure_arr[last_figure.row, col_figure].label.Show();
            //        move_figure(figure_arr[last_figure.row, last_figure.col], figure_arr[sameY.Last(), last_figure.col]);
            //        sameY.Remove(sameY.Last());
            //    }
            //    foreach (int y in sameY)
            //    {
            //        figure_arr[y, col_figure].label.Hide();

            //    }
            //    for (int i = sameY.Last(); i > sameY.Count(); i--)
            //    {
            //            move_figure(figure_arr[i, col_figure], figure_arr[i - sameY.Count(), col_figure]);
            //    }
            //    for (int i = 0; i < sameY.Count(); i++)
            //    {
            //        figure_arr[1, col_figure].type = rnd.Next() % 5;
            //        figure_arr[1, col_figure].set_type_color(figure_arr[1, col_figure].type);
            //        figure_arr[1, col_figure].label.Text="";
            //        figure_arr[1, col_figure].label.Show();
            //        move_figure(figure_arr[1, col_figure], figure_arr[sameY.Count() - i, col_figure]);
            //    }



            //    form_Game.score_label.Text = (Convert.ToInt32(form_Game.score_label.Text) + 100 * sameY.Count).ToString();

            //}
            //TODO добавить скорость падения

            private void fall_down(ColRow figure_to_fall, int speed)
            {
                figure_arr[figure_to_fall.Row, figure_to_fall.Col].label.Top += speed;

            }
            public void delete_resulted_and_spawn_new(List<ColRow> figures_to_delete, Figure last_figure)
            {
                ColToFall[] colToFalls=new ColToFall[figure_arr.Length];
                int num_of_coll = 0;
                foreach(ColRow p in figures_to_delete)
                {
                    num_of_coll++;
                    figure_arr[p.Row, p.Col].label.Hide();
                    for(int i = p.Row-1; i > 0; i--)
                    {
                        colToFalls[num_of_coll].Figure_to_move.Add(figure_arr[i, p.Col]);
                        colToFalls[num_of_coll].Count_row++;
                    }
                    figure_arr[p.Row, p.Col].label.Location = figure_arr[0, p.Col].label.Location;
                }

                //for (int i = 1; i < 9; i++)
                //{

                //    find_match3_and_match_it(figure_arr[i, last_figure.col]);
                //    find_match3_and_match_it(figure_arr[last_figure.row, i]);
                //}


            }



            private void Label_Click(object sender, EventArgs e, Figure figure_in, Figure_table figure_table)
            {
                if (isClickedFirstFigure)
                {
                    figure_first.unlight_figure();
                   

                    if (!(form_Game.is_debag_on))
                    {
                        if (figure_first == figure_in)
                        {
                            isClickedFirstFigure = false;
                        }
                        else
                        {
                            if (is_near(figure_first, figure_in))
                            {
                                move_figure(figure_first, figure_in);
                                
                                if (!(find_match3_and_match_it(figure_first) || find_match3_and_match_it(figure_in)))
                                {
                                    move_figure(figure_first, figure_in);
                                }
                                isClickedFirstFigure = false;
                                figure_first = null;
                            }
                            else
                            {
                                figure_in.light_figure();
                                figure_first = figure_in;
                                isClickedFirstFigure = true;

                            }
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
                    figure_in.light_figure();
                    figure_first = figure_in;
                    isClickedFirstFigure = true;
                    //TODO light it up

                }

            }

            public class Figure
            {
                public Label label = new Label()
                {
                    Size = new Size(40, 40),

                };
                public int col;
                public int row;

                public int type;

                public Figure_table figure_table;

                public void light_figure()
                {
                    this.label.Size = new Size(figure_table.form_Game.x_step, figure_table.form_Game.y_step);
                    this.label.Location = new Point(this.label.Location.X-5, this.label.Location.Y-5);

                }

                public void unlight_figure()
                {
                    this.label.Size = new Size(figure_table.form_Game.figure_size, figure_table.form_Game.figure_size);
                    this.label.Location = new Point(this.label.Location.X + 5, this.label.Location.Y + 5);

                }

                public Figure()
                {

                }
                public Figure(Figure figure_in)
                {

                    this.label = figure_in.label;
                    this.col = figure_in.col;
                    this.row = figure_in.row;
                    this.type = figure_in.type;
                    figure_table = figure_in.figure_table;

                }

                public Figure(int type_in,int row_in, int col_in, Figure_table figure_table_in)
                {
                    if (type_in == -1)
                    {
                        type = type_in;
                    }
                    else
                    {
                        this.change_figure_type();
                    }
                    row = row_in;
                    col = col_in;
                    figure_table = figure_table_in;
                    label.Click += (sender, e) => figure_table.Label_Click(sender, e, this, figure_table);


                }
                public void set_type_color(int typeIn=-2)
                {
                    if (typeIn == -2)
                    {
                        typeIn = this.type;
                    }
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
              
                public void change_figure_type()
                {
                    type = figure_table.rnd.Next();
                    set_type_color();
                }
                
                //public class LineBonus : Figure
                //{
                //    public string dir;
                //    Random r = new Random(DateTime.Now.Millisecond);
                //    public Figure destroyer_1;
                //    public Figure destroyer_2;


                //    public LineBonus(Figure figure_in) : base(figure_in)
                //    {
                //        dir =  r.Next() % 2 == 0 ? "col": "row";
                //        label.Text = "Line "+dir;
                        

                //    }

                //}

                //public class BombBonus : Figure
                //{
                //    public BombBonus(Figure figure_in) : base(figure_in)
                //    {
                //        label.Text = "BOMB";
                //    }

                //}
            }

            public class ColRow
            {
                private int col;
                private int row;
                public int Col
                {
                    get
                    {
                        return col;
                    }
                    set
                    {
                        col = value;
                    }
                }
                public int Row
                {
                    get
                    {
                        return row;
                    }
                    set
                    {
                        row = value;
                    }
                }
                public ColRow(int col_in, int row_in)
                {
                    col = col_in;
                    row = row_in;
                }
            }

            public class ColToFall
            {
                public List<Figure> Figure_to_move = new List<Figure>();
                public int Count_row=0;
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

        private void b_refill_Click(object sender, EventArgs e)
        {
            this.f.clear_table();
            this.f.Fill_table();
            this.s = 60;
            countdown_timer.Start();
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
