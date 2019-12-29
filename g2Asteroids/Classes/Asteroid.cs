using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace g2Asteroids
{
    class Asteroid : g2AsteroidsObject
    {
        static readonly Random zufällig = new Random();

        //Konstruktor der Kindklasse
        public Asteroid(Canvas zeichenfläche)
                : base(0.5, 0.5, (zufällig.NextDouble() - 0.5) * 250, (zufällig.NextDouble() - 0.5) * 250)
        {
            for (int i = 0; i < 15; i++)
            {
                double alpha = 2.0 * Math.PI / 15 * i;
                double radius = 25.0 + 15.0 * zufällig.NextDouble();
                umriss.Points.Add(new Point(radius * Math.Cos(alpha), radius * Math.Sin(alpha)));
            }
            umriss.StrokeThickness = 5;
            umriss.Stroke = Brushes.LightBlue;
            umriss.Fill = Brushes.Gray;
            //ImageBrush img = new ImageBrush
            //{
            //    ImageSource = new BitmapImage(new Uri(@"C:\Users\Nikolaus\source\repos\g2Asteroids\g2Asteroids\images\mf.jpg", UriKind.Relative))
            //};
        }

        //überschriebene (override) Methoden der Kindklasse
        public override void ZeichneObjekt(Canvas zeichenfläche)
        {

            // TODO : Dies hier jeweils in Mutterklasse einmalig in der Mutterklasse einfügen? virtuell abstract?
            zeichenfläche.Children.Add(umriss);
            Canvas.SetLeft(umriss, X);
            Canvas.SetTop(umriss, Y);
        }

        public bool Collided(double x, double y)
        {
            return umriss.RenderedGeometry.FillContains(new Point(x - X, y - Y));
        }
    }
}
