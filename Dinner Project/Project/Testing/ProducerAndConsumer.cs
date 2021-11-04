
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dinner_Project.Project.Testing;
using System.Threading;

namespace Dinner_Project.Project
{ 
    public class ProducerAndConsumer
    {
        Queue<Consumer> container = new Queue<Consumer>();

        public Consumer GetConsumer()
        {
            lock (container)
            {
                while (container.Count < 1)
                {
                    Monitor.Wait(container);
                }
                
                Console.WriteLine("Consumer har consumeret: ");
                return container.Dequeue();
            }
        }

        public void Producer(Consumer[] consumed)
        {
            lock (container)
            {
                foreach (Consumer d in consumed)
                {
                    container.Enqueue(d);
                    Console.WriteLine("Producer har prduceret: " + d.A);
                }

                Monitor.PulseAll(container);

            }
        }

    }
}
