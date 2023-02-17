using ActividadColisiones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ActividadColisiones
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Ball ball;
        List<Ball> balls;
        SolidBrush brush;

        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);

            brush = new SolidBrush(Color.White);

            Random rand = new Random(); // declare and initialize the 'rand' variable

            balls = new List<Ball>();
            for (int i = 0; i < 10; i++)
            {
                balls.Add(new Ball(rand.Next(PCT_CANVAS.Width), rand.Next(PCT_CANVAS.Height), rand.Next(10, 20), rand.Next(-5, 5), rand.Next(-5, 5)));
            }

            PCT_CANVAS.Paint += new PaintEventHandler(PCT_CANVAS_Paint);
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }



        private void PCT_CANVAS_Paint(object sender, PaintEventArgs e)
        {
         
            e.Graphics.Clear(Color.Black);

            foreach (var ball in balls)
            {
                using (SolidBrush brush = new SolidBrush(ball.Color)) { 
                    e.Graphics.FillEllipse(brush, ball.X - ball.Radius, ball.Y - ball.Radius, ball.Radius * 2, ball.Radius * 2);
                }
            }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
           
            foreach (var ball in balls)
            {
                ball.Update(balls, PCT_CANVAS.Width, PCT_CANVAS.Height);
            }

            PCT_CANVAS.Refresh();
        }


    }
}





