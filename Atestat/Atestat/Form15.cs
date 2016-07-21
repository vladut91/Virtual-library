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
    public partial class Form15 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        int boolean;

        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
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

            string CommandText = "SELECT Titlu, Autor, Anul, Stoc" + "  FROM Carti";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Titlu"].ToString());
                lvi.SubItems.Add(rdr["Autor"].ToString());
                lvi.SubItems.Add(rdr["Anul"].ToString());
                lvi.SubItems.Add(rdr["Stoc"].ToString());
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
            SqlDataReader rdr2 = null;
            SqlCommand cmd = null;
            string st, st2, titlut;
            int txt3;

            //cautarea

            SqlConnection sqlCon2 = new SqlConnection(connString2Builder.ToString());
            sqlCon2.Open();
            try
            {
                string s = listView1.SelectedItems[0].SubItems[0].Text;
                string CommandText = "SELECT Titlu,Autor,Anul,Stoc" + "  FROM Carti" + " WHERE (Titlu LIKE @Cauta)";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = sqlCon2;
                cmd.Parameters.Add(new SqlParameter("@Cauta", System.Data.SqlDbType.VarChar, 50, "Titlu"));
                cmd.Parameters["@Cauta"].Value = s;
                rdr2 = cmd.ExecuteReader();
                if (rdr2.Read())
                {
                    if (rdr2["Stoc"].ToString() != "0")
                    {


                        titlut = rdr2["Titlu"].ToString();
                        st = rdr2["Stoc"].ToString();
                        SqlCommand CmdSql2 = new SqlCommand("UPDATE Carti SET Stoc= @txt2 WHERE Titlu = @txt", sqlCon2);
                        CmdSql2.Parameters.AddWithValue("@txt", titlut);
                        txt3 = Convert.ToInt16(st) - Convert.ToInt16(textBox1.Text);
                        st2 = txt3.ToString();
                        CmdSql2.Parameters.AddWithValue("@txt2", st2);
                        rdr2.Close();
                        CmdSql2.ExecuteNonQuery();
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }

                }
                else { }

                sqlCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.");
            }
            finally
            {
                if (rdr2 != null)
                    rdr2.Close();
                sqlCon2.Close();
            }

            listView1.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
           

            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText2 = "SELECT Titlu, Autor, Anul, Stoc" + "  FROM Carti";
            cmd = new SqlCommand(CommandText2);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Titlu"].ToString());
                lvi.SubItems.Add(rdr["Autor"].ToString());
                lvi.SubItems.Add(rdr["Anul"].ToString());
                lvi.SubItems.Add(rdr["Stoc"].ToString());

                listView1.Items.Add(lvi);

            }
            rdr.Close();
            sqlCon.Close();
            timer1.Start();
            label1.Visible = true;
            label1.Text = "The stock was modified !";
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
            SqlDataReader rdr2 = null;
            SqlCommand cmd = null;
            string st, st2, titlut;
            int txt3;

            //cautarea

            SqlConnection sqlCon2 = new SqlConnection(connString2Builder.ToString());
            sqlCon2.Open();
            try
            {
                string s = listView1.SelectedItems[0].SubItems[0].Text;
                string CommandText = "SELECT Titlu,Autor,Anul,Stoc" + "  FROM Carti" + " WHERE (Titlu LIKE @Cauta)";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = sqlCon2;
                cmd.Parameters.Add(new SqlParameter("@Cauta", System.Data.SqlDbType.VarChar, 50, "Titlu"));
                cmd.Parameters["@Cauta"].Value = s;
                rdr2 = cmd.ExecuteReader();
                if (rdr2.Read())
                {
                  
                        titlut = rdr2["Titlu"].ToString();
                        st = rdr2["Stoc"].ToString();
                        SqlCommand CmdSql2 = new SqlCommand("UPDATE Carti SET Stoc= @txt2 WHERE Titlu = @txt", sqlCon2);
                        CmdSql2.Parameters.AddWithValue("@txt", titlut);
                        txt3 = Convert.ToInt16(st) + Convert.ToInt16(textBox1.Text);
                        st2 = txt3.ToString();
                        CmdSql2.Parameters.AddWithValue("@txt2", st2);
                        rdr2.Close();
                        CmdSql2.ExecuteNonQuery();
                        textBox1.Text = "";

                }
                else { }

                sqlCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.");
            }
            finally
            {
                if (rdr2 != null)
                    rdr2.Close();
                sqlCon2.Close();
            }

            listView1.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;

            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText2 = "SELECT Titlu, Autor, Anul, Stoc" + "  FROM Carti";
            cmd = new SqlCommand(CommandText2);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Titlu"].ToString());
                lvi.SubItems.Add(rdr["Autor"].ToString());
                lvi.SubItems.Add(rdr["Anul"].ToString());
                lvi.SubItems.Add(rdr["Stoc"].ToString());

                listView1.Items.Add(lvi);

            }
            rdr.Close();
            sqlCon.Close();
            timer1.Start();
            label1.Visible = true;
            label1.Text = "The stock was modified !";
            
        }

        private void button3_Click(object sender, EventArgs e)
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

            string CommandText = "SELECT Titlu, Autor, Anul, Stoc" + "  FROM Carti";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

           while (rdr.Read())
            {
                if (rdr["Stoc"].ToString() == "0")
                {

                    ListViewItem lvi = new ListViewItem(rdr["Titlu"].ToString());
                    lvi.SubItems.Add(rdr["Autor"].ToString());
                    lvi.SubItems.Add(rdr["Anul"].ToString());
                    lvi.SubItems.Add(rdr["Stoc"].ToString());

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

            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT Titlu, Autor, Anul, Stoc" + "  FROM Carti";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
               

                    ListViewItem lvi = new ListViewItem(rdr["Titlu"].ToString());
                    lvi.SubItems.Add(rdr["Autor"].ToString());
                    lvi.SubItems.Add(rdr["Anul"].ToString());
                    lvi.SubItems.Add(rdr["Stoc"].ToString());

                    listView1.Items.Add(lvi);                
            }
            rdr.Close();
            sqlCon.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "0")
                button1.Enabled = button2.Enabled = true;
            else
            {
                //MessageBox.Show("Please enter the number of books you want to modify the stock !", "Books No.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = button2.Enabled = false;
            }
            if (textBox1.Text == "0")
                textBox1.Text = "";
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            textBox2.Text = "@  " + listView1.SelectedItems[0].SubItems[0].Text + "  @";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox2.Text = "";
            timer1.Stop();
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

            
            if (textBox2.Text != "")
            {
                SqlConnection sqlCon2 = new SqlConnection(connString2Builder.ToString());
                sqlCon2.Open();
                
                string commandString = "SELECT * FROM Carti";

                SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon2);

                SqlCommand CmdSql = new SqlCommand("DELETE FROM [Carti] WHERE[Titlu]=@title", sqlCon2);
                CmdSql.Parameters.Add(new SqlParameter("@title", System.Data.SqlDbType.VarChar, 50, "Titlu"));

                CmdSql.Parameters["@title"].Value = listView1.SelectedItems[0].SubItems[0].Text;

                CmdSql.ExecuteNonQuery();
                sqlCon2.Close();
                timer1.Start();
                label1.Visible = true;
                label1.Text = "The book was deleted from the database !";
                boolean = 1;
            }
            else
            {
                MessageBox.Show("Please double click on the book in the list you desire to delete !", "ADD BOOK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (boolean == 1)
            {
                listView1.Items.Clear();
                SqlDataReader rdr = null;
                SqlConnection sqlCon = null;
                SqlCommand cmd = null;

                sqlCon = new SqlConnection(connString2Builder.ToString());
                sqlCon.Open();

                string CommandText = "SELECT Titlu, Autor, Anul, Stoc" + "  FROM Carti";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = sqlCon;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(rdr["Titlu"].ToString());
                    lvi.SubItems.Add(rdr["Autor"].ToString());
                    lvi.SubItems.Add(rdr["Anul"].ToString());
                    lvi.SubItems.Add(rdr["Stoc"].ToString());
                    listView1.Items.Add(lvi);
                }
                rdr.Close();
                sqlCon.Close();
                boolean = 0;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

            string CommandText = "SELECT Titlu, Autor, Anul, Stoc" + "  FROM Carti";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;
            string decaut;
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["Titlu"].ToString());
                lvi.SubItems.Add(rdr["Autor"].ToString());
                lvi.SubItems.Add(rdr["Anul"].ToString());
                lvi.SubItems.Add(rdr["Stoc"].ToString());
                decaut = rdr["Titlu"].ToString().ToLower();
                if (decaut.Contains(textBox2.Text.ToLower()))
                    listView1.Items.Add(lvi);
                
            }
            rdr.Close();
            sqlCon.Close();
        }

       
    }
}
