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
        private Form_main main;
        public Form_game()
        {
            InitializeComponent();
        }
        public Form_game(Form_main Form_main)
        {
            InitializeComponent();
            main = Form_main; 
        }

        private void Form_game_exit_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }
    }
}
