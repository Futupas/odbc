using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace ODBC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UInt32 counter = 0;
            dataGridView1.Rows.Clear();
            OdbcConnection db = new OdbcConnection("DSN=xoops3");
            db.Open();
            OdbcCommand dbCommand = db.CreateCommand();
            dbCommand.CommandText = "SELECT * FROM xoops_buyersguide_manufacturer";
            OdbcDataReader dbReader = dbCommand.ExecuteReader();
            string[] columns = new string[6];
            while (dbReader.Read())
            {
                counter++;
                columns[0] = counter.ToString();
                columns[1] = dbReader["manu_name"].ToString();
                columns[2] = dbReader["manu_description"].ToString();
                columns[3] = dbReader["manu_address"].ToString();
                columns[4] = dbReader["manu_zip"].ToString();
                columns[5] = dbReader["manu_town"].ToString();
                dataGridView1.Rows.Add(columns);
            }
        }
    }
}
