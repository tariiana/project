using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_N
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-T4GITP2\SQLEXPRESS;Initial Catalog=RepairNas;Integrated Security=True");

            SqlDataAdapter sda = new SqlDataAdapter("Select Role From Users where Login = '" + tb_login.Text + "'and Password ='" + tb_password.Text + "'", con);

            sda.SelectCommand.Parameters.AddWithValue("@Login", tb_login.Text);
            sda.SelectCommand.Parameters.AddWithValue("@Password", tb_password.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            try
            {

                if (dt.Rows.Count > 0)
                {
                    data.roleA = dt.Rows[0]["Role"].ToString();
                    if (data.roleA.StartsWith("Пользователь"))
                    {
                        this.Hide();
                        Main f = new Main();
                        f.Show();
                    }
                    else
                    {
                        this.Hide();
                        Main_admin f = new Main_admin();
                        f.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуста введите приавильный логин и пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
