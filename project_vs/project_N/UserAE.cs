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
    public partial class UserAE : Form
    {
        private SqlConnection sqlConnection = null;
        private DataTable dt = new DataTable();
        public UserAE()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(@"Data Source=DESKTOP-T4GITP2\SQLEXPRESS;Initial Catalog=RepairNas;Integrated Security=True");
            sqlConnection.Open();
            if (data.buf == "add")
            {
                panel_add.Visible = true;
            }
            else if (data.buf == "edit")
            {
                panel_edit.Visible = true;

                SqlDataAdapter sda = new SqlDataAdapter("Select * From Users where Id = '" + data.idIndex + "'", sqlConnection);
                sda.Fill(dt);
                textBox4.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][2].ToString();
                textBox5.Text = dt.Rows[0][3].ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Users f = new Users();
            f.Show();
            this.Close();
        }

        private void panel_edit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_add_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ShowErrorMessage()
        {
            MessageBox.Show("Пожалуйста заполните все поля!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                ShowErrorMessage();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Users SET Login = N'" + textBox4.Text + "', Password = N'" + textBox3.Text +
                      "', Role = N'" + textBox5.Text + "' WHERE Id = '" + data.idIndex + "'", sqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Запись изменена");
                Users f = new Users();
                f.Show();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                ShowErrorMessage();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into [Users] (Login, Password, Role)" +
                    " values (@Login, @Password, @Role)", sqlConnection);
                cmd.Parameters.AddWithValue("Login", textBox6.Text);
                cmd.Parameters.AddWithValue("Password", textBox2.Text);
                cmd.Parameters.AddWithValue("Role", textBox1.Text);
                cmd.ExecuteNonQuery();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox6.Text = "";

                MessageBox.Show("Запись отправлена");
            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox5.Text, out s))
            {
                errorProvider1.SetError(textBox5, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox1.Text, out s))
            {
                errorProvider1.SetError(textBox1, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }
    }
}
