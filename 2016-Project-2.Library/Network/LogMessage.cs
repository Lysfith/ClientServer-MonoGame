using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public enum TypeLog
    {
        INFO,
        DEBUG,
        WARNING,
        ERROR
    }

    public class LogMessage
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public TypeLog Type { get; set; }
    }
}
