using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStore
{
    /// <summary>
    /// Cash Storage Class
    /// </summary>
    public class Wallet
    {
        public enum Currencies { A = 0, B = 1}

        float[] cash;


        public Wallet()
        {
            cash = new float[2];
        }

        /// <summary>
        /// Adds A specific amount to the respective currency
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="cur"></param>
        public void Add(float amount,Currencies cur)
        {
            cash[(int)cur] += amount;
        }

        public void Substract(float amount,Currencies cur)
        {
            cash[(int)cur] -= amount;
        }

        /// <summary>
        /// Substract the specific price of given item
        /// </summary>
        /// <param name="item">Item to substract cash</param>
        public void Substract(StoreItem item)
        {
            for (int i = 0; i < cash.Length; i++)
            {
                cash[i] -= item.Price[i];
            }
        }

        public float[] Cash { get => cash; set => cash = value; }
    }
}
