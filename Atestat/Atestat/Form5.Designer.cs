namespace Atestat
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.comenziUseriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abonamenteNoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interziceAccesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaAbatereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ȘtergeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comenziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.istoricComenziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comenzileDeAziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comenziDeReturnatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printeazaComenzileDeAziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cărțiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugăCărțiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificăStoculToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ieșireAplicațieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comenziUseriToolStripMenuItem,
            this.comenziToolStripMenuItem,
            this.cărțiToolStripMenuItem,
            this.ieșireAplicațieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // comenziUseriToolStripMenuItem
            // 
            this.comenziUseriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abonamenteNoiToolStripMenuItem,
            this.interziceAccesToolStripMenuItem,
            this.adaugaAbatereToolStripMenuItem,
            this.ȘtergeUserToolStripMenuItem});
            this.comenziUseriToolStripMenuItem.Name = "comenziUseriToolStripMenuItem";
            this.comenziUseriToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.comenziUseriToolStripMenuItem.Text = "&User\'s";
            // 
            // abonamenteNoiToolStripMenuItem
            // 
            this.abonamenteNoiToolStripMenuItem.Name = "abonamenteNoiToolStripMenuItem";
            this.abonamenteNoiToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.abonamenteNoiToolStripMenuItem.Text = "&New Subscriprions";
            this.abonamenteNoiToolStripMenuItem.Click += new System.EventHandler(this.abonamenteNoiToolStripMenuItem_Click);
            // 
            // interziceAccesToolStripMenuItem
            // 
            this.interziceAccesToolStripMenuItem.Name = "interziceAccesToolStripMenuItem";
            this.interziceAccesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.interziceAccesToolStripMenuItem.Text = "&Add mistake";
            this.interziceAccesToolStripMenuItem.Click += new System.EventHandler(this.interziceAccesToolStripMenuItem_Click);
            // 
            // adaugaAbatereToolStripMenuItem
            // 
            this.adaugaAbatereToolStripMenuItem.Name = "adaugaAbatereToolStripMenuItem";
            this.adaugaAbatereToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.adaugaAbatereToolStripMenuItem.Text = "&All user\'s";
            this.adaugaAbatereToolStripMenuItem.Click += new System.EventHandler(this.adaugaAbatereToolStripMenuItem_Click);
            // 
            // ȘtergeUserToolStripMenuItem
            // 
            this.ȘtergeUserToolStripMenuItem.Name = "ȘtergeUserToolStripMenuItem";
            this.ȘtergeUserToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ȘtergeUserToolStripMenuItem.Text = "&Delete user";
            this.ȘtergeUserToolStripMenuItem.Click += new System.EventHandler(this.ȘtergeUserToolStripMenuItem_Click);
            // 
            // comenziToolStripMenuItem
            // 
            this.comenziToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.istoricComenziToolStripMenuItem,
            this.comenzileDeAziToolStripMenuItem,
            this.comenziDeReturnatToolStripMenuItem,
            this.printeazaComenzileDeAziToolStripMenuItem});
            this.comenziToolStripMenuItem.Name = "comenziToolStripMenuItem";
            this.comenziToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.comenziToolStripMenuItem.Text = "&Orders";
            // 
            // istoricComenziToolStripMenuItem
            // 
            this.istoricComenziToolStripMenuItem.Name = "istoricComenziToolStripMenuItem";
            this.istoricComenziToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.istoricComenziToolStripMenuItem.Text = "&History";
            this.istoricComenziToolStripMenuItem.Click += new System.EventHandler(this.istoricComenziToolStripMenuItem_Click);
            // 
            // comenzileDeAziToolStripMenuItem
            // 
            this.comenzileDeAziToolStripMenuItem.Name = "comenzileDeAziToolStripMenuItem";
            this.comenzileDeAziToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.comenzileDeAziToolStripMenuItem.Text = "&Today\'s orders";
            this.comenzileDeAziToolStripMenuItem.Click += new System.EventHandler(this.comenzileDeAziToolStripMenuItem_Click);
            // 
            // comenziDeReturnatToolStripMenuItem
            // 
            this.comenziDeReturnatToolStripMenuItem.Name = "comenziDeReturnatToolStripMenuItem";
            this.comenziDeReturnatToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.comenziDeReturnatToolStripMenuItem.Text = "&Orders to be returned";
            this.comenziDeReturnatToolStripMenuItem.Click += new System.EventHandler(this.comenziDeReturnatToolStripMenuItem_Click);
            // 
            // printeazaComenzileDeAziToolStripMenuItem
            // 
            this.printeazaComenzileDeAziToolStripMenuItem.Name = "printeazaComenzileDeAziToolStripMenuItem";
            this.printeazaComenzileDeAziToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.printeazaComenzileDeAziToolStripMenuItem.Text = "&Print today\'s orders";
            this.printeazaComenzileDeAziToolStripMenuItem.Click += new System.EventHandler(this.printeazaComenzileDeAziToolStripMenuItem_Click);
            // 
            // cărțiToolStripMenuItem
            // 
            this.cărțiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugăCărțiToolStripMenuItem,
            this.modificăStoculToolStripMenuItem});
            this.cărțiToolStripMenuItem.Name = "cărțiToolStripMenuItem";
            this.cărțiToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.cărțiToolStripMenuItem.Text = "&Book\'s";
            // 
            // adaugăCărțiToolStripMenuItem
            // 
            this.adaugăCărțiToolStripMenuItem.Name = "adaugăCărțiToolStripMenuItem";
            this.adaugăCărțiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.adaugăCărțiToolStripMenuItem.Text = "&Add book\'s";
            this.adaugăCărțiToolStripMenuItem.Click += new System.EventHandler(this.adaugăCărțiToolStripMenuItem_Click);
            // 
            // modificăStoculToolStripMenuItem
            // 
            this.modificăStoculToolStripMenuItem.Name = "modificăStoculToolStripMenuItem";
            this.modificăStoculToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificăStoculToolStripMenuItem.Text = "&Modify stock";
            this.modificăStoculToolStripMenuItem.Click += new System.EventHandler(this.modificăStoculToolStripMenuItem_Click);
            // 
            // ieșireAplicațieToolStripMenuItem
            // 
            this.ieșireAplicațieToolStripMenuItem.Name = "ieșireAplicațieToolStripMenuItem";
            this.ieșireAplicațieToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.ieșireAplicațieToolStripMenuItem.Text = "&Exit application";
            this.ieșireAplicațieToolStripMenuItem.Click += new System.EventHandler(this.ieșireAplicațieToolStripMenuItem_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(889, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(658, 476);
            this.richTextBox1.TabIndex = 30;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 37);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(848, 476);
            this.listView1.TabIndex = 31;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Recepient name";
            this.columnHeader1.Width = 113;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Delivery time";
            this.columnHeader5.Width = 83;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Address";
            this.columnHeader6.Width = 249;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Book\'s title";
            this.columnHeader7.Width = 164;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Orders date";
            this.columnHeader8.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Extra taxe";
            this.columnHeader2.Width = 133;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 525);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form5";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista Comenzilor";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem comenziUseriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ȘtergeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaAbatereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interziceAccesToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem comenziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem istoricComenziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comenzileDeAziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comenziDeReturnatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printeazaComenzileDeAziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cărțiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugăCărțiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ieșireAplicațieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificăStoculToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abonamenteNoiToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}