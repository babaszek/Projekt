using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using programowanie.Klasy;

namespace programowanie
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            programowanie.Klasy.CSV C = new programowanie.Klasy.CSV();
            C.writeCSV(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void załadujPonownieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            programowanie.Klasy.CSV C = new programowanie.Klasy.CSV();
            C.readCSV(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataBindings.Clear();
            //dataGridView1.Rows.Add("test");
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "")
            {
                MessageBox.Show("Wszystkie pola są obowiązkowe!");
                textBox1.Focus();
            }
            else
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                dt.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                dataGridView1.DataSource = dt;
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
                textBox1.Focus();
                MessageBox.Show("Produkt dodany, jest na końcu listy");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            programowanie.Klasy.CSV C = new programowanie.Klasy.CSV();
            C.search(dataGridView1, textBox5.Text);
        
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show("enter");
                button2.PerformClick();
            }
        }

        private void zakończProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
