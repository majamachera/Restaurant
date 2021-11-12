using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant
{
    class Program
    {

        static async Task Main(string[] args)
        {
            View view = new View();
            await view.UserView();
            
            
        }

    }
    

    
}
