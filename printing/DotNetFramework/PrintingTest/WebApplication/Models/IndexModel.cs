using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class IndexModel
    {
        public IndexModel()
        {
            Printers = new List<string>();
        }

        public List<string> Printers { get; set; }
        public string ErrorMessage { get; set; }
    }
}