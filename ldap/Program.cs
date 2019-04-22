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
            string username = @"REDACTED";
            string password = @"REDACTED";

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "REDACTED", username, password))
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

        }
    }
}
