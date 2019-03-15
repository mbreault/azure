using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.IO;

namespace CloudFileUpload
{
    class AzureFileHelper
    {
        public static void Upload(string filePath)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string storageKey = configuration.GetConnectionString("StorageConnectionString");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageKey);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("oreilly");
            CloudFileDirectory root = share.GetRootDirectoryReference();

            FileInfo file = new FileInfo(filePath);
            CloudFile cloudFile = root.GetFileReference(file.Name);

            var exists = cloudFile.ExistsAsync();

            if (!exists.Result)
            {
                Console.WriteLine("{0} uploading",file.Name);
                using (FileStream fs = file.OpenRead())
                {
                    var result = cloudFile.UploadFromStreamAsync(fs);
                }
            }
            else
            {
                Console.WriteLine("{0} exists", file.Name);
            }
        }
    }
}
