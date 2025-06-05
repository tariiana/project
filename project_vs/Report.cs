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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project_N
{
    public partial class Report : Form
    {
        private SqlConnection sqlConnection = null;
        public Report()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 10);
            sqlConnection = new SqlConnection(@"Data Source=DESKTOP-T4GITP2\SQLEXPRESS;Initial Catalog=RepairNas;Integrated Security=True");
            sqlConnection.Open();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "repairNasDataSet.Report". При необходимости она может быть перемещена или удалена.
            this.reportTableAdapter.Fill(this.repairNasDataSet.Report);
            

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.idIndex != "")
            {
                DialogResult dialogResult = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE Report WHERE Id = '" + data.idIndex + "'", sqlConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись удалена");
                    this.reportTableAdapter.Fill(this.repairNasDataSet.Report);
                }
                else if (dialogResult == DialogResult.No)
                { }
            }
            else
            {
                MessageBox.Show("Пожалуйста выберите продукт!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void изменитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.idIndex != "")
            {
                data.buf = "edit";
                ReportAE f = new ReportAE();
                f.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста выберите продукт!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.buf = "add";
            ReportAE f = new ReportAE();
            f.Show();
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    String idIndex = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    data.idIndex = idIndex;
                }
            }
        }
    }
}
