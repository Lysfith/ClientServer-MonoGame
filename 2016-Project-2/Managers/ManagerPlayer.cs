using _2016_Project_2.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Managers
{
    public class ManagerPlayer
    {
        private static ManagerPlayer _instance;

        public static ManagerPlayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerPlayer();
                }
                return _instance;
            }
        }

        public Player Player { get; set; }

        public Hub Hub { get; set; }

        public ManagerPlayer()
        {

        }
    }
}
