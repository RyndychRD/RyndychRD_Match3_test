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
        //start of configuration list
        
        int s = 60;

        const int cell_size = 50;

        const int count_cell = 8;

        const int figure_speed = 2;

        const int step_of_falling = 2;

        const int figure_size = 40;

        const string linebonus_col = "|";
        const string line_bonus_row = "--";
        const string bomb_bonus = "*";

        const int destroyer_step = 10;
        const int destroyer_speed = 2;
        //end of configuration list

        Figure_table figure_table;

        private readonly Form_main main;

        bool is_debag_on;


        public Form_game(Form_main Form_main)
        {
            InitializeComponent();
            main = Form_main;
          

            Draw_game_desk();

            t_game_desk.Width = cell_size * count_cell;
            t_game_desk.Height = cell_size * count_cell;
            this.Width = cell_size * count_cell + 17;
            this.Height = cell_size * count_cell + curtain_top.Height + 40;

            figure_table = new Figure_table(this);
            figure_table.Fill_table();
            countdown_timer.Start();


        }
        //Function of background drawing. Make background chess plate
        private void Draw_game_desk()
        {
            Bitmap bmp = new Bitmap(t_game_desk.Width, t_game_desk.Height);

            Graphics g_game_desk = Graphics.FromImage(bmp);
            SolidBrush b_dark_gray = new SolidBrush(Color.DarkGray);
            SolidBrush b_light_gray = new SolidBrush(Color.Gray);

            for (int x = 0; x < cell_size * count_cell; x += cell_size)
            {
                for (int y = 0; y < cell_size * count_cell; y += cell_size)
                {
                    if (((x / cell_size) % 2 == 1) ^ ((y / cell_size) % 2 == 1))
                    {
                        g_game_desk.FillRectangle(b_light_gray, x, y, cell_size, cell_size);
                    }
                    else
                    {
                        g_game_desk.FillRectangle(b_dark_gray, x, y, cell_size, cell_size);
                    }
                }
            }
            t_game_desk.BackgroundImage = bmp;
            
        }

       

          
           

        

        //Enable or disable debug mode. On debug mode we can swap any figures. No check or match fing enabled
        private void Form_game_debug_Click(object sender, EventArgs e)
        {
            is_debag_on = !(is_debag_on);
            if (is_debag_on)
            {
                b_debug.Text = "Debug on";
                countdown_timer.Stop();
            }
            else
            {
                b_debug.Text = "Debug off";
                countdown_timer.Start();
            }

        }

        //restart game qiuckly
        private void b_refill_Click(object sender, EventArgs e)
        {
            this.figure_table.clear_table();
            this.figure_table.Fill_table();
            this.l_score.Text = "0";
            s = 60;
            countdown_timer.Start();
        }
        
        //countdown timer untill gameover
        private void countdown_timer_Tick(object sender, EventArgs e)
        {
            s = s - 1;
            this.l_countdown_timer.Text = s.ToString();
            
            if (s == 0)
            {
                countdown_timer.Stop();
                MessageBox.Show("Game over");
                main.Show();
                this.Close();

            }

        }
        
        //protection for game window closing
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            main.Show();
        }


    }


}
