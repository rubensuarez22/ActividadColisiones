using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadColisiones
{ 
    public class Balls
{
    public PointF p, v;
    public int size;
    static Random rand = new Random();
    public Color c;
    Size bound;
    public Balls(Size s)
    {

        p = new PointF(rand.Next(0, s.Width), rand.Next(0, s.Height));
        v = new PointF(rand.Next(-20, 20), rand.Next(-20, 20));
        c = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        size = rand.Next(35, 150);

    }
    public void Update()
    {
        p.X += v.X;
        p.Y += v.Y;
    }


}
}
