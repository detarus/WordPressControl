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
    public partial class Post : Form
    {
        public Post()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms.OfType<Menu>().FirstOrDefault().Con.NotQuery("INSERT INTO wp_posts (`post_author`, `post_content`, `post_title`) VALUES( 1,'"  + richTextBox1.Text + "','" + textBox1.Text + "')");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ListPosts()
        {

            var List = Application.OpenForms.OfType<Menu>().FirstOrDefault().Con.Query("SELECT post_author, post_title, post_content,post_name  FROM wp_posts");
            dataGridView1.RowCount = List.Length;
            for (int i = 0; i < List.Length; i++)
            {
                var List1 = Application.OpenForms.OfType<Menu>().FirstOrDefault().Con.Query("SELECT user_nicename FROM wp_users WHERE ID=" + List[i].ItemArray[0]);
                try
                {
                    dataGridView1[0, i].Value = List1[0].ItemArray[0].ToString();
                    dataGridView1[1, i].Value = List[i].ItemArray[1];
                    dataGridView1[2, i].Value = List[i].ItemArray[2];
                    dataGridView1[3, i].Value = List[i].ItemArray[3];
                }
                catch { }
            }
        }
        private void Post_Load(object sender, EventArgs e)
        {
            ListPosts();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.OpenForms.OfType<Menu>().FirstOrDefault().Con.NotQuery("INSERT INTO wp_posts (`post_author`, `post_content`, `post_title`) VALUES( 1,'" + richTextBox1.Text + "','" + textBox1.Text + "')");
            ListPosts();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
