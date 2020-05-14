using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public abstract class EmiterBase
    {
        List<Particle> particles = new List<Particle>();

        int particleCount = 0;
     
        public int ParticlesCount
        {
            get
            {
                return particleCount;
            }
            set
            {
              
                particleCount = value;
              
                if (value < particles.Count)
                {
                    particles.RemoveRange(value, particles.Count - value);
                }
            }
        }

        public abstract void ResetParticle(Particle particle);
        public abstract void UpdateParticle(Particle particle);
        public abstract Particle CreateParticle();

        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    ResetParticle(particle);
                }
                else
                {
                    UpdateParticle(particle);
                }
            }

            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500)
                {
                    particles.Add(CreateParticle());
                }
                else
                {
                    break;
                }
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }
    }
    public class PointEmiter : EmiterBase
    {
        public Point Position;

        public override Particle CreateParticle()
        {
            var particle = ParticleImage.Generate();
            particle.image = Properties.Resources.drop1;
            particle.FromColor = Color.LightBlue;
            particle.ToColor = Color.White;


            particle.X = 0 ;
            particle.Y = 0;
          
           
            particle.Direction = -90 + 15 - Particle.rand.Next(30);
         
            return particle;
        }

        public override void ResetParticle(Particle particle)
        {
            particle.Life =  20 ;
            particle.Speed =  Particle.rand.Next(10);
            particle.Direction = -90 + 15 - Particle.rand.Next(30);
            particle.Radius = 1 + Particle.rand.Next(5);
            particle.X = Position.X;
            particle.Y = Position.Y;
        }

        public override void UpdateParticle(Particle particle)
        {
            var directionInRadians = particle.Direction / 180 * Math.PI;
            particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
            particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
        }
    }
    public class DirectionColorfulEmiter : PointEmiter
    {
        public int Speed = 0;
        public int Spread = 20; 
        public int Direction = -90 ; 
        public int Life = 20;
        public Color FromColor = Color.LightBlue; // исходный цвет
        public Color ToColor = Color.White; // конечный цвет

        public override Particle CreateParticle()
        {
            var particle = ParticleImage.Generate();
             particle.image = Properties.Resources.drop1;
            particle.FromColor = this.FromColor;
            particle.ToColor = Color.FromArgb(0, this.ToColor);


            particle.Life = this.Life +  20 + Particle.rand.Next(100); ;
            particle.Direction = this.Direction + Particle.rand.Next(-Spread / 2, Spread / 2);

            particle.X = Position.X;
            particle.Y = Position.Y;
            return particle;
        }

        public override void ResetParticle(Particle particle)
        {
            var particleColorful = particle as ParticleImage;
            if (particleColorful != null)
            {
                particleColorful.Life = this.Life+ 20 + Particle.rand.Next(100); ;
                particleColorful.Speed = 1 + 10;

                particleColorful.Direction = this.Direction + Particle.rand.Next(-Spread / 2, Spread / 2);
                particleColorful.FromColor = this.FromColor;
                particleColorful.ToColor = Color.FromArgb(0, this.ToColor);

                particleColorful.X = Position.X;
                particleColorful.Y = Position.Y;
            }
        }
    }
    public class Particle
    {
        public int Radius;
        public float X; 
        public float Y;

        public float Direction; 
        public float Speed;
        public float Life; 

        public static Random rand = new Random();


        public virtual void Draw(Graphics g)
        {
           
            float k = Math.Min(1f, Life / 100);
            int alpha = (int)(k * 255);

          
            var color = Color.FromArgb(alpha, Color.White);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
        
    }
    public class ParticleColorful : Particle
    {
        // два новых поля под цвет начальный и конечный
        public Color FromColor;
        public Color ToColor;

        // для смеси цветов
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        // подменяем метод генерации на новый, который будет возвращать ParticleColorful
        public new static ParticleColorful Generate()
        {
            return new ParticleColorful
            {
                Direction = rand.Next(360),
                Speed = 1 + rand.Next(10),
                Radius = 2 + rand.Next(10),
                Life = 20 + rand.Next(100),
            };
        }
    }
        public class ParticleImage : Particle
        {
            public Image image;
            public Color FromColor;
            public Color ToColor;


            public new static ParticleImage Generate()
            {
                return new ParticleImage
                {
                    Direction = rand.Next(360),
                    Speed = 1 + rand.Next(10),
                    Radius = 1 + rand.Next(5),
                    Life = 500 + rand.Next(500),
                };
            }
        
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

                var color = ParticleColorful.MixColor(ToColor, FromColor, k);
                ColorMatrix matrix = new ColorMatrix(new float[][]{
            new float[] {0, 0, 0, 0, 0}, // умножаем текущий красный цвет на 0
            new float[] {0, 0, 0, 0, 0}, // умножаем текущий зеленый цвет на 0
            new float[] {0, 0, 0, 0, 0}, // умножаем текущий синий цвет на 0
            new float[] {0, 0, 0, k, 0}, // тут подставляем k который прозрачность задает
            new float[] {(float)color.R / 255, (float)color.G / 255, (float)color.B/255, 0, 1F}}); // а сюда пихаем рассчитанный цвет переведенный из шкалы от 0 до 255 в шкалу от 0 до 1

                // эту матрицу пихают в атрибуты
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(matrix);



                g.DrawImage(image,
        
                new Rectangle((int)(X - Radius), (int)(Y - Radius), Radius * 2, Radius * 2),
          
                0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel,
                 imageAttributes
               );
        }
    }
}
