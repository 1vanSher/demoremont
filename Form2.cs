using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            showmanager();
            showusercontrol2($"SELECT  * FROM application;");

        }

        public void showmanager()
        {
            conn.setData($"SELECT name FROM managers;");
            var manager = conn.dt;
            for (int j = 0; j < manager.Rows.Count; j++)
            {
                comboBox1.Items.Add(manager.Rows[j][0].ToString());
            }
        }
        public void showusercontrol2(string str)
        {
            conn.setData(str);
            var applic = conn.dt;
            conn.setData($"SELECT name FROM managers;");
            var manager = conn.dt;
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < applic.Rows.Count; i++)
            {
                UserControl2 userControl2 = new UserControl2(Convert.ToInt32(applic.Rows[i][0]));
                userControl2.textBox1.Text = applic.Rows[i][5].ToString();
                userControl2.textBox3.Text = applic.Rows[i][6].ToString();
                userControl2.textBox2.Text = applic.Rows[i][7].ToString();
                userControl2.label6.Text = applic.Rows[i][3].ToString();
                for (int j = 0; j < manager.Rows.Count; j++)
                {
                    userControl2.comboBox1.Items.Add(manager.Rows[j][0].ToString());
                }
                if (applic.Rows[i][2].ToString().Length > 0)
                {
                    conn.setData($"SELECT name FROM managers WHERE id = {applic.Rows[i][2]};");
                    userControl2.comboBox1.SelectedItem = conn.dt.Rows[0][0].ToString();
                }
                flowLayoutPanel1.Controls.Add(userControl2);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.setData($"select id from managers where name = '{comboBox1.SelectedItem}'");
            int idmanager = Convert.ToInt32(conn.dt.Rows[0][0]);
            if (comboBox1.SelectedItem != null)
            {

                showusercontrol2($"select * from application where idmanager = {idmanager} and type LIKE '%{textBox1.Text}%'");
            }
            else
            {
                showusercontrol2($"select * from application where type LIKE '%{textBox1.Text}%'");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.setData($"select id from managers where name = '{comboBox1.SelectedItem}'");
            int idmanager = Convert.ToInt32(conn.dt.Rows[0][0]);
            if (textBox1.Text != null)
            {
                showusercontrol2($"select * from application where idmanager = {idmanager} and type LIKE '%{textBox1.Text}%'");
            }
            else
            {
                showusercontrol2($"select * from application where idmanager = {idmanager}");
            }
        }
    }
}
