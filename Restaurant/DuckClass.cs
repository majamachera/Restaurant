using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class DuckClass : Dish
    {
        int member = 3;
        private int chefId;

        public DuckClass(int number, int id, int chefId) : base(number, id)
        {
            MenberOfMenu = member;
            this.chefId = chefId;

        }
        public async Task DuckWithBakedVegetables()
        {
            Task<Duck> duckTask = MakeDuck(4);
            Task<Vegetables> vegetablesTask = MakeVegetables();
            var listOfTasks = new List<Task> { duckTask, vegetablesTask };
            await Task.WhenAll(listOfTasks);
            Console.WriteLine($"{chefId}: Duck with vegetables is ready");
           
        }
        private async Task<Duck> Pickling()
        {
            Console.WriteLine($"{chefId}: Pickling duck with honey and herbs");
            Console.WriteLine($"{chefId}: Take duck to the fridge");
            Console.WriteLine($"{chefId}: cooling...");
            await Task.Delay(2000);
            return new Duck();
        }
        private void ApplySauce(Duck duck) =>
            Console.WriteLine($"{chefId}: Fancy sauce pouring");

        private async Task<Duck> MakeDuck(int slices)
        {
            var pickledDuck = Pickling();
            var duck = await pickledDuck;
            duck = await FryDuck(slices, duck);
            Console.WriteLine($"{chefId}: Put duck on plate");
            ApplySauce(duck);
            Console.WriteLine($"{chefId}: Duck is ready");
            return duck;
        }

        private async Task<Duck> FryDuck(int slices, Duck duck)
        {
            Console.WriteLine($"{chefId}: Preheat the pan");
            await Task.Delay(1000);
            Console.WriteLine($"{chefId}: Putting {slices} slices of duck in the pan");
            Console.WriteLine($"{chefId}: fry duck first skin side down");
            await Task.Delay(2000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"{chefId}: Flipping slice ");
            }
            Console.WriteLine($"{chefId}: Frying the second side...");
            await Task.Delay(1000);
            return duck;
        }
        private async Task<Vegetables> PreparingVegetables()
        {
            Console.WriteLine($"{chefId}: Washing vegetables");
            Console.WriteLine($"{chefId}: Cutting vegetables");
            return new Vegetables();
        }
        private async Task<Vegetables> MakeVegetables()
        {
            var vegetables = await PreparingVegetables();
            Console.WriteLine($"{chefId}: Put the vegetables into an arrest vessel");
            vegetables = await BeakingVegetables(vegetables);
            Console.WriteLine($"{chefId}: Put the vagatabbles on the plate");
            Console.WriteLine($"{chefId}: Baked vagatables are ready");
            return vegetables;
        }
        private async Task<Vegetables> BeakingVegetables(Vegetables vegetables)
        {
            Console.WriteLine($"{chefId}: Preheat the oven");
            await Task.Delay(1000);
            Console.WriteLine($"{chefId}: Put bowl with vagatabbles into the oven");
            Console.WriteLine($"{chefId}: Beaking...");
            await Task.Delay(2000);
            return vegetables;
           
        }
    }

}
