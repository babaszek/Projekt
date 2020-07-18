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
    public class grid_test 
    {
       
        [TestMethod]
        public void RowExists()
        {
            // arrange
            CSV l = new CSV();
           // bool expected = true;
            // act
            //bool r = CSV.read_data(Form1.dataGridView1);
            // assert
            //Assert.AreEqual(expected, r, "Data not found");
        }
    }
}
