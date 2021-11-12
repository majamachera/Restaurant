using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    
    public class SalmonClass :Dish
    {
        readonly int member = 2;
        private int chefId;

        public SalmonClass(int number, int id, int chefId) : base(number, id)
        {
            MenberOfMenu = member;
            this.chefId = chefId;

        }
        public async Task SalmonWithSalad()
        {
            
            Task<Salmon> salmonTask = MakeSalmon(2);
            Task<Salad> saladTask = MakeSalad();
            var listOfTasks = new List<Task> { salmonTask, saladTask };
            await Task.WhenAll(listOfTasks);
            Console.WriteLine($"{chefId}: Salmon with salad is ready");
        }
        private async Task<Salmon> Pickling()
        {
            Console.WriteLine($"{chefId}: Pickling salmon with salt and pepper");
            Console.WriteLine($"{chefId}: Take salmon to the fridge");
            Console.WriteLine($"{chefId}: cooling...");
            await Task.Delay(2000);
            return new Salmon();
        }
        private void ApplyHerbs(Salmon salmon) =>
            Console.WriteLine($"{chefId}: Putting herbs on the salmon");

        private async Task<Salmon> MakeSalmon(int slices)
        {
            var pickledSalmon = Pickling();
            var salmon = await pickledSalmon;
            salmon = await GrillSalmon(slices, salmon);
            ApplyHerbs(salmon);
            Console.WriteLine($"{chefId}: Put salmon on plate");
            Console.WriteLine($"{chefId}: Salmon is ready");
            return salmon;
        }

        internal async Task<Salmon> GrillSalmon(int slices, Salmon salmon)
        {
            Console.WriteLine($"{chefId}: Preheat the grill");
            await Task.Delay(1000);
            Console.WriteLine($"{chefId}: Putting {slices} slices of salmon in the grill");
            Console.WriteLine($"{chefId}: Grill the salmon first skin side down..");
            await Task.Delay(2000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"{chefId}: Flipping slice " + slice + 1);
            }
            Console.WriteLine($"{chefId}: Grill the second side of salmon...");
            await Task.Delay(2000);
            return salmon;
        }
        private async Task<Salad> PreparingVegetables()
        {
            Console.WriteLine($"{chefId}: Washing vegetables");
            Console.WriteLine($"{chefId}: Cutting vegetables");
            return new Salad();
        }
        private async Task<Salad> MakeSalad()
        {
            var salad = await PreparingVegetables();
            salad = await MakeTost(salad);
            Console.WriteLine($"{chefId}: Put salad on the plate");
            Console.WriteLine($"{chefId}: salad is ready");
            return salad;
        }
        private async Task<Salad> MakeTost(Salad salad)
        {
            Console.WriteLine($"{chefId}: Heating the toaster...");
            await Task.Delay(1000);
            Console.WriteLine($"{chefId}: Beaking tost");
            await Task.Delay(3000);
            Console.WriteLine($"{chefId}: Cutting tost");
            Console.WriteLine($"{chefId}: Adding pieces of toast to salad");
            return salad;
        }

    }
}
