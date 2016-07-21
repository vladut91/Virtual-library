using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Net.Sockets;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Atestat
{
    public partial class Form16 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
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
            listView1.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;


            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT Nume, Prenume, Abonament, Data" + "  FROM Abonanoi";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (Convert.ToDateTime(rdr["Data"].ToString())>=DateTime.Now.AddDays(-10))
                {
                    ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString());
                    lvi.SubItems.Add(rdr["Prenume"].ToString());
                    lvi.SubItems.Add(rdr["Abonament"].ToString());
                    lvi.SubItems.Add(rdr["Data"].ToString());

                    listView1.Items.Add(lvi);
                }
            }
            rdr.Close();
            sqlCon.Close();
        
        }
    }
}
