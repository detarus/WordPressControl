using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WordPressControl
{
   
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        public SqlCon Con = new SqlCon();
        public class SqlCon
        {
            public string serverName;
            public string userName;
            public string dbName;
            public string port;
            public string password;
            public string connStr;
            public MySqlConnection connection;
            public SqlCon()
            {
                serverName = "localhost";
                userName = "root";
                dbName = "wp";
                port = "3306";
                password = "";
                connStr = "server=" + serverName +
                          ";user=" + userName +
                          ";database=" + dbName +
                          ";port=" + port +
                          ";password=" + password + ";";

            }
            public void Relink()
            {
                MySqlConnection connection = new MySqlConnection(connStr);
            }
            public DataRow[] Query(string sql)
            {
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand sqlCom = new MySqlCommand(sql, connection);
                connection.Open();
                sqlCom.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                var myData = dt.Select();
                return myData;
            }


            public DataRow[] Query()
            {
                return Query("SELECT * FROM floors");
            }
            public void NotQuery(string sql)
            {
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand sqlCom = new MySqlCommand(sql, connection);
                connection.Open();
                sqlCom.ExecuteNonQuery();
                return;
            }
        }
        public void ListPosts()
        {
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            var List = Con.Query("SELECT post_author, post_title, post_content,post_name  FROM wp_posts");
            dataGridView1.RowCount = List.Length;
            for (int i = 0; i < List.Length; i++)
            {
                var List1 = Con.Query("SELECT user_nicename FROM wp_users WHERE ID=" + List[i].ItemArray[0]);
                try
                {
                    dataGridView1[0, i].Value = List1[0].ItemArray[0].ToString();
                    dataGridView1[1, i].Value = List[i].ItemArray[1];
                    dataGridView1[2, i].Value = List[i].ItemArray[2];
                }
                catch { }
            }
        }
        public void ListUsers()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            var List = Con.Query("SELECT user_nicename, user_login, user_email FROM wp_users");
            dataGridView1.RowCount = List.Length;
            for (int i = 0; i < List.Length; i++)
            {
                 try
                {
                    dataGridView1[4, i].Value = List[0].ItemArray[0];
                    dataGridView1[5, i].Value = List[i].ItemArray[1];
                    dataGridView1[6, i].Value = List[i].ItemArray[2];

                }
                catch { }
            }
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            ListPosts();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ListPosts();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ListUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User Use = new WordPressControl.User();
            Use.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Post Pos = new WordPressControl.Post();
            Pos.ShowDialog();
        }
    }
}
