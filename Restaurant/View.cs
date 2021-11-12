using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurant
{
    public class View
    {
        public async Task UserView()
        {
            List<int> desks = new List<int>();
            Queue<Client> listOfClients = new Queue<Client>();
            Console.WriteLine("Set number of clients");
            try
            {
                int clients = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Set number of cooks");
                try
                {
                    int cooks = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Set number of waiters");
                    try
                    {
                        int waiters = Convert.ToInt32(Console.ReadLine());


                        Console.WriteLine("Today in the menu: 1-Baked raspberies with ice cream, 2-Salmon with fresh salad with crunchy tosts and 3-Duck pickling with honey and herbs with baked vegetables.");
                        for (int i = 1; i <= clients; i++)
                        {
                            Console.WriteLine("Enter the [Table Number],[Menu Positions Number],[Waiting Time]");
                            string line = Console.ReadLine();
                            var client = new Client(line);
                            while (client.DishNumber > 3 || client.DishNumber < 1)
                            {
                                Console.WriteLine("Wrong number of dish");
                                Console.WriteLine("Enter the [Table Number],[Menu Positions Number],[Waiting Time]");
                                line = Console.ReadLine();
                                client = new Client(line);
                            }

                            foreach (var item in desks)
                            {
                                while (item == client.Id)
                                {
                                    Console.WriteLine("Set other desk");

                                    try
                                    {
                                        client.Id = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine("FormatException while parse to int ", e.Message);
                                    }
                                }
                            }
                            desks.Add(client.Id);
                            listOfClients.Enqueue(client);

                        }
                        List<Chef> lisOfChefs = CreateListOfChefs(cooks);
                        List<Waiter> lisOfWaiters = CreateListOfWaiters(waiters);
                        Queue<Dish> listOfDishes = new Queue<Dish>();
                        ChefWork chefw = new ChefWork();
                        await chefw.chefsWork(lisOfChefs, listOfClients, listOfDishes);
                        Console.WriteLine(listOfClients.Count);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("FormatException while parse to int ", e.Message);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("FormatException while parse to int ", e.Message);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException while parse to int ", e.Message);
            }
        }
        public static bool CorrectPattern(string line)
        {
            if (!Regex.IsMatch(line, "[1-3]"))
                return false;
            return true;
        }
        private static List<Chef> CreateListOfChefs(int cooks)
        {
            List<Chef> lisOfChefs = new List<Chef>();
            for (int i = 0; i < cooks; i++)
            {
                lisOfChefs.Add(new Chef { Id = i + 1, IsBusy = false });

            }
            return lisOfChefs;
        }

        private static List<Waiter> CreateListOfWaiters(int waiters)
        {
            List<Waiter> lisOfWaiters = new List<Waiter>();
            for (int i = 0; i < waiters; i++)
            {
                lisOfWaiters.Add(new Waiter { Id = i + 1, IsBusy = false });
            }
            return lisOfWaiters;
        }
    }
}
