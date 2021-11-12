using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Client
    {
        private string line;
        public Client(string line)
        {
            this.line = line;
            DestroyString();
        }
        public int Id { get; set; }
        public int DishNumber { get;  set; }
        public int MaximalTime { get; set; }
        private void DestroyString()
        {
            string[] subs = line.Split(',');
            try
            {
                Id = Convert.ToInt32(subs[0]);
                DishNumber = Convert.ToInt32(subs[1]);
                MaximalTime = Convert.ToInt32(subs[2]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException for parse to int ", e.Message);
            }
           

        }
       
    }
}
