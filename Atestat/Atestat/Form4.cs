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
    public partial class Form4 : Form
    {
        string s;
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        
        public Form4()
        {
            InitializeComponent();
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
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;
           
            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT Utilizator, Nume, Prenume, Parola, Adresa, Abonament, Data, Nrcarti" + "  FROM Useri5" + " WHERE (Nume LIKE @Nume AND Prenume LIKE @Prenume)";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;

            cmd.Parameters.Add(new SqlParameter("@Nume", System.Data.SqlDbType.VarChar, 50, "Nume"));
            cmd.Parameters.Add(new SqlParameter("@Prenume", System.Data.SqlDbType.VarChar, 50, "Prenume"));

            cmd.Parameters["@Nume"].Value = label7.Text;
            cmd.Parameters["@Prenume"].Value = label8.Text;
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                if (rdr["Abonament"].ToString() == "1 Year:       25 $" && Convert.ToInt16(rdr["Nrcarti"]) < 61)
                {

                    if (comboBox1.Text!="")
                    {
                        SqlConnection sqlCon1 = new SqlConnection(connString2Builder.ToString());
                        sqlCon1.Open();

                        string commandString = "SELECT * FROM Comenzi";

                        SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon1);

                        SqlCommand CmdSql = new SqlCommand("INSERT INTO Comenzi(Destinatar, Adresa, Carte, Ora, Data) Values('" + label4.Text + "','" + label5.Text + "','" + label6.Text + "','" + comboBox1.Text + "','" + DateTime.Now.ToShortDateString() + "')", sqlCon1);

                        CmdSql.ExecuteNonQuery();
                        sqlCon1.Close();

                        MessageBox.Show("The book will be delivered to you address in the course of the next day between the hours" + comboBox1.Text + ".\nWe seek seriously from you,so please be present at home at the time of delivery!", "Delivery Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select the hours of your book delivery!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (rdr["Abonament"].ToString() == "6 Months:  15 $" && Convert.ToInt16(rdr["Nrcarti"]) < 31)
                    {
                        if (comboBox1.Text!="")
                        {
                            SqlConnection sqlCon1 = new SqlConnection(connString2Builder.ToString());
                            sqlCon1.Open();

                            string commandString = "SELECT * FROM Comenzi";

                            SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon1);

                            SqlCommand CmdSql = new SqlCommand("INSERT INTO Comenzi(Destinatar, Adresa, Carte, Ora, Data) Values('" + label4.Text + "','" + label5.Text + "','" + label6.Text + "','" + comboBox1.Text + "','" + DateTime.Now.ToShortDateString() + "')", sqlCon1);

                            CmdSql.ExecuteNonQuery();
                            sqlCon1.Close();
                            MessageBox.Show("The book will be delivered to you address in the course of the next day between the hours" + comboBox1.Text + ".\nWe seek seriously from you,so please be present at home at the time of delivery!", "Delivery Report", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please select the hours of your book delivery!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (rdr["Abonament"].ToString() == "3 Months:  10 $" && Convert.ToInt16(rdr["Nrcarti"]) < 16)
                        {
                            if (comboBox1.Text != "")
                            {
                                SqlConnection sqlCon1 = new SqlConnection(connString2Builder.ToString());
                                sqlCon1.Open();

                                string commandString = "SELECT * FROM Comenzi";

                                SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon1);

                                SqlCommand CmdSql = new SqlCommand("INSERT INTO Comenzi(Destinatar, Adresa, Carte, Ora, Data) Values('" + label4.Text + "','" + label5.Text + "','" + label6.Text + "','" + comboBox1.Text + "','" + DateTime.Now.ToShortDateString() + "')", sqlCon1);

                                CmdSql.ExecuteNonQuery();
                                sqlCon1.Close();

                                MessageBox.Show("The book will be delivered to you address in the course of the next day between the hours" + comboBox1.Text + ".\nWe seek seriously from you,so please be present at home at the time of delivery!", "Delivery Report", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Please select the hours of your book delivery!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            if (rdr["Abonament"].ToString() == "1 Month:      5 $" && Convert.ToInt16(rdr["Nrcarti"]) < 6)
                            {
                                if (comboBox1.Text!="")
                                {
                                    SqlConnection sqlCon1 = new SqlConnection(connString2Builder.ToString());
                                    sqlCon1.Open();

                                    string commandString = "SELECT * FROM Comenzi";

                                    SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon1);

                                    SqlCommand CmdSql = new SqlCommand("INSERT INTO Comenzi(Destinatar, Adresa, Carte, Ora, Data) Values('" + label4.Text + "','" + label5.Text + "','" + label6.Text + "','" + comboBox1.Text + "','" + DateTime.Now.ToShortDateString() + "')", sqlCon1);

                                    CmdSql.ExecuteNonQuery();
                                    sqlCon1.Close();

                                    MessageBox.Show("The book will be delivered to you address in the course of the next day between the hours" + comboBox1.Text + ".\nWe seek seriously from you,so please be present at home at the time of delivery!", "Delivery Report", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please select the hours of your book delivery!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                if (comboBox1.Text!="")
                                {
                                    SqlConnection sqlCon1 = new SqlConnection(connString2Builder.ToString());
                                    sqlCon1.Open();

                                    string commandString = "SELECT * FROM Comenzi";

                                    SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon1);

                                    SqlCommand CmdSql = new SqlCommand("INSERT INTO Comenzi(Destinatar, Adresa, Carte, Ora, Data, Cartiplus) Values('" + label4.Text + "','" + label5.Text + "','" + label6.Text + "','" + comboBox1.Text + "','" + DateTime.Now.ToShortDateString() + "','" + " +  1.5$/book " + "')", sqlCon1);

                                    CmdSql.ExecuteNonQuery();
                                    sqlCon1.Close();

                                    MessageBox.Show("The book will be delivered to you address in the course of the next day between the hours" + comboBox1.Text + ".\nWe seek seriously from you,so please be present at home at the time of delivery!");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please select the hours of your book delivery!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }                            
                        }
                    }
                }
            }           
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            s = DateTime.Now.AddDays(15).ToShortDateString();
            label2.Text = s;
            string nume, nume1, prenume1;
            string adresa;
            string carte;
            nume = Form2.TextNumOnForm2;
            adresa = Form2.TextAdrOnForm2;
            carte = Form2.TextCarteOnForm2;
            label4.Text = nume;
            label5.Text = adresa;
            label6.Text = carte;
            nume1 = Form2.Text1OnForm2;
            prenume1 = Form2.Text2OnForm2;
            label7.Text = nume1;
            label8.Text = prenume1;

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
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;
           
            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT Nume, Prenume, Parola, Adresa, Abonament, Data, Nrcarti" + "  FROM Useri5" + " WHERE (Nume LIKE @Nume AND Prenume LIKE @Prenume)";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;

            cmd.Parameters.Add(new SqlParameter("@Nume", System.Data.SqlDbType.VarChar, 50, "Nume"));
            cmd.Parameters.Add(new SqlParameter("@Prenume", System.Data.SqlDbType.VarChar, 50, "Prenume"));

            cmd.Parameters["@Nume"].Value = label7.Text;
            cmd.Parameters["@Prenume"].Value = label8.Text;
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                if (rdr["Abonament"].ToString() == "1 Year:       25 $" && Convert.ToInt16(rdr["Nrcarti"]) > 60)
                {
                    MessageBox.Show("Because you have reached the limit of books you can lent with your type of subscription, it will be added 1.5$/book when it will be delivered.\nThank you for your understanding!");
                }
                else
                {
                    if (rdr["Abonament"].ToString() == "6 Months:  15 $" && Convert.ToInt16(rdr["Nrcarti"]) > 30)
                    {
                        MessageBox.Show("Because you have reached the limit of books you can lent with your type of subscription, it will be added 1.5$/book when it will be delivered.\nThank you for your understanding!");

                    }
                    else
                    {
                        if (rdr["Abonament"].ToString() == "3 Months:  10 $" && Convert.ToInt16(rdr["Nrcarti"]) > 15)
                        {
                            MessageBox.Show("Because you have reached the limit of books you can lent with your type of subscription, it will be added 1.5$/book when it will be delivered.\nThank you for your understanding!");

                        }
                        else
                        {
                            if (rdr["Abonament"].ToString() == "1 Month:      5 $" && Convert.ToInt16(rdr["Nrcarti"]) > 6)
                            {
                                MessageBox.Show("Because you have reached the limit of books you can lent with your type of subscription, it will be added 1.5$/book when it will be delivered.\nThank you for your understanding!");

                            }
                        }
                    }
                }
            }


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
                button1.Enabled = true;
            else
            {
                MessageBox.Show("Please select the hours of your book delivery!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
            }
        }

       
    }
}
