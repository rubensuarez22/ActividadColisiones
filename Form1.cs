using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActividadColisiones
{ 
    public partial class Form1 : Form
{

    Bitmap bmp;
    Graphics g;
    Balls ball;
    List<Balls> balls;
    SolidBrush brush;
    public Form1()
    {
        InitializeComponent();
    }
    private void MAIN_Load(object sender, EventArgs e)
    {
        bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
        g = Graphics.FromImage(bmp);
        PCT_CANVAS.Image = bmp;
        balls = new List<Balls>();

        for (int b = 0; b < 50; b++)
        {
            balls.Add(new Balls(bmp.Size));
        }


    }

    private void TIMER_Tic(object sender, EventArgs e)
        {
            
            g.Clear(Color.Black);

            for (int b = 0; b < balls.Count; b++)
            {
                ball = balls[b];
                g.FillEllipse(Brushes.Aqua, ball.p.X - (ball.size / 2), ball.p.Y - (ball.size / 2), ball.size, ball.size);
            }

            PCT_CANVAS.Invalidate();
        }
    }
}
