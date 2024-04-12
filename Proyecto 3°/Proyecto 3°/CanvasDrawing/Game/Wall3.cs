using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.Game
{
    class Wall3 : GameObject
    {
        public bool PushDown;
        public int vida = 1;
        public Wall3(Image newSprite, Vector2 newSize, float xPos = 0, float yPos = 0) : base(newSprite, newSize, xPos, yPos)
        {
            rigidbody.isStatic = true;
            rigidbody.colliders[0].isSolid = true;
        }
        public override void OnCollisionEnter(GameObject other)
        {

            base.OnCollisionEnter(other);
            Frame f = other as Frame;
            //f?.GoBack();
        }
    }
}

