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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms.PropertyGridInternal;

namespace Atestat
{
    public partial class Form9 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
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
            label3.Visible = false;
            
            listView1.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;


            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT Utilizator, Abonament, Abateri, Data" + "  FROM Useri5";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Utilizator"].ToString());
                lvi.SubItems.Add(rdr["Abonament"].ToString());
                lvi.SubItems.Add(rdr["Abateri"].ToString());
                lvi.SubItems.Add(rdr["Data"].ToString());


                listView1.Items.Add(lvi);
               
            }
            rdr.Close();
            sqlCon.Close();
            
        }

        private void button7_Click(object sender, EventArgs e)
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
            SqlDataReader rdr3 = null;
            SqlConnection sqlCon2 = null;
            SqlCommand cmd = null;           


            if (textBox1.Text != "" && textBox1.Text!="vladut" )
            {
                SqlConnection sqlCon = new SqlConnection(connString2Builder.ToString());
                sqlCon.Open();


                string commandString = "SELECT * FROM Useri5";

                SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);

                SqlCommand CmdSql = new SqlCommand("DELETE FROM [Useri5] WHERE[Utilizator]=@user", sqlCon);
                CmdSql.Parameters.Add(new SqlParameter("@user", System.Data.SqlDbType.VarChar, 50, "Utilizator"));
               



                CmdSql.Parameters["@user"].Value = textBox1.Text;
                

                CmdSql.ExecuteNonQuery();
                sqlCon.Close();
                label3.Visible = true;
            }
            else
            {
                MessageBox.Show("ADD User.");
            }
            listView1.Items.Clear();


            sqlCon2 = new SqlConnection(connString2Builder.ToString());
            sqlCon2.Open();

            string CommandText1 = "SELECT Utilizator, Abonament, Abateri, Data" + "  FROM Useri5";
            cmd = new SqlCommand(CommandText1);
            cmd.Connection = sqlCon2;



            rdr3 = cmd.ExecuteReader();

            while (rdr3.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr3["Utilizator"].ToString());
                lvi.SubItems.Add(rdr3["Abonament"].ToString());
                lvi.SubItems.Add(rdr3["Abateri"].ToString());
                lvi.SubItems.Add(rdr3["Data"].ToString());


                listView1.Items.Add(lvi);

            }
            rdr3.Close();
            sqlCon2.Close();
            textBox1.Clear();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].Text;
            
        }

    }
}
