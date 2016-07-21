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
    public partial class Form1 : Form
    {
        private Form2 f;
        private Form3 d;
        private Form12 q;
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        
        public static string Text1OnForm1;
        int tick;
       
        
           
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {              
                ToolTip toolTip1 = new ToolTip();
                toolTip1.AutoPopDelay = 500000000;
                toolTip1.InitialDelay = 100;
                toolTip1.ReshowDelay = 50;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(this.pictureBox1, "Press the buton to find out more about this software.");
            }

            private void button1_Click(object sender, EventArgs e)
            {
                d = new Form3();
                d.ShowDialog();
            }


            private void button2_Click(object sender, EventArgs e)
            {
                if (textBox1.Text != "" && textBox3.Text != "")
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

                    SqlConnection sqlCon = null;
                    SqlCommand cmd = null;
                    SqlDataReader rdr = null;
                    try
                    {
                        sqlCon = new SqlConnection(connString2Builder.ToString());
                        sqlCon.Open();

                        string CommandText = "SELECT * " + "  FROM Useri5" + " WHERE (Utilizator LIKE @Utilizator AND Parola LIKE @Parola)";
                        cmd = new SqlCommand(CommandText);
                        cmd.Connection = sqlCon;

                        cmd.Parameters.Add(new SqlParameter("@Utilizator", System.Data.SqlDbType.VarChar, 50, "Utilizator"));
                        cmd.Parameters.Add(new SqlParameter("@Parola", System.Data.SqlDbType.VarChar, 50, "Parola"));

                        cmd.Parameters["@Utilizator"].Value = textBox1.Text;
                        cmd.Parameters["@Parola"].Value = textBox3.Text;

                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {

                            string data;
                            data = rdr["Data"].ToString();

                            if (rdr["Abonament"].ToString() == "1 Year:       25 $" && Convert.ToDateTime(data) < DateTime.Today.AddYears(-1))
                            {
                                Form1.Text1OnForm1 = textBox1.Text;
                                q = new Form12();
                                q.Nume = rdr["Nume"].ToString();
                                q.Prenume = rdr["Prenume"].ToString();
                                q.ShowDialog();
                            }
                            else
                            {
                                if (rdr["Abonament"].ToString() == "6 Months:  15 $" && Convert.ToDateTime(data) < DateTime.Today.AddMonths(-6))
                                {
                                    Form1.Text1OnForm1 = textBox1.Text;
                                    q = new Form12();
                                    q.Nume = rdr["Nume"].ToString();
                                    q.Prenume = rdr["Prenume"].ToString();
                                    q.ShowDialog();
                                }
                                else
                                {
                                    if (rdr["Abonament"].ToString() == "3 Months:  10 $" && Convert.ToDateTime(data) < DateTime.Today.AddMonths(-3))
                                    {
                                        Form1.Text1OnForm1 = textBox1.Text;

                                        q = new Form12();
                                        q.Nume = rdr["Nume"].ToString();
                                        q.Prenume = rdr["Prenume"].ToString();
                                        q.ShowDialog();
                                    }
                                    else
                                    {
                                        if (rdr["Abonament"].ToString() == "1 Month:      5 $" && Convert.ToDateTime(data) < DateTime.Today.AddMonths(-1))
                                        {
                                            Form1.Text1OnForm1 = textBox1.Text;

                                            q = new Form12();
                                            q.Nume = rdr["Nume"].ToString();
                                            q.Prenume = rdr["Prenume"].ToString();
                                            q.ShowDialog();
                                        }
                                    }
                                }
                            }


                            if (rdr == null)
                            {
                                MessageBox.Show("You are not registered.\nPress Register.\nFill out the form and log in.");
                            }
                            else
                            {

                                if (textBox1.Text != "")
                                {
                                    Form1.Text1OnForm1 = textBox1.Text;

                                    f = new Form2();
                                    f.Adresa = rdr["Adresa"].ToString();
                                    f.Nume = rdr["Nume"].ToString();
                                    f.Prenume = rdr["Prenume"].ToString();
                                    f.User = textBox1.Text;
                                    f.CNP = rdr["CNP"].ToString();
                                    f.ShowDialog();
                                    textBox1.Clear();
                                    textBox3.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("You are not registered.\nPress Register.\nFill out the form and log in.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("You are not registered.\nPress Register.\nFill out the form and log in.");
                        }
                        sqlCon.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "You are not registered!!!");
                    }
                    finally
                    {
                        if (rdr != null)
                            rdr.Close();
                        sqlCon.Close();
                    }
                }
                else
                    MessageBox.Show("Please enter your data!");
            }
    
            private void pictureBox1_Click(object sender, EventArgs e)
            {

                MessageBox.Show("This is a virtual library with copyright for all the files within.\nTo have access to our services you need to subscribe:\nMonthly:   5 $\n3 Months:  10 $\n6 Months:  15 $\n1 Year:    25 $\nThe subscripsion choosed will be paid when the first delivery is made.\nWith the help provided by the library you don't have come to our headquarters, because the book's will be delivered to your location and read in the harmony of your own enviroment.");
            }

            private void pictureBox1_MouseEnter(object sender, EventArgs e)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile("help_icon_enter.png");
            }

            private void pictureBox1_MouseLeave(object sender, EventArgs e)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile("help_icon_svg.png");
            }

            
        }

    
}
