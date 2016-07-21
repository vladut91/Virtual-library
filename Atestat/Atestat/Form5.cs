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
    public partial class Form5 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        private Form6 f;
        private Form7 d;
        private Form9 s;
        
        
        private Form13 y;
        private Form14 z;
        private Form15 x;
        private Form16 t;
        private ListViewColumnSorter lvwColumnSorter;
        string te="                               Today orders\n\n\n\n\n\n";


        public Form5()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;


        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }   
            this.listView1.Sort();


        }

        private void ȘtergeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            s = new Form9();
            s.ShowDialog();
        }

        private void adaugaAbatereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            f = new Form6();
            f.ShowDialog();
        }

        
        private void interziceAccesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            y = new Form13();
            y.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat of = new StringFormat();
            Font printFont = new Font("Courier New", 10);
            int leftMargin = 25;
            int topMargin = 50;
           
                e.Graphics.DrawString(te, printFont, Brushes.Black, leftMargin, topMargin);
            
        }

      

        private void istoricComenziToolStripMenuItem_Click(object sender, EventArgs e)
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

            string CommandText = "SELECT Destinatar, Adresa, Carte, Data, Ora, Cartiplus" + "  FROM Comenzi";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Destinatar"].ToString());
                lvi.SubItems.Add(rdr["Ora"].ToString());
                lvi.SubItems.Add(rdr["Adresa"].ToString());
                lvi.SubItems.Add(rdr["Carte"].ToString());
                lvi.SubItems.Add(rdr["Data"].ToString());
                lvi.SubItems.Add(rdr["Cartiplus"].ToString());

                listView1.Items.Add(lvi);

            }
            rdr.Close();
            sqlCon.Close();
        }

        private void comenzileDeAziToolStripMenuItem_Click(object sender, EventArgs e)
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

            string CommandText = "SELECT Destinatar, Adresa, Carte, Data, Ora, Cartiplus" + "  FROM Comenzi";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr["Data"].ToString() == DateTime.Today.ToShortDateString())
                {
                    ListViewItem lvi = new ListViewItem(rdr["Destinatar"].ToString());
                    lvi.SubItems.Add(rdr["Ora"].ToString());
                    lvi.SubItems.Add(rdr["Adresa"].ToString());
                    lvi.SubItems.Add(rdr["Carte"].ToString());
                    lvi.SubItems.Add(rdr["Data"].ToString());
                    lvi.SubItems.Add(rdr["Cartiplus"].ToString());

                    listView1.Items.Add(lvi);
                }


            }

            rdr.Close();
            sqlCon.Close();
        }

       
        private void comenziDeReturnatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            d = new Form7();
            d.ShowDialog();
        }

        private void printeazaComenzileDeAziToolStripMenuItem_Click(object sender, EventArgs e)
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

            string CommandText = "SELECT Destinatar, Adresa, Carte, Data, Ora, Cartiplus" + "  FROM Comenzi";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr["Data"].ToString() == DateTime.Today.ToShortDateString())
                {
                    ListViewItem lvi = new ListViewItem(rdr["Destinatar"].ToString());
                    lvi.SubItems.Add(rdr["Ora"].ToString());
                    lvi.SubItems.Add(rdr["Adresa"].ToString());
                    lvi.SubItems.Add(rdr["Carte"].ToString());
                    lvi.SubItems.Add(rdr["Data"].ToString());
                    lvi.SubItems.Add(rdr["Cartiplus"].ToString());


                    listView1.Items.Add(lvi);
                }


            }

            rdr.Close();
            sqlCon.Close();


            for (int x = 0; x < listView1.Items.Count; x++)
            {
                te = te + listView1.Items[x].SubItems[0].Text + ";   " + listView1.Items[x].SubItems[1].Text + ";    " + listView1.Items[x].SubItems[2].Text + "\n  " + listView1.Items[x].SubItems[3].Text + "     " + listView1.Items[x].SubItems[4].Text + "     " + listView1.Items[x].SubItems[5].Text + "\n\n";
            }
            richTextBox1.Text = te;
            

            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument1;
            if (pd.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }


        private void adaugăCărțiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            z = new Form14();
            z.ShowDialog();
        }

        private void ieșireAplicațieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void modificăStoculToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x = new Form15();
            x.ShowDialog();
        }

        private void Form5_Load(object sender, EventArgs e)
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

            string CommandText = "SELECT Destinatar, Adresa, Carte, Data, Ora, Cartiplus" + "  FROM Comenzi";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;


            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Destinatar"].ToString());
                lvi.SubItems.Add(rdr["Ora"].ToString());
                lvi.SubItems.Add(rdr["Adresa"].ToString());
                lvi.SubItems.Add(rdr["Carte"].ToString());
                lvi.SubItems.Add(rdr["Data"].ToString());
                lvi.SubItems.Add(rdr["Cartiplus"].ToString());

                listView1.Items.Add(lvi);
            }
            rdr.Close();
            sqlCon.Close();
        }

        private void abonamenteNoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t = new Form16();
            t.ShowDialog();
        }       
    }


}
