using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPressControl
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms.OfType<Menu>().FirstOrDefault().Con.NotQuery("INSERT INTO wp_users (`user_login`,  `user_pass`) VALUES('" + textBox1.Text + "','" + textBox2.Text+"')");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void ListUsers()
        {
     
            var List = Application.OpenForms.OfType<Menu>().FirstOrDefault().Con.Query("SELECT user_login, user_pass FROM wp_users");
            dataGridView1.RowCount = List.Length;
            for (int i = 0; i < List.Length; i++)
            {
                try
                {
                    dataGridView1[0, i].Value = List[i].ItemArray[0];
                    dataGridView1[1, i].Value = List[i].ItemArray[1];
                    

                }
                catch { }
            }
        }
        private void User_Load(object sender, EventArgs e)
        {
            ListUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.OpenForms.OfType<Menu>().FirstOrDefault().Con.NotQuery("INSERT INTO wp_users (`user_login`,  `user_pass`) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')");
            ListUsers();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
