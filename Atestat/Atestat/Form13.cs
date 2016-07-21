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
    public partial class Form13 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";

        private ListViewColumnSorter lvwColumnSorter;

        public Form13()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            this.listView2.ListViewItemSorter = lvwColumnSorter;
            this.listView3.ListViewItemSorter = lvwColumnSorter;
        }

        private void Form13_Load(object sender, EventArgs e)
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
            label2.Visible = false;
            label5.Visible = false;
            listView1.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;      
            SqlCommand cmd = null;
            
            sqlCon = new SqlConnection(connString2Builder.ToString());           
            sqlCon.Open();            

            string CommandText = "SELECT CNP, Utilizator, Abateri, Data, Abonament" + "  FROM Useri5";           
            cmd = new SqlCommand(CommandText);            
            cmd.Connection = sqlCon;
     
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Utilizator"].ToString());
                lvi.SubItems.Add(rdr["Abateri"].ToString());
                lvi.SubItems.Add(rdr["Data"].ToString());
                lvi.SubItems.Add(rdr["Abonament"].ToString());
                lvi.SubItems.Add(rdr["CNP"].ToString());
                listView1.Items.Add(lvi);

            }


            sqlCon.Close();
            rdr.Close();
            SqlDataReader rdr2 = null;
            SqlConnection sqlCon2 = null;
            SqlCommand cmd2 = null;

            sqlCon2 = new SqlConnection(connString2Builder.ToString());
            sqlCon2.Open();

            string CommandText2 = "SELECT Utilizator, Data, Abonament" + "  FROM Useritmp";
            cmd2 = new SqlCommand(CommandText2);
            cmd2.Connection = sqlCon2;
            
            rdr2 = cmd2.ExecuteReader();
            
            while (rdr2.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr2["Utilizator"].ToString());
                lvi.SubItems.Add(rdr2["Data"].ToString());
                lvi.SubItems.Add(rdr2["Abonament"].ToString());
                listView2.Items.Add(lvi);
            }


            sqlCon2.Close();
            rdr2.Close();
           
           
            SqlDataReader rdr3 = null;
            SqlConnection sqlCon3 = null;
            SqlCommand cmd3 = null;

            sqlCon3 = new SqlConnection(connString2Builder.ToString());
            sqlCon3.Open();

            string CommandText3 = "SELECT Utilizator, Data" + "  FROM Useritmp";
            cmd3 = new SqlCommand(CommandText3);
            cmd3.Connection = sqlCon3;

            rdr3 = cmd3.ExecuteReader();
           
            while (rdr3.Read())
            {
                string data;
                data = Convert.ToDateTime(rdr3["Data"].ToString()).AddDays(14).ToShortDateString();
            
                ListViewItem lvi = new ListViewItem(rdr3["Utilizator"].ToString());
                lvi.SubItems.Add(data.ToString());

                listView3.Items.Add(lvi);

            }


            sqlCon3.Close();
            rdr3.Close();
           
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

            try
            {
                sqlCon2 = new SqlConnection(connString2Builder.ToString());
                sqlCon2.Open();

                string CommandText = "SELECT Utilizator, Abateri" + "  FROM Useri5" + " WHERE (Utilizator LIKE @user)";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = sqlCon2;

                cmd.Parameters.Add(new SqlParameter("@user", System.Data.SqlDbType.VarChar, 50, "Utilizator"));
                         
                cmd.Parameters["@user"].Value = textBox1.Text;
                rdr3 = cmd.ExecuteReader();


                if (rdr3.Read())
                {
                    int txt3; string st2;
                    string nume = rdr3["Utilizator"].ToString();
                    string abat = rdr3["Abateri"].ToString();
                    SqlCommand CmdSql2 = new SqlCommand("UPDATE Useri5 SET Abateri= @txt2 WHERE Utilizator = @txt", sqlCon2);
                    CmdSql2.Parameters.AddWithValue("@txt", nume);
                    txt3 = Convert.ToInt16(abat) + 1;
                    st2 = txt3.ToString();
                    CmdSql2.Parameters.AddWithValue("@txt2", st2);
                    rdr3.Close();
                    CmdSql2.ExecuteNonQuery();

                    label3.Visible = true;
                }
                else
                {

                    MessageBox.Show("The user do not exist!\nEnter a new search.");
                }
                sqlCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "We do not have the user!!!");
            }
            finally
            {
                
                    rdr3.Close();
                sqlCon2.Close();
            }
            
            listView1.Items.Clear();
           
            sqlCon2 = new SqlConnection(connString2Builder.ToString());
            sqlCon2.Open();

            string CommandText1 = "SELECT CNP, Utilizator, Abonament, Abateri, Data" + "  FROM Useri5";
            cmd = new SqlCommand(CommandText1);
            cmd.Connection = sqlCon2;



            rdr3 = cmd.ExecuteReader();

            while (rdr3.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr3["Utilizator"].ToString());
                lvi.SubItems.Add(rdr3["Abateri"].ToString());
                lvi.SubItems.Add(rdr3["Data"].ToString());
                lvi.SubItems.Add(rdr3["Abonament"].ToString());
                lvi.SubItems.Add(rdr3["CNP"].ToString());

                listView1.Items.Add(lvi);

            }
            rdr3.Close();
            sqlCon2.Close();
            textBox1.Clear();
            label4.Text = "";
            
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

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            label3.Visible = false;
            label2.Visible = false;
            label5.Visible = false;
            textBox1.Text = listView1.SelectedItems[0].Text;
            label4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            label6.Text = listView1.SelectedItems[0].SubItems[4].Text;
            
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
            string s1;
            s1 = textBox1.Text;

            if (s1 != "")
            {
                SqlConnection sqlCon = new SqlConnection(connString2Builder.ToString());
                sqlCon.Open();

                string commandString = "SELECT * FROM Useritmp";

                SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
                if (textBox1.Text != "vlad")
                {
                    SqlCommand CmdSql = new SqlCommand("INSERT INTO Useritmp(CNP, Utilizator, Data, Abonament) Values('" + label6.Text + "','" + textBox1.Text + "','" + DateTime.Now.ToShortDateString() + "','" + label4.Text + "')", sqlCon);

                    CmdSql.ExecuteNonQuery();
                }


                sqlCon.Close();
            }
            else MessageBox.Show("Please enter user!");
             
            label2.Visible = true;
                listView2.Items.Clear();
                listView3.Items.Clear();
                textBox1.Clear();
                label4.Text = "";
                SqlDataReader rdr = null;
                SqlConnection sqlCon1 = null;
                SqlCommand cmd = null;
               

                sqlCon1 = new SqlConnection(connString2Builder.ToString());
                sqlCon1.Open();

                string CommandText = "SELECT Utilizator, Data, Abonament" + "  FROM Useritmp";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = sqlCon1;
                rdr = cmd.ExecuteReader();
                

                while (rdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(rdr["Utilizator"].ToString());
                    lvi.SubItems.Add(rdr["Data"].ToString());
                    lvi.SubItems.Add(rdr["Abonament"].ToString());
                    listView2.Items.Add(lvi);

                }
                rdr.Close();
                sqlCon1.Close();
                
                SqlDataReader rdr3 = null;
                SqlConnection sqlCon3 = null;
                SqlCommand cmd3 = null;

                sqlCon3 = new SqlConnection(connString2Builder.ToString());
                sqlCon3.Open();

                string CommandText3 = "SELECT Utilizator, Data" + "  FROM Useritmp";
                cmd3 = new SqlCommand(CommandText3);
                cmd3.Connection = sqlCon3;

                rdr3 = cmd3.ExecuteReader();

                while (rdr3.Read())
                {
                    string data;
                    data = Convert.ToDateTime(rdr3["Data"].ToString()).AddDays(14).ToShortDateString();

                    ListViewItem lvi = new ListViewItem(rdr3["Utilizator"].ToString());
                    lvi.SubItems.Add(data.ToString());

                    listView3.Items.Add(lvi);

                }


                sqlCon3.Close();
                rdr3.Close();
            
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
            
            SqlConnection sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();


            string commandString = "SELECT * FROM Useritmp";
            SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
            SqlCommand CmdSql = new SqlCommand("DELETE FROM [Useritmp] WHERE[Utilizator]=@user", sqlCon);
            CmdSql.Parameters.Add(new SqlParameter("@user", System.Data.SqlDbType.VarChar, 50, "Utilizator"));
            CmdSql.Parameters["@user"].Value = textBox1.Text;;
            CmdSql.ExecuteNonQuery();
            listView3.Items.Clear();


            SqlDataReader rdr3 = null;
            
            SqlCommand cmd3 = null;

            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText3 = "SELECT Utilizator, Data" + "  FROM Useritmp";
            cmd3 = new SqlCommand(CommandText3);
            cmd3.Connection = sqlCon;

            rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())
            {
                string data;
                data = Convert.ToDateTime(rdr3["Data"].ToString()).AddDays(14).ToShortDateString();

                ListViewItem lvi = new ListViewItem(rdr3["Utilizator"].ToString());
                lvi.SubItems.Add(data.ToString());

                listView3.Items.Add(lvi);

            }


            sqlCon.Close();
            rdr3.Close();
            label5.Visible = true;
            textBox1.Clear();
            listView2.Items.Clear();
            SqlDataReader rdr2 = null;
            SqlConnection sqlCon2 = null;
            SqlCommand cmd2 = null;

            sqlCon2 = new SqlConnection(connString2Builder.ToString());
            sqlCon2.Open();

            string CommandText2 = "SELECT Utilizator, Data, Abonament" + "  FROM Useritmp";
            cmd2 = new SqlCommand(CommandText2);
            cmd2.Connection = sqlCon2;

            rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr2["Utilizator"].ToString());
                lvi.SubItems.Add(rdr2["Data"].ToString());
                lvi.SubItems.Add(rdr2["Abonament"].ToString());
                listView2.Items.Add(lvi);
            }


            sqlCon2.Close();
            rdr2.Close();
        }
        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.listView2.Sort();

        }
        private void listView3_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.listView3.Sort();

        }

        private void listView3_ItemActivate(object sender, EventArgs e)
        {
            label3.Visible = false;
            label2.Visible = false;
            label5.Visible = false;
            textBox1.Text = listView3.SelectedItems[0].Text;
        }
    }
}
