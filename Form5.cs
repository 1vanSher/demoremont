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
    public partial class Form5 : Form
    {
        int iduser;
        public Form5(int iduser)
        {
            InitializeComponent();
            this.iduser = iduser;
            showusercontrol();
        }

        public void showusercontrol()
        {
            conn.setData($"SELECT startdate, type, status, descr FROM application where iduser = {iduser};");
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < conn.dt.Rows.Count; i++)
            {
                UserControl1 userControl1 = new UserControl1();
                userControl1.label5.Text = conn.dt.Rows[i][1].ToString();
                userControl1.label3.Text = conn.dt.Rows[i][2].ToString();
                userControl1.label4.Text = conn.dt.Rows[i][0].ToString();
                userControl1.textBox1.Text = conn.dt.Rows[i][3].ToString();
                flowLayoutPanel1.Controls.Add(userControl1);
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
