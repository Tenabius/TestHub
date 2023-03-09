using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.Infrastructure.EmailSender
{
    public class EmailConfig
    {
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Server { get; set; }
        public int? Port { get; set; }
    }
}
