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
            particle.image = Properties.Resources.drop;


            particle.X = 0 ;
            particle.Y = 0;
          
           
            particle.Direction = -90 + 15 - Particle.rand.Next(30);
         
            return particle;
        }

        public override void ResetParticle(Particle particle)
        {
            particle.Life =  20 + Particle.rand.Next(100);
            particle.Speed = 1 + Particle.rand.Next(10);
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
        public int Direction = -90 + 15 - Particle.rand.Next(30); 
        public int Life = 20;

        public override Particle CreateParticle()
        {
            var particle = ParticleImage.Generate();
             particle.image = Properties.Resources.drop;

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
   
    public class ParticleImage : Particle
    {
        public Image image;
      
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

            
        
       

            g.DrawImage(image,
        
                new Rectangle((int)(X - Radius), (int)(Y - Radius), Radius * 2, Radius * 2),
          
                0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel
               );
        }
    }
}
