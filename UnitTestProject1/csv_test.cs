using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using programowanie.Klasy;

namespace programowanieTest
{
    /// <summary>
    /// Unit test . The purpose of the test is to determine the correctness of the method. 
    /// The method aims to find the file. File name is in the CSV variable called plik_bazy. 
    /// </summary>
    [TestClass]
    public class csv_test 
    {
        [TestMethod]
        public void check_db_file()
        {
                // arrange
            CSV l = new CSV();
            bool expected = true;
            // act
            bool r=CSV.findCSV(l.plik_bazy);
            // assert
            Assert.AreEqual(expected, r, "File not found");
        }
    }
}
