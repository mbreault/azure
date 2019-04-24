using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace ldap
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> userNameList = new List<string>();
            string username = Environment.GetEnvironmentVariable("LDAP_VM_USER");
            string password = Environment.GetEnvironmentVariable("LDAP_VM_PASSWORD"); 
            string domain = Environment.GetEnvironmentVariable("LDAP_VM_AD_DOMAIN");

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain, username, password))
            {
                using (UserPrincipal user = new UserPrincipal(context))
                {
                    using (PrincipalSearcher searcher = new PrincipalSearcher(user))
                    {
                        foreach (System.DirectoryServices.AccountManagement.UserPrincipal result in searcher.FindAll())
                        {
                            Console.WriteLine(result.Name);
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
