using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobDotNet47
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\temp\test.txt";
            AzureFileHelper.Upload(filePath);
        }
    }
}
