using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        DirectionColorfulEmiter emiter;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = Properties.Resources.water;
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            emiter = new DirectionColorfulEmiter
            {
                ParticlesCount = 0,
              
                Position = new Point(picDisplay.Width / 2, picDisplay.Height /12)
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UpdateState()
        {
            emiter.UpdateState();
        }

  
        private void Render(Graphics g)
        {
            emiter.Render(g);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                Render(g);
            }
            picDisplay.Invalidate();
        }

       
        private void PicDisplay_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void TbDirection_Scroll(object sender, EventArgs e)
        {
            emiter.Speed = tbDirection.Value;
            emiter.Life = tbDirection.Value;
        }

        private void TbSpead_Scroll(object sender, EventArgs e)
        {
            emiter.Spread = tbSpread.Value;
        }

       
    }
}
