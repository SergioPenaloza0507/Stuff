using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStore
{
    /// <summary>
    /// UnusedClass 
    /// </summary>
    class Currency
    {
        float cash;

        public Currency()
        {
            cash = 0;
        }

        public float Cash { get => cash; set => cash = value; }
    }
}
