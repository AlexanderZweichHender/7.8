using _7._8.Items;
using System;

namespace Solution
{
    internal class Program
    {
        private const string PATH = "Data.txt";

        private static void Main()
        {
            while (true)
            {
                if (!File.Exists(PATH))
                {
                    try
                    {
                        File.Create(PATH);
                        Console.WriteLine("file has been created successfully");
                    }
                    catch
                    {
                        Console.WriteLine("something went wrong");
                    }

                }
                else
                {
                    var repository = new Repository(PATH);

                    Console.WriteLine("Select comand:\n0 - view all workers\n1 - add worker\n" +
                        "2 - delete worker\n3 - get workers in dateRange");

                    switch (Console.ReadLine())
                    {
                        case "0":
                            repository.WriteWorkers(repository.GetAllWorkers());
                            break;
                        case "1":
                            repository.AddWorker();
                            break;
                        case "2":
                            repository.DeleteWorker();
                            break;
                        case "3":
                            repository.WriteWorkers(repository.GetWorkersInDateRange());
                            break;
                        default:
                            Console.WriteLine("Wrong command");
                            break;
                    }
                }
            }
        }
    }
}
