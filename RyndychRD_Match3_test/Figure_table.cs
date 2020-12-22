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
    public class Figure_table
    {
        //Matrix of figures, which contain each playable figure and using for figure right switching and deleting
        Figure[,] figure_arr;
        Random rnd = new Random();

        //variables to know if we have already clicked on figure and which figure it is
        Figure figure_first;
        bool is_clicked_first_figure;

        Form_game Form_Game;

        public Figure_table(Form_game form_Game_in)
        {
            Form_Game = form_Game_in;
            figure_arr = new Figure[count_cell + 2, count_cell + 2];
        }

        //delete all figures on table
        public void clear_table()
        {
            for (int row = 0; row < count_cell + 2; row++)
            {
                for (int col = 0; col < count_cell + 2; col++)
                {

                    figure_arr[row, col].label.Dispose();
                    figure_arr[row, col].type = -1;
                    figure_arr[row, col].row = -1;
                    figure_arr[row, col].col = -1;


                }
            }
        }

        //formula to get right figure position on chess plate
        private Point get_Location_of_col_and_row(int col, int row)
        {
            int padding = (cell_size - figure_size) / 2;

            return new Point(Form_Game.t_game_desk.Left + padding + (col - 1) * cell_size,
                             Form_Game.t_game_desk.Top + padding + (row - 1) * cell_size);
        }


        //function to fill table with figures. first and last column and row is used for borders and to make match checking easier
        public void Fill_table()
        {
            for (int row = 0; row < count_cell + 2; row++)
            {

                for (int col = 0; col < count_cell + 2; col++)
                {
                    if (row == 0 || col == 0 || row == count_cell + 1 || col == count_cell + 1)
                    {
                        figure_arr[row, col] = new Figure(-1, row, col, this);
                        figure_arr[row, col].label.Hide();
                    }
                    else
                    {
                        figure_arr[row, col] = new Figure(rnd.Next() % 5, row, col, this);
                    }
                    figure_arr[row, col].label.Location = get_Location_of_col_and_row(col, row);
                    Form_Game.Controls.Add(figure_arr[row, col].label);
                    figure_arr[row, col].label.BringToFront();

                }
            }

            //checking if after filling we have match already. If so, make figure type to be so that match cannot be
            for (int row = 1; row < count_cell + 1; row++)
            {
                for (int col = 1; col < count_cell + 1; col++)
                {
                    //does not used. Made only because of ref argument in function. 
                    List<Figure> temp = new List<Figure>();
                    if (is_resulted(figure_arr[row, col], ref temp))
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

        //function to swap figure with animation
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
            //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            //timer.Interval = 1;

            //timer.Start();
            //int count = 0;
            //int max = 25;
            //timer.Tick += new EventHandler((o, ev) =>
            //{
            for (int i = 0; i < 25; i++)
            {
                figure_1.label.Left += (posx_figure_2 - posx_figure_1) / 25;
                figure_2.label.Left += (posx_figure_1 - posx_figure_2) / 25;
                figure_1.label.Top += (posy_figure_2 - posy_figure_1) / 25;
                figure_2.label.Top += (posy_figure_1 - posy_figure_2) / 25;
                Form_Game.Refresh();
                //count++;
                //if (count == max)
                //{
                //    System.Windows.Forms.Timer t = o as System.Windows.Forms.Timer; // можно тут просто воспользоваться timer
                //    t.Stop();
                //}
            }
        }
        //    });
        //    //figure_2.label.Location = new Point(posx_figure_1, posy_figure_1);
        //    //figure_1.label.Location = new Point(posx_figure_2, posy_figure_2);
        //}

        //check if second clicked figure is near first one
        private bool is_near(Figure figure_1, Figure figure_2)
        {
            return
               ((Math.Abs(figure_1.col - figure_2.col) == 1) && (figure_1.row == figure_2.row)) ^
               ((Math.Abs(figure_1.row - figure_2.row) == 1) && (figure_1.col == figure_2.col));

        }

        //check if match happend and return list of matched figures we need to proceed
        private bool is_resulted(Figure figure, ref List<Figure> figures_to_delete)
        {
            figures_to_delete.Clear();
            List<int> row_match = new List<int>();
            List<int> col_match = new List<int>();

            int in_figure_type = figure_arr[figure.row, figure.col].type;

            //look up
            int i = figure.row;
            while (i > 0 && figure_arr[i, figure.col].type == in_figure_type)
            {
                col_match.Add(i);
                i--;
            }
            //look down
            i = figure.row + 1;
            while (i < count_cell + 1 && figure_arr[i, figure.col].type == in_figure_type)
            {
                col_match.Add(i);
                i++;
            }
            //look left
            i = figure.col;
            while (i > 0 && figure_arr[figure.row, i].type == in_figure_type)
            {
                row_match.Add(i);
                i--;
            }
            //look right
            i = figure.col + 1;
            while (i < count_cell + 1 && figure_arr[figure.row, i].type == in_figure_type)
            {
                row_match.Add(i);
                i++;
            }

            //if match in row
            if (row_match.Count > 2)
            {
                foreach (int x in row_match)
                {
                    figures_to_delete.Add(figure_arr[figure.row, x]);
                }
            }
            //if match in column
            if (col_match.Count > 2)
            {
                foreach (int y in col_match)
                {
                    figures_to_delete.Add(figure_arr[y, figure.col]);
                }
            }
            return (figures_to_delete.Count > 0);
        }



        //check if any match around figure and call to delete it and spawn new
        private bool find_match3_and_match_it(Figure figure)
        {
            List<Figure> figures_to_delete = new List<Figure>();
            if (is_resulted(figure, ref figures_to_delete))
            {

                delete_resulted_and_spawn_new(figures_to_delete, figure);
                return true;
            }
            else
            {
                return false;
            }

        }

        //function used for animation of figures falling
        private void move_figures_down(List<Figure> Figure_to_move)
        {
            for (int count_steps = 0; count_steps < (cell_size / step_of_falling); count_steps++)
            {
                foreach (Figure figure in Figure_to_move)
                {
                    figure.label.Top += step_of_falling;
                }
                Form_Game.Refresh();

                Thread.Sleep(figure_speed);
            }
        }

        //changing of z coordinate of interface elements
        private void curtain_up()
        {
            Form_Game.curtain_top.BringToFront();
            Form_Game.b_refill.BringToFront();
            Form_Game.l_score.BringToFront();
            Form_Game.l_score_text.BringToFront();
            Form_Game.l_countdown_timer_text.BringToFront();
            Form_Game.b_debug.BringToFront();
            Form_Game.l_countdown_timer.BringToFront();
        }

        //function used for animation of destroyer
        private void move_destroyer(Figure start_figure)
        {
            string dir = start_figure.bonus;
            Figure destroyer_1 = new Figure(start_figure);
            Figure destroyer_2 = new Figure(start_figure);
            Form_Game.Controls.Add(destroyer_1.label);
            Form_Game.Controls.Add(destroyer_2.label);
            destroyer_1.label.BringToFront();
            destroyer_2.label.BringToFront();
            curtain_up();

            //variables used for moving around row or column axes according to line bonus figure
            int figure_to_destroyer_1_pos;
            int figure_to_destroyer_2_pos;

            //if linebonus is column destroyer bonus
            if (dir == linebonus_col)
            {
                figure_to_destroyer_1_pos = start_figure.row;
                figure_to_destroyer_2_pos = start_figure.row;

                while (destroyer_1.label.Top > get_Location_of_col_and_row(0, 0).Y ||
                    destroyer_2.label.Top < get_Location_of_col_and_row(0, count_cell + 2).Y)
                {
                    if (destroyer_1.label.Top > get_Location_of_col_and_row(0, 0).Y)
                    {
                        destroyer_1.label.Top -= destroyer_step;
                        if (destroyer_1.label.Top < figure_arr[figure_to_destroyer_1_pos, start_figure.col].label.Top &&
                            figure_to_destroyer_1_pos > 0)
                        {
                            figure_arr[figure_to_destroyer_1_pos, start_figure.col].label.Hide();
                            figure_to_destroyer_1_pos--;
                        }
                    }
                    if (destroyer_2.label.Top < get_Location_of_col_and_row(count_cell + 2, count_cell + 2).Y)
                    {
                        destroyer_2.label.Top += destroyer_step;
                        if (destroyer_2.label.Top > figure_arr[figure_to_destroyer_2_pos, start_figure.col].label.Top &&
                            figure_to_destroyer_2_pos < count_cell + 1)
                        {
                            figure_arr[figure_to_destroyer_2_pos, start_figure.col].label.Hide();
                            figure_to_destroyer_2_pos++;
                        }
                    }
                    Form_Game.Refresh();
                    Thread.Sleep(destroyer_speed);
                }
            }

            //if linebonus is row destroyer bonus
            if (dir == line_bonus_row)
            {
                figure_to_destroyer_1_pos = start_figure.col;
                figure_to_destroyer_2_pos = start_figure.col;
                while (destroyer_1.label.Left > get_Location_of_col_and_row(0, 0).X ||
                    destroyer_2.label.Left < get_Location_of_col_and_row(count_cell + 2, count_cell + 2).X)
                {
                    if (destroyer_1.label.Left > get_Location_of_col_and_row(0, 0).X)
                    {
                        destroyer_1.label.Left -= destroyer_step;
                        if (destroyer_1.label.Left < figure_arr[start_figure.row, figure_to_destroyer_1_pos].label.Left &&
                            figure_to_destroyer_1_pos > 0)
                        {
                            figure_arr[start_figure.row, figure_to_destroyer_1_pos].label.Hide();
                            figure_to_destroyer_1_pos--;
                        }
                    }
                    if (destroyer_2.label.Left < get_Location_of_col_and_row(count_cell + 2, count_cell + 2).X)
                    {
                        destroyer_2.label.Left += destroyer_step;
                        if (destroyer_2.label.Left > figure_arr[start_figure.row, figure_to_destroyer_2_pos].label.Left &&
                            figure_to_destroyer_2_pos < count_cell + 1)
                        {
                            figure_arr[start_figure.row, figure_to_destroyer_2_pos].label.Hide();
                            figure_to_destroyer_2_pos++;
                        }
                    }
                    Form_Game.Refresh();
                    Thread.Sleep(destroyer_speed);
                }


            }
            destroyer_1.label.Dispose();
            destroyer_2.label.Dispose();

        }

        //function used for checking if any bonus is matched and proceed matched ones to delete
        private List<Figure> bonus_blast(List<Figure> figures_to_delete)
        {
            List<Figure> figures_temp = new List<Figure>();
            int figures_to_delete_count = figures_to_delete.Count;
            for (int i = 0; i < figures_to_delete_count; i++)
            {
                if (figures_to_delete[i].bonus == linebonus_col)
                {
                    for (int j = 1; j < count_cell + 1; j++)
                    {
                        figures_to_delete.Add(figure_arr[j, figures_to_delete[i].col]);
                        figures_to_delete_count++;
                    }

                    move_destroyer(figures_to_delete[i]);
                    figures_to_delete[i].bonus = null;
                }
                if (figures_to_delete[i].bonus == line_bonus_row)
                {
                    for (int j = 1; j < count_cell + 1; j++)
                    {
                        figures_to_delete.Add(figure_arr[figures_to_delete[i].row, j]);
                        figures_to_delete_count++;

                    }

                    move_destroyer(figures_to_delete[i]);
                    figures_to_delete[i].bonus = null;
                }
                if (figures_to_delete[i].bonus == bomb_bonus)
                {
                    figures_to_delete[i].label.Hide();
                    Form_Game.Refresh();
                    for (int j = -1; j < 2; j++)
                    {
                        for (int k = -1; k < 2; k++)
                            if (figure_arr[figures_to_delete[i].row + j, figures_to_delete[i].col + k].type != -1)
                            {
                                figures_to_delete.Add(figure_arr[figures_to_delete[i].row + j, figures_to_delete[i].col + k]);
                                figures_to_delete_count++;
                            }
                    }
                    figures_to_delete[i].bonus = null;

                    Thread.Sleep(250);
                }

            }

            figures_temp.AddRange(figures_to_delete);
            figures_to_delete = figures_temp.Distinct().ToList();
            return figures_to_delete;
        }

        //change figure to line bonus
        private Figure make_line_bonus(Figure last_figure)
        {
            last_figure.bonus = rnd.Next() % 2 == 0 ? linebonus_col : line_bonus_row;
            last_figure.label.Text = last_figure.bonus;
            last_figure.label.ForeColor = Color.White;
            last_figure.label.Font = new Font("Tobota", 25, FontStyle.Regular);
            last_figure.label.TextAlign = ContentAlignment.TopCenter;
            return last_figure;
        }
        //change figure to bomb bonus
        private Figure make_bomb_bonus(Figure last_figure)
        {
            last_figure.bonus = bomb_bonus;
            last_figure.label.Text = last_figure.bonus;
            last_figure.label.ForeColor = Color.White;
            last_figure.label.Font = new Font("Tobota", 25, FontStyle.Regular);
            last_figure.label.TextAlign = ContentAlignment.MiddleCenter;
            return last_figure;
        }

        //animation of deleting and spawn new figures after match. Get list of figures to delete based on is_resulted list
        private void delete_resulted_and_spawn_new(List<Figure> figures_to_delete, Figure last_figure)
        {

            ColToFall[] colToFalls = new ColToFall[count_cell + 2];
            for (int i = 0; i < colToFalls.Length; i++)
            {
                colToFalls[i] = new ColToFall();
            }

            int figures_to_delete_count_before_bonus_blast = figures_to_delete.Count;

            figures_to_delete = bonus_blast(figures_to_delete);

            if (figures_to_delete_count_before_bonus_blast == 4)
            {
                last_figure = make_line_bonus(last_figure);
                figures_to_delete.Remove(last_figure);
            }

            if (figures_to_delete_count_before_bonus_blast > 4)
            {
                last_figure = make_bomb_bonus(last_figure);
                //to make bomb bonus we can add 1 figure 2 times. It resolve this issue
                figures_to_delete.Remove(last_figure);
                figures_to_delete.Remove(last_figure);
            }

            Form_Game.l_score.Text = (Convert.ToInt32(Form_Game.l_score.Text) + 100 * figures_to_delete.Count).ToString();

            //for each figure in list to delete we remember to move figures above one cell down 
            //and create new figure, waiting for its time to fall down on border position
            foreach (Figure f in figures_to_delete)
            {

                f.label.Dispose();
                for (int i = f.row - 1; i > 0; i--)
                {
                    colToFalls[f.col].Figure_to_move.Add(figure_arr[i, f.col]);
                    colToFalls[f.col].Count_row_to_fall++;
                    figure_arr[i + 1, f.col] = figure_arr[i, f.col];
                    figure_arr[i + 1, f.col].row = i + 1;
                }
                colToFalls[f.col].Count_row_deleted++;
                figure_arr[1, f.col] = new Figure(-1, 1, f.col, this);

                colToFalls[f.col].Figure_to_move.Add(figure_arr[1, f.col]);
                Form_Game.Controls.Add(figure_arr[1, f.col].label);
                figure_arr[1, f.col].change_figure_type();
                figure_arr[1, f.col].label.Location = get_Location_of_col_and_row(f.col, 0);
                figure_arr[1, f.col].label.Show();
                figure_arr[1, f.col].label.BringToFront();
                curtain_up();

            }
            //move all necessary figures until we've moved all of them
            bool is_any_left = true;
            do
            {
                List<Figure> figures_to_fall = new List<Figure>();
                is_any_left = true;
                for (int i = 0; i < colToFalls.Length; i++)
                {
                    if (colToFalls[i].Count_row_to_fall >= 0)
                    {
                        figures_to_fall.AddRange(colToFalls[i].Figure_to_move);
                        colToFalls[i].Count_row_to_fall--;
                        is_any_left = false;
                    }

                }

                foreach (ColToFall col in colToFalls)
                {
                    col.Count_row_deleted--;
                }
                //after accumulating all figures we want to fall, move them. Accumulating is used for smoother animation
                move_figures_down(figures_to_fall);

            } while (is_any_left);

            //check if any new match appeared
            for (int i = 1; i < count_cell + 1; i++)
            {
                for (int j = 1; j < count_cell + 1; j++)
                {

                    find_match3_and_match_it(figure_arr[i, j]);
                }
            }



        }


        //if we click on figure first time, it lights up. If we click on figure near first one, it changes position and start to find match. 
        //if no match found, swap figures back. If second click is not near first one, change active figure
        //if debug is activated, just swap figures positions. No check or find match included
        private void Label_Click(object sender, EventArgs e, Figure figure_in, Figure_table figure_table)
        {
            if (is_clicked_first_figure)
            {
                figure_first.unlight_figure();


                if (!(Form_Game.is_debag_on))
                {
                    if (figure_first == figure_in)
                    {
                        is_clicked_first_figure = false;
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
                            is_clicked_first_figure = false;
                            figure_first = null;
                        }
                        else
                        {
                            figure_in.light_figure();
                            figure_first = figure_in;
                            is_clicked_first_figure = true;

                        }
                    }
                }
                else
                {
                    move_figure(figure_first, figure_in);
                    is_clicked_first_figure = false;
                    figure_first = null;
                }

            }
            else
            {
                figure_in.light_figure();
                figure_first = figure_in;
                is_clicked_first_figure = true;

            }

        }
    }
}
