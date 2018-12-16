using _2016_Project_2.Library.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Server.Util
{
    public static class MyExtensions
    {
        public static string ToStringLine(this LogMessage log)
        {
            return string.Format("{0} : [{1}] {2}",
                log.Date.ToString("HH:mm:ss"),
                log.Id,
                log.Message
                );
        }
    }
}
