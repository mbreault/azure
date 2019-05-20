using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;


namespace PrintingTest
{
    class Program
    {
        static void Main(string[] args)
        {

            // mbreault 05/17/2019
            // First setup a Mock Printer to output to a file without a user prompt
            // https://support.microsoft.com/en-us/help/2528405/how-to-print-to-file-without-user-intervention
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "MockPrinter2";
            pd.PrinterSettings.PrintToFile = true;
            pd.Print();
        }
    }
}
