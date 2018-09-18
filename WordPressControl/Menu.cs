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
      
        
        private void Menu_Load(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.ShowDialog();
           
        }

        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
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

        private void button4_Click(object sender, EventArgs e)
        {
            Post Pos = new WordPressControl.Post();
            Pos.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            User Use = new WordPressControl.User();
            Use.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
