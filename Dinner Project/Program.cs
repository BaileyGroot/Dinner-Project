using System;
using System.Threading;
using Dinner_Project.Project;
using Dinner_Project.Project.Testing;

namespace Dinner_Project
{
    class Program
    {
        static ProducerAndConsumer producerObject = new ProducerAndConsumer();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(ProducerThread);
            t1.Start();
            Thread t2 = new Thread(ConsumerThread);
            t2.Start();



        }

        static void ProducerThread()
        {
            Consumer[] array = new Consumer[3];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = new Consumer(i);
            }
            while(true)
            {
                producerObject.Producer(array);
                Thread.Sleep(250);
            }
        }

        static void ConsumerThread()
        {
            while (true)
            {
                Consumer c = producerObject.GetConsumer();
                Console.WriteLine("har nu konsumeret " + c.A);
            }
        }
    }
}
