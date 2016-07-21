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
using System.Data.SqlClient;


namespace Atestat
{
    public partial class Form6 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        private ListViewColumnSorter lvwColumnSorter;

        public Form6()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void Form6_Load(object sender, EventArgs e)
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

            string CommandText = "SELECT Nume,Prenume,Utilizator,Adresa,Abonament,Datainr" + "  FROM Useri5";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString()+" "+rdr["Prenume"].ToString());
                lvi.SubItems.Add(rdr["Utilizator"].ToString());
                lvi.SubItems.Add(rdr["Adresa"].ToString());
                lvi.SubItems.Add(rdr["Abonament"].ToString());
                lvi.SubItems.Add(rdr["Datainr"].ToString());

                listView1.Items.Add(lvi);

            }
            rdr.Close();
            sqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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

            string CommandText = "SELECT Nume,Prenume,Utilizator,Adresa,Abonament,Datainr" + "  FROM Useri5";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString() + " " + rdr["Prenume"].ToString());
                lvi.SubItems.Add(rdr["Utilizator"].ToString());
                lvi.SubItems.Add(rdr["Adresa"].ToString());
                lvi.SubItems.Add(rdr["Abonament"].ToString());
                lvi.SubItems.Add(rdr["Datainr"].ToString());

                listView1.Items.Add(lvi);

            }
            rdr.Close();
            sqlCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

            string CommandText = "SELECT Nume,Prenume,Utilizator,Adresa,Abonament,Data,Abateri,Datainr" + "  FROM Useri5";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (Convert.ToDateTime(rdr["Datainr"].ToString()) >= DateTime.Today.AddDays(-5) && rdr["Abateri"].ToString()!="ADMIN")
                {
                    ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString() + " " + rdr["Prenume"].ToString());
                    lvi.SubItems.Add(rdr["Utilizator"].ToString());
                    lvi.SubItems.Add(rdr["Adresa"].ToString());
                    lvi.SubItems.Add(rdr["Abonament"].ToString());
                    lvi.SubItems.Add(rdr["Datainr"].ToString());

                    listView1.Items.Add(lvi);
                }

            }
            rdr.Close();
            sqlCon.Close();
        }

        
        private void button4_Click(object sender, EventArgs e)
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

            try
            {
                sqlCon = new SqlConnection(connString2Builder.ToString());
                sqlCon.Open();

                string CommandText = "SELECT Nume,Prenume,Utilizator,Adresa,Abonament,Datainr,Abateri,Data" + "  FROM Useri5";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = sqlCon;               
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {

                    string data;
                    data = rdr["Data"].ToString();


                    if (rdr["Abonament"].ToString() == "1 AN:    80 RON" && Convert.ToDateTime(data) < DateTime.Today.AddYears(-1))
                    {
                        ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString() + " " + rdr["Prenume"].ToString());
                        lvi.SubItems.Add(rdr["Utilizator"].ToString());
                        lvi.SubItems.Add(rdr["Adresa"].ToString());
                        lvi.SubItems.Add(rdr["Abonament"].ToString());
                        lvi.SubItems.Add(rdr["Datainr"].ToString());

                        listView1.Items.Add(lvi);
                    }
                    else
                    {
                        if (rdr["Abonament"].ToString() == "6 Luni:  50 RON" && Convert.ToDateTime(data) < DateTime.Today.AddMonths(-6))
                        {
                            ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString() + " " + rdr["Prenume"].ToString());
                            lvi.SubItems.Add(rdr["Utilizator"].ToString());
                            lvi.SubItems.Add(rdr["Adresa"].ToString());
                            lvi.SubItems.Add(rdr["Abonament"].ToString());
                            lvi.SubItems.Add(rdr["Datainr"].ToString());

                            listView1.Items.Add(lvi);
                        }
                        else
                        {
                            if (rdr["Abonament"].ToString() == "3 Luni:  30 RON" && Convert.ToDateTime(data) < DateTime.Today.AddMonths(-3))
                            {
                                ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString() + " " + rdr["Prenume"].ToString());
                                lvi.SubItems.Add(rdr["Utilizator"].ToString());
                                lvi.SubItems.Add(rdr["Adresa"].ToString());
                                lvi.SubItems.Add(rdr["Abonament"].ToString());
                                lvi.SubItems.Add(rdr["Datainr"].ToString());

                                listView1.Items.Add(lvi);
                            }
                            else
                            {

                                if (rdr["Abonament"].ToString() == "1 Luna: 15 RON" && Convert.ToDateTime(data) < DateTime.Today.AddMonths(-1))
                                {
                                    ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString() + " " + rdr["Prenume"].ToString());
                                    lvi.SubItems.Add(rdr["Utilizator"].ToString());
                                    lvi.SubItems.Add(rdr["Adresa"].ToString());
                                    lvi.SubItems.Add(rdr["Abonament"].ToString());
                                    lvi.SubItems.Add(rdr["Datainr"].ToString());

                                    listView1.Items.Add(lvi);
                                }
                            }
                        }
                    }                   
                }


                
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "There are no expired subscribtions:D.");
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                sqlCon.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
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

            string CommandText = "SELECT Nume,Prenume,Utilizator,Adresa,Abonament,Datainr,Abateri" + "  FROM Useri5";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr["Abateri"].ToString() == "0")
                {
                    ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString() + " " + rdr["Prenume"].ToString());
                    lvi.SubItems.Add(rdr["Utilizator"].ToString());
                    lvi.SubItems.Add(rdr["Adresa"].ToString());
                    lvi.SubItems.Add(rdr["Abonament"].ToString());
                    lvi.SubItems.Add(rdr["Datainr"].ToString());

                    listView1.Items.Add(lvi);
                }

            }
            rdr.Close();
            sqlCon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
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
            listView1.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;

            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT Nume,Prenume,Utilizator,Adresa,Abonament,Datainr,Abateri" + "  FROM Useri5";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (Convert.ToDateTime(rdr["Datainr"].ToString())<=DateTime.Today.AddYears(-1))
                {
                    ListViewItem lvi = new ListViewItem(rdr["Nume"].ToString() + " " + rdr["Prenume"].ToString());
                    lvi.SubItems.Add(rdr["Utilizator"].ToString());
                    lvi.SubItems.Add(rdr["Adresa"].ToString());
                    lvi.SubItems.Add(rdr["Abonament"].ToString());
                    lvi.SubItems.Add(rdr["Datainr"].ToString());

                    listView1.Items.Add(lvi);
                }

            }
            rdr.Close();
            sqlCon.Close();
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
    }
}
