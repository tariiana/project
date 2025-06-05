using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project_N
{
    public partial class Stat : Form
    {
        public Stat()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (data.role == "user")
            {
                Main m = new Main();
                m.Show();
                this.Close();
            }
            else
            {
                Main_admin m = new Main_admin();
                m.Show();
                this.Close();
            }
        }

        private void Stat_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-T4GITP2\SQLEXPRESS;Initial Catalog=RepairNas;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Request WHERE Status = 'Выполнено                                             '", con);
            SqlCommand cmd2 = new SqlCommand("SELECT AVG(Lead_time) FROM Report", con);
            SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Request WHERE Type_of_malfunction = 'Электрический                                                          '", con);

            try
            {
                con.Open();
                label1.Text = "Количество выполненных заявок: " + cmd.ExecuteScalar().ToString();
                label2.Text = "Среднее время выполнения заявки: " + cmd2.ExecuteScalar().ToString() + " часов.";
                label3.Text = "Количество электрических несправностей: " + cmd3.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    }
