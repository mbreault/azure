# Resource Group
$keyVaultRG = "KeyVaultRG"
$keyVaultName = "REDACTED" # Key Vault name needs to be globally unique
$location =  "West US"
$publishedWebAppNameDotNetCore = "REDACTED"

az group create --name $keyVaultRG --location $location

# Key Vault
az keyvault create --name $keyVaultName   --resource-group $keyVaultRG --location  $location

# Key Vault Secret
az keyvault secret set --vault-name $keyVaultName  --name "AppSecret" --value "MySecret"

## Created Managed Identities
##az webapp identity assign --name $publishedWebAppNameDotNetCore --resource-group $keyVaultRG

# Assign permissions to your app
#az keyvault set-policy --name '<YourKeyVaultName>' --object-id <PrincipalId> --secret-permissions get list