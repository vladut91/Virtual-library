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
    public partial class Form2 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        private Form4 f;
        private Form5 d;
        private Form8 h;
        int nr = 0;
        public static string Text1OnForm2;
        public static string Text2OnForm2;
        public static string TextNumOnForm2;
        public static string TextAdrOnForm2;
        public static string TextCarteOnForm2;
        
        private ListViewColumnSorter lvwColumnSorter;
        string nrcrt;       

        public Form2()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(timer1_Tick); 
            timer1.Interval = (1000) * (1);              
            timer1.Enabled = true;                      
            timer1.Start();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //schimbare stoc
            string book = listView1.SelectedItems[0].Text;
            var result=MessageBox.Show("You are about to borrow '" + book + "'.\nDo you want to continue?", "Borrow books", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (nr < 5)
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
                    SqlDataReader rdr1 = null;
                    SqlCommand cmd1 = null;
                    string nrc, nrc2, nume, prenume;
                    int txt;


                    //cautarea

                    SqlConnection sqlCon1 = new SqlConnection(connString2Builder.ToString());
                    sqlCon1.Open();
                    try
                    {

                        string CommandText = "SELECT Nume, Prenume, Nrcarti" + "  FROM Useri5" + " WHERE (Nume LIKE @Nume AND Prenume LIKE @Prenume)";
                        cmd1 = new SqlCommand(CommandText);
                        cmd1.Connection = sqlCon1;
                        cmd1.Parameters.Add(new SqlParameter("@Nume", System.Data.SqlDbType.VarChar, 50, "Nume"));
                        cmd1.Parameters.Add(new SqlParameter("@Prenume", System.Data.SqlDbType.VarChar, 50, "Prenume"));
                        cmd1.Parameters["@Nume"].Value = label13.Text;
                        cmd1.Parameters["@Prenume"].Value = label14.Text;
                        rdr1 = cmd1.ExecuteReader();
                        if (rdr1.Read())
                        {

                            nume = rdr1["Nume"].ToString();
                            prenume = rdr1["Prenume"].ToString();

                            nrc = rdr1["Nrcarti"].ToString();
                            SqlCommand CmdSql1 = new SqlCommand("UPDATE Useri5 SET Nrcarti = @txt1 WHERE Nume = @num AND Prenume = @pren", sqlCon1);
                            CmdSql1.Parameters.AddWithValue("@num", nume);
                            CmdSql1.Parameters.AddWithValue("@pren", prenume);
                            txt = Convert.ToInt16(nrc) + 1;
                            nrc2 = txt.ToString();

                            CmdSql1.Parameters.AddWithValue("@txt1", nrc2);
                            rdr1.Close();
                            CmdSql1.ExecuteNonQuery();


                        }
                        else { }

                        sqlCon1.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error.");
                    }
                    finally
                    {
                        if (rdr1 != null)
                            rdr1.Close();
                        sqlCon1.Close();
                    }


                    SqlDataReader rdr2 = null;
                    SqlCommand cmd2 = null;
                    string st, st2, titlut;
                    int txt3;

                    //cautarea

                    SqlConnection sqlCon2 = new SqlConnection(connString2Builder.ToString());
                    sqlCon2.Open();
                    try
                    {
                        string s = listView1.SelectedItems[0].SubItems[0].Text;
                        string CommandText = "SELECT Titlu,Autor,Anul,Stoc" + "  FROM Carti" + " WHERE (Titlu LIKE @Cauta)";
                        cmd2 = new SqlCommand(CommandText);
                        cmd2.Connection = sqlCon2;
                        cmd2.Parameters.Add(new SqlParameter("@Cauta", System.Data.SqlDbType.VarChar, 50, "Titlu"));
                        cmd2.Parameters["@Cauta"].Value = s;
                        rdr2 = cmd2.ExecuteReader();
                        if (rdr2.Read())
                        {
                            if (rdr2["Stoc"].ToString() != "0")
                            {


                                titlut = rdr2["Titlu"].ToString();
                                st = rdr2["Stoc"].ToString();
                                SqlCommand CmdSql2 = new SqlCommand("UPDATE Carti SET Stoc= @txt2 WHERE Titlu = @txt", sqlCon2);
                                CmdSql2.Parameters.AddWithValue("@txt", titlut);
                                txt3 = Convert.ToInt16(st) - 1;
                                st2 = txt3.ToString();
                                CmdSql2.Parameters.AddWithValue("@txt2", st2);
                                rdr2.Close();
                                CmdSql2.ExecuteNonQuery();


                                Form2.TextNumOnForm2 = label4.Text;
                                Form2.TextAdrOnForm2 = label7.Text;
                                Form2.TextCarteOnForm2 = listView1.SelectedItems[0].Text;
                                nr = nr + 1;
                                label6.Text = Convert.ToString(nr);
                                f = new Form4();
                                f.ShowDialog();



                                SqlDataReader rdr = null;
                                SqlConnection sqlCon = null;
                                SqlCommand cmd = null;


                                sqlCon = new SqlConnection(connString2Builder.ToString());
                                sqlCon.Open();

                                string CommandText1 = "SELECT Titlu, Autor, Anul, Stoc" + "  FROM Carti";
                                cmd = new SqlCommand(CommandText1);
                                cmd.Connection = sqlCon;


                                listView1.Items.Clear();
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
                            else
                            {
                                MessageBox.Show("For the moment we do not have the book.");
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
                }
                else
                {
                    MessageBox.Show("You reached the limit for this sesion.\nFor the moment you cannot borrow more books.\nThank you for understanding.");
                }
            }
            else
                textBox3.Text = "";
            pictureBox1.Image = System.Drawing.Image.FromFile("cc_tab.jpg");
            
        }

        

        private void Form2_Load(object sender, EventArgs e)
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
            SqlDataReader rdr1 = null;            
            SqlConnection sqlCon1 = null;           
            SqlCommand cmd1 = null;            
            
            
            sqlCon1 = new SqlConnection(connString2Builder.ToString());
            sqlCon1.Open();

            string CommandText1 = "SELECT TOP 15 * FROM  Carti ORDER BY Nr_carti desc";
           
            cmd1 = new SqlCommand(CommandText1);
            cmd1.Connection = sqlCon1;
            rdr1 = cmd1.ExecuteReader();
          
            while(rdr1.Read())
            {
                 nrcrt = rdr1["Nr_carti"].ToString();
              
                    ListViewItem lvi = new ListViewItem(rdr1["Titlu"].ToString());
                    listView3.Items.Add(lvi);
              

            }rdr1.Close();
            sqlCon1.Close();
           
           
            

            button2.Enabled = false;
            button5.Enabled = false;
            
            label4.Text = label13.Text + " " + label14.Text;
            Form2.Text1OnForm2 = label13.Text;
            Form2.Text2OnForm2 = label14.Text;
            
            label6.Text = nr.ToString();
            pictureBox1.Image = System.Drawing.Image.FromFile("home_tab.jpg");

            if (label4.Text == "Glitia Vlad-Florin" || label4.Text == "glitia vlad-florin")
            {
                button8.Visible = true;
            }
            else
            {
                button8.Visible = false;
            }


            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;
            
            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT CNP" + "  FROM Useritmp" + " WHERE (CNP LIKE @user)";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;

            cmd.Parameters.Add(new SqlParameter("@user", System.Data.SqlDbType.VarChar, 50, "CNP"));
            

            cmd.Parameters["@user"].Value = label9.Text;
            

            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                if (label8.Text == rdr["CNP"].ToString())
                {
                    MessageBox.Show("   We are sorry for the incovenince, but you are banned for the moment!    ");
                    Application.Exit();
                }
            }
            rdr.Close();
            sqlCon.Close();         

           
        }

        
        
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            webBrowser1.Navigate(linkLabel1.Text);
            pictureBox1.Image = System.Drawing.Image.FromFile("crw_tab.jpg");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            webBrowser1.Navigate(linkLabel5.Text);
            pictureBox1.Image = System.Drawing.Image.FromFile("crw_tab.jpg");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            webBrowser1.Navigate(linkLabel4.Text);
            pictureBox1.Image = System.Drawing.Image.FromFile("crw_tab.jpg");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            webBrowser1.Navigate(linkLabel3.Text);
            pictureBox1.Image = System.Drawing.Image.FromFile("crw_tab.jpg");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            webBrowser1.Navigate(linkLabel2.Text);
            pictureBox1.Image = System.Drawing.Image.FromFile("crw_tab.jpg");
        }

            
        private void tabPage1_Click(object sender, EventArgs e)
        {
              pictureBox1.Image = System.Drawing.Image.FromFile("home_tab.jpg");
        }
              

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                    button2.Enabled = true;
               
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        { 
            button5.Enabled = true;
            
        }

        private void button6_Click(object sender, EventArgs e)
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
            pictureBox1.Image = System.Drawing.Image.FromFile("cr_tab.jpg");
            listView2.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;
            
            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT ID, Titlu, Domeniu" + "  FROM Referate";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["ID"].ToString());
                lvi.SubItems.Add(rdr["Titlu"].ToString());
                lvi.SubItems.Add(rdr["Domeniu"].ToString());
                listView2.Items.Add(lvi);
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
            pictureBox1.Image = System.Drawing.Image.FromFile("cc_tab.jpg");
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

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel6.LinkVisited = true;
            webBrowser1.Navigate(linkLabel6.Text);
            pictureBox1.Image = System.Drawing.Image.FromFile("crw_tab.jpg");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel7.LinkVisited = true;
            webBrowser1.Navigate(linkLabel7.Text);
            pictureBox1.Image = System.Drawing.Image.FromFile("crw_tab.jpg");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string x = listView2.SelectedItems[0].SubItems[1].Text;
            x = x + ".pdf";
            Process.Start(x);       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             label1.Text=DateTime.Now.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            d = new Form5();
            d.ShowDialog();
        }

        public string Adresa
        {
            get { return label7.Text; }
            set { label7.Text = value; }
        }

        public string Nume
        {
            get { return label13.Text; }
            set { label13.Text = value; }
        }

        public string Prenume
        {
            get { return label14.Text; }
            set { label14.Text = value; }
        }

        public string User
        {
            get { return label8.Text; }
            set { label8.Text = value; }
        }
        public string CNP
        {
            get { return label9.Text; }
            set { label9.Text = value; }
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

        private void button9_Click(object sender, EventArgs e)
        {
            h = new Form8();
            h.ShowDialog();
        }

        
        private void textBox3_TextChanged(object sender, EventArgs e)
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
            string decaut;

            
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
                decaut = rdr["Titlu"].ToString().ToLower();
                if (decaut.Contains(textBox3.Text.ToLower()))
                    listView1.Items.Add(lvi);

            }


            pictureBox1.Image = System.Drawing.Image.FromFile("cc_tab.jpg");
            rdr.Close();
            sqlCon.Close();  
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
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
            pictureBox1.Image = System.Drawing.Image.FromFile("cr_tab.jpg");
            listView2.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;
            string decaut;

            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT ID, Titlu, Domeniu" + "  FROM Referate";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem lvi = new ListViewItem(rdr["ID"].ToString());
                lvi.SubItems.Add(rdr["Titlu"].ToString());
                lvi.SubItems.Add(rdr["Domeniu"].ToString());
                decaut = rdr["Titlu"].ToString().ToLower();
                if (decaut.Contains(textBox8.Text.ToLower()))
                    listView2.Items.Add(lvi);

            }
            rdr.Close();
            sqlCon.Close();
        } 
    }
}
