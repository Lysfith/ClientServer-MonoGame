using System;
using System.Collections.Generic;
using System.Threading;

namespace _2016_Project_2
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var threads = new List<Thread>();
            for (var i = 0; i < 1; i++)
            {
                threads.Add(new Thread(new ThreadStart(() =>
                {
                    MyGame.Instance.Run();
                })));
                
            }

            foreach(var t in threads)
            {
                t.Start();
                Thread.Sleep(500);
            }
            
        }
    }
#endif
}
