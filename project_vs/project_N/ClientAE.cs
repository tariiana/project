using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace project_N
{
    public partial class ClientAE : Form
    {
        private SqlConnection sqlConnection = null;
        private DataTable dt = new DataTable();
        public ClientAE()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(@"Data Source=DESKTOP-T4GITP2\SQLEXPRESS;Initial Catalog=RepairNas;Integrated Security=True");
            sqlConnection.Open();
            Loaded();
        }

        public void Loaded() {
           
            if (data.buf == "add")
            {
                panel_add.Visible = true;
            }
            else if (data.buf == "edit")
            {
                panel_edit.Visible = true;

                SqlDataAdapter sda = new SqlDataAdapter("Select * From Client where Id = '" + data.idIndex + "'", sqlConnection);
                sda.Fill(dt);
                textBox4.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][2].ToString();
                maskedTextBox2.Text = dt.Rows[0][3].ToString();
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            Client f = new Client();
            f.Show();
            this.Close();
        }
        private void ShowErrorMessage()
        {
            MessageBox.Show("Пожалуйста заполните все поля!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox3.Text == "" || maskedTextBox2.Text == "")
            {
                ShowErrorMessage();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Client SET Surname = N'" + textBox4.Text + "', Name = N'" + textBox3.Text +
                     "', Phone = N'" + maskedTextBox2.Text + "' WHERE Id = '" + data.idIndex + "'", sqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Запись изменена");
                Client f = new Client();
                f.Show();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "")
            {
                ShowErrorMessage();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into [Client] (Surname, Name, Phone)" +
                    " values (@Surname, @Name, @Phone)", sqlConnection);
                cmd.Parameters.AddWithValue("Surname", textBox1.Text);
                cmd.Parameters.AddWithValue("Name", textBox2.Text);
                cmd.Parameters.AddWithValue("Phone", maskedTextBox1.Text);
                cmd.ExecuteNonQuery();

                textBox1.Text = "";
                textBox2.Text = "";
                maskedTextBox1.Text = "";

                MessageBox.Show("Запись отправлена");
            }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox2.Text, out s))
            {
                errorProvider1.SetError(textBox2, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox4.Text, out s))
            {
                errorProvider1.SetError(textBox4, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox3.Text, out s))
            {
                errorProvider1.SetError(textBox3, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }

       private void ClientAE_Load(object sender, EventArgs e)
       {
            
       }
    }
}
