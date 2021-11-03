using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dinner_Project.Project
{
    class Dining_Task
    {
        // Randomize
        Random random = new Random();
        // The forks are generated.
        private static bool[] fork = new bool[5];

        // Properties
        public string Name { get; private set; }
        public int Rightfork { get; private set; }
        public int Leftfork { get; private set; }

        // Constructor
        public Dining_Task(string name, int rightfork, int leftfork)
        {
            Name = name;
            Rightfork = rightfork;
            Leftfork = leftfork;
        }

        // Program that runs the method Eat and Think endless.
        void RunProgram()
        {
            while (true)
            {
                Eat();
                Think();
            }
        }

        // Method that checking if our rightfork and leftfork is false - If yes then it is eat if not then it move on to think.
        void Eat()
        {
            bool ItsEating = false;
            lock (fork)
                if (fork[Rightfork] == false && fork[Leftfork] == false)
                {
                    ItsEating = true;
                    fork[Rightfork] = true;
                    fork[Leftfork] = true;
                    Console.WriteLine(Name + " eating.");
                    
                }

            if (ItsEating)
            {
                Thread.Sleep(4000 + random.Next(12000));
                lock(fork)
                {
                    fork[Rightfork] = false;
                    fork[Leftfork] = false;
                }
                Console.WriteLine(Name + " stopped eating.");
            }
            Console.WriteLine(Name + " thinking.");
            Think();
        }
        // Thinking for x seconds.
        void Think()
        {
            Thread.Sleep(2000 + random.Next(8000));
        }

        public static void RunDining()
        {

            // Users
            Dining_Task u1 = new Dining_Task("Per", 0, 1);
            Dining_Task u2 = new Dining_Task("Marc", 1, 2);
            Dining_Task u3 = new Dining_Task("Kenneth", 2, 3);
            Dining_Task u4 = new Dining_Task("Louise", 3, 4);
            Dining_Task u5 = new Dining_Task("Simon", 4, 0);
            // Threads
            Thread t1 = new Thread(u1.RunProgram);
            t1.Start();
            Thread t2 = new Thread(u2.RunProgram);
            t2.Start();
            Thread t3 = new Thread(u3.RunProgram);
            t3.Start();
            Thread t4 = new Thread(u4.RunProgram);
            t4.Start();
            Thread t5 = new Thread(u5.RunProgram);
            t5.Start();
        }
    }
}
