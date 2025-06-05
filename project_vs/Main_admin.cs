using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_N
{
    public partial class Main_admin : Form
    {
        public Main_admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff f = new Staff();
            f.Show();
            data.role = "admin";
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client f = new Client();
            f.Show();
            data.role = "admin";
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Request f = new Request();
            f.Show();
            data.role = "admin";
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report f = new Report();
            f.Show();
            data.role = "admin";
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Users f = new Users();
            f.Show();
            data.role = "admin";
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stat f = new Stat();
            f.Show();
            data.role = "admin";
            Hide();
        }
    }
}
