using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace project_N
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client f = new Client();
            f.Show();
            data.role = "user";
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff f = new Staff();
            f.Show();
            data.role = "user";
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Request f = new Request();
            f.Show();
            data.role = "user";
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report f = new Report();
            f.Show();
            data.role = "user";
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stat f = new Stat();
            f.Show();
            data.role = "user";
            Hide();
        }
    }
    public static class data
    {
        public static String buf;
        public static String tempFolder;
        public static String newPath;
        public static String idIndex = "";
        public static String role = "";
        public static String roleA = "";
    }
}
