using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;



namespace RyndychRD_Match3_test
{
    public class Figure
    {
        public Label label = new Label()
        {
            
            Size = new Size(Consts.figure_size, Consts.figure_size),

        };
        public int col;
        public int row;

        public string bonus = null;

        public int type;



        public Figure_table figure_table;

        public void light_figure()
        {
            this.label.Size = new Size(Consts.cell_size, Consts.cell_size);
            this.label.Location = new Point(this.label.Location.X - (Consts.cell_size - Consts.figure_size) / 2, this.label.Location.Y - (Consts.cell_size - Consts.figure_size) / 2);

        }

        public void unlight_figure()
        {
            this.label.Size = new Size(Consts.figure_size, Consts.figure_size);
            this.label.Location = new Point(this.label.Location.X + (Consts.cell_size - Consts.figure_size) / 2, this.label.Location.Y + (Consts.cell_size - Consts.figure_size) / 2);

        }


        //Used for destroyer creation 
        public Figure(Figure figure_in)
        {

            this.label = new Label();

            label.Size = new Size(Consts.figure_size, Consts.figure_size);
            label.BackColor = Color.Bisque;
            label.Location = figure_in.label.Location;
            label.Show();
            this.col = figure_in.col;
            this.row = figure_in.row;

        }

        //create new figure, make type for it and remember its position in main matrix
        public Figure(int type_in, int row_in, int col_in, Figure_table figure_table_in)
        {
            figure_table = figure_table_in;

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
            label.Click += (sender, e) => figure_table.Label_Click(sender, e, this, figure_table);
        }


        //change picture or color of figure according to its type
        public void set_type_color(int typeIn = -2)
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

        //create type for figure and set it
        public void change_figure_type()
        {
            type = figure_table.rnd.Next() % 5;
            set_type_color();
        }


    }

}
