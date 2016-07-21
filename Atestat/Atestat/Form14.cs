using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Windows.Forms.PropertyGridInternal;

namespace Atestat
{
    public partial class Form14 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";

        public Form14()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4;
            s1 = textBox1.Text;
            s2 = textBox2.Text;
            s3 = textBox3.Text;
            s4 = textBox4.Text;

            if (s1 != "" && s2 != "" && s3 != "" && s4 != "")
            {
                if (Convert.ToInt16(textBox3.Text)<=DateTime.Now.Year)
                {
                    SqlConnectionStringBuilder connString1Builder;
                    connString1Builder = new SqlConnectionStringBuilder();
                    connString1Builder.DataSource = dataSource;
                    connString1Builder.InitialCatalog = "master";
                    connString1Builder.Encrypt = true;
                    connString1Builder.TrustServerCertificate = false;
                    connString1Builder.UserID = userName;
                    connString1Builder.Password = password;

                    SqlConnectionStringBuilder connString2Builder;
                    connString2Builder = new SqlConnectionStringBuilder();
                    connString2Builder.DataSource = dataSource;
                    connString2Builder.InitialCatalog = DatabaseName;
                    connString2Builder.Encrypt = true;
                    connString2Builder.TrustServerCertificate = false;
                    connString2Builder.UserID = userName;
                    connString2Builder.Password = password;

                    SqlConnection sqlCon = new SqlConnection(connString2Builder.ToString());
                    sqlCon.Open();

                    string commandString = "SELECT * FROM Carti";

                    SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);

                    SqlCommand CmdSql = new SqlCommand("INSERT INTO Carti(Titlu, Autor, Anul, Stoc, Datainr) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + DateTime.Now.ToShortDateString() + "')", sqlCon);

                    CmdSql.ExecuteNonQuery();
                    sqlCon.Close();


                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("You have entered a wrong year!");
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not all the fields are completed!");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 500000000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.textBox4, "In this field you can enter only digits!");
        }
    }
}
