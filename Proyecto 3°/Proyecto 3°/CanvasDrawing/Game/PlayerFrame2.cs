using CanvasDrawing.UtalEngine2D_2023_1;
using CanvasDrawing.UtalEngine2D_2023_1.Physics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace CanvasDrawing.Game
{
    public class PlayerFrame2 : Frame
    {
        public static PlayerFrame2 Instance;

        public PlayerFrame2(float Speed, Image newsprite, Vector2 newSize, float x = 0, float y = 0) : base(Speed, newsprite, newSize, x, y)
        {
            Instance = this;
            rigidbody.isStatic = true;
            rigidbody.colliders[0].isSolid = true;
            Speed = 13000;
        }
        public override void OnCollisionEnter(GameObject other)
        {
            //renderer.sprite.Dispose();
            Console.WriteLine("Choque");
            //GameEngine.Destroy(other);}

        }

        public override void OnCollisionStay(GameObject other)
        {
            if (GameEngine.KeyUp(System.Windows.Forms.Keys.Space))
            {
                other.rigidbody.Velocity = transform.Right * 10;
            }
        }

        public override void Update()
        {

            //transform.rotation += Time.deltaTime * 100;
            Vector2 textPosition = GameEngine.WorldToCameraPos(transform.position);
            float speed = 300 * Time.deltaTime;
            //text.x = textPosition.x;
            //text.y = textPosition.y;
            if (GameEngine.KeyPress(System.Windows.Forms.Keys.Oemplus))
            {
                GameEngine.MainCamera.scale += Time.deltaTime;
            }
            if (GameEngine.KeyPress(System.Windows.Forms.Keys.OemMinus))
            {
                GameEngine.MainCamera.scale -= Time.deltaTime;
            }

            timerMove -= 1;

            bool moved = false;
            Vector2 auxLastPos = transform.position;
            /*if (GameEngine.KeyPress(System.Windows.Forms.Keys.W))
            {
                if (transform.position.y - 25 > 0)
                {
                    transform.position.y -= speed;
                    moved = true;
                }
            }
            if (GameEngine.KeyPress(System.Windows.Forms.Keys.S))
            {
                if (transform.position.y + 25 < 600)
                {
                    transform.position.y += speed;
                    moved = true;
                }
            }*/
            if (GameEngine.KeyPress(System.Windows.Forms.Keys.Left))
            {
                if (transform.position.x - 25 > 0)
                {
                    transform.position.x -= speed;
                    moved = true;
                }
            }
            if (GameEngine.KeyPress(System.Windows.Forms.Keys.Right))
            {
                if (transform.position.x + 25 < 600)
                {
                    transform.position.x += speed;
                    moved = true;
                }
            }
            if (moved)
            {
                lastPos = auxLastPos;
                myCamera.Position = transform.position;
                timerMove -= 1;

            }

        }

    }
}
