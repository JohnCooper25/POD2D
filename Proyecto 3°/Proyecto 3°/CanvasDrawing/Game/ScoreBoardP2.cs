using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.Game
{
    public class ScoreBoardP2 : EmptyUpdatable
    {
        UtalText textbalas = new UtalText("P2: " + Score2, 500, 578);
        public static int Score2 = 0;

        public override void Update()
        {

            textbalas.drawString = ("P2:" + Score2).ToString();


        }
    }
}
