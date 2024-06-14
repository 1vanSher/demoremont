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
    public partial class Form3 : Form
    {
        int iduser;
        public Form3(int iduser)
        {
            InitializeComponent();
            this.iduser = iduser;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(iduser);
            form4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(iduser);
            form5.ShowDialog();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
