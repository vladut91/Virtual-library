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
    public partial class Form12 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        
        public Form12()
        {
            InitializeComponent();
        }
        public string Nume
        {
            get { return label8.Text; }
            set { label8.Text = value; }
        }

        public string Prenume
        {
            get { return label9.Text; }
            set { label9.Text = value; }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
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
                string ab, dt, nrc, ab2, dt2, nrc2, nume, prenume;


                //cautarea

                SqlConnection sqlCon2 = new SqlConnection(connString2Builder.ToString());
                sqlCon2.Open();
                try
                {

                    string CommandText = "SELECT Nume, Prenume, Abonament, Data, Nrcarti" + "  FROM Useri5" + " WHERE (Nume LIKE @Nume AND Prenume LIKE @Prenume)";
                    cmd = new SqlCommand(CommandText);
                    cmd.Connection = sqlCon2;
                    cmd.Parameters.Add(new SqlParameter("@Nume", System.Data.SqlDbType.VarChar, 50, "Nume"));
                    cmd.Parameters.Add(new SqlParameter("@Prenume", System.Data.SqlDbType.VarChar, 50, "Prenume"));
                    cmd.Parameters["@Nume"].Value = label8.Text;
                    cmd.Parameters["@Prenume"].Value = label9.Text;
                    rdr2 = cmd.ExecuteReader();
                    if (rdr2.Read())
                    {

                        nume = rdr2["Nume"].ToString();
                        prenume = rdr2["Prenume"].ToString();
                        ab = rdr2["Abonament"].ToString();
                        dt = rdr2["Data"].ToString();
                        nrc = rdr2["Nrcarti"].ToString();
                        SqlCommand CmdSql2 = new SqlCommand("UPDATE Useri5 SET Abonament = @txt2, Data = @txt3, Nrcarti = @txt1 WHERE Nume = @num AND Prenume = @pren", sqlCon2);
                        CmdSql2.Parameters.AddWithValue("@num", nume);
                        CmdSql2.Parameters.AddWithValue("@pren", prenume);
                        ab2 = comboBox3.Text;
                        dt2 = DateTime.Now.ToShortDateString();
                        nrc2 = "0";
                        CmdSql2.Parameters.AddWithValue("@txt2", ab2);
                        CmdSql2.Parameters.AddWithValue("@txt3", dt2);
                        CmdSql2.Parameters.AddWithValue("@txt1", nrc2);
                        rdr2.Close();
                        CmdSql2.ExecuteNonQuery();



                        SqlConnection sqlCon = new SqlConnection(connString2Builder.ToString());
                        sqlCon.Open();
                        string commandString = "SELECT * FROM Abonanoi";
                        SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
                        SqlCommand CmdSql = new SqlCommand("INSERT INTO Abonanoi(Nume,Prenume,Abonament,Data) Values('" + label8.Text + "','" + label9.Text + "','" + comboBox3.Text + "','" + DateTime.Now.ToShortDateString() + "')", sqlCon);
                        CmdSql.ExecuteNonQuery();
                        sqlCon.Close();
                        
                        
                        this.Close();
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
                MessageBox.Show("Please choose a price!");
            }
        }

        
    }
}
