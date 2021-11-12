using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class ChefWork
    {
        public async Task chefsWork(List<Chef> lisOfChefs, Queue<Client> listOfClients, Queue<Dish> dishes)
        {
            Queue<Task> taskslist = new Queue<Task>();
            int j = 0;
            int m = 0;
            foreach (var item in listOfClients)
            {
                if (j < lisOfChefs.Count)
                {


                    if (lisOfChefs[j].IsBusy == false)
                    {

                        switch (item.DishNumber)
                        {
                            case 1:
                                lisOfChefs[j].IsBusy = true;
                                DuckClass duck = new DuckClass(item.MaximalTime, item.Id, lisOfChefs[j].Id);
                                Console.WriteLine($"Chef {lisOfChefs[j].Id} start work");
                                Task duc = duck.DuckWithBakedVegetables();
                                taskslist.Enqueue(duc);
                                dishes.Enqueue(duck);

                                break;
                            case 2:
                                lisOfChefs[j].IsBusy = true;
                                SalmonClass salmon = new SalmonClass(item.MaximalTime, item.Id, lisOfChefs[j].Id);
                                Console.WriteLine($"Chef {lisOfChefs[j].Id} start work");
                                Task sal = salmon.SalmonWithSalad();
                                taskslist.Enqueue(sal);
                                dishes.Enqueue(salmon);

                                break;
                            case 3:
                                lisOfChefs[j].IsBusy = true;
                                BakedRaspberriesClass bakedRaspb = new BakedRaspberriesClass(item.MaximalTime, item.Id, lisOfChefs[j].Id);
                                Console.WriteLine($"Chef {lisOfChefs[j].Id} start work");
                                Task rasp = bakedRaspb.BakedRaspberriesWithIceCreams();
                                taskslist.Enqueue(rasp);
                                dishes.Enqueue(bakedRaspb);

                                break;
                            default:
                                break;
                        }
                        m++;

                    }
                    j++;

                }
            }
            await Task.WhenAll(taskslist);
            for (int i = 0; i < m; i++)
            {
                listOfClients.Dequeue();
            }
            foreach (var chef in lisOfChefs)
            {
                chef.IsBusy = false;


            }
            if (listOfClients.Count > 0)
                await chefsWork(lisOfChefs, listOfClients, dishes);



        }

    }
       
       
}
