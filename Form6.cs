using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoremont
{
    public partial class Form6 : Form
    {
        private string text = String.Empty;
        public Form6()
        {
            InitializeComponent();
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        public Bitmap CreateImage(int width, int height)
        {
            Random random = new Random();
            //Создадим изображение
            Bitmap bmp = new Bitmap(width, height);
            //Вычислим позицию текста
            double Xpos = width * 0.2;
            double Ypos = width * 0.2;
            //Укажем где рисовать
            Graphics g = Graphics.FromImage(bmp);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; i++)
                text += ALF[random.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
            new Font("Arial", 15), Brushes.Black,
            new PointF(Convert.ToInt32(Xpos), Convert.ToInt32(Ypos)));

            return bmp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == this.text)
            {
                this.Close();
            }
            else
            {
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                textBox1.Text = string.Empty;
            }
        }
    }
}
