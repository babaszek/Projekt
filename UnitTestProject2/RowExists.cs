using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using programowanie.Klasy;
//using System.Windows.Forms;
using System.Windows;

namespace programowanie
{
    /// <summary>
    /// Unit test of the CSV method. The purpose of the test is to determine if there is any data in dataviewgrid.
    /// </summary>
    [TestClass]
    public class grid_test : programowanie.Form1 
    {
       
        [TestMethod]
        public void RowExists()
        {
            // arrange
            CSV l = new CSV();
            bool expected = true;
            var Forma1 = new Form1();
            
            Forma1.dataGridView1.Columns.Add("Column", "Test");
            Forma1.dataGridView1.Rows.Add("test");

            // act
            bool r = CSV.read_data(Forma1.dataGridView1);
            // assert
            Assert.AreEqual(expected, r, "Data not found");
        }
    }
}
