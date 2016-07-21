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


    public partial class Form3 : Form
    {

        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        int result_age = 0;
        int result_zip_code = 0;

        public Form3()
        {

            InitializeComponent();
        }
        private void test_age()
        {
            string year = "19";
            int max = Convert.ToInt16(textBox7.Text.Substring(0, 1));
            if (textBox7.TextLength != 13)
            {
                MessageBox.Show("Incorrect SOCIAL SECURITY NUMBER", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Text = "";
                pictureBox3.Image = System.Drawing.Image.FromFile("ics_icn.png");
                result_age = 0;
            }
            else
            {
                if (max != 5 && max != 6)
                {
                    if (max == 1 || max == 2)
                    {
                        if (Convert.ToInt16(year + textBox7.Text.Substring(1, 2).ToString()) <= (DateTime.Now.Year - 18))
                            result_age = 1;
                        else
                            result_age = 0;
                    }
                    else
                        result_age = 1;
                }
                else
                    result_age = 0;
            }
        }

        private void test_zip_code()
        {
            if (textBox8.TextLength == 6)
            {
                if (Convert.ToInt16(textBox8.Text.Substring(0, 2)) == 30)
                    result_zip_code = 1;
                else
                {
                    result_zip_code = 0;
                    MessageBox.Show("Incorrect Zip Code","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox8.Text = "";
                }
            }
            else
            {
                result_zip_code = 0;
                MessageBox.Show("Incorrect Zip Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4, s5, s6, s7,s8, s9;
            s1 = textBox1.Text; //username
            s2 = textBox2.Text; //first name
            s3 = textBox3.Text; //last name
            s4 = textBox7.Text; //social security number
            s5 = textBox8.Text; //zip code
            s6 = textBox4.Text; //address
            s7 = textBox5.Text; //password
            s8 = comboBox3.Text;    //pricing
            s9 = textBox6.Text;     //password 2nd time
            test_age();
            test_zip_code();
            if (result_age == 1 && result_zip_code == 1)
            {
                pictureBox3.Image = System.Drawing.Image.FromFile("bifa_icn.png");
                if (s1 != "" && s2 != "" && s3 != "" && s4 != "" && s5 != "" && s6 != "" && s7 != "" && s8 != "" && s9 != "")
                {
                    if (s7 == s9)
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

                        sqlCon = new SqlConnection(connString2Builder.ToString());
                        sqlCon.Open();

                        string commandString = "SELECT * FROM Useri5";

                        SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);

                        SqlCommand CmdSql = new SqlCommand("INSERT INTO Useri5(CNP,Utilizator,Nume,Prenume,Adresa,Parola,Abonament,Abateri,Data,Nrcarti,Datainr) Values('"+textBox7.Text+"','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text+" ZipCode "+textBox8.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "','" + 0 + "','" + DateTime.Now.ToShortDateString() + "','" + 0 + "','" + DateTime.Now.ToShortDateString() + "')", sqlCon);

                        CmdSql.ExecuteNonQuery();
                        sqlCon.Close();

                        MessageBox.Show("Successfully registered!!!\nPress OK and log in.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password the second time.\nPlease recheck your password!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please complete all the fields in the form!");
                }
            }
            else
            {
                if (result_age == 0)
                {
                    pictureBox3.Image = System.Drawing.Image.FromFile("ics_icn.png");
                    MessageBox.Show("You have to be al least 18 years old to register!\nTry again in later.");
                    Application.Exit();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 500000000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.textBox4, "The address you enter need's to be near Timisoara,\nbecause the books will be delivered at the specified location.");
            ToolTip toolTip2 = new ToolTip();
            toolTip2.AutoPopDelay = 500000000;
            toolTip2.InitialDelay = 100;
            toolTip2.ReshowDelay = 50;
            toolTip2.ShowAlways = true;
            toolTip2.SetToolTip(this.textBox7, "Social Security Number");

        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
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

            string CommandText = "SELECT Utilizator" + "  FROM Useri5" + " WHERE (Utilizator LIKE @Utilizator)";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;

            cmd.Parameters.Add(new SqlParameter("@Utilizator", System.Data.SqlDbType.VarChar, 50, "Utilizator"));

            cmd.Parameters["@Utilizator"].Value = textBox1.Text;

            rdr = cmd.ExecuteReader();

            if (textBox1.Text != "")
            {
                pictureBox1.Image = System.Drawing.Image.FromFile("bifa_icn.png");
                pictureBox1.BringToFront();

                if (rdr.Read())
                {
                    if (textBox1.Text == rdr["Utilizator"].ToString())
                    {
                        pictureBox1.Image = System.Drawing.Image.FromFile("ics_icn.png");
                    }
                }

                else
                {
                    sqlCon.Close();
                    rdr.Close();
                }
            }
            else
            {
                MessageBox.Show("Choose the desired user.");
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

    }

}
