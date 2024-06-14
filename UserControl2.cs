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
    public partial class UserControl2 : UserControl
    {
        int id;
        public UserControl2(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.setData($"select id from managers where name = '{comboBox1.SelectedItem}'");
            conn.refdata($"UPDATE application SET  idmanager={Convert.ToInt32(conn.dt.Rows[0][0])}, enddate='{textBox4.Text}', type='{textBox1.Text}', status='{textBox3.Text}', descr='{textBox2.Text}' WHERE id = {id};");
        }
    }
}
