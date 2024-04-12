using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.UtalEngine2D_2023_1.Physics
{
    public class RectCollider : Collider
    {
        public Vector2 size;        
        public RectCollider(Rigidbody rigidbody, Vector2 size) : base(rigidbody)
        {
            this.size = size;
        }

        public override bool CheckCollision(Collider other)
        {
            CircleCollider otherC = other as CircleCollider;
            if (otherC != null)
            {
                //check if corners are in circle
                {
                    Vector2[] corners = new Vector2[4];
                    Vector2 pos = rigidbody.transform.position;
                    corners[0] = new Vector2(pos.x - size.x / 2, pos.y - size.y / 2);
                    corners[1] = new Vector2(pos.x + size.x / 2, pos.y - size.y / 2);
                    corners[2] = new Vector2(pos.x - size.x / 2, pos.y + size.y / 2);
                    corners[3] = new Vector2(pos.x + size.x / 2, pos.y + size.y / 2);
                    foreach (Vector2 v in corners)
                    {
                        if (otherC.CheckPointInCircle(v))
                        {
                            return true;
                        }
                    }
                }

                //check distance from boxed circle inside rectangle
                {
                    Vector2[] corners = new Vector2[4];
                    Vector2 pos = otherC.rigidbody.transform.position;
                    corners[0] = new Vector2(pos.x - otherC.radius, pos.y - otherC.radius);
                    corners[1] = new Vector2(pos.x + otherC.radius, pos.y - otherC.radius);
                    corners[2] = new Vector2(pos.x - otherC.radius, pos.y + otherC.radius);
                    corners[3] = new Vector2(pos.x + otherC.radius, pos.y + otherC.radius);
                    foreach (Vector2 v in corners)
                    {
                        if (CheckPointInRec(v))
                        {
                            return true;
                        }
                    }
                }

                //check stranger cases
            }

            RectCollider otherRC = other as RectCollider;
            if (otherRC != null)
            {
                Vector2[] corners = new Vector2[4];
                Vector2 pos = rigidbody.transform.position;
                corners[0] = new Vector2(pos.x - size.x / 2, pos.y - size.y / 2);
                corners[1] = new Vector2(pos.x + size.x / 2, pos.y - size.y / 2);
                corners[2] = new Vector2(pos.x - size.x / 2, pos.y + size.y / 2);
                corners[3] = new Vector2(pos.x + size.x / 2, pos.y + size.y / 2);
                foreach (Vector2 v in corners)
                {
                    if (otherRC.CheckPointInRec(v))
                    {
                        return true;
                    }
                }
                pos = otherRC.rigidbody.transform.position;
                corners[0] = new Vector2(pos.x - otherRC.size.x / 2, pos.y - otherRC.size.y / 2);
                corners[1] = new Vector2(pos.x + otherRC.size.x / 2, pos.y - otherRC.size.y / 2);
                corners[2] = new Vector2(pos.x - otherRC.size.x / 2, pos.y + otherRC.size.y / 2);
                corners[3] = new Vector2(pos.x + otherRC.size.x / 2, pos.y + otherRC.size.y / 2);
                foreach(Vector2 v in corners)
                {
                    if (CheckPointInRec(v))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CheckPointInRec(Vector2 point)
        {
            Vector2 center = rigidbody.transform.position;
            if(point.x > center.x-size.x/2 && point.x < center.x + size.x / 2 &&
               point.y > center.y - size.y / 2 && point.y < center.y + size.y / 2)
            {
                return true;
            }
            return false;
        }
    }
}
