using _2016_Project_2.Server.Managers;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Server.Commands
{
    interface ICommand
    {
        PlayerAndConnection Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection);
    }
}
