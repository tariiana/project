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
    public partial class RequestAE : Form
    {
        private SqlConnection sqlConnection = null;
        private DataTable dt = new DataTable();
        public RequestAE()
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

                SqlDataAdapter sda = new SqlDataAdapter("Select * From Request where Id = '" + data.idIndex + "'", sqlConnection);
                sda.Fill(dt);
                maskedTextBox1.Text = dt.Rows[0][1].ToString();
                textBox2.Text = dt.Rows[0][2].ToString();
                textBox3.Text = dt.Rows[0][3].ToString();
                textBox4.Text = dt.Rows[0][4].ToString();
                textBox5.Text = dt.Rows[0][5].ToString();
                textBox1.Text = dt.Rows[0][6].ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Request f = new Request();
            f.Show();
            this.Close();
        }
        private void ShowErrorMessage()
        {
            MessageBox.Show("Пожалуйста заполните все поля!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""|| maskedTextBox1.Text == "")
            {
                ShowErrorMessage();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Request SET Date_added = N'" + maskedTextBox1.Text + "', Repaired_equipment = N'" + textBox2.Text +
                      "', Type_of_malfunction = N'" + textBox3.Text + "', Problem_description = N'" + textBox4.Text + "', Id_client = N'" + textBox5.Text +
                      "', Status = N'" + textBox1.Text + "' WHERE Id = '" + data.idIndex + "'", sqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Запись изменена");
                Request f = new Request();
                f.Show();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || textBox9.Text == "" || textBox8.Text == "" || textBox7.Text == "" || textBox6.Text == ""|| maskedTextBox2.Text == "")
            {
                ShowErrorMessage();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into [Request] (Date_added, Repaired_equipment, Type_of_malfunction, Problem_description, Id_client, Status)" +
                    " values (@Date_added, @Repaired_equipment, @Type_of_malfunction, @Problem_description, @Id_client, @Status)", sqlConnection);
                cmd.Parameters.AddWithValue("Date_added", maskedTextBox2.Text);
                cmd.Parameters.AddWithValue("Repaired_equipment", textBox10.Text);
                cmd.Parameters.AddWithValue("Type_of_malfunction", textBox9.Text);
                cmd.Parameters.AddWithValue("Problem_description", textBox8.Text);
                cmd.Parameters.AddWithValue("Id_client", textBox7.Text);
                cmd.Parameters.AddWithValue("Status", textBox6.Text);
                cmd.ExecuteNonQuery();

                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                maskedTextBox2.Text = "";
                MessageBox.Show("Запись отправлена");
            }
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!Int32.TryParse(textBox5.Text, out num))
                errorProvider1.SetError(textBox5, "Некорректные данные");
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox10.Text, out s))
            {
                errorProvider1.SetError(textBox10, "Некорректные данные");
            }
            else
                errorProvider1.Clear();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox9.Text, out s))
            {
                errorProvider1.SetError(textBox9, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox8.Text, out s))
            {
                errorProvider1.SetError(textBox8, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!Int32.TryParse(textBox7.Text, out num))
                errorProvider1.SetError(textBox7, "Некорректные данные");
            else
                errorProvider1.Clear();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox6.Text, out s))
            {
                errorProvider1.SetError(textBox6, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }
    }
}
