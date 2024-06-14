namespace demoremont
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Заполните поля!");
                }
                else
                {
                    conn.setData($"SELECT EXISTS (SELECT true FROM users WHERE login = '{textBox1.Text}');");
                    if (conn.dt.Rows[0][0].ToString() == "True")
                    {
                        conn.setData($"select * from users where login = '{textBox1.Text}'");
                        if (conn.dt.Rows[0][3].ToString() == "1")
                        {
                            this.Hide();
                            Form2 form2 = new Form2();
                            form2.ShowDialog();
                        }
                        else
                        {
                            this.Hide();
                            Form3 form3 = new Form3(Convert.ToInt32(conn.dt.Rows[0][0]));
                            form3.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователя не существует");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Заполните поля!");
                }
                else
                {
                    conn.setData($"SELECT EXISTS (SELECT true FROM users WHERE login = '{textBox1.Text}');");
                    if (conn.dt.Rows[0][0].ToString() == "True")
                    {
                        MessageBox.Show("Логин занят");
                    }
                    else
                    {
                        Form6 form6 = new Form6();
                        form6.ShowDialog();
                        //conn.refdata($"INSERT INTO users(login, password, idrole) VALUES ('{textBox1.Text}', '{textBox2.Text}', 2);");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
