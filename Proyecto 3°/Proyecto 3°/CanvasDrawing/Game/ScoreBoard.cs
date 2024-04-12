using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.Game
{
    public class ScoreBoard : EmptyUpdatable
    {
        UtalText textpuntaje = new UtalText("P1: " + puntaje, 500, 0);
        public static int puntaje = 0;

        public override void Update()
        {
            textpuntaje.drawString = ("P1:" + puntaje).ToString();
        }
    }
}
