using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyndychRD_Match3_test
{

    //class for pointing out which figures in what column we need to move and for how many steps
    public class ColToFall
    {
        public List<Figure> Figure_to_move;
        //Count of rows above deleted figures
        public int Count_row_to_fall;
        //Count of deleted figures
        public int Count_row_deleted;
        public int col;
        public ColToFall()
        {
            Figure_to_move = new List<Figure>();
            Count_row_to_fall = 0;
            Count_row_deleted = 0;
            col = 0;
        }

    }
}
