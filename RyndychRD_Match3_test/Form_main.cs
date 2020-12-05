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
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_playbutton_Click(object sender, EventArgs e)
        {
            Form_game Form_game = new Form_game(this);
            Form_game.Show();
            this.Hide();
        }
    }
}
