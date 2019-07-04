using System;
using System.Runtime.InteropServices;

namespace Stateless1
{
    public static class PrintTestPageHelper
    {
        // From https://stackoverflow.com/questions/3710196/how-to-print-test-page-on-default-printer

        [DllImport("printui.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern void PrintUIEntryW(IntPtr hwnd,
            IntPtr hinst, string lpszCmdLine, int nCmdShow);

        /// <summary>
        /// Print a Windows test page.
        /// </summary>
        /// <param name="printerName">
        /// Format: \\Server\printer name, for example:
        /// \\myserver\sap3
        /// </param>
        public static void Print(string printerName)
        {
            var printParams = string.Format(@"/k /n{0}", printerName);
            PrintUIEntryW(IntPtr.Zero, IntPtr.Zero, printParams, 0);
        }
    }

}
