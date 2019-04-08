using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace AzureBlobDotNet47
{
    class AzureFileHelper
    {

        public static void Upload(string filePath)
        {
            string storageKey = System.Configuration.ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageKey);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            var containers = blobClient.ListContainers();

            // Get a reference to the file share we created previously.
            CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference("reports");

            FileInfo file = new FileInfo(filePath);
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(file.Name);
            cloudBlockBlob.UploadFromFile(filePath);
           
        }
    }
}
