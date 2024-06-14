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
    public partial class Form4 : Form
    {
        int iduser;
        public Form4(int iduser)
        {
            this.iduser = iduser;
            InitializeComponent();
            label3.Text = DateTime.Now.ToString("d");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.refdata($"INSERT INTO application(iduser, startdate, type, status, descr) VALUES ({iduser}, '{DateTime.Now.ToString("d")}','{textBox1.Text}', 'В рассмотрении', '{textBox2.Text}');");
            this.Close();
        }
    }
}
