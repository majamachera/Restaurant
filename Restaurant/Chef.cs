using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public delegate void HaveAnswear(object sender, ReadyEventArg e);
    public class Chef : IChef
    {
        public int Id { get; set; }
        public bool IsBusy { get; set; }

       

        public event HaveAnswear DishReady;

        public void Attach(IWaiter observer)
        {
            throw new NotImplementedException();
        }

        public void Detach(IWaiter observer)
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
