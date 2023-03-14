using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.Infrastructure.EmailSender
{
    public class SmtpSettings
    {
        public string? Mailbox { get; set; }
        public string? Server { get; set; }
        public int? Port { get; set; }
    }
}
