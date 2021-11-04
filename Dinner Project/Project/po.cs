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
        private static int[] container = new int[8];
        void Producer()
        {
            lock (container)
            {
                while (true)
                {
                    dfvqa
                }

            }
        }

        void Consumer()
        {
            lock (container)
            {
                while (true)
                {

                }
            }
        }

       public static void mainrun()
        {
            po pg = new po();
            Thread t1 = new Thread(pg.Producer);
            t1.Start();
            Thread t2 = new Thread(pg.Consumer);
            t2.Start();
        }
    }
}
