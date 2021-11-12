using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class BakedRaspberriesClass :Dish
    {
        int member = 1;
        int chefId;
        public BakedRaspberriesClass(int number, int id, int chefId) : base(number, id)
        {
            MenberOfMenu = member;
            this.chefId = chefId;
        }
        public async Task BakedRaspberriesWithIceCreams()
        {
            Task<Raspberry> raspberryTask = MakeRaspberries();
            Task<IceCream> icecCeamTask = MakeIceCream();
            var listOfTasks = new List<Task> { raspberryTask, icecCeamTask };
            await Task.WhenAll(listOfTasks);
            Console.WriteLine($"{chefId}: Baked raspberries with ice creams are ready!");
        }
        private async Task<Raspberry> PreparingRaspberries()
        {
            Console.WriteLine($"{chefId}: Crush the raspberries");
            Console.WriteLine($"{chefId}: Brush the ramek with butter");
            Console.WriteLine($"{chefId}: Put raspberries on the ramekin");
            return new Raspberry();
        }
        private async Task<Raspberry> PreparingCrumble(Raspberry raspberry)
        {
            Console.WriteLine($"{chefId}: Mixing cold butter with plain flour and brown sugar");
            Console.WriteLine($"{chefId}: Take crumble to the freezer");
            Console.WriteLine($"{chefId}: Freazing...");
            await Task.Delay(1000);
            Console.WriteLine($"{chefId}: Sprinkle crumble raspberries");
            return raspberry;
        }
        private async Task<Raspberry> BakeRaspberries(Raspberry raspberry)
        {
            Console.WriteLine($"{chefId}: Preheat the oven");
            await Task.Delay(1000);
            Console.WriteLine($"{chefId}: Put ramek with raspberries into the oven");
            Console.WriteLine($"{chefId}: Beaking...");
            await Task.Delay(2000);
            Console.WriteLine($"{chefId}: Take out the ramek");
            return raspberry;
        }
      

        private async Task<Raspberry> MakeRaspberries()
        {
            var raspberries = await PreparingRaspberries();
            raspberries = await PreparingCrumble(raspberries);
            raspberries = await BakeRaspberries(raspberries);
            Console.WriteLine($"{chefId}: Raspberries are ready");
            return raspberries;
        }
        private async Task<IceCream> OperatioOfTheIceCreamMachine(IceCream iceCream)
        {
            Console.WriteLine($"{chefId}: Adding cream, brown sugar and vanilla extract into the ice cream machine");
            Console.WriteLine($"{chefId}: Ice cream making...");
            Task.Delay(4000);
            Console.WriteLine($"{chefId}: Pulling ice cream out of the machine");
            return iceCream;
        }
        private async Task<IceCream> MakeIceCream()
        {
            var iceCream = await MakeCarmel();
            iceCream = await OperatioOfTheIceCreamMachine(iceCream);
            Console.WriteLine($"{chefId}: Putting ice cream on the plate");
            ApplyCarmelGlaze(iceCream);
            Console.WriteLine($"{chefId}: Ice cream is ready");
            return iceCream;
        }
        private async Task<IceCream> MakeCarmel()
        {
            Console.WriteLine($"{chefId}: Preheat the pan");
            await Task.Delay(1000);
            Console.WriteLine($"{chefId}: Put sugair on pan");
            Console.WriteLine($"{chefId}: Frying...");
            await Task.Delay(2000);
            Console.WriteLine($"{chefId}: Pour the caramel into the cup");
            return new IceCream();
        }
        private void ApplyCarmelGlaze(IceCream iceCream) =>
          Console.WriteLine($"{chefId}: Apply the caramel glaze");
       
    }
}
