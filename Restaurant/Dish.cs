using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Dish
    {
        public int ClientId { get; set; }
        public int Number { get; set; }
        public int MenberOfMenu { get; set; }
        public Dish() { }

        public Dish(int number, int id)
        {
            this.ClientId = id;
            this.Number = number;

        }

    }
}
