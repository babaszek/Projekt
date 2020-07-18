using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;



namespace programowanie.Klasy
{
    /// <summary>
    /// CSV file class.
    /// The class contains all the necessary methods to operate on CSV file.
    /// </summary>
   public class CSV // : System.Windows.Forms.Form
    {
        private char separator = char.Parse(";");
        public string plik_bazy = "baza.csv";
        
        /// <summary>
        /// A method that test if CSV file exists
        /// </summary>
        /// <param name="plik_bazy">plik_bazy is a file with data.</param>
        public static bool findCSV(string plik_bazy)
        {
            return File.Exists(plik_bazy) ? true : false;
        }//findCSV

        /// <summary>
        /// A method that test if CSV file exists
        /// </summary>
        /// <param name="plik_bazy">plik_bazy is a file with data.</param>
        public static bool read_data(System.Windows.Forms.DataGridView dataGridView1)
        {
            return (dataGridView1.RowCount > 0) ? true : false;
        }//read_data

        /// <summary>
        /// A method that reads a CSV file.
        /// </summary>
        /// <param name="dataGridView1">dataGridView1 is a grid representing data.</param>
        public bool readCSV(System.Windows.Forms.DataGridView dataGridView1)
        {
            if (! ( findCSV(plik_bazy) ))
            {
                MessageBox.Show("Database file not found");
                return false;
            }
            try
            {
                List<string[]> rows = File.ReadAllLines(plik_bazy).Select(x => x.Split(separator)).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("SKU");
                dt.Columns.Add("NAZWA");
                dt.Columns.Add("KATEGORIA");
                dt.Columns.Add("POŁOŻENIE");
                rows.ForEach(x => {
                    dt.Rows.Add(x);
                });
                dataGridView1.DataSource = dt;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
                throw;
            }
        }//read csv

        /// <summary>
        /// A method that write CSV file
        /// </summary>
        /// <param name="dataGridView1">dataGridView1 is a grid representing data.</param>
        public void writeCSV(System.Windows.Forms.DataGridView dataGridView1)
        {
            //test to see if the DataGridView has any rows
            if (dataGridView1.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(plik_bazy);


                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = dataGridView1.Rows[j];

                    for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(";");
                        }

                        value = dr.Cells[i].Value.ToString();

                        //zamień separator na spacje
                        value = value.Replace(separator, ' ');
                        //zamień nowe linie na spacje
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
            }
        }// write csv

        /// <summary>
        /// A method that add row to datagrid
        /// </summary>
        /// <param name="dataGridView1">dataGridView1 is a grid representing data.</param>
        /// <param name="sku">string - sku is a product identification number.</param>
        /// <param name="nazwa">string - nazwa is a product name.</param>
        /// <param name="kat">string - kat is a category name.</param>
        /// <param name="polo">string - polo is a product place name.</param>   
        public void addRow(System.Windows.Forms.DataGridView dataGridView1, string sku, string nazwa, string kat, string polo)
        {
            //dataGridView1.DataBindings.Clear();
            //dataGridView1.Rows.Add("test");
            if (sku == "" | nazwa == "" | kat == "" | polo == "")
            {
                MessageBox.Show("Wszystkie pola są obowiązkowe!");
            }
            else
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                dt.Rows.Add(sku, nazwa, kat, polo);
                dataGridView1.DataSource = dt;
                sku = ""; nazwa = ""; kat = ""; polo = "";
                MessageBox.Show("Produkt dodany, jest na końcu listy");
            }
        }//add rows

        /// <summary>
        /// A method that add row to datagrid
        /// </summary>
        /// <param name="dataGridView1">dataGridView1 is a grid representing data.</param>
        /// <param name="text">string - text is a text to find.</param>
        public void search(System.Windows.Forms.DataGridView dataGridView1, string text)
        {
            if (dataGridView1.RowCount > 0)
            {
                string lacznik = " LIKE '%{0}%' OR ";
                //string[] l = new string[10];
                List<string> l = new List<string>();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    //MessageBox.Show(dataGridView1.Columns[0].HeaderText);
                    l.Add(dataGridView1.Columns[i].HeaderText);
                }//for
                string[] la = l.ToArray();
                // string lap = string.Format(string.Join(lacznik, la), text);
                string lap = string.Join(lacznik, la);
                lap = lap + " LIKE '%{0}%'";
                lap = string.Format(lap, text);
                //MessageBox.Show(string.Format(string.Join(lacznik, la), text));
                // (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format(string.Join(lacznik, la), text);
                MessageBox.Show(lap);
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format(lap);
            }//if 
        }//search
    }//class
}//namespace
