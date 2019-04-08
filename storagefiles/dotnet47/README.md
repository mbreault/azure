To get this working do the following:

1.  Set the connection string in app.config to your storage account connection.
2.  Change Line 19 of AzureFileHelper to an existing container name in your Blob Storage account.  The default is "reports."
3.  Create a file c:\temp\test.txt to be used in the upload 