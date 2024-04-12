using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.Game
{
    class Wall2 : GameObject
    {
        public bool PushDown;
        public int vida = 1;
        public Wall2(Image newSprite, Vector2 newSize, float xPos = 0, float yPos = 0) : base(newSprite, newSize, xPos, yPos)
        {
            rigidbody.isStatic = true;
        }
        public override void OnCollisionEnter(GameObject other)
        {

            base.OnCollisionEnter(other);
            Frame f = other as Frame;
            //f?.GoBack();
        }
    }
}

