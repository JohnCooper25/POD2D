using CanvasDrawing.Game;
using CanvasDrawing.UtalEngine2D_2023_1;
using CanvasDrawing.UtalEngine2D_2023_1.Physics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasDrawing
{
    public partial class Form1 : Form
    {
        Image testImagen;
        Image Enemies;
        SoundPlayer Musicmenu;
        

        Frame Sven;
        Frame Sven2;

        public Form1()
        {
           
           InitializeComponent();
           Musicmenu = new SoundPlayer(Properties.Resources.Menu);
           Musicmenu.Play();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //GameEngine.MainCamera.xSize = Width;
            //GameEngine.MainCamera.ySize = Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int posX = e.X;
            int posY = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            label1.Hide();
            label2.Hide();
            Musicmenu.Stop();

            testImagen = global::CanvasDrawing.Properties.Resources.SmallSven;
            Enemies = global::CanvasDrawing.Properties.Resources.SmallSven2;

            Image Mix = Properties.Resources.Mix_color;
            Image Grass = Properties.Resources.Grass;
            Image Malla = Properties.Resources.Malla;
            Image Limite = Properties.Resources.Limite;

            //Genera el Suelo
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    new BackgroundElement(Grass, new Vector2(50, 50), i * 50 + 25, j * 50 + 25);
                }
            }
            //Genera la malla Blanca del medio del mapa
            for (int i = 0; i < 12; i++)
            {
                new BackgroundElement(Malla, new Vector2(50, 50), i * 50 + 25, 288);
            }
            //Generar Arco 1
            for (int i = 0; i < 12; i++)
            {
                new Wall(Properties.Resources.Malla, new Vector2(50, 50), i * 50 - 20 + 25, 0);
            }

            //Generar Arco 2
            for (int i = 0; i < 12; i++)
            {
                new Wall2(Properties.Resources.Malla, new Vector2(50, 50), i * 50 - 20 + 25, 597);
            }

            GameObject MixGO = new GameObject(Mix, new Vector2(Mix.Width / 1, Mix.Height / 1), true, true, 45, 330);
            MixGO.rigidbody.isStatic = true;

            GameObject MixGO2 = new GameObject(Mix, new Vector2(Mix.Width / 1, Mix.Height / 1), true, true, 555, 330);
            MixGO2.rigidbody.isStatic = true;

            DoubleBuffered = true;


            new PlayerFrame(1, testImagen, new Vector2(100, 20), 300, 50);
            new PlayerFrame2(1, Enemies, new Vector2(100, 20), 300, 544);

            GameEngine.MainCamera.xSize = GameEngine.MainCamera.ySize = 600;
            GameEngine.InitEngine(this);
            GameEngine.MainCamera.scale = 1f;

            PhysicsEngine.gravity = new Vector2(0f, 4);

            GameEngine.MainCamera.Position = new Vector2(300, 300);
            new FrameManager();
            //new UtalText("Hola", 10, 10, Color.Black);
            new TimerBoard();
            new ScoreBoardP2();
            new ScoreBoard();
            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
