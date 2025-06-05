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
    public partial class ReportAE : Form
    {
        private SqlConnection sqlConnection = null;
        private DataTable dt = new DataTable();
        public ReportAE()
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

                SqlDataAdapter sda = new SqlDataAdapter("Select * From Report where Id = '" + data.idIndex + "'", sqlConnection);
                sda.Fill(dt);
                textBox1.Text = dt.Rows[0][1].ToString();
                textBox2.Text = dt.Rows[0][2].ToString();
                textBox3.Text = dt.Rows[0][3].ToString();
                textBox4.Text = dt.Rows[0][4].ToString();
                textBox5.Text = dt.Rows[0][5].ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Report f = new Report();
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                ShowErrorMessage();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Report SET Id_request = N'" + textBox1.Text + "', Id_master = N'" + textBox2.Text +
                      "', Lead_time = N'" + textBox3.Text + "', Materials = N'" + textBox4.Text + "', Cost = N'" + textBox5.Text + "' WHERE Id = '" + data.idIndex + "'", sqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Запись изменена");
               Report f = new Report();
                f.Show();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || textBox9.Text == "" || textBox8.Text == "" || textBox7.Text == "" || textBox6.Text == "")
            {
                ShowErrorMessage();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into [Report] (Id_request, Id_master, Lead_time, Materials, Cost)" +
                    " values (@Id_request, @Id_master, @Lead_time, @Materials, @Cost)", sqlConnection);
                cmd.Parameters.AddWithValue("Id_request", textBox10.Text);
                cmd.Parameters.AddWithValue("Id_master", textBox9.Text);
                cmd.Parameters.AddWithValue("Lead_time", textBox8.Text);
                cmd.Parameters.AddWithValue("Materials", textBox7.Text);
                cmd.Parameters.AddWithValue("Cost", textBox6.Text);
                cmd.ExecuteNonQuery();

                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";

                MessageBox.Show("Запись отправлена");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!Int32.TryParse(textBox1.Text, out num))
                errorProvider1.SetError(textBox1, "Некорректные данные");
            else
                errorProvider1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!Int32.TryParse(textBox2.Text, out num))
                errorProvider1.SetError(textBox2, "Некорректные данные");
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!Int32.TryParse(textBox10.Text, out num))
                errorProvider1.SetError(textBox10, "Некорректные данные");
            else
                errorProvider1.Clear();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!Int32.TryParse(textBox9.Text, out num))
                errorProvider1.SetError(textBox9, "Некорректные данные");
            else
                errorProvider1.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (Int32.TryParse(textBox7.Text, out s))
            {
                errorProvider1.SetError(textBox7, "Некорректные данные");
            }
            else
                errorProvider1.Clear();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!Int32.TryParse(textBox6.Text, out num))
                errorProvider1.SetError(textBox6, "Некорректные данные");
            else
                errorProvider1.Clear();
        }
    }
}
