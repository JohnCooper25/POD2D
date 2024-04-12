using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.UtalEngine2D_2023_1.Physics
{
    public class CircleCollider : Collider
    {
        public float radius;
        public CircleCollider(Rigidbody rigidbody, float radius) : base(rigidbody)
        {
            this.radius = radius;
        }

        public override bool CheckCollision(Collider other)
        {
            CircleCollider otherC = other as CircleCollider;
            if(otherC != null)
            {
                Vector2 distVector = otherC.rigidbody.transform.position - rigidbody.transform.position;
                float squareDist = distVector.x * distVector.x + distVector.y * distVector.y;
                if (squareDist < (radius + otherC.radius) * (otherC.radius + otherC.radius))
                {
                    return true;
                }

            }
            RectCollider otherRC = other as RectCollider;
            if(otherRC != null)
            {
                return otherRC.CheckCollision(this);
            }
            return false;
        }
        public bool CheckPointInCircle(Vector2 point)
        {
            Vector2 distVector = point - rigidbody.transform.position;
            float squareDist = distVector.x * distVector.x + distVector.y * distVector.y;
            if (squareDist < radius * radius)
            {
                return true;
            }
            return false;
        }
    }
}
