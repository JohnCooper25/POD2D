using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.Game
{
    public class Bullet : GameObject
    {
        public Vector2 Direction;
        public float Speed;
        public float timeToDie = 5000f;
        public bool isEnemy = false;
        public Image[] animationImages;
        public int indexAnim;
        public float timeBTFrames = 0.2f;
        public float animTimer = 0.2f;
        public int vida = 1;
        public Bullet(Vector2 dir, float speed, Image newSprite, Vector2 newSize, float xPos = 0, float yPos = 0, bool isEnemy = false) : base(newSprite, newSize, xPos, yPos)
        {
            this.isEnemy = isEnemy;
            //rigidbody.colliders[0].isSolid = false;
            //rigidbody.isStatic = true;
            this.Direction = dir;
            this.Speed = speed*1.01f;
            animationImages = new Image[1];
            animationImages[0] = newSprite;
        }

        public override void Update()
        {
            base.Update();
            animTimer -= Time.deltaTime;
            this.Speed = Speed*1.01f;

            if (animTimer <= 0)
            {
                indexAnim++;
                indexAnim %= animationImages.Length;
                renderer.rotatedSprite = animationImages[indexAnim];
                animTimer = timeBTFrames;
            }


            transform.position += Direction * Speed * Time.deltaTime;
            
            if (timeToDie > 0)
            {
                timeToDie -= Time.deltaTime;
                if (timeToDie <= 0) {
                    GameEngine.Destroy(this);
                }
            }
        }
        public override void OnCollisionEnter(GameObject other)
        {
            if (other is Wall)
            {
                SoundPlayer gol;
                vida--;
                if (vida <= 0)
                {
                    base.OnDestroy();
                    GameEngine.Destroy(this);
                    PlayerFrame.Pelota++;
                    ScoreBoardP2.Score2 += 1;
                }
                gol = new SoundPlayer(Properties.Resources.Punto);
                gol.Play();

            }
            if(other is Wall2)
            {
                SoundPlayer gol;
                vida--;
                if(vida <= 0) 
                {
                    base.OnDestroy();
                    GameEngine.Destroy(this);
                    PlayerFrame.Pelota++;
                    ScoreBoard.puntaje += 1;
                }
                gol = new SoundPlayer(Properties.Resources.Punto);
                gol.Play();
            }

            if(other is PlayerFrame)
            {
                SoundPlayer toque;
                toque = new SoundPlayer(Properties.Resources.Rebote);
                toque.Play();
            }

            if(other is PlayerFrame2)
            {
                SoundPlayer toque;
                toque = new SoundPlayer(Properties.Resources.Rebote);
                toque.Play();
            }

        }
    }
}
