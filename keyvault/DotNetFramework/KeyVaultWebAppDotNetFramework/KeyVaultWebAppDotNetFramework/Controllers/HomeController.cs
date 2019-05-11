using KeyVaultWebAppDotNetFramework.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeyVaultWebAppDotNetFramework.Controllers
{
    public class HomeController : Controller
    {
        private string getMessage()
        {
            string returnValue = String.Empty;

            try
            {
                /* The next four lines of code show you how to use AppAuthentication library to fetch secrets from your key vault */
                AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
                KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
                var secret = keyVaultClient.GetSecretAsync("https://redacted.vault.azure.net/secrets/AppSecret");
                returnValue = secret.Result.Value;
            }
            /* If you have throttling errors see this tutorial https://docs.microsoft.com/azure/key-vault/tutorial-net-create-vault-azure-web-app */
            /// <exception cref="KeyVaultErrorException">
            /// Thrown when the operation returned an invalid status code
            /// </exception>
            catch (Exception ex)
            {
                returnValue = ex.Message;
            }

            return returnValue;
        }

        public ActionResult Index()
        {
            var indexModel = new IndexModel
            {
                Message = getMessage()
            };

            return View(indexModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}