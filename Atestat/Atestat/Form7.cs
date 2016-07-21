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
    public partial class Form7 : Form
    {
        private static string userName = "vlad.glitia";
        private static string password = "merry2011.,christmas";
        private static string dataSource = "xoyg2l1usz.database.windows.net";
        private static string DatabaseName = "VirtualLibrary";
        private ListViewColumnSorter lvwColumnSorter;
        string s="                        THE LIST OF BOOK'S THAT NEED TO BE RETURNED\n\n\n\n\n\n";

        public Form7()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void Form7_Load(object sender, EventArgs e)
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
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 500000000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.pictureBox1, "Print list");
            listView1.Items.Clear();
            SqlDataReader rdr = null;
            SqlConnection sqlCon = null;
            SqlCommand cmd = null;


            sqlCon = new SqlConnection(connString2Builder.ToString());
            sqlCon.Open();

            string CommandText = "SELECT Destinatar, Adresa, Carte, Data" + "  FROM Comenzi";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = sqlCon;



            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string data;
                data = rdr["Data"].ToString();


                if (Convert.ToDateTime(data) == DateTime.Today.AddDays(-15))
                {
                    ListViewItem lvi = new ListViewItem(rdr["Destinatar"].ToString());
                    lvi.SubItems.Add(rdr["Adresa"].ToString());
                    lvi.SubItems.Add(rdr["Carte"].ToString());
                    lvi.SubItems.Add(rdr["Data"].ToString());

                    listView1.Items.Add(lvi);
                }
            }
            rdr.Close();
            sqlCon.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            for(int x=0;x<listView1.Items.Count;x++)
            {
                s = s + listView1.Items[x].SubItems[0].Text + ";    " + listView1.Items[x].SubItems[1].Text + "\n" + listView1.Items[x].SubItems[2].Text + ";           " + listView1.Items[x].SubItems[3].Text + "\n\n";
            }
            richTextBox1.Text = s;
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument1;
            if (pd.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat of = new StringFormat();
            Font printFont = new Font("Courier New", 10);
            int leftMargin = 50;
            int topMargin = 50;
            e.Graphics.DrawString(s, printFont, Brushes.Black, leftMargin, topMargin);
           

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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = System.Drawing.Image.FromFile("Printer-icon1_over.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = System.Drawing.Image.FromFile("Printer-icon1.png");
        }
    }
}
