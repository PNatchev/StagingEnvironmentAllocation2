using System;
using System.Collections;
using System.Collections.Generic;

namespace StagingEnvironmentAllocation2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Used for comparing in Case 2 of Switch
            string north = "North";
            string south = "South";
            string admin = "admin@gmail.com";

            //The available environments
            Queue<string> stgEnvr = new Queue<string>();
            stgEnvr.Enqueue("North");
            stgEnvr.Enqueue("South");


            Queue<string> registeredEng = new Queue<string>();

            Queue<string> tempPriorityQueue = new Queue<string>();



            //This will allow me to choose in an options menu style app.
            //Infinite Loop to simulate a constantly running application.
            while (true)
            {
                Console.WriteLine("Welcome to the staging environment assignment app!");
                Console.WriteLine("Please select one of the following options:");
                Console.WriteLine("1) Register for an environment.");
                Console.WriteLine("2) Unregister from environment.");
                Console.WriteLine("3) Ping the current users for Priority 1 testing.");
                Console.WriteLine("4) Exit.");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    //Registering Process
                    case 1:
                        Console.WriteLine("Please enter your email:\n");
                        registeredEng.Enqueue(Console.ReadLine());
                        if (stgEnvr.Count != 0)
                        {
                            Console.WriteLine("\nNext user {0} in queue has been assigned to {1} for the day.\n", registeredEng.Peek(), stgEnvr.Peek());
                            registeredEng.Dequeue();
                            stgEnvr.Dequeue();
                            if (registeredEng.Count > 0)
                            {
                                Console.WriteLine("\nYou are number {0} on the waitlist.", registeredEng.Count);
                            }
                            Console.WriteLine("\nPlease press Enter to continue.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\nNo current environments available.");
                            Console.WriteLine("We will notify you of the next available environment:");             
                            Console.WriteLine("\nYou are number {0} on the waitlist.",registeredEng.Count);
                            Console.WriteLine("Please press Enter to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            
                        }
                        break;
                    //Unregistering Process
                    case 2:
                        Console.WriteLine("\nPlease enter the environment's name you wish to release.");
                        Console.WriteLine("\nType North or South case sensitive");
                        string temp = Console.ReadLine();
                        if (temp == north)
                        {
                            stgEnvr.Enqueue("North");
                            Console.WriteLine("The current environment {0} is available for use",north);
                           
                            Console.WriteLine("Please press Enter to continue");
                            Console.ReadKey();
                            Console.Clear();


                        }
                        else if(temp == south)
                        {
                            stgEnvr.Enqueue("South");
                            Console.WriteLine("The current environment {0} is available for use", south);

                            Console.WriteLine("Please press Enter to continue");
                            Console.ReadKey();
                            Console.Clear();
                            
                        }
                        else
                        {
                            Console.WriteLine("The environment you listed does not exist.\n");
                            Console.WriteLine("Please press Enter to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }    
                        break;
                    //Global Ping For Urgency
                    //Used tempPriorityQueue to change the order and bring admin to the front
                    case 3:
                        Console.WriteLine("Priority 1 - Please release North or South within 30 minutes\n");
                        Console.WriteLine("Please enter admin email to bypass Queue.");
                        if (Console.ReadLine().Equals(admin))
                        {
                            tempPriorityQueue.Enqueue(admin);
                            while (registeredEng.Count != 0)
                            {
                                tempPriorityQueue.Enqueue(registeredEng.Dequeue());
                            }
                            while (tempPriorityQueue.Count != 0)
                            {
                                registeredEng.Enqueue(tempPriorityQueue.Dequeue());
                            }
                                
                            
                        }
                        else
                        {
                            Console.WriteLine("That is not an admin email please try again.");
                        }
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Environment.Exit(0);
                            break;
                    default:
                        Console.WriteLine("The option you chose does not exist. Please try again.");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            
        }
    }
}
