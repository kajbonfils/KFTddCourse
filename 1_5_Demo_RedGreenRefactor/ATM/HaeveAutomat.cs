using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class HaeveAutomat
    {
        public HaeveAutomat(int i)
        {
            Saldo = i;
        }

        public void Haev(int i)
        {
           
            if (i > Saldo)
            {
                throw new OvertraekException();
            }

            Saldo -= i;
        }

        public int Saldo
        {
            get;
            private set;
        }
    }
}
