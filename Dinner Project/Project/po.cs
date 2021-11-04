using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dinner_Project.Project
{
    class po
    {

         static Queue<int> container = new Queue<int>();
        // private static int[] container = new int[8];

        void Producer()
        {
            lock (this)
            {
                while (true)
                {
                    if (container.Count != 0)
                    {
                        container.Enqueue(1);
                        Console.WriteLine("Producer added one.");
                    }
                    Thread.Sleep(1000);
                }

            }
        }

        //void Consumer()
        //{
        //    lock (this)
        //    {
        //        while (true)
        //        {

        //            SZ
        //                Console.WriteLine("Consumer removed one.");
        //            }

        //            Thread.Sleep(1000);

        //        }
        //    }
        //}

       public static void mainrun()
        {
            po pg = new po();
            Thread.Sleep(1000);
            Thread t2 = new Thread(pg.Producer);
            t2.Start();
        }
    }
}
